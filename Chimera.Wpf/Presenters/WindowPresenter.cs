using System;
using System.Collections.Generic;
using System.Windows;
using Chimera.Default.ViewPresenters;
using Chimera.Framework.Extensions;

namespace Chimera.Wpf.Presenters
{
    public class WindowPresenter : PresenterProcessor
    {
        public WindowPresenter() : base("window")
        {
            _windows = new Dictionary<object, Window>();
        }

        readonly Dictionary<object, Window> _windows;

        public override void RegisterHost(object host)
        {
            // do nothing
        }

        public override void Show(object view)
        {
            var window = new Window();
            window.Content = view;

            _windows.Add(view, window);

            window.Closed += (sender, e) => _windows.SafeRemove(view);
            window.Show();
        }

        public override void Close(object view)
        {
            if (!_windows.ContainsKey(view))
                return;
            
            _windows[view].Close();

            _windows.SafeRemove(view);
        }
    }
}