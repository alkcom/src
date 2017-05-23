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
    /// Interaction logic for CuePropertiesWindow.xaml
    /// </summary>
    public partial class CuePropertiesWindow : Window
    {
        public CuePropertiesWindow(Cue cue, ObservableCollection<Cue> existingCues)
        {
            InitializeComponent();

            Cue = cue;
            ExistingCues = existingCues;

            Loaded += CuePropertiesWindow_Loaded;
        }

        private void CuePropertiesWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Binding cueNameBinding = new Binding("Cue.Name") { Mode = BindingMode.TwoWay };
            cueNameBinding.ValidationRules.Add(new CueNameValidationRule() { Cues = ExistingCues});

            CueNameText.SetBinding(TextBox.TextProperty, cueNameBinding);
        }

        public static readonly DependencyProperty CueProperty = DependencyProperty.Register(
            "Cue", typeof(Cue), typeof(CuePropertiesWindow), new PropertyMetadata(default(Cue)));

        public Cue Cue
        {
            get { return (Cue) GetValue(CueProperty); }
            set { SetValue(CueProperty, value); }
        }

        public static readonly DependencyProperty ExistingCuesProperty = DependencyProperty.Register(
            "ExistingCues", typeof(ObservableCollection<Cue>), typeof(CuePropertiesWindow), new PropertyMetadata(default(ObservableCollection<Cue>)));

        public ObservableCollection<Cue> ExistingCues
        {
            get { return (ObservableCollection<Cue>) GetValue(ExistingCuesProperty); }
            set { SetValue(ExistingCuesProperty, value); }
        }

        private void AfParameters_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Cue?.Parent != null && Cue.Parent.Type == CueType.Default;
        }

        private void AfParameters_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AfParametersWindow window = new AfParametersWindow
            {
                Cue = Cue,
                Owner = this
            };

            window.ShowDialog();
        }

        private void Ok_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Ok_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ReadOnlyObservableCollection<ValidationError> validationErrors = System.Windows.Controls.Validation.GetErrors(CueNameText);

            if (validationErrors.Any())
            {
                StringBuilder sb = new StringBuilder();
                foreach (ValidationError error in validationErrors)
                {
                    sb.AppendLine($"* {error.ErrorContent}");
                }

                MessageBoxWindow messageBox = new MessageBoxWindow
                {
                    Header = "Cue errors",
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

        private void Cancel_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
