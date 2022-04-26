using System;

namespace CircusDataAccessLibrary.Data
{
    public sealed class User : BaseEntity<int>
    {
        public User()
        {
            
        }

        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        private bool Equals(User other)
        {
            return base.Equals(other) &&
                   Name == other.Name &&
                   Login == other.Login &&
                   Password == other.Password &&
                   RoleId == other.RoleId;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((User) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name, Login, Password, RoleId);
        }
    }
}