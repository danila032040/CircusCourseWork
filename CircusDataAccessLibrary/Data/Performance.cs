using System;

namespace CircusDataAccessLibrary.Data
{
    public class Performance : BaseEntity<int>
    {
        public Performance()
        {
            Name = string.Empty;
            Slogan = string.Empty;
            ShowDate = DateTime.Now;
        }

        public string Name { get; set; }
        public DateTime ShowDate { get; set; }
        public string Slogan { get; set; }

        private bool Equals(Performance other)
        {
            return base.Equals(other) &&
                   Name == other.Name &&
                   ShowDate.Equals(other.ShowDate) &&
                   Slogan == other.Slogan;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Performance) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name, ShowDate, Slogan);
        }
    }
}