using System.Windows;

namespace Chimera.Wpf.Fluent
{
    public class Register
    {
        public static DependencyProperty Property<T, TOwner>(string name)
        {
            return DependencyProperty.Register(name, typeof (T), typeof (TOwner));
        }

        public static DependencyProperty Property<T, TOwner>(string name, PropertyChangedCallback callback)
        {
            return DependencyProperty.Register(name, typeof (T), typeof (TOwner), new PropertyMetadata(callback));
        }
    }
}