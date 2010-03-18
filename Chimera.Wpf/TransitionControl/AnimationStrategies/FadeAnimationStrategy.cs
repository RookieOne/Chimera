using System.Windows;
using Chimera.Wpf.Fluent;

namespace Chimera.Wpf.TransitionControl.AnimationStrategies
{
    public class FadeAnimationStrategy : BaseTransitionAnimationStrategy
    {
        public FadeAnimationStrategy(Duration duration)
        {
            _duration = duration;
        }

        readonly Duration _duration;

        protected override FrameworkElement ModifyNewContent(ITransitionControl container, FrameworkElement newContent)
        {
            newContent.Opacity = 0;
            return newContent;
        }

        protected override Animation GetOutAnimation()
        {
            return Animate.The(UIElement.OpacityProperty)
                .From(1)
                .To(0)
                .For(_duration)
                .Create();
        }

        protected override Animation GetInAnimation()
        {
            return Animate.The(UIElement.OpacityProperty)
                .From(0)
                .To(1)
                .For(_duration)
                .Create();
        }
    }
}