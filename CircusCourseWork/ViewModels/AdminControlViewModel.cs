using CircusCourseWork.ViewModels.Base;
using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.ViewModels
{
    public class AdminControlViewModel : ViewModel
    {
        public TicketCategoryInfo TicketCategoryInfo0 { get; set; }
        public TicketCategoryInfo TicketCategoryInfo1 { get; set; }
        public TicketCategoryInfo TicketCategoryInfo2 { get; set; }

        public string TciName0 => TicketCategoryInfo0.Name;
        public string TciName1 => TicketCategoryInfo1.Name;
        public string TciName2 => TicketCategoryInfo2.Name;

        public decimal TciPrice0
        {
            get => TicketCategoryInfo0.Price;
            set
            {
                TicketCategoryInfo0.Price = value;
                ValidateTicketCategoryInfos();
                OnPropertyChanged();
                OnErrorsChanged();
            }
        }
        
        public decimal TciPrice1
        {
            get => TicketCategoryInfo1.Price;
            set
            {
                TicketCategoryInfo1.Price = value;
                ValidateTicketCategoryInfos();
                OnPropertyChanged();
                OnErrorsChanged();
            }
        }
        public decimal TciPrice2
        {
            get => TicketCategoryInfo2.Price;
            set
            {
                TicketCategoryInfo2.Price = value;
                ValidateTicketCategoryInfos();
                OnPropertyChanged();
                OnErrorsChanged();
            }
        }

        private void ValidateTicketCategoryInfos()
        {
            ClearErrors(nameof(TciName0));
            ClearErrors(nameof(TciName1));
            ClearErrors(nameof(TciName2));
            ClearErrors(nameof(TciPrice0));
            ClearErrors(nameof(TciPrice1));
            ClearErrors(nameof(TciPrice2));
        }
    }
}