using System.Linq;
using System.Windows;
using CircusCourseWork.Services;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.UserControls
{
    public partial class RegisteredUserControl
    {
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
                         .Where(performance => DalSingleton.Instance.TicketRepository.Read()
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
            foreach (Performance performance in DalSingleton.Instance.PerformanceRepository.Read())
                PerformanceStackPanel.Children.Add(new PerformanceRegisteredUserControl(performance));
        }
    }
}