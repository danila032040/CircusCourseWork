using System;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using CircusDataAccessLibrary.Authorization.Interfaces;
using CircusDataAccessLibrary.Data;
using CircusDataAccessLibrary.Helpers.Implementations;
using CircusDataAccessLibrary.Helpers.Interfaces;
using CircusDataAccessLibrary.Repositories.Interfaces;

namespace CircusDataAccessLibrary.Authorization.Implementations
{
    public class Auth : IAuth
    {
        private readonly string _filePath;
        private readonly IUserRepository _userRepository;
        private readonly IXmlConverter _xmlConverter;


        public Auth(string filePath, IUserRepository userRepository)
        {
            _filePath = filePath;
            _userRepository = userRepository;
            _xmlConverter = new XmlConverter();

            try
            {
                SignedInUser = _xmlConverter.ConvertFromXml<User>(File.ReadAllText(_filePath));
            }
            catch
            {
                SignedInUser = null;
            }
        }

        public void SignIn(string login, string password)
        {
            if (login is null) throw new ArgumentNullException(nameof(login));
            if (password is null) throw new ArgumentNullException(nameof(password));
            if (SignedInUser is not null) throw new InvalidOperationException("You`ve already signed in!!!");

            SignedInUser = _userRepository.Read().FirstOrDefault(u => u.Login == login && u.Password == password) ??
                           throw new InvalidCredentialException("Incorrect login or password!!!");

            File.WriteAllText(_filePath, _xmlConverter.ConvertToXml(SignedInUser));
        }

        public void SignOut()
        {
            SignedInUser = null;
            File.WriteAllText(_filePath, _xmlConverter.ConvertToXml(SignedInUser));
        }

        public User? SignedInUser { get; private set; }
    }
}