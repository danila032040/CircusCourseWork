using CircusDataAccessLibrary.Data;

namespace CircusCourseWork.ViewModels
{
    public class PerformanceUserControlViewModel
    {
        public Performance Performance { get; set; }
        public string PerformanceName => Performance.Name;
        public string PerformanceShowDate => Performance.ShowDate.ToShortDateString();
        public string PerformanceSlogan => Performance.Slogan;
    }
}