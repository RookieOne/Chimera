using System.Windows;
using System.Windows.Data;

namespace Chimera.Wpf.Fluent
{
    public class Bind
    {
        public static BindBuilder This(DependencyObject source, string propertyPath)
        {
            return new BindBuilder(source, propertyPath);
        }
    }

    public class BindBuilder
    {
        public BindBuilder(DependencyObject source, string propertyPath)
        {
            _source = source;
            _propertyPath = propertyPath;
        }

        readonly string _propertyPath;
        readonly DependencyObject _source;

        public void To(DependencyObject target, DependencyProperty targetProperty)
        {
            Binding b = new Binding(_propertyPath);
            b.Source = _source;

            BindingOperations.SetBinding(target, targetProperty, b);
        }
    }
}