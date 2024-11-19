using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team
{
    class Magazine
    {
        private string? _name;
        private DateTime _dateOfPublicationMagazine;
        private int _magazineCirculation;
        private Article[] article;
        private readonly Frequency frequency;

        public double AverageRate
        {
            get
            {
                double avarageRate = 0;
                foreach (var item in article)
                {
                    avarageRate += item.Rate;
                }
                return avarageRate / article.Length;
            }
        }

        public bool this[Frequency index]
        {
            get
            {
                if (index == frequency)
                    return true;
                return false;
            }
        }

        public string Name
        {
            set
            {
                if (!string.IsNullOrEmpty(_name)) _name = value;
                else throw new ArgumentException("The provided name is either empty or uninitialized.", nameof(value));
            }
            get => _name ?? string.Empty;
        }

        public DateTime DateOfPublicationMagazine
        {
            set
            {
                if (value != default) _dateOfPublicationMagazine = value;
                else throw new ArgumentException("The provided date of publication is invalid.", nameof(value));
            }
            get => _dateOfPublicationMagazine;
        }

        public int MagazineCirculation
        {
            set
            {
                if (value > 0) _magazineCirculation = value;
                else throw new ArgumentException("The provided circulation of magazine cannot be a negative or equals zero", nameof(value));
            }
            get => _magazineCirculation;
        }

        public Frequency GetFrequency
        {
            get => frequency;
        }

        public Magazine(string name, DateTime dateOfPublicationMagazine, int magazineCirculation, Frequency frequency, Article[] articles)
        {
            Name = name;
            DateOfPublicationMagazine = dateOfPublicationMagazine;
            MagazineCirculation = magazineCirculation;
            this.frequency = frequency;
            article = articles;
        }

        public Magazine()
        {
            _name = "Model";
            _dateOfPublicationMagazine = DateTime.Today;
            _magazineCirculation = 10000;
            frequency = Frequency.Weekly;
            article = new Article[1];
        }

        public override string ToString()
        {
            string stringName = "";
            foreach (Article elem in article)
                stringName += elem.Title + " ";
            return ToShortString() +
                $"List of articles : {stringName}\n";
        }

        public virtual string ToShortString()
        {
            string stringRate = "";
            foreach (Article elem in article)
                stringRate += elem.Rate + " ";
            return $"Name of magazine: {_name}\n" +
                $"Date of publication: {_dateOfPublicationMagazine}\n" +
                $"Magazine circulation: {_magazineCirculation}\n" + stringRate;

        }

        public void AddArticles(params Article[] articles)
        {
            article = articles;
        }
    }
}

