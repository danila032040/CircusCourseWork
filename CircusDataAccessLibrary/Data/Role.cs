using System;

namespace CircusDataAccessLibrary.Data
{
    public sealed class Role : BaseEntity<int>
    {
        public Role()
        {
        }

        public string Name { get; set; }

        private bool Equals(Role other)
        {
            return base.Equals(other) &&
                   Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Role) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name);
        }
    }
}