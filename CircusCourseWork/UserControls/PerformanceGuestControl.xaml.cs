using CircusCourseWork.ViewModels;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.UserControls
{
    public partial class PerformanceGuestControl
    {
        private readonly PerformanceUserControlViewModel _viewModel = new();
        public PerformanceGuestControl(Performance performance)
        {
            _viewModel.Performance = performance;
            DataContext = _viewModel;
            InitializeComponent();
        }
    }
}