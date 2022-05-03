using System.Collections.Generic;
using System.Linq;
using System.Windows;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.UserControls
{
    public partial class AdminControl
    {
        private readonly AdminControlViewModel _viewModel = new();

        public AdminControl()
        {
            List<TicketCategoryInfo> tci = DalSingleton.Instance.TicketCategoryInfoRepository.Read();
            _viewModel.TicketCategoryInfo0 = tci[0];
            _viewModel.TicketCategoryInfo1 = tci[1];
            _viewModel.TicketCategoryInfo2 = tci[2];
            DataContext = _viewModel;
            InitializeComponent();

            RefreshPerformanceStackPanel();
            RefreshReportsStackPanel();
            RefreshUsersStackPanel();
        }


        private void ButtonSaveTci_OnClick(object sender, RoutedEventArgs e)
        {
            DalSingleton.Instance.TicketCategoryInfoRepository.Update(_viewModel.TicketCategoryInfo0);
            DalSingleton.Instance.TicketCategoryInfoRepository.Update(_viewModel.TicketCategoryInfo1);
            DalSingleton.Instance.TicketCategoryInfoRepository.Update(_viewModel.TicketCategoryInfo2);
        }

        private void ButtonAddPerformance_OnClick(object sender, RoutedEventArgs e)
        {
            var performance = new Performance();
            DalSingleton.Instance.PerformanceRepository.Create(performance);
            foreach (TicketCategoryInfo tci in DalSingleton.Instance.TicketCategoryInfoRepository.Read())
            {
                for (int i = 0; i < tci.Count; ++i)
                    DalSingleton.Instance.TicketRepository.Create(new Ticket
                    {
                        PerformanceId = performance.Id,
                        TicketCategoryInfoId = tci.Id,
                        Price = tci.Price
                    });
            }

            RefreshPerformanceStackPanel();
        }

        private void RefreshPerformanceStackPanel()
        {
            PerformanceStackPanel.Children.Clear();
            foreach (EditablePerformanceControl? epc in DalSingleton.Instance.PerformanceRepository.Read()
                         .Select(p => new EditablePerformanceControl(p)))
            {
                epc.Delete += RefreshPerformanceStackPanel;
                PerformanceStackPanel.Children.Add(epc);
            }
        }

        private void RefreshUsersStackPanel()
        {
            UserStackPanel.Children.Clear();
            Role adminRole = DalSingleton.Instance.RoleRepository.Read().First(r => r.Name == "Admin");
            foreach (EditableUserControl? euc in DalSingleton.Instance.UserRepository.Read()
                         .Where(user => user.RoleId != adminRole.Id).Select(user => new EditableUserControl(user)))
            {
                euc.Delete += RefreshUsersStackPanel;
                UserStackPanel.Children.Add(euc);
            }
        }

        private void RefreshReportsStackPanel()
        {
            ReportsStackPanel.Children.Clear();
            foreach (ReportControl? rc in DalSingleton.Instance.PerformanceRepository.Read()
                         .Select(performance => new ReportControl(performance)))
                ReportsStackPanel.Children.Add(rc);
        }

        private void PerformanceTabItem_OnSelected(object sender, RoutedEventArgs e)
        {
            RefreshPerformanceStackPanel();
        }

        private void UserTabItem_OnSelected(object sender, RoutedEventArgs e)
        {
            RefreshUsersStackPanel();
        }

        private void ReportsTabItem_OnSelected(object sender, RoutedEventArgs e)
        {
            RefreshReportsStackPanel();
        }
    }
}