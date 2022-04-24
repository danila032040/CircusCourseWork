using CircusDataAccessLibrary.Data;
using CircusDataAccessLibrary.Helpers.Interfaces;
using CircusDataAccessLibrary.Repositories.Interfaces;

namespace CircusDataAccessLibrary.Repositories.Implementations
{
    public class PerformanceXmlRepository : XmlRepository<Performance, int>,
                                            IPerformanceRepository
    {
        public PerformanceXmlRepository(string filePath,
                                        IXmlConverter xmlConverter,
                                        IIdGenerator<int> idGenerator) : base(filePath, xmlConverter, idGenerator)
        {
        }
    }
}