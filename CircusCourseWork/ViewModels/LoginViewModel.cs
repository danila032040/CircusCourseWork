using CircusCourseWork.ViewModels.Base;

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

        private void ValidateLogin()
        {
            ClearErrors(nameof(Login));
            if (string.IsNullOrEmpty(Login)) AddError(new Error($"{nameof(Login)} can`t be empty."), nameof(Login));
        }

        private void ValidatePassword()
        {
            ClearErrors(nameof(Password));
            if (string.IsNullOrEmpty(Password)) AddError(new Error($"{nameof(Password)} can`t be empty"), nameof(Password));
        }
    }
}