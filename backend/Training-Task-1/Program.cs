using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("A- Name Printer");
            Console.WriteLine("B- Countries Search");
            Console.WriteLine("C- Letters Counter");
            Console.WriteLine("D- Smart Calculator");
            Console.WriteLine("E- Week Description");
            Console.WriteLine("X- Exit");

            Console.Write("Choose an option: ");
            char choice = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            switch (choice)
            {
                case 'A':
                    NamePrinter();
                    break;

                case 'B':
                    CountriesSearch();
                    break;

                case 'C':
                    LettersCounter();
                    break;

                case 'D':
                    SmartCalculator();
                    break;

                case 'E':
                    WeekDescription();
                    break;

                case 'X':
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void NamePrinter()
    {
        Console.Write("Enter your Name: ");
        string name = Console.ReadLine();

        // Print reversed name
        Console.WriteLine($"Reversed Name: {new string(name.Reverse().ToArray())}");

        // Print name with capital letters
        Console.WriteLine($"Name in Capital Letters: {name.ToUpper()}");

        // Print name with small letters
        Console.WriteLine($"Name in Small Letters: {name.ToLower()}");

        // Check if the name is valid
        bool isValidName = name.All(char.IsLetter);
        Console.WriteLine($"Is Name Valid? {isValidName}");
    }

    static bool IsValidName(string name)
    {
        foreach (char c in name)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
        }
        return true;
    }

    static void CountriesSearch()
    {
        List<string> countries = new List<string> { "Afghanistan", "Albania", "Algeria", "palestine" };

        Console.Write("Search for a Country: ");
        string searchQuery = Console.ReadLine().ToLower();

        
        List<string> resultCountries = new List<string>();
        foreach (string country in countries)
        {
            if (country.ToLower().StartsWith(searchQuery))
            {
                resultCountries.Add(country);
            }
        }

        Console.WriteLine("Results:");
        foreach (string country in resultCountries)
        {
            Console.WriteLine(country);
        }
    }

    static void LettersCounter()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        int[] letterCounts = new int['Z' - 'A' + 1]; // Assuming case-insensitive counting for English letters
        List<char> invalidChars = new List<char>();

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char upperCaseChar = char.ToUpper(c);
                letterCounts[upperCaseChar - 'A']++;
            }
            else
            {
                invalidChars.Add(c);
            }
        }

        Console.WriteLine("Letter Counts:");
        for (char c = 'A'; c <= 'Z'; c++)
        {
            int count = letterCounts[c - 'A'];
            if (count > 0)
            {
                Console.WriteLine($"{c}: {count}");
            }
        }

        // Check for invalid characters
        if (invalidChars.Count > 0)
        {
            Console.WriteLine("Invalid Characters: " + string.Join(", ", invalidChars));
        }
    }


    static void SmartCalculator()
    {
        Console.Write("Enter the first Number: ");
        double numA = GetValidNumberInput();

        Console.Write("Enter the second Number: ");
        double numB = GetValidNumberInput();

        Console.WriteLine($"A/B: {numA / numB}");
        Console.WriteLine($"Square root of (A + B): {Math.Sqrt(numA + numB)}");
        Console.WriteLine($"A^B: {Math.Pow(numA, numB)}");
        Console.WriteLine($"Binary representation of A: {Convert.ToString((int)numA, 2)}");
        Console.WriteLine($"Binary representation of B: {Convert.ToString((int)numB, 2)}");
    }

    static double GetValidNumberInput()
    {
        string input = Console.ReadLine();
        double number;
        if (double.TryParse(input, out number))
        {
            // Keep only 4 digits after the comma
            return Math.Round(number, 4);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return GetValidNumberInput();
        }
    }

    enum WeekDay
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    static void WeekDescription()
    {
        Console.Write("Enter Week day: ");
        string input = Console.ReadLine();
        WeekDay day;

        if (Enum.TryParse(input, true, out day))
        {
            switch (day)
            {
                case WeekDay.Sunday:
                    Console.WriteLine("It's the first day of the week.");
                    break;

                case WeekDay.Monday:
                case WeekDay.Tuesday:
                case WeekDay.Wednesday:
                case WeekDay.Thursday:
                    Console.WriteLine("It's a workday.");
                    break;

                case WeekDay.Friday:
                    Console.WriteLine("It's the last workday before the weekend.");
                    break;

                case WeekDay.Saturday:
                    Console.WriteLine("It's the weekend!");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid Week day. Please enter a valid day.");
        }
    }
}
