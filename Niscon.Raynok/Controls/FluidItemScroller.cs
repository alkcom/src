using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Niscon.Raynok.Controls
{
    //TODO: fix issue with resizing
    public class FluidItemScroller : ScrollViewer
    {
        private Point? _capturedPosition = null;
        private double? _scrollOffset = null;

        public FluidItemScroller()
        {
            PreviewMouseDown += OnPreviewMouseDown;
            PreviewMouseUp += OnPreviewMouseUp;
            PreviewMouseMove += OnPreviewMouseMove;
            SizeChanged += OnSizeChanged;

            Loaded += FluidItemScroller_Loaded;   
        }

        private void FluidItemScroller_Loaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Grid grid = (Grid)VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(this, 0), 1), 0);
            if (grid != null)
            {
                grid.SizeChanged += Grid_SizeChanged;
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AlignScrollOffset(HorizontalOffset, TimeSpan.Zero, false);
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            //AlignScrollOffset(HorizontalOffset, TimeSpan.Zero, true);
        }

        private void OnPreviewMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.LeftButton == MouseButtonState.Pressed && _capturedPosition.HasValue && _scrollOffset.HasValue)
            {
                Vector delta = Mouse.GetPosition(this) - _capturedPosition.Value;

                double newOffset = _scrollOffset.Value - delta.X;

                if (newOffset > 0 && newOffset != _scrollOffset.Value)
                {
                    ScrollToHorizontalOffset(newOffset);

                    mouseEventArgs.Handled = true;
                }
            }
        }

        private void OnPreviewMouseUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (_capturedPosition.HasValue && _scrollOffset.HasValue)
            {
                Vector delta = Mouse.GetPosition(this) - _capturedPosition.Value;
                double newOffset = _scrollOffset.Value - delta.X;

                if (delta.X != 0)
                {
                    mouseButtonEventArgs.Handled = true;

                    AlignScrollOffset(newOffset);
                }

                _capturedPosition = null;
                _scrollOffset = null;
            }
        }

        private void OnPreviewMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (mouseButtonEventArgs.LeftButton == MouseButtonState.Pressed)
            {
                _capturedPosition = Mouse.GetPosition(this);
                _scrollOffset = HorizontalOffset;

                mouseButtonEventArgs.Handled = true;
            }
        }

        private void AlignScrollOffset(double newOffset, TimeSpan? duration = null, bool internalChange = false)
        {
            if (!duration.HasValue)
            {
                duration = TimeSpan.FromMilliseconds(300);
            }

            Grid grid = (Grid)VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(this, 0), 1), 0);

            FrameworkElement selectedChild = null;

            double totalWidth = 0;
            
            int i = 0;
            FrameworkElement[] children = GetChildren().ToArray();
            int childrenCount = children.Length;
            foreach (FrameworkElement child in children)
            {
                if (child.Visibility != Visibility.Visible)
                {
                    continue;
                }

                selectedChild = child;

                double childTotalWidth = child.ActualWidth + child.Margin.Left + child.Margin.Right;
                double newWidth = totalWidth + childTotalWidth;
                double middle = totalWidth + childTotalWidth / 2;

                //stopped in a left half of control
                if (newOffset < middle && newOffset >= totalWidth)
                {
                    newOffset = totalWidth;

                    break;
                }
                //stopped in a right half of control
                else if (newOffset >= middle && newOffset < newWidth && i < (childrenCount - 1))
                {
                    newOffset = newWidth;
                    //this will only happen if current element is not the last one
                    //exception is not plausible
                    selectedChild = (FrameworkElement) VisualTreeHelper.GetChild(grid, i + 1);

                    break;
                }

                totalWidth = newWidth;
                i++;
            }

            if (!internalChange && selectedChild != null)
            {
                SelectedValue = GetItemValue(selectedChild);
            }

            DoubleAnimation animation = new DoubleAnimation
            {
                From = HorizontalOffset,
                To = newOffset,
                Duration = new Duration(duration.Value)
            };

            BeginAnimation(AnimatableHorizontalOffsetProperty, animation);
        }

        private IEnumerable<FrameworkElement> GetChildren()
        {
            Grid grid = (Grid)VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(this, 0), 1), 0);
            int childrenCount = VisualTreeHelper.GetChildrenCount(grid);

            for (int i = 0; i < childrenCount; i++)
            {
                yield return (FrameworkElement) VisualTreeHelper.GetChild(grid, i);
            }
        }

        #region Dependency properties

        public static readonly DependencyProperty AnimatableHorizontalOffsetProperty = DependencyProperty.Register(
            "AnimatableHorizontalOffset", typeof(double), typeof(FluidItemScroller), new PropertyMetadata(default(double), AnimatableHorizontalOffset_Changed));

        private static void AnimatableHorizontalOffset_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            ScrollViewer scroller = (ScrollViewer) dependencyObject;

            scroller.ScrollToHorizontalOffset((double)dependencyPropertyChangedEventArgs.NewValue);
        }

        public double AnimatableHorizontalOffset
        {
            get { return (double) GetValue(AnimatableHorizontalOffsetProperty); }
            set { SetValue(AnimatableHorizontalOffsetProperty, value); }
        }

        public static readonly DependencyProperty AnimatableVerticalOffsetProperty = DependencyProperty.Register(
            "AnimatableVerticalOffset", typeof(double), typeof(FluidItemScroller), new PropertyMetadata(default(double), AnimatableVerticalOffset_Changed));

        private static void AnimatableVerticalOffset_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            ScrollViewer scroller = (ScrollViewer)dependencyObject;

            scroller.ScrollToVerticalOffset((double)dependencyPropertyChangedEventArgs.NewValue);
        }

        public double AnimatableVerticalOffset
        {
            get { return (double) GetValue(AnimatableVerticalOffsetProperty); }
            set { SetValue(AnimatableVerticalOffsetProperty, value); }
        }

        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register(
            "SelectedValue", typeof(object), typeof(FluidItemScroller), new PropertyMetadata(default(object), SelectedValue_Changed));

        private static void SelectedValue_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            FluidItemScroller fluidScroller = (FluidItemScroller) dependencyObject;
            object selected = fluidScroller.SelectedValue;

            if (selected == null)
            {
                return;
            }

            double newOffset = 0;
            foreach (FrameworkElement child in fluidScroller.GetChildren())
            {
                double childTotalWidth = child.ActualWidth + child.Margin.Left + child.Margin.Right;

                object itemValue = GetItemValue(child);
                if (selected.Equals(itemValue))
                {
                    fluidScroller.AlignScrollOffset(newOffset, internalChange: true);
                    break;
                }

                newOffset += childTotalWidth;
            }
        }

        public object SelectedValue
        {
            get { return (object) GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        #endregion

        #region Attached properties

        public static readonly DependencyProperty ItemValueProperty = DependencyProperty.RegisterAttached(
            "ItemValue", typeof(object), typeof(FluidItemScroller), new PropertyMetadata(default(object)));

        [AttachedPropertyBrowsableForChildren]
        public static void SetItemValue(DependencyObject element, object value)
        {
            element.SetValue(ItemValueProperty, value);
        }

        [AttachedPropertyBrowsableForChildren]
        public static object GetItemValue(DependencyObject element)
        {
            return (object) element.GetValue(ItemValueProperty);
        }

        #endregion
    }
}
