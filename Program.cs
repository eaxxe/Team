using System;
using Team;

class Program
{
    static void Main(string[] args)
    {
        Edition edition1 = new Edition("The Example", new DateTime(2024, 12, 1), 1000);
        Edition edition2 = new Edition("The Example", new DateTime(2024, 12, 1), 1000);

        Console.WriteLine($"edition1 == edition2: {edition1 == edition2}");
        Console.WriteLine($"ReferenceEquals(edition1, edition2): {ReferenceEquals(edition1, edition2)}");
        Console.WriteLine($"Hash code edition1: {edition1.GetHashCode()}");
        Console.WriteLine($"Hash code edition2: {edition2.GetHashCode()}");

        try
        {
            edition1.Tirazh = -500;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }

        Article[] articles = new Article[]
        {
            new Article(new Person("Arseniy", "Serzhan", new DateTime(2006, 11, 14)), "Minecumph", 10),
            new Article(new Person("Arseniy", "Goids", new DateTime(2007, 1, 14)), "SDF", 10.0),
            new Article(new Person("Valera", "Goids", new DateTime(2002, 12, 11)), "SDF", 7.0)
        };

        Magazine magazine = new Magazine("Tech Today", DateTime.Now, 5000, Frequency.Monthly);
        magazine.AddArticles(articles);

        Person[] editors = new Person[]
        {
            new Person("John", "Doe", new DateTime(1980, 5, 10)),
            new Person("Jane", "Smith", new DateTime(1985, 8, 22))
        };

        magazine.AddEditors(editors);

        Console.WriteLine(magazine.ToString());

        Console.WriteLine(magazine.Edition);

        Magazine magazineCopy = (Magazine)magazine.DeepCopy();
        magazine.NameOfProduct = "Changed Magazine Name";

        Console.WriteLine("Original Magazine:");
        Console.WriteLine(magazine.ToString());

        Console.WriteLine("Copied Magazine:");
        Console.WriteLine(magazineCopy.ToString());

        double ratingThreshold = 8.0;
        foreach (Article article in magazine.ArticlesWithRatingAbove(ratingThreshold))
        {
            Console.WriteLine($"Article with rating above {ratingThreshold}: {article}");
        }

        string keyword = "SDF";
        foreach (Article article in magazine.ArticlesWithTitleContaining(keyword))
        {
            Console.WriteLine($"Article with title containing '{keyword}': {article}");
        }
    }
}
