using System.Collections.Generic;
using System.Linq;
using System.Windows;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.Windows
{
    public partial class BuyTicketsWindow
    {
        private readonly BuyTicketsWindowViewModel _viewModel = new();
        public BuyTicketsWindow(Performance performance)
        {
            _viewModel.Performance = performance;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void ButtonBuy_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            User? user = DalSingleton.Instance.Auth.SignedInUser;
            List<IGrouping<int, Ticket>> grouping = DalSingleton.Instance.TicketRepository.Read()
                .Where(t => t.PerformanceId == _viewModel.Performance.Id)
                .GroupBy(t => t.TicketCategoryInfoId, t => t).ToList();

            foreach (Ticket ticket in grouping[0])
            {
                if (ticket.CustomerUserId != null) continue;
                if (_viewModel.TciCount0 == 0) break;
                ticket.CustomerUserId = user?.Id;
                DalSingleton.Instance.TicketRepository.Update(ticket);

                _viewModel.TciCount0--;
            }
            
            foreach (Ticket ticket in grouping[1])
            {
                if (ticket.CustomerUserId != null) continue;
                if (_viewModel.TciCount1 == 0) break;
                ticket.CustomerUserId = user?.Id;
                DalSingleton.Instance.TicketRepository.Update(ticket);

                _viewModel.TciCount1--;
            }
            
            foreach (Ticket ticket in grouping[2])
            {
                if (ticket.CustomerUserId != null) continue;
                if (_viewModel.TciCount2 == 0) break;
                ticket.CustomerUserId = user?.Id;
                DalSingleton.Instance.TicketRepository.Update(ticket);

                _viewModel.TciCount2--;
            }
            
            Close();
        }
    }
}