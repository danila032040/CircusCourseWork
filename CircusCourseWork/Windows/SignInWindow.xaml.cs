using System.Windows;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels;

namespace CircusCourseWork.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SignInWindow
    {
        private readonly LoginViewModel _viewModel = new();
        public SignInWindow()
        {
            DataContext = _viewModel;
            InitializeComponent();

            if (DalSingleton.Instance.Auth.SignedInUser == null) return;
            
            var window = new MainWindow();
            Application.Current.MainWindow = window;
            window.Show();
            
            Close();
        }

        private void ButtonSignIn_OnClick(object sender, RoutedEventArgs e)
        {
            DalSingleton.Instance.Auth.SignIn(_viewModel.Login, _viewModel.Password);
            var window = new MainWindow();
            Application.Current.MainWindow = window;
            window.Show();
            
            Close();
        }

        private void HyperlinkSignInAsGuest_OnClick(object sender, RoutedEventArgs e)
        {
            DalSingleton.Instance.Auth.SignOut();
            var window = new MainWindow();
            Application.Current.MainWindow = window;
            window.Show();
            
            Close();
        }

        private void HyperlinkRegister_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}