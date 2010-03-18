using System.Windows.Input;

namespace Example.Menu
{
    public interface IMenu
    {
        void Add(ICommand command, params string[] menuHeaders);
        void Remove(params string[] menuHeaders);
    }
}