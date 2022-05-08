using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.Windows
{
    public partial class SortTicketsWindow
    {
        private SortTicketWindowViewModel _viewModel = new();
        public Func<Performance, bool>? SearchCondition;

        public SortTicketsWindow()
        {
            DataContext = _viewModel;
            InitializeComponent();
            SearchCriterionComboBox.SelectedIndex = 0;
        }

        private void ComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (SearchCriterionComboBox.SelectedIndex)
            {
                case 0:
                {
                    PerformanceNameTextBox.Visibility = Visibility.Visible;
                    PerformanceDatePicker.Visibility = Visibility.Collapsed;
                    TicketCategoryNumberComboBox.Visibility = Visibility.Collapsed;
                    break;
                }
                case 1:
                {
                    PerformanceNameTextBox.Visibility = Visibility.Collapsed;
                    PerformanceDatePicker.Visibility = Visibility.Visible;
                    TicketCategoryNumberComboBox.Visibility = Visibility.Collapsed;
                    break;
                }
                case 2:
                {
                    PerformanceNameTextBox.Visibility = Visibility.Collapsed;
                    PerformanceDatePicker.Visibility = Visibility.Collapsed;
                    TicketCategoryNumberComboBox.Visibility = Visibility.Visible;
                    break;
                }
            }
        }

        private void ButtonSearch_OnClick(object sender, RoutedEventArgs e)
        {
            SearchCondition = SearchCriterionComboBox.SelectedIndex switch
            {
                0 => p => p.Name.Contains(_viewModel.PerformanceName),
                1 => p => p.ShowDate == _viewModel.PerformanceDate,
                2 => p => DalSingleton.Instance.TicketRepository.Read()
                    .Any(t => t.PerformanceId == p.Id && t.CustomerUserId == null &&
                              t.TicketCategoryInfoId == _viewModel.Tci.Id),
                _ => null
            };

            DialogResult = true;
            Close();
        }
    }
}