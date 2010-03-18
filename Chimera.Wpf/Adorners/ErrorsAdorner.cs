using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Chimera.Framework.Errors;

namespace Chimera.Wpf.Adorners
{
    public class ErrorsAdorner : Adorner
    {
        public ErrorsAdorner(UIElement adornedElement,
                             IEnumerable<IError> errors) : base(adornedElement)
        {
            VisualChildren = new VisualCollection(this);

            CreatePanel(errors);
        }

        StackPanel _stackPanel;
        VisualCollection VisualChildren { get; set; }

        protected override Visual GetVisualChild(int index)
        {
            return VisualChildren[index];
        }

        protected override int VisualChildrenCount
        {
            get { return VisualChildren.Count; }
        }

        void CreatePanel(IEnumerable<IError> errors)
        {
            _stackPanel = new StackPanel();

            VisualChildren.Add(_stackPanel);

            foreach (var error in errors)
            {
                var textBlock = new TextBlock();
                textBlock.Text = error.Message;
                _stackPanel.Children.Add(textBlock);
            }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            _stackPanel.Measure(constraint);

            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            _stackPanel.Arrange(new Rect(finalSize));

            return base.ArrangeOverride(finalSize);
        }
    }
}