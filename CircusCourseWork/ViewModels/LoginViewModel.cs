using System;

namespace CircusCourseWork.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                ValidateLogin();
                
                OnPropertyChanged();
                OnErrorsChanged();
            }
        }


        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                ValidatePassword();
                
                OnPropertyChanged();
                OnErrorsChanged();
            }
        }

        public LoginViewModel()
        {
            _login = string.Empty;
            _password = string.Empty;
        }

        public LoginViewModel(string login, string password)
        {
            _login = login ?? throw new ArgumentNullException(nameof(login));
            _password = password ?? throw new ArgumentNullException(nameof(password));
        }

        private void ValidateLogin()
        {
            ClearErrors(nameof(Login));
            if (_login == string.Empty) AddError(new Error("Login can`t be empty."), nameof(Login));
        }

        private void ValidatePassword()
        {
            ClearErrors(nameof(Password));
            if (_password == string.Empty) AddError(new Error("Password can`t be empty"), nameof(Password));
        }
    }
}