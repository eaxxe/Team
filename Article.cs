using System;

namespace Team
{
    public class Article : IRateAndCopy
    {
        public Person author { get; set; }
        public string title { get; set; }
        public double rate { get; set; }

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

        public override string ToString()
        {
            return $"Author - {author}, title of the book - {title}, rating of the book - {rate}";
        }

        public Person Author
        {
            get => author;
            set
            {
                if (value != null) author = value;
                else throw new ArgumentException("The provided author is NULL");
            }
        }

        public string Title
        {
            get => title;
            set
            {
                if (!string.IsNullOrEmpty(value)) title = value;
                else throw new ArgumentException("The provided title is NULL");
            }
        }

        public double Rate
        {
            get => rate;
            set
            {
                if (value >= 0 && value < 11) rate = value;
                else throw new ArgumentException("The provided rating is invalid");
            }
        }

        public virtual object DeepCopy()
        {
            return new Article(author, title, rate);
        }

        public double Rating
        {
            get { return rate; }
        }
    }
}
