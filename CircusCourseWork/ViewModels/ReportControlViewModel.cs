using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CircusCourseWork.Services;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.ViewModels
{
    public class ReportControlViewModel
    {
        public Performance Performance { get; set; }

        public string PerformanceName => Performance.Name;
        public string PerformanceShowDate => Performance.ShowDate.ToShortDateString();

        public string BoughtTicketsCount0
        {
            get
            {
                int tciId = DalSingleton.Instance.TicketCategoryInfoRepository.Read()[0].Id;
                return
                    $"{GetBoughtTickets(Performance.Id, tciId).Count.ToString()}/{GetTickets(Performance.Id, tciId).Count.ToString()}";
            }
        }

        public string BoughtTicketsCount1
        {
            get
            {
                int tciId = DalSingleton.Instance.TicketCategoryInfoRepository.Read()[1].Id;
                return
                    $"{GetBoughtTickets(Performance.Id, tciId).Count.ToString()}/{GetTickets(Performance.Id, tciId).Count.ToString()}";
            }
        }

        public string BoughtTicketsCount2
        {
            get
            {
                int tciId = DalSingleton.Instance.TicketCategoryInfoRepository.Read()[2].Id;
                return
                    $"{GetBoughtTickets(Performance.Id, tciId).Count.ToString()}/{GetTickets(Performance.Id, tciId).Count.ToString()}";
            }
        }

        public string Profit =>
            $"{DalSingleton.Instance.TicketRepository.Read().Where(t => t.PerformanceId == Performance.Id && t.CustomerUserId != null).Sum(t => t.Price).ToString()} б.р.";

        private List<Ticket> GetTickets(int performanceId, int ticketCategoryInfoId)
        {
            return DalSingleton.Instance.TicketRepository.Read().Where(t =>
                t.PerformanceId == performanceId && t.TicketCategoryInfoId == ticketCategoryInfoId).ToList();
        }

        private List<Ticket> GetBoughtTickets(int performanceId, int ticketCategoryInfoId)
        {
            return DalSingleton.Instance.TicketRepository.Read().Where(t =>
                t.PerformanceId == performanceId && t.TicketCategoryInfoId == ticketCategoryInfoId &&
                t.CustomerUserId != null).ToList();
        }
    }
}