using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Windows
{
    /// <summary>
    /// Interaction logic for EditViewWindow.xaml
    /// </summary>
    public partial class EditViewWindow : Window
    {
        public EditViewWindow()
        {
            InitializeComponent();

            Array values = Enum.GetValues(typeof(ViewType));

            List<NamedItem> viewTypes = new List<NamedItem>();

            foreach (ViewType value in values)
            {
                string description = Extensions.Extensions.GetEnumDescription(value);

                viewTypes.Add(new NamedItem(description, value));
            }

            ViewTypes = viewTypes;
        }

        public static readonly DependencyProperty ViewTypesProperty = DependencyProperty.Register(
            "ViewTypes", typeof(List<NamedItem>), typeof(EditViewWindow), new PropertyMetadata(default(List<NamedItem>)));

        public List<NamedItem> ViewTypes
        {
            get { return (List<NamedItem>) GetValue(ViewTypesProperty); }
            set { SetValue(ViewTypesProperty, value); }
        }

        //public static readonly DependencyProperty ViewTypeProperty = DependencyProperty.Register(
        //    "ViewType", typeof(ViewType), typeof(EditViewWindow), new PropertyMetadata(default(ViewType)));

        //public ViewType ViewType
        //{
        //    get { return (ViewType) GetValue(ViewTypeProperty); }
        //    set { SetValue(ViewTypeProperty, value); }
        //}

        //public static readonly DependencyProperty ViewNameProperty = DependencyProperty.Register(
        //    "ViewName", typeof(string), typeof(EditViewWindow), new PropertyMetadata(default(string)));

        //public string ViewName
        //{
        //    get { return (string) GetValue(ViewNameProperty); }
        //    set { SetValue(ViewNameProperty, value); }
        //}

        public static readonly DependencyProperty ViewProperty = DependencyProperty.Register(
            "View", typeof(View), typeof(EditViewWindow), new PropertyMetadata(default(View)));

        public View View
        {
            get { return (View) GetValue(ViewProperty); }
            set { SetValue(ViewProperty, value); }
        }

        public static readonly DependencyProperty AxesProperty = DependencyProperty.Register(
            "Axes", typeof(ObservableCollection<Axis>), typeof(EditViewWindow), new PropertyMetadata(default(ObservableCollection<Axis>)));

        public ObservableCollection<Axis> Axes
        {
            get { return (ObservableCollection<Axis>) GetValue(AxesProperty); }
            set { SetValue(AxesProperty, value); }
        }

        public static readonly DependencyProperty SelectedAxisProperty = DependencyProperty.Register(
            "SelectedAxis", typeof(Axis), typeof(EditViewWindow), new PropertyMetadata(default(Axis)));

        public Axis SelectedAxis
        {
            get { return (Axis) GetValue(SelectedAxisProperty); }
            set { SetValue(SelectedAxisProperty, value); }
        }

        public static readonly DependencyProperty SelectedViewAxisProperty = DependencyProperty.Register(
            "SelectedViewAxis", typeof(Axis), typeof(EditViewWindow), new PropertyMetadata(default(Axis)));

        public Axis SelectedViewAxis
        {
            get { return (Axis) GetValue(SelectedViewAxisProperty); }
            set { SetValue(SelectedViewAxisProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof(string), typeof(ConfirmationWindow), new PropertyMetadata(default(string)));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        private void OkButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void AddAxis_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (Axes != null && View?.Axes != null && SelectedAxis != null)
            {
                e.CanExecute = Axes.Except(View.Axes).Any();
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void AddAxis_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (SelectedAxis != null)
            {
                View.Axes.Add(SelectedAxis);
                //View.Axes = new ObservableCollection<Axis>(View.Axes.OrderBy(a => a.OrderNumber));
            }
        }

        private void RemoveAxis_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = View?.Axes != null && SelectedViewAxis != null && View.Axes.Any();
        }

        private void RemoveAxis_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (SelectedViewAxis != null)
            {
                View.Axes.Remove(SelectedViewAxis);
            }
        }
    }
}
