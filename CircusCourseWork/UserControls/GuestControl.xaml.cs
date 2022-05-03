using CircusCourseWork.Services;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.UserControls
{
    public partial class GuestControl
    {
        public GuestControl()
        {
            InitializeComponent();
            RefreshPerformanceStackPanel();
        }

        private void RefreshPerformanceStackPanel()
        {
            PerformanceStackPanel.Children.Clear();
            foreach (Performance performance in DalSingleton.Instance.PerformanceRepository.Read())
                PerformanceStackPanel.Children.Add(new PerformanceGuestControl(performance));
        }
    }
}