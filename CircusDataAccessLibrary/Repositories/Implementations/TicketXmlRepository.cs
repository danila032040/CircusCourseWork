using CircusDataAccessLibrary.Data;
using CircusDataAccessLibrary.Helpers.Implementations;
using CircusDataAccessLibrary.Repositories.Interfaces;

namespace CircusDataAccessLibrary.Repositories.Implementations
{
    public class TicketXmlRepository : XmlRepository<Ticket, int>, ITicketRepository
    {
        public TicketXmlRepository(string filePath) : base(filePath, new XmlConverter(), new IntIdGenerator())
        {
        }
    }
}