using System.Windows;
using CircusCourseWork.ViewModels;
using CircusCourseWork.Windows;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.UserControls
{
    public partial class PerformanceRegisteredUserControl
    {
        private readonly PerformanceUserControlViewModel _viewModel=new();
        public PerformanceRegisteredUserControl(Performance performance)
        {
            _viewModel.Performance = performance;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void ButtonBuy_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new BuyTicketsWindow(_viewModel.Performance);
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
        }
    }
}