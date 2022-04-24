namespace CircusDataAccessLibrary.Data
{
    public abstract class BaseEntity<T> 
        where T : struct
    {
        public T Id { get; set; }

        protected BaseEntity(T id)
        {
            Id = id;
        }

        protected bool Equals(BaseEntity<T> other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((BaseEntity<T>) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}