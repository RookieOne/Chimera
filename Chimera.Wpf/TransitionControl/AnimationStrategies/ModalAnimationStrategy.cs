using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Chimera.Wpf.Fluent;

namespace Chimera.Wpf.TransitionControl.AnimationStrategies
{
    public class ModalAnimationStrategy : BaseTransitionAnimationStrategy
    {
        public ModalAnimationStrategy(Duration duration, FrameworkElement modalScope)
        {
            _duration = duration;
            _modalScope = modalScope;
            _background = GetBackground();
        }

        readonly FrameworkElement _background;
        Border _border;
        readonly Duration _duration;
        readonly FrameworkElement _modalScope;

        protected override FrameworkElement ModifyNewContent(ITransitionControl container, FrameworkElement newContent)
        {
            if (newContent == null)
            {
                HideBackground(container);
                container.Remove(_border);
                return null;
            }

            ShowBackground(container);

            _border = WrapInBorder(newContent);

            _border.Opacity = 0;

            SetPosition(_border);

            newContent.SizeChanged += (sender, e) => SetPosition(_border);

            var ctrl = container.AsControl();

            ctrl.SizeChanged += (sender, e) => SetPosition(_border);

            return _border;
        }

        Border WrapInBorder(FrameworkElement newContent)
        {
            var border = new Border();            
            border.Style = Application.Current.FindResource("ModalBorderStyle") as Style;            
            border.Child = newContent;            

            return border;
        }

        protected override Animation GetOutAnimation()
        {
            return Animate.The(UIElement.OpacityProperty)
                .From(1d)
                .To(0d)
                .For(_duration)
                .Create();
        }

        protected override Animation GetInAnimation()
        {
            return Animate.The(UIElement.OpacityProperty)
                .From(0d)
                .To(1d)
                .For(_duration)
                .Create();
        }

        void SetPosition(FrameworkElement newContent)
        {
            Func<double, double, double> getPoint = (n, m) =>
                                                        {
                                                            var newContentMidPoint = n/2;
                                                            var modalScopeMidPoint = m/2;
                                                            return modalScopeMidPoint - newContentMidPoint;
                                                        };

            var left = getPoint(newContent.ActualWidth, _modalScope.ActualWidth);
            var top = getPoint(newContent.ActualHeight, _modalScope.ActualHeight);

            Canvas.SetLeft(newContent, left);
            Canvas.SetTop(newContent, top);
        }

        void HideBackground(ITransitionControl container)
        {
            if (container.Contains(_background))
            {
                Animate.The(UIElement.OpacityProperty)
                    .From(1d)
                    .To(0d)
                    .For(_duration)
                    .UponCompletion(() => container.Remove(_background))
                    .Create()
                    .AnimateOn(_background);
            }
        }

        void ShowBackground(ITransitionControl container)
        {
            if (!container.Contains(_background))
            {
                container.Add(_background);

                Animate.The(UIElement.OpacityProperty)
                    .From(0d)
                    .To(1d)
                    .For(_duration)
                    .Create()
                    .AnimateOn(_background);
            }
        }

        FrameworkElement GetBackground()
        {
            var r = new Rectangle();
            var color = Color.FromArgb(225, 0, 0, 0);
            r.Fill = new SolidColorBrush(color);

            Bind.This(_modalScope, "ActualWidth")
                .To(r, FrameworkElement.WidthProperty);

            Bind.This(_modalScope, "ActualHeight")
                .To(r, FrameworkElement.HeightProperty);

            Panel.SetZIndex(r, -5);

            return r;
        }
    }
}