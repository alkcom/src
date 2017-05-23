using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Niscon.Raynok.Models;
using Niscon.Raynok.Validation;

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

            Loaded += EditViewWindow_Loaded; 
        }

        private void EditViewWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //implementing binding programmatically, because declarative way does not work
            Binding viewNameBinding = new Binding("View.Name") {Mode = BindingMode.TwoWay};
            viewNameBinding.ValidationRules.Add(new ViewNameValidationRule { Views = ExistingViews});

            ViewNameText.SetBinding(TextBox.TextProperty, viewNameBinding);
        }

        public static readonly DependencyProperty ViewTypesProperty = DependencyProperty.Register(
            "ViewTypes", typeof(List<NamedItem>), typeof(EditViewWindow), new PropertyMetadata(default(List<NamedItem>)));

        public List<NamedItem> ViewTypes
        {
            get { return (List<NamedItem>) GetValue(ViewTypesProperty); }
            set { SetValue(ViewTypesProperty, value); }
        }

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
            "Header", typeof(string), typeof(EditViewWindow), new PropertyMetadata(default(string)));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty ExistingViewsProperty = DependencyProperty.Register(
            "ExistingViews", typeof(ObservableCollection<View>), typeof(EditViewWindow), new PropertyMetadata(default(ObservableCollection<View>)));

        public ObservableCollection<View> ExistingViews
        {
            get { return (ObservableCollection<View>) GetValue(ExistingViewsProperty); }
            set { SetValue(ExistingViewsProperty, value); }
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

        private void ViewTypeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (View.Id == Guid.Empty)
            {
                string type = Extensions.Extensions.GetEnumDescription(View.Type);
                int? viewsCount = ExistingViews?.Count;

                View.Name = $"{type} {viewsCount}";
            }
        }

        private void Ok_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Ok_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ValidationError[] validationErrors = System.Windows.Controls.Validation.GetErrors(ViewNameText).Union(System.Windows.Controls.Validation.GetErrors(ViewTypesList)).ToArray();

            if (validationErrors.Any())
            {
                StringBuilder sb = new StringBuilder();
                foreach (ValidationError error in validationErrors)
                {
                    sb.AppendLine($"* {error.ErrorContent}");
                }

                MessageBoxWindow messageBox = new MessageBoxWindow
                {
                    Header = "View errors",
                    Message = sb.ToString(),
                    Owner = this,
                    Height = 300,
                    Width = 500
                };

                messageBox.ShowDialog();

                return;
            }

            DialogResult = true;
            Close();
        }

        private void Cancel_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Cancel_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
