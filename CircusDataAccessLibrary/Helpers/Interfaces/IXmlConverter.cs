namespace CircusDataAccessLibrary.Helpers.Interfaces
{
    public interface IXmlConverter
    {
        string ConvertToXml<T>(T obj);
        T? ConvertFromXml<T>(string xml);
    }
}