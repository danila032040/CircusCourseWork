using System.Windows;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.Windows
{
    public partial class RegisterWindow
    {
        private readonly RegisterViewModel _viewModel = new();
        public RegisterWindow()
        {
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void ButtonRegister_OnClick(object sender, RoutedEventArgs e)
        {
            if (_viewModel.HasErrors)
            {
                MessageBox.Show("Неверный логин или пароль!");
                return;
            }
            DalSingleton.Instance.UserRepository.Create(new User
                                                        {
                                                            Name = _viewModel.UserName,
                                                            Login = _viewModel.Login,
                                                            Password = _viewModel.Password
                                                        });
            DalSingleton.Instance.Auth.SignIn(_viewModel.Login, _viewModel.Password);
            DialogResult = true;
            Close();
        }
    }
}