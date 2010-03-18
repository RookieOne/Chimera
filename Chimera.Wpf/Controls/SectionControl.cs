using System.Windows;
using System.Windows.Controls;

namespace Chimera.Wpf.Controls
{
    public class SectionControl : ContentControl
    {
        static SectionControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (SectionControl), new FrameworkPropertyMetadata(typeof (SectionControl)));
            TitleProperty = DependencyProperty.Register("Title",
                                                        typeof (string),
                                                        typeof (SectionControl));
        }

        public static readonly DependencyProperty TitleProperty;

        public string Title
        {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
}