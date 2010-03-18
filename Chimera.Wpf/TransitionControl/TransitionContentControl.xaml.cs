using System.Windows;
using System.Windows.Controls;
using Chimera.Wpf.Extensions;
using Chimera.Wpf.TransitionControl.AnimationStrategies;

namespace Chimera.Wpf.TransitionControl
{
    /// <summary>
    ///   Interaction logic for TransitionContentControl.xaml
    /// </summary>
    public partial class TransitionContentControl : UserControl, ITransitionControl
    {
        static TransitionContentControl()
        {
            TransitionContentProperty = DependencyProperty.Register("TransitionContent",
                                                                    typeof (FrameworkElement),
                                                                    typeof (TransitionContentControl),
                                                                    new PropertyMetadata(OnContentChanged));
        }

        public TransitionContentControl()
        {
            InitializeComponent();
            AnimationStrategy = new SlideAnimationStrategy(1.Seconds());
        }

        public static readonly DependencyProperty TransitionContentProperty;

        public FrameworkElement TransitionContent
        {
            get { return (FrameworkElement) GetValue(TransitionContentProperty); }
            set { SetValue(TransitionContentProperty, value); }
        }

        public ITransitionAnimationStrategy AnimationStrategy { get; set; }

        public void Add(FrameworkElement element)
        {
            if (element != null)
                canvas.Children.Add(element);
        }

        public void Remove(FrameworkElement element)
        {
            if (element != null)
                canvas.Children.Remove(element);
        }

        public bool Contains(FrameworkElement element)
        {
            return canvas.Children.Contains(element);
        }

        public Control AsControl()
        {
            return this;
        }

        static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var control = d as TransitionContentControl;
            if (control == null)
                return;

            control.ChangeContent((FrameworkElement) args.OldValue, (FrameworkElement) args.NewValue);
        }

        void ChangeContent(FrameworkElement oldValue, FrameworkElement newValue)
        {
            AnimationStrategy.Transition(this, oldValue, newValue);
        }
    }
}