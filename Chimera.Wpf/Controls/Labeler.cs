using System;
using System.Windows;
using System.Windows.Controls;
using Chimera.Wpf.Fluent;

namespace Chimera.Wpf.Controls
{    
    public class Labeler : ContentControl
    {
        static Labeler()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (Labeler), new FrameworkPropertyMetadata(typeof (Labeler)));

            ContentTypeProperty = Register.Property<string, Labeler>("ContentType");

            LabelProperty = Register.Property<string, Labeler>("Label");
        }

        public static readonly DependencyProperty ContentTypeProperty;

        public static readonly DependencyProperty LabelProperty;

        public string Label
        {
            get { return (string) GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public string ContentType
        {
            get { return (string) GetValue(ContentTypeProperty); }
            set { SetValue(ContentTypeProperty, value); }
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            Type type = newContent.GetType();

            ContentType = type.Name;

            base.OnContentChanged(oldContent, newContent);
        }
    }
}