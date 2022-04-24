using System;

namespace CircusDataAccessLibrary.Data
{
    public sealed class TicketCategoryInfo : BaseEntity<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public TicketCategoryInfo(int id,
                                  string name, 
                                  decimal price, 
                                  int count) : base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Count = count;
        }

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
            return obj.GetType() == this.GetType() && Equals((TicketCategoryInfo) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name, Price, Count);
        }
    }
}