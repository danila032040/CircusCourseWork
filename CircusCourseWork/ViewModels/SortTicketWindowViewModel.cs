using System;
using System.Linq;
using CircusCourseWork.Services;
using CircusCourseWork.ViewModels.Base;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.ViewModels
{
    public class SortTicketWindowViewModel : ViewModel
    {
        private string _performanceName;
        private DateTime _performanceDate;
        
        public TicketCategoryInfo Tci { get; set; }

        public SortTicketWindowViewModel()
        {
            _performanceName = string.Empty;
            _performanceDate = DateTime.Now;
            Tci = DalSingleton.Instance.TicketCategoryInfoRepository.Read().First();
        }

        public string PerformanceName
        {
            get => _performanceName;
            set
            {
                _performanceName = value; 
                OnPropertyChanged();
                OnErrorsChanged();
            }
        }

        public DateTime PerformanceDate
        {
            get => _performanceDate;
            set
            {
                _performanceDate = value; 
                OnPropertyChanged();
                OnErrorsChanged();
            }
        }
        
        public int TicketCategoryNumber
        {
            get => DalSingleton.Instance.TicketCategoryInfoRepository.Read().FindIndex(tci=>tci.Id == Tci.Id);
            set
            {
                Tci = DalSingleton.Instance.TicketCategoryInfoRepository.Read().ElementAt(value); 
                OnPropertyChanged();
                OnErrorsChanged();
            }
        }
    }
}