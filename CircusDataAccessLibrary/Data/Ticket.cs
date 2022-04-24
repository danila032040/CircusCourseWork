using System;

namespace CircusDataAccessLibrary.Data
{
    public sealed class Ticket : BaseEntity<int>
    {
        public Ticket(int id, int performanceId, int userId, int ticketCategoryInfoId) : base(id)
        {
            PerformanceId = performanceId;
            UserId = userId;
            TicketCategoryInfoId = ticketCategoryInfoId;
        }

        public int PerformanceId { get; set; }
        public int UserId { get; set; }
        public int TicketCategoryInfoId { get; set; }

        private bool Equals(Ticket other)
        {
            return base.Equals(other) &&
                   PerformanceId == other.PerformanceId &&
                   UserId == other.UserId &&
                   TicketCategoryInfoId == other.TicketCategoryInfoId;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Ticket) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), PerformanceId, UserId, TicketCategoryInfoId);
        }
    }
}