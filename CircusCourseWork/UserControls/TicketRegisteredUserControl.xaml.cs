using System;
using System.Linq;
using System.Windows;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.UserControls
{
    public partial class TicketRegisteredUserControl
    {
        private readonly TicketRegisteredUserControlViewModel _viewModel = new();
        public event Action? Delete;
        public TicketRegisteredUserControl(Performance performance)
        {
            _viewModel.Performance = performance;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Будут удалены все билеты на представление", "Внимание", MessageBoxButton.OKCancel) !=
                MessageBoxResult.OK) return;
            foreach (Ticket ticket in DalSingleton.Instance.TicketRepository.Read()
                         .Where(t => t.PerformanceId == _viewModel.Performance.Id))
            {
                ticket.CustomerUserId = null;
                DalSingleton.Instance.TicketRepository.Update(ticket);
            }

            Delete?.Invoke();
        }
    }
}