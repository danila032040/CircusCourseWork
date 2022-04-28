using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.UserControls
{
    public partial class AdminControl : UserControl
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
            throw new System.NotImplementedException();
        }

        private void RefreshPerformanceStackPanel()
        {
            PerformanceStackPanel.Children.Clear();
            foreach (Performance performance in DalSingleton.Instance.PerformanceRepository.Read())
            {
                var sp = new StackPanel();
                var delete = new Button
                             {
                                 Content = "X",
                                 DataContext = performance
                             };
                delete.Click += (s, e) =>
                                {
                                    DalSingleton.Instance.PerformanceRepository.Delete(performance.Id);
                                    RefreshPerformanceStackPanel();
                                };

                sp.Children.Add(new EditablePerformance(performance));
                sp.Children.Add(delete);
                PerformanceStackPanel.Children.Add(sp);
            }
        }

        private void RefreshUsersStackPanel()
        {
        }

        private void RefreshReportsStackPanel()
        {
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