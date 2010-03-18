using System.Windows;
using System.Windows.Controls;
using Chimera.Wpf.Fluent;

namespace Chimera.Wpf.TransitionControl.AnimationStrategies
{
    public class SlideAnimationStrategy : BaseTransitionAnimationStrategy
    {
        public SlideAnimationStrategy(Duration duration)
        {
            _duration = duration;
        }

        readonly Duration _duration;

        double _leftStart;
        double _width;

        protected override FrameworkElement ModifyNewContent(ITransitionControl container, FrameworkElement newContent)
        {
            var ctrl = container.AsControl();

            _leftStart = GetLeftStart(ctrl);
            _width = ctrl.ActualWidth;

            Canvas.SetLeft(newContent, _leftStart - _width);
            return newContent;
        }

        protected override Animation GetOutAnimation()
        {
            return Animate.The(Canvas.LeftProperty)
                .From(_leftStart)
                .To(_leftStart + _width)
                .For(_duration)
                .Create();
        }

        protected override Animation GetInAnimation()
        {
            return Animate.The(Canvas.LeftProperty)
                .From(_leftStart - _width)
                .To(_leftStart)
                .For(_duration)
                .Create();
        }

        double GetLeftStart(FrameworkElement oldContent)
        {
            if (oldContent == null)
                return 0;

            double leftStart = Canvas.GetLeft(oldContent);

            return (double.IsNaN(leftStart))
                       ? 0
                       : leftStart;
        }
    }
}


