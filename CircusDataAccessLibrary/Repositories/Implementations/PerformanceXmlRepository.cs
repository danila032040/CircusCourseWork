using CircusDataAccessLibrary.Data;
using CircusDataAccessLibrary.Helpers.Implementations;
using CircusDataAccessLibrary.Repositories.Interfaces;

namespace CircusDataAccessLibrary.Repositories.Implementations
{
    public class PerformanceXmlRepository : XmlRepository<Performance, int>,
                                            IPerformanceRepository
    {
        public PerformanceXmlRepository(string filePath) : base(filePath, new XmlConverter(), new IntIdGenerator())
        {
        }
    }
}