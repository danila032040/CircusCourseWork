using System;

namespace CircusDataAccessLibrary.Data
{
    public class Performance : BaseEntity<int>
    {
        public string Name { get; set;  }
        public DateTime ShowDate { get; set; }
        public string Slogan { get; set; }

        public Performance(int id,
                           string name,  
                           string slogan,
                           DateTime showDate) : base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Slogan = slogan ?? throw new ArgumentNullException(nameof(slogan));
            ShowDate = showDate;
        }

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
            return obj.GetType() == this.GetType() && Equals((Performance) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name, ShowDate, Slogan);
        }
    }
}