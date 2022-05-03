using System.Collections.Generic;
using System.Linq;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels.Base;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.ViewModels
{
    public class BuyTicketsWindowViewModel : ViewModel
    {
        private int _tciCount0;
        private int _tciCount1;
        private int _tciCount2;

        public Performance Performance { get; set; }

        public int TciCount0
        {
            get => _tciCount0;
            set
            {
                _tciCount0 = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Price));
            }
        }

        public int TciCount1
        {
            get => _tciCount1;
            set
            {
                _tciCount1 = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Price));
            }
        }

        public int TciCount2
        {
            get => _tciCount2;
            set
            {
                _tciCount2 = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Price));
            }
        }

        public int TciMaxCount0 => TicketCategoriesIdsForTickets.ElementAtOrDefault(0)?.Count(t => t.CustomerUserId is null) ?? 0;

        public int TciMaxCount1 => TicketCategoriesIdsForTickets.ElementAtOrDefault(1)?.Count(t => t.CustomerUserId is null) ?? 0;

        public int TciMaxCount2 =>
            TicketCategoriesIdsForTickets.ElementAtOrDefault(2)?.Count(t => t.CustomerUserId is null) ?? 0;

        public decimal Price
        {
            get
            {
                List<IGrouping<int, Ticket>> grouping = DalSingleton.Instance.TicketRepository.Read(
                    ).Where(t => t.PerformanceId == Performance.Id)
                    .GroupBy(t => t.TicketCategoryInfoId, t => t).ToList();

                Ticket t0;
                Ticket t1;
                Ticket t2;

                using (IEnumerator<Ticket> enumerator = grouping[0].GetEnumerator())
                {
                    enumerator.MoveNext();
                    t0 = enumerator.Current;
                }

                using (IEnumerator<Ticket> enumerator = grouping[1].GetEnumerator())
                {
                    enumerator.MoveNext();
                    t1 = enumerator.Current;
                }

                using (IEnumerator<Ticket> enumerator = grouping[2].GetEnumerator())
                {
                    enumerator.MoveNext();
                    t2 = enumerator.Current;
                }

                return t0.Price * TciCount0 +
                       t1.Price * TciCount1 +
                       t2.Price * TciCount2;
            }
        }

        private IEnumerable<IGrouping<int, Ticket>> TicketCategoriesIdsForTickets => DalSingleton.Instance
            .TicketRepository.Read()
            .Where(t => t.PerformanceId == Performance.Id)
            .GroupBy(t => t.TicketCategoryInfoId, t => t);
    }
}