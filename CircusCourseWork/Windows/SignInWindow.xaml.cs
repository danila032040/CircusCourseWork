using System.Windows;
using CircusCourseWork.ViewModels;

namespace CircusCourseWork.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            
            DataContext = new LoginViewModel();
            
            InitializeComponent();

        }

        private void ButtonSignIn_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void HyperlinkSignInAsGuest_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void HyperlinkRegister_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}