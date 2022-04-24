using CircusDataAccessLibrary.Data;
using CircusDataAccessLibrary.Helpers.Implementations;
using CircusDataAccessLibrary.Repositories.Interfaces;

namespace CircusDataAccessLibrary.Repositories.Implementations
{
    public class UserXmlRepository : XmlRepository<User, int>, IUserRepository
    {
        public UserXmlRepository(string filePath) : base(filePath, new XmlConverter(), new IntIdGenerator())
        {
        }
    }
}