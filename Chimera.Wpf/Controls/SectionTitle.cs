using System.Windows;
using System.Windows.Controls;

namespace Chimera.Wpf.Controls
{
    public class SectionTitle : Control
    {
        static SectionTitle()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SectionTitle),
                                                     new FrameworkPropertyMetadata(typeof(SectionTitle)));

            TitleProperty = DependencyProperty.Register("Title",
                                                        typeof (string),
                                                        typeof (SectionTitle));
        }

        public static readonly DependencyProperty TitleProperty;

        public string Title
        {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
}