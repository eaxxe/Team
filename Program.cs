using System;
using Team;

class Program
{
    static void Main(string[] args)
    {
        // 1. Создать два объекта типа Edition с совпадающими данными и проверить, что ссылки на объекты не равны, а объекты равны, вывести значения хэш-кодов для объектов.
        Edition edition1 = new Edition("The Example", new DateTime(2024, 12, 1), 1000);
        Edition edition2 = new Edition("The Example", new DateTime(2024, 12, 1), 1000);

        Console.WriteLine($"edition1 == edition2: {edition1 == edition2}");
        Console.WriteLine($"ReferenceEquals(edition1, edition2): {ReferenceEquals(edition1, edition2)}");
        Console.WriteLine($"Hash code edition1: {edition1.GetHashCode()}");
        Console.WriteLine($"Hash code edition2: {edition2.GetHashCode()}");

        // 10. В блоке try/catch присвоить свойству с тиражом издания некорректное значение, в обработчике исключения вывести сообщение, переданное через объект-исключение.
        try
        {
            edition1.Tirazh = -500;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }

        // 11. Создать объект типа Magazine, добавить элементы в списки статей и редакторов журнала и вывести данные объекта Magazine.
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

        // 12. Вывести значение свойства типа Edition для объекта типа Magazine.
        Console.WriteLine(magazine.Edition);

        // 13. С помощью метода DeepCopy() создать полную копию объекта Magazine. Изменить данные в исходном объекте Magazine и вывести копию и исходный объект, полная копия исходного объекта должна остаться без изменений.
        Magazine magazineCopy = (Magazine)magazine.DeepCopy();
        magazine.NameOfProduct = "Changed Magazine Name";

        Console.WriteLine("Original Magazine:");
        Console.WriteLine(magazine.ToString());

        Console.WriteLine("Copied Magazine:");
        Console.WriteLine(magazineCopy.ToString());

        // 14. С помощью оператора foreach для итератора с параметром типа double вывести список всех статей с рейтингом больше некоторого заданного значения.
        double ratingThreshold = 8.0;
        foreach (Article article in magazine.ArticlesWithRatingAbove(ratingThreshold))
        {
            Console.WriteLine($"Article with rating above {ratingThreshold}: {article}");
        }

        // 15. С помощью оператора foreach для итератора с параметром типа string вывести список статей, в названии которых есть заданная строка.
        string keyword = "SDF";
        foreach (Article article in magazine.ArticlesWithTitleContaining(keyword))
        {
            Console.WriteLine($"Article with title containing '{keyword}': {article}");
        }
    }
}
