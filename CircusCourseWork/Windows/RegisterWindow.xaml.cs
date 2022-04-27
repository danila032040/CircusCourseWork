using CircusCourseWork.ViewModels;

namespace CircusCourseWork.Windows
{
    public partial class RegisterWindow
    {
        private readonly RegisterViewModel _viewModel = new();
        public RegisterWindow()
        {
            DataContext = _viewModel;
            InitializeComponent();
        }
    }
}