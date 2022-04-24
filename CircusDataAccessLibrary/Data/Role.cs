using System;

namespace CircusDataAccessLibrary.Data
{
    public sealed class Role : BaseEntity<int>
    {
        public string Name { get; set; }

        public Role(int id,
                    string name) : base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        private bool Equals(Role other)
        {
            return base.Equals(other) &&
                   Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Role) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name);
        }
    }
}