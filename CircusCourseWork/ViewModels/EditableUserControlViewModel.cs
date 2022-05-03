using CircusCourseWork.ViewModels.Base;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.ViewModels
{
    public class EditableUserControlViewModel : ViewModel
    {
        public string UserName => User.Name;

        public User User { get; set; }
    }
}