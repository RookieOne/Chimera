using System;
using System.Windows.Input;

namespace Chimera.Wpf.Commands
{
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action action)
            : this(() => true, action)
        {
        }

        public DelegateCommand(Func<bool> can, Action action)
        {
            _can = can;
            _action = action;
        }

        readonly Action _action;
        readonly Func<bool> _can;

        public void Execute(object parameter)
        {
            if (_action != null
                && CanExecute(parameter))
                _action.Invoke();
        }

        public bool CanExecute(object parameter)
        {
            return _can != null
                       ? _can.Invoke()
                       : true;
        }

        public event EventHandler CanExecuteChanged = delegate { }; 
    }
}