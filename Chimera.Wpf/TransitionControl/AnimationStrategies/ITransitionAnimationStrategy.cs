using System.Windows;

namespace Chimera.Wpf.TransitionControl.AnimationStrategies
{
    public interface ITransitionAnimationStrategy
    {
        void Transition(ITransitionControl container,
                        FrameworkElement oldContent,
                        FrameworkElement newContent);
    }
}