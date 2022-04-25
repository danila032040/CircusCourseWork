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
    }
}