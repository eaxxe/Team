using System;

namespace Team
{
    public class Edition
    {
        protected string nameOfProduct;
        private DateTime date;
        private int tirazh;

        public Edition() { }

        public Edition(string nameOfProduct, DateTime date, int tirazh)
        {
            this.nameOfProduct = nameOfProduct;
            this.date = date;
            this.tirazh = tirazh;
        }

        public string NameOfProduct
        {
            get { return nameOfProduct; }
            set { nameOfProduct = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int Tirazh
        {
            get { return tirazh; }
            set
            {
                if (value < 0) throw new ArgumentException("Передаваемый аргумент меньше 0");
                tirazh = value;
            }
        }

        public virtual object DeepCopy()
        {
            return new Edition(nameOfProduct, date, tirazh);
        }

        public override string ToString()
        {
            return $"Название продукта: {nameOfProduct}, дата выхода: {date}, тираж издания: {tirazh}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Edition other = (Edition)obj;
            return nameOfProduct == other.nameOfProduct && date == other.date && tirazh == other.tirazh;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(nameOfProduct, date, tirazh);
        }

        public static bool operator ==(Edition lhs, Edition rhs)
        {
            if (ReferenceEquals(lhs, null))
                return ReferenceEquals(rhs, null);
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Edition lhs, Edition rhs)
        {
            return !(lhs == rhs);
        }
    }
}
