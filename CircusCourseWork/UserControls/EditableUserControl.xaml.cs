using System;
using System.Linq;
using System.Windows;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.UserControls
{
    public partial class EditableUserControl
    {
        private readonly EditableUserControlViewModel _viewModel=new();
        public event Action? Delete;
        public EditableUserControl(User user)
        {
            _viewModel.User = user;
            DataContext = _viewModel;
            
            InitializeComponent();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Будут удалены все когда-либо купленные билеты удаляемого пользователя", "Внимание",
                    MessageBoxButton.OKCancel) != MessageBoxResult.OK) return;
            foreach (Ticket ticket in DalSingleton.Instance.TicketRepository.Read().Where(ticket => ticket.CustomerUserId == _viewModel.User.Id))
            {
                ticket.CustomerUserId = null;
                DalSingleton.Instance.TicketRepository.Update(ticket);
            }

            DalSingleton.Instance.UserRepository.Delete(_viewModel.User.Id);
            Delete?.Invoke();
        }
    }
}