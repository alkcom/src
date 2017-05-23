using System.Windows;
using System.Windows.Input;
using Niscon.Raynok.Models;

namespace Niscon.Raynok.Windows
{
    /// <summary>
    /// Interaction logic for AfParametersWindow.xaml
    /// </summary>
    public partial class AfParametersWindow : Window
    {
        public AfParametersWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CueProperty = DependencyProperty.Register(
            "Cue", typeof(Cue), typeof(AfParametersWindow), new PropertyMetadata(default(Cue)));

        public Cue Cue
        {
            get { return (Cue) GetValue(CueProperty); }
            set { SetValue(CueProperty, value); }
        }

        private void Ok_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Ok_Executed(object sender, ExecutedRoutedEventArgs e)
        {
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
