using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Chimera.Default.ViewPresenters;
using Chimera.Wpf.Extensions;
using Chimera.Wpf.TransitionControl;
using Chimera.Wpf.TransitionControl.AnimationStrategies;
using WPF.MDI;

namespace Chimera.Wpf.Presenters
{
    public class MdiPresenter : PresenterProcessor
    {
        public MdiPresenter() : base("mdi")
        {            
        }

        MdiContainer _container;

        public override void RegisterHost(object host)
        {
            _container = host as MdiContainer;
            _registry = new Dictionary<object, MdiChild>();
        }

        public override void Show(object view)
        {
            var child = CreateWindow(view as UIElement, "");

            _registry.Add(view, child);
            _container.AddChild(child);
        }

        public override void Close(object view)
        {
            if (_registry.ContainsKey(view))
            {
                _container.Children.Remove(_registry[view]);
                _registry.Remove(view);
            }
        }

        Dictionary<object, MdiChild> _registry;

        MdiChild CreateWindow(UIElement content, string header)
        {
            var grid = new Grid();
            var transitionControl = new TransitionContentControl();
            transitionControl.AnimationStrategy = new ModalAnimationStrategy(500.MilliSeconds(), grid);

            grid.Children.Add(transitionControl);
            grid.Children.Add(content);

            Panel.SetZIndex(transitionControl, 100);

            var child = new MdiChild
                            {
                                Title = header,
                                Content = grid,
                                Background = Brushes.White,
                                Height = 600,
                                Width = 600
                            };            
            return child;
        }
    }
}