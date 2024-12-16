using System;
using System.Collections;

namespace Team
{
    public class Magazine : Edition, IRateAndCopy
    {
        private Frequency frequency;
        private ArrayList editors;
        private ArrayList articles;

        public Magazine(string name, DateTime dateOfPublication, int tirazh, Frequency frequency)
            : base(name, dateOfPublication, tirazh)
        {
            this.frequency = frequency;
            editors = new ArrayList();
            articles = new ArrayList();
        }

        public Magazine() : base("Default", DateTime.Today, 10000)
        {
            frequency = Frequency.Weekly;
            editors = new ArrayList();
            articles = new ArrayList();
        }

        public double Rating
        {
            get
            {
                if (articles.Count == 0) return 0;
                double totalRate = 0;
                foreach (Article article in articles)
                {
                    totalRate += article.Rating;
                }
                return totalRate / articles.Count;
            }
        }

        public ArrayList Articles
        {
            get { return articles; }
        }

        public ArrayList Editors
        {
            get { return editors; }
        }

        public void AddArticles(params Article[] newArticles)
        {
            articles.AddRange(newArticles);
        }

        public void AddEditors(params Person[] newEditors)
        {
            editors.AddRange(newEditors);
        }

        public override string ToString()
        {
            string articlesList = "";
            foreach (Article article in articles)
                articlesList += article + "\n";

            string editorsList = "";
            foreach (Person editor in editors)
                editorsList += editor + "\n";

            return base.ToString() +
                   $"\nПериодичность: {frequency}\nСредний рейтинг статей: {Rating}\n" +
                   $"Список статей:\n{articlesList}\nСписок редакторов:\n{editorsList}";
        }

        public string ToShortString()
        {
            return base.ToString() + $"\nПериодичность: {frequency}\nСредний рейтинг статей: {Rating}\n";
        }

        public override object DeepCopy()
        {
            Magazine copy = new Magazine(NameOfProduct, Date, Tirazh, frequency);
            foreach (Person editor in editors)
                copy.AddEditors((Person)editor.DeepCopy());
            foreach (Article article in articles)
                copy.AddArticles((Article)article.DeepCopy());
            return copy;
        }

        public Edition Edition
        {
            get { return new Edition(NameOfProduct, Date, Tirazh); }
            set
            {
                NameOfProduct = value.NameOfProduct;
                Date = value.Date;
                Tirazh = value.Tirazh;
            }
        }

        public IEnumerable ArticlesWithRatingAbove(double rating)
        {
            foreach (Article article in articles)
            {
                if (article.Rating > rating)
                    yield return article;
            }
        }

        public IEnumerable ArticlesWithTitleContaining(string keyword)
        {
            foreach (Article article in articles)
            {
                if (article.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    yield return article;
            }
        }
    }
}
