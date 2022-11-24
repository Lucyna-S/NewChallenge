using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new SavedDriver("Jan");
            driver.ConsumptionAdded += OnConsumptionAdded;
            driver.ConsumptionLow += OnConsumptionLow;

            var name = driver.Name;
            
            driver.Name = "New Jan";
            var f = InMemoryDriver.FIRM;

            EnterDriver(driver, f);

            // driver.AddConsumption(4.8);
            //  driver.AddConsumption("5+");
            //  driver.AddConsumption("five");
            var driv = new SavedDriver("Jerzy");
            //driv.ChangeName("Jerz7");
            driver.CarBrand("");
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
                    var consumption = double.Parse(input);
                    driver.AddConsumption(consumption);     

                   // driver.AddConsumption(input);
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
                    //Console.WriteLine("Here is finally");
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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

