using System.Linq.Expressions;
using System.Windows;

namespace Chimera.Wpf.AttachedProperties
{
    public static class ViewProperties
    {
        static ViewProperties()
        {
            ViewProperty = DependencyProperty.RegisterAttached("View",
                                                               typeof (object),
                                                               typeof (ViewProperties),
                                                               new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
            ShowAsProperty = DependencyProperty.RegisterAttached("ShowAs",
                                                                 typeof (string),
                                                                 typeof (ViewProperties),
                                                                 new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
        }

        public static readonly DependencyProperty ShowAsProperty;
        public static readonly DependencyProperty ViewProperty;

        public static object GetView(DependencyObject o)
        {
            return o.GetValue(ViewProperty);
        }

        public static void SetView(DependencyObject o, object value)
        {
            o.SetValue(ViewProperty, value);
        }

        public static string GetShowAs(DependencyObject o)
        {
            return (string) o.GetValue(ShowAsProperty);
        }

        public static void SetShowAs(DependencyObject o, string value)
        {
            o.SetValue(ShowAsProperty, value);
        }
    }
}