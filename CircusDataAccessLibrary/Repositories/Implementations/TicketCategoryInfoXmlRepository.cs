using CircusDataAccessLibrary.Data;
using CircusDataAccessLibrary.Helpers.Implementations;
using CircusDataAccessLibrary.Repositories.Interfaces;

namespace CircusDataAccessLibrary.Repositories.Implementations
{
    public class TicketCategoryInfoXmlRepository : XmlRepository<TicketCategoryInfo, int>, ITicketCategoryInfoRepository
    {
        public TicketCategoryInfoXmlRepository(string filePath) : base(filePath, new XmlConverter(),
                                                                       new IntIdGenerator())
        {
        }
    }
}