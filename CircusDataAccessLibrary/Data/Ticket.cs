using System;

namespace CircusDataAccessLibrary.Data
{
    public sealed class Ticket : BaseEntity<int>
    {
        public int PerformanceId { get; set; }
        public int TicketCategoryInfoId { get; set; }
        public int? CustomerUserId { get; set; }
        public decimal Price { get; set; }

        private bool Equals(Ticket other)
        {
            return base.Equals(other) &&
                   PerformanceId == other.PerformanceId &&
                   TicketCategoryInfoId == other.TicketCategoryInfoId &&
                   CustomerUserId == other.CustomerUserId &&
                   Price == other.Price;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Ticket) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), PerformanceId, TicketCategoryInfoId, CustomerUserId, Price);
        }
    }
}