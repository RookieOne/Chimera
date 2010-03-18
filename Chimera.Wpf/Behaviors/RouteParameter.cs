using System.Windows;
using Chimera.Wpf.Fluent;

namespace Chimera.Wpf.Behaviors
{
    public class RouteParameter : FrameworkElement
    {
        static RouteParameter()
        {
            KeyProperty = Register.Property<string, RouteParameter>("Key");
            ValueProperty = Register.Property<object, RouteParameter>("Value");
        }

        public static readonly DependencyProperty KeyProperty;
        public static readonly DependencyProperty ValueProperty;

        public string Key
        {
            get { return (string) GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }

        public object Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
}