using CircusDataAccessLibrary.Data;
using CircusDataAccessLibrary.Helpers.Implementations;
using CircusDataAccessLibrary.Repositories.Interfaces;

namespace CircusDataAccessLibrary.Repositories.Implementations
{
    public class RoleXmlRepository : XmlRepository<Role, int>, IRoleRepository
    {
        public RoleXmlRepository(string filePath) : base(filePath, new XmlConverter(), new IntIdGenerator())
        {
        }
    }
}