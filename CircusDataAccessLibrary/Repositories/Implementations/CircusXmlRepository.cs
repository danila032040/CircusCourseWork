using CircusDataAccessLibrary.Data;
using CircusDataAccessLibrary.Helpers.Implementations;
using CircusDataAccessLibrary.Repositories.Interfaces;

namespace CircusDataAccessLibrary.Repositories.Implementations
{
    public class CircusXmlRepository : XmlRepository<Circus,int>, ICircusRepository
    {
        public CircusXmlRepository(string filePath) : base(filePath, new XmlConverter(), new IntIdGenerator())
        {
        }
    }
}