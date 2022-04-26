using System;

namespace CircusDataAccessLibrary.Data
{
    public sealed class TicketCategoryInfo : BaseEntity<int>
    {
        public TicketCategoryInfo()
        {
            Name = string.Empty;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        private bool Equals(TicketCategoryInfo other)
        {
            return base.Equals(other) &&
                   Name == other.Name &&
                   Price == other.Price &&
                   Count == other.Count;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((TicketCategoryInfo) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name, Price, Count);
        }
    }
}