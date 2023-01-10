using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new InMemoryDriver("Janek");

            var fullData = new InMemoryDriver("Jan", "Janowski", "Fiat", 'M');

            var name = driver.Name;

            driver.Name = "Jan";

            var company = InMemoryDriver.FIRM;

            driver.ChangeSurname("Janowski");

            driver.CarBrand("Fiat");

            driver.ConsumptionAdded += OnConsumptionAdded;
            driver.ConsumptionLow += OnConsumptionLow;

            EnterDriver(driver, company);

            var stats = driver.GetStatistics();

            Console.WriteLine($"High:{stats.High}");
            Console.WriteLine($"Low:{stats.Low}");
            Console.WriteLine($"Average:{stats.Average}");
            Console.WriteLine($"Letter:{stats.Letter}");
        }

        private static void EnterDriver(IDriver driver, string f)
        {
            while (true)
            {
                Console.WriteLine($"Hello! Enter consumption for {driver.Name} works at {company}. Press 'q' to break");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    driver.AddConsumption(input);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void OnConsumptionAdded(object sender, EventArgs args)
        {
            Console.WriteLine("New consumption is added");
        }

        static void OnConsumptionLow(object sender, EventArgs args)
        {
            Console.WriteLine("Oh yes! We should inform boss about that");
        }
    }
}