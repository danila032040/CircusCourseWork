using System;
using System.Linq;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels.Base;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.ViewModels
{
    public class EditablePerformanceControlViewModel : ViewModel
    {
        public Performance Performance { get; set; }


        public string Name
        {
            get => Performance.Name;
            set
            {
                Performance.Name = value;

                ValidatePerformance();
                OnPropertyChanged();
                OnErrorsChanged();
            }
        }

        public string Slogan
        {
            get => Performance.Slogan;
            set
            {
                Performance.Slogan = value;

                ValidatePerformance();
                OnPropertyChanged();
                OnErrorsChanged();
            }
        }

        public DateTime ShowDate
        {
            get => Performance.ShowDate;
            set
            {
                Performance.ShowDate = value;

                ValidatePerformance();
                OnPropertyChanged();
                OnErrorsChanged();
            }
        }

        private void ValidatePerformance()
        {
            ClearErrors(nameof(Name));
            ClearErrors(nameof(Slogan));
            ClearErrors(nameof(ShowDate));
            if (string.IsNullOrEmpty(Name)) AddError(new Error($"{nameof(Name)} can`t be empty"), nameof(Name));
            if (string.IsNullOrEmpty(Slogan)) AddError(new Error($"{nameof(Slogan)} can`t be empty"), nameof(Slogan));
            if (DalSingleton.Instance.PerformanceRepository.Read()
                .Any(p => p.Id != Performance.Id && p.ShowDate.Date == ShowDate.Date))
                AddError(new Error($"{nameof(ShowDate)} is already used by another Performance"), nameof(ShowDate));
        }
    }
}