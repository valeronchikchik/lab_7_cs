using System;

class TMan
{
    //int YearOfBirth = 0;
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public int Day { get; set; }
    public int Month { get; set; }

    public TMan(string name, int age, string gender, int day, int month)
    {
        Name = name;
        Age = age;
        Gender = gender;
        Day = day;
        Month = month;
    }

    public string GetHoroscope()
    {
        if ((Month == 3 && Day >= 21) || (Month == 4 && Day <= 20))
            return "Овен";
        if ((Month == 4 && Day >= 21) || (Month == 5 && Day <= 21))
            return "Телець";
        if ((Month == 5 && Day >= 22) || (Month == 6 && Day <= 21))
            return "Близнюки";
        if ((Month == 6 && Day >= 22) || (Month == 7 && Day <= 22))
            return "Рак";
        if ((Month == 7 && Day >= 23) || (Month == 8 && Day <= 23))
            return "Лев";
        if ((Month == 8 && Day >= 24) || (Month == 9 && Day <= 23))
            return "Діва";
        if ((Month == 9 && Day >= 24) || (Month == 10 && Day <= 23))
            return "Терези";
        if ((Month == 10 && Day >= 24) || (Month == 11 && Day <= 22))
            return "Скорпіон";
        if ((Month == 11 && Day >= 23) || (Month == 12 && Day <= 21))
            return "Стрілець";
        if ((Month == 12 && Day >= 22) || (Month == 1 && Day <= 20))
            return "Козеріг";
        if ((Month == 1 && Day >= 21) || (Month == 2 && Day <= 18))
            return "Водолій";
        if ((Month == 2 && Day >= 19) || (Month == 3 && Day <= 20))
            return "Риби";

        return "Невідомо";
    }

    public string GetCategory()
    {
        if (Age < 12)
            return "Дитина";
        else if (Age < 18)
            return "Юнак/Юначка";
        else
            return "Доросла людина";
    }

    public override string ToString()
    {
        return $"Ім'я: {Name}\n" +
               $"Вік: {Age}\n" +
               $"Стать: {Gender}\n" +
               $"Дата народження: {Day}.{Month}\n" +
               $"Знак зодіаку: {GetHoroscope()}\n" +
               $"Категорія: {GetCategory()}";
    }
    public int GetYearOfBirth()
    {
        DateTime today = DateTime.Now;
        int currentYear = today.Year;
        int currentMonth = today.Month;
        int currentDay = today.Day;

        int yearOfBirth = currentYear - Age;

        if (currentMonth < Month || (currentMonth == Month && currentDay < Day))
        {
            yearOfBirth--;
        }

        return yearOfBirth;
    }
}

class Program
{
    static void Main()
    {
        TMan person = new TMan("Іван", 20, "Чоловіча", 15, 5);

        Console.WriteLine(person.ToString());
        Console.WriteLine("Рік народження: " + person.GetYearOfBirth());
    }
}