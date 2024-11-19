namespace Team
{
    class Article
    {
        private Person author;
        private string title;
        private double rate;

        public Article()
        {
            author = new Person("Arseniy", "Serzhan", new DateTime(2006, 11, 14));
            title = "Minecumph";
            rate = 10;
        }

        public Article(Person _author, string _title, double _rate)
        {
            author = _author;
            title = _title;
            rate = _rate;
        }

        public override string ToString() { return $"Author - {author}, title of the book - {title},rating of the book - {rate}"; }

        public Person Author
        {
            get => author;
            set
            {
                if (value != null) author = value;
                else throw new ArgumentException("The provide author is equals NULL");
            }
        }

        public string Title
        {
            get => title;
            set
            {
                if (!string.IsNullOrEmpty(value)) title = value;
                else throw new ArgumentException("The provide author is equals NULL");
            }
        }

        public double Rate
        {
            get => rate;
            set
            {
                if (value >= 0 && value < 11) rate = value;
                else throw new ArgumentException("The provide rating is lower then 0");
            }
        }


    }
}
