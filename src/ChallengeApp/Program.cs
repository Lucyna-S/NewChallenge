using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new InMemoryDriv("Janek");

            var fullData = new InMemoryDriv("Jan", "Janowski", "Fiat", 'M');

            var name = driver.Name;

            driver.Name = "Jan";

            var f = InMemoryDriv.FIRM;

            driver.ChangeSurname("Janow8ski");

            driver.CarBrand("Fiat");

            driver.ConsumptionAdded += OnConsumptionAdded;
            driver.ConsumptionLow += OnConsumptionLow;

            EnterDriver(driver, f);


            driver.DriversAge();

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
                Console.WriteLine($"Hello! Enter consumption for {driver.Name} works at {f}. Press 'q' to break");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try

                {
                    if (input!= null)
                    {
                        var consumption = double.Parse(input);
                        driver.AddConsumption(consumption);
                    }
                    else
                    {
                        driver.AddConsumption(input);
                    }
                    
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Here is finally");
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


// public override bool Equals(object obj)
//         {
//             return base.Equals(obj);
//         }

//         public override int GetHashCode()
//         {
//             return base.GetHashCode();
//         }

//         public override string ToString()
//         {
//             return base.ToString();
//         }