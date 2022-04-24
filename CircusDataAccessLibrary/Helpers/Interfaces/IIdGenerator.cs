namespace CircusDataAccessLibrary.Helpers.Interfaces
{
    public interface IIdGenerator<out TId> 
        where TId : struct
    {
        public TId Next();
    }
}