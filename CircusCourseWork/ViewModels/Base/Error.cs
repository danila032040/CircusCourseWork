namespace CircusCourseWork.ViewModels.Base
{
    public class Error
    {
        public string Message { get; init; }

        public Error()
        {
            Message = string.Empty;
        }

        public Error(string message)
        {
            Message = message;
        }
    }
}