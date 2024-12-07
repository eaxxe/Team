namespace Team
{
    class Edition
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
            set {  date = value; }
        }   
        public int Tirazh
        {
            get { return tirazh; }
       
            set {
                if (value < 0) throw new ArgumentException("Передоваемый аргумент меньше 0");
                    tirazh = value; 
            }
        }

        public virtual object DeepCopy()
        {
            return new Edition(nameOfProduct, date, tirazh);
        }

        public override string ToString()
        {
            return $"Название продукта: {nameOfProduct},дата выхода: {date},тираж издания: {tirazh}";
        }

        public virtual bool Equals(object other)
        {
            if (other == null) return false;
            else
            {
                Edition edition = other as Edition;
                if (edition.nameOfProduct == nameOfProduct && edition.tirazh == tirazh && edition.date == date) return true;
                return false;
            }
        }

        public static bool operator ==(Edition edition1, Edition edition2) { return edition1.Equals(edition2); }
        public static bool operator !=(Edition edition1, Edition edition2) { return edition1.Equals(edition2); }
        public override int GetHashCode()
        {
            int hash = 52;
            hash = (hash * 69) + nameOfProduct.GetHashCode();
            hash = (hash * 69) + tirazh.GetHashCode();
            hash = (hash * 69) + date.GetHashCode();
            return hash;
        }
    }
}
