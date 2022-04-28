using System;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.UserControls
{
    public partial class EditableUserControl
    {
        public event Action Banned;
        public EditableUserControl(User user)
        {
            InitializeComponent();
        }
    }
}