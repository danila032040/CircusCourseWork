using CircusDataAccessLibrary.Data;

namespace CircusDataAccessLibrary.Authorization.Interfaces
{
    public interface IAuth
    {
        void SignIn(string login, string password);
        void SignOut();
        User? SignedInUser { get; }
    }
}