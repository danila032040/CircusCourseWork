using System;
using System.Collections.Generic;
using System.Linq;

namespace CircusDataAccessLibrary.Data
{
    public sealed class Circus : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<int> TicketCategoryInfoIds { get; }

        public Circus(int id,
                      string name,
                      List<int> ticketCategoryInfoIds) : base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            TicketCategoryInfoIds = ticketCategoryInfoIds ?? throw new ArgumentNullException(nameof(ticketCategoryInfoIds));
        }

        private bool Equals(Circus other)
        {
            return base.Equals(other) &&
                   Name == other.Name &&
                   TicketCategoryInfoIds.SequenceEqual(other.TicketCategoryInfoIds);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Circus) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name, TicketCategoryInfoIds);
        }
    }
}