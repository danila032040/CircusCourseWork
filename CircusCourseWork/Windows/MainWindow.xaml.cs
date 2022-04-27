using System.Linq;
using System.Windows;
using CircusCourseWork.Services;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.Windows
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            SetSignedInUser(DalSingleton.Instance.Auth.SignedInUser);
        }
        
        private void SetSignedInUser(User? user)
        {
            if (user != null)
            {
                Role? userRole = DalSingleton.Instance.RoleRepository.Read()
                    .FirstOrDefault(r => r.Id == user.RoleId);

                if (userRole == null)
                {
                    GuestControl.Visibility = Visibility.Hidden;
                    AdminControl.Visibility = Visibility.Hidden;
                    RegisteredUserControl.Visibility = Visibility.Visible;
                }
                else if (userRole.Name == "Admin")
                {
                    GuestControl.Visibility = Visibility.Hidden;
                    AdminControl.Visibility = Visibility.Visible;
                    RegisteredUserControl.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                GuestControl.Visibility = Visibility.Visible;
                AdminControl.Visibility = Visibility.Hidden;
                RegisteredUserControl.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonSignOut_OnClick(object sender, RoutedEventArgs e)
        {
            DalSingleton.Instance.Auth.SignOut();
            var window = new SignInWindow();
            Application.Current.MainWindow = window;
            window.Show();
            
            Close();
        }
    }
}