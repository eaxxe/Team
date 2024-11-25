﻿using Team;
Article[] list = new Article[3];
list[0] = new Article();
list[1] = new Article(new Person("Arseniy", "Goids", new DateTime(2007, 1, 14)),"SDF",10.0);
list[2] = new Article(new Person("Valera", "Goids", new DateTime(2002, 12, 11)),"SDF",7.0);
Magazine magazine = new();
magazine.AddArticles(list);
Console.WriteLine(magazine.ToString());
Console.WriteLine(magazine.ToShortString());
//
Console.WriteLine((int)Frequency.Monthly);
Console.WriteLine((int)Frequency.Yearly);
Console.WriteLine((int)Frequency.Weekly);
//
string name = magazine.Name;
Console.WriteLine(name);
//
double avg = magazine.AverageRate;
Console.WriteLine(avg);
//
int mag = magazine.MagazineCirculation;
Console.WriteLine(mag);
//
DateTime goida = magazine.DateOfPublicationMagazine;
Console.WriteLine(goida);
//
Frequency gg = magazine.GetFrequency;
Console.WriteLine(gg);
//
Console.WriteLine(magazine[Frequency.Monthly]);
int size = 3;
Article sampleArticle = new Article(new Person("Arseniy", "DFD", new DateTime(2006, 11, 14)), "Minecumph", 1.0);
Article[] oneDimnesionalArr = new Article[size*size];
//Заполняем одномерный массив
for (int i = 0; i < size*size; i++)
{
    oneDimnesionalArr[i] = new Article();
}
//Заполняем двумерный прямоугольный массив
Article[,] twoDimnesionalRectArr = new Article[size, size];
for (int i = 0; i < size; i++)
{
    for (int j = 0; j < size; j++)
    {
        twoDimnesionalRectArr[i, j] = new Article();
    }
}
//Заполняем двумерный ступеньчатый массив
Article[][] twoDimnesionalJaggedArr = new Article[size][];
for (int i = 0; i < size; i++)
{
    twoDimnesionalJaggedArr[i] = new Article[size];
    for (int j = 0; j < size; j++)
    {
        twoDimnesionalJaggedArr[i][j] = new Article();
    }
}
MeasureTime("Одномерный массив", () =>
{
    for (int i = 0; i < size*size; i++)
    {
       oneDimnesionalArr[i].title="test";
    }
});
MeasureTime("Двумерный прямоугольный массив", () =>
{
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            twoDimnesionalRectArr[i, j].title = "test";
        }
    }
});
MeasureTime("Двумерный ступеньчатый массив", () =>
{
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
           twoDimnesionalJaggedArr[i][j].title = "test";
        }
    }
});
static void MeasureTime(string description, Action operation)
{
    long startTicks = DateTime.Now.Ticks;
    operation();
    long endTicks = DateTime.Now.Ticks;
    Console.WriteLine($"{description} выполнено за {endTicks - startTicks} тиков.");
}