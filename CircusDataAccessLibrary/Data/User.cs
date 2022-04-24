using System;

namespace CircusDataAccessLibrary.Data
{
    public sealed class User : BaseEntity<int>
    {
        public string Name { get; }
        public string Login { get; }
        public string Password { get; }
        public Role Role { get; }

        public User(int id,
                    string name,
                    string login,
                    string password,
                    Role role) : base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Role = role ?? throw new ArgumentNullException(nameof(role));
        }

        private bool Equals(User other)
        {
            return base.Equals(other) &&
                   Name == other.Name &&
                   Login == other.Login &&
                   Password == other.Password &&
                   Role.Equals(other.Role);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((User) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name, Login, Password, Role);
        }
    }
}