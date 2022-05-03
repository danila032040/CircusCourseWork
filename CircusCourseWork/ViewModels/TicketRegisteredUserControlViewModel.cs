using System.Collections.Generic;
using System.Linq;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels.Base;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.ViewModels
{
    public class TicketRegisteredUserControlViewModel :ViewModel
    {
        public Performance Performance { get; set; }

        public int TciCount0 => TicketCategoriesIdsForBoughtTickets.ElementAtOrDefault(0)?.Count() ?? 0;

        public int TciCount1 => TicketCategoriesIdsForBoughtTickets.ElementAtOrDefault(1)?.Count() ?? 0;

        public int TciCount2 => TicketCategoriesIdsForBoughtTickets.ElementAtOrDefault(2)?.Count() ?? 0;

        public decimal Price
        {
            get
            {
                IEnumerable<decimal> grouping = DalSingleton.Instance.TicketRepository.Read(
                    ).Where(t => t.PerformanceId == Performance.Id)
                    .GroupBy(t => new
                    {
                        t.TicketCategoryInfoId,
                        t.Price
                    }).Select(t => t.Key.Price);
                return grouping.ElementAt(0) * TciCount0 +
                       grouping.ElementAt(1) * TciCount1 +
                       grouping.ElementAt(2) * TciCount2;
            }
        }
        
        private IEnumerable<IGrouping<int, Ticket>> TicketCategoriesIdsForBoughtTickets => DalSingleton.Instance
            .TicketRepository.Read()
            .Where(t => t.PerformanceId == Performance.Id && t.CustomerUserId == DalSingleton.Instance.Auth.SignedInUser?.Id)
            .GroupBy(t => t.TicketCategoryInfoId);
    }
}