using System.Linq;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels.Base;

namespace CircusCourseWork.ViewModels
{
    public class RegisterViewModel : ViewModel
    {
        private string _userName;
        private string _login;
        private string _password;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;

                ValidateUserName();
                OnPropertyChanged();
                OnErrorsChanged();
            }
        }

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


        public RegisterViewModel()
        {
            _userName = string.Empty;
            _login = string.Empty;
            _password = string.Empty;
        }

        private void ValidateUserName()
        {
            ClearErrors(nameof(UserName));
            if (string.IsNullOrEmpty(UserName))
                AddError(new Error($"{nameof(UserName)} can`t be empty!"), nameof(UserName));
        }

        private void ValidateLogin()
        {
            ClearErrors(nameof(Login));
            if (string.IsNullOrEmpty(Login)) AddError(new Error($"{nameof(Login)} can`t be empty!"), nameof(Login));
            if (DalSingleton.Instance.UserRepository.Read().Any(u => u.Login == Login))
                AddError(new Error($"This {nameof(Login)} is already used."), nameof(Login));
        }

        private void ValidatePassword()
        {
            ClearErrors(nameof(Password));
            if (string.IsNullOrEmpty(Password))
                AddError(new Error($"{nameof(Password)} can`t be empty!"), nameof(Password));
        }
    }
}