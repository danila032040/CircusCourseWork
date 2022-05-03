using System;
using System.Linq;
using System.Windows;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.UserControls
{
    public partial class EditablePerformanceControl
    {
        private readonly EditablePerformanceControlViewModel _viewModel = new();

        public event Action? Delete;

        public EditablePerformanceControl(Performance performance)
        {
            _viewModel.Performance = performance;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (DalSingleton.Instance.PerformanceRepository.Read()
                .Any(p => p.Id != _viewModel.Performance.Id && p.ShowDate.Date == _viewModel.Performance.ShowDate.Date))
            {
                MessageBox.Show("В этот день уже идет другое представление!!!");
                return;
            }

            if (MessageBox.Show("Цены на билеты останутся такими же, какими были при создании представления!!!",
                    "Внимание!!!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                DalSingleton.Instance.PerformanceRepository.Update(_viewModel.Performance);
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Будут удалены так же все билеты на это представление!!!", "Внимание!!!",
                    MessageBoxButton.OKCancel) != MessageBoxResult.OK) return;
            
            foreach (Ticket ticket in DalSingleton.Instance.TicketRepository.Read()
                         .Where(t => t.PerformanceId == _viewModel.Performance.Id))
                DalSingleton.Instance.TicketRepository.Delete(ticket.Id);

            DalSingleton.Instance.PerformanceRepository.Delete(_viewModel.Performance.Id);

            Delete?.Invoke();
        }
    }
}