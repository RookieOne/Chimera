using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Chimera.Wpf.Commands;

namespace Example.Menu
{
    public class WpfMenu : IMenu
    {
        public WpfMenu(System.Windows.Controls.Menu menu)
        {
            _menu = menu;
        }

        readonly System.Windows.Controls.Menu _menu;

        public void Add(ICommand command, params string[] menuHeaders)
        {
            var headerStack = new Stack<string>(menuHeaders.Reverse());

            Add(_menu.Items, command, headerStack);
        }

        public void Remove(params string[] menuHeaders)
        {
            var headerStack = new Stack<string>(menuHeaders.Reverse());

            Remove(_menu.Items, headerStack);
        }

        void Remove(ItemCollection items, Stack<string> headers)
        {
            var header = headers.Pop();

            if (headers.Count == 0)
            {
                RemoveMenuItem(items, header);
            }
            else
            {
                var m = Find(items, header);
                Remove(m.Items, headers);
            }
        }

        void RemoveMenuItem(ItemCollection items, string header)
        {
            var m = Find(items, header);

            items.Remove(m);
        }

        void Add(ItemCollection items, ICommand command, Stack<string> headers)
        {
            var header = headers.Pop();

            if (headers.Count == 0)
            {
                AddMenuItem(items, header, command);
            }
            else
            {
                var menuItem = Find(items, header);

                if (menuItem == null)
                    menuItem = AddMenuItem(items, header, new DelegateCommand(() => { }));

                Add(menuItem.Items, command, headers);
            }
        }

        MenuItem AddMenuItem(ItemCollection items, string header, ICommand command)
        {
            var menuItem = new MenuItem();
            menuItem.Header = header;
            menuItem.Command = command;

            items.Add(menuItem);

            return menuItem;
        }

        MenuItem Find(ItemCollection items, string header)
        {
            return items
                .Cast<MenuItem>()
                .FirstOrDefault(i => i.Header.ToString() == header);
        }
    }
}