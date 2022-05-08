using System;
using System.Linq;
using System.Windows;
using CircusCourseWork.Services;
using CircusCourseWork.Windows;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.UserControls
{
    public partial class RegisteredUserControl
    {
        private Func<Performance, bool>? _isInWhere;

        public RegisteredUserControl()
        {
            InitializeComponent();
        }

        private void TicketsTabItem_OnSelected(object sender, RoutedEventArgs e)
        {
            RefreshTicketsStackPanel();
        }

        private void PerformanceTabItem_OnSelected(object sender, RoutedEventArgs e)
        {
            RefreshPerformanceStackPanel();
        }


        private void RefreshTicketsStackPanel()
        {
            TicketsStackPanel.Children.Clear();
            foreach (TicketRegisteredUserControl? truc in DalSingleton.Instance.PerformanceRepository.Read()
                         .Where(performance => DalSingleton.Instance
                             .TicketRepository.Read()
                             .Any(t => t.PerformanceId == performance.Id &&
                                       t.CustomerUserId == DalSingleton.Instance.Auth.SignedInUser?.Id))
                         .Select(performance => new TicketRegisteredUserControl(performance)))
            {
                truc.Delete += RefreshTicketsStackPanel;
                TicketsStackPanel.Children.Add(truc);
            }
        }

        private void RefreshPerformanceStackPanel()
        {
            PerformanceStackPanel.Children.Clear();
            foreach (Performance performance in DalSingleton.Instance.PerformanceRepository.Read()
                         .Where(performance => _isInWhere is null || _isInWhere(performance)))
                PerformanceStackPanel.Children.Add(new PerformanceRegisteredUserControl(performance));
        }

        private void ButtonRemoveSearch_OnClick(object sender, RoutedEventArgs e)
        {
            _isInWhere = null;
            ButtonSearch.IsEnabled = true;
            ButtonRemoveSearch.IsEnabled = false;
            RefreshPerformanceStackPanel();
        }

        private void ButtonSearch_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new SortTicketsWindow();
            window.Owner = Application.Current.MainWindow;
            if (window.ShowDialog() != true) return;

            _isInWhere = window.SearchCondition;
            ButtonSearch.IsEnabled = false;
            ButtonRemoveSearch.IsEnabled = true;
            RefreshPerformanceStackPanel();
        }
    }
}