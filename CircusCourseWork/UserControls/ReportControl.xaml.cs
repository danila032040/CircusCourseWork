using CircusCourseWork.ViewModels;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.UserControls
{
    public partial class ReportControl
    {
        private ReportControlViewModel _viewModel = new();
        public ReportControl(Performance performance)
        {
            _viewModel.Performance = performance;
            DataContext = _viewModel;
            InitializeComponent();
        }
    }
}