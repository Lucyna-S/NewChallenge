using System;
using System.Collections.Generic;
using System.IO;

namespace ChallengeApp
{
    public delegate void ConsumptionAddedDelegate(object sender, EventArgs args);
    public delegate void ConsumptionLowDelegate(object sender, EventArgs args);
    public class InMemoryDriver : DriverBase
    {
        private string name;
        private string surname;
        readonly char sex;
        private string car;
        public const string FIRM = "ITEC";
        private List<double> consumptions;
        private List<string> cars = new List<string>();
        public InMemoryDriver(string name) : base(name)
        {
            this.consumptions = new List<double>();
        }

        public InMemoryDriver(string name, string surname, string car, char sex) : base(name, surname, car, sex)
        {
            this.consumptions = new List<double>();
            this.sex = 'M';
        }
        public string NewName
        {
            get
            {
                return this.name.ToLower();
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
            }
        }
        public void ChangeSurname(string surname)
        {
            bool digit = false;
            foreach (char c in surname)
            {
                if (char.IsDigit(c))
                {
                    digit = true;
                }
            }
            if (!digit)
            {
                this.Surname = surname;
                Console.WriteLine($"New Surname is: {Surname}");
            }
            else
            {
                Console.WriteLine($"New Surname have digit");
            }
        }
        public override event ConsumptionAddedDelegate ConsumptionAdded;
        public override event ConsumptionLowDelegate ConsumptionLow;

        public override void AddConsumption(double consumption)
        {
            if (consumption >= 4.0 && consumption <= 10.0)
            {
                this.consumptions.Add(consumption);

                if (ConsumptionAdded != null)
                {
                    ConsumptionAdded(this, new EventArgs());
                }
                if (consumption < 10 && ConsumptionLow != null)
                {
                    ConsumptionLow(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid argumnet: {nameof(consumption)}");
            }
        }
        public override void AddConsumption(string consumption)
        {
            var value = double.TryParse(consumption, out double result);
            if (result >= 4.0 && result <= 10.0)
            {
                this.consumptions.Add(result);

                if (ConsumptionAdded != null)
                {
                    ConsumptionAdded(this, new EventArgs());
                }
                if ( result < 6 && ConsumptionLow != null)
                {
                    ConsumptionLow(this, new EventArgs());
                }

            }
            else
            {
                switch (consumption)
                {
                    case "4+":
                        this.AddConsumption(4.5);
                        break;
                    case "5+":
                        this.AddConsumption(5.5);
                        break;
                    case "6+":
                        this.AddConsumption(6.5);
                        break;
                    case "7+":
                        this.AddConsumption(7.5);
                        break;
                    case "8+":
                        this.AddConsumption(8.5);
                        break;
                    case "9+":
                        this.AddConsumption(9.5);
                        break;
                    case "10-":
                        this.AddConsumption(9.75);
                        break;
                    case "9-":
                        this.AddConsumption(8.75);
                        break;
                    case "8-":
                        this.AddConsumption(7.75);
                        break;
                    case "7-":
                        this.AddConsumption(6.75);
                        break;
                    case "6-":
                        this.AddConsumption(5.75);
                        break;
                    case "5-":
                        this.AddConsumption(4.75);
                        break;
                    default:
                        throw new ArgumentException($"Invalid argumnet: {nameof(consumption)}");
                }
            }
        }
        public override void DriversAge()
        {
            const int year = 2022;
            var bornyear = new[] { 1997, 1986, 1995, 1989, 2000, 1981, 2002, 2004, 1983, 2001 };
            var driver = new[] { "Piotr", "Szymon", "Tadeusz", "Jan", "Jakub", "Andrzej", "Filip", "Bartłomiej", "Tomasz", "Mateusz" };

            for (var index = 0; index < driver.Length; index++)

                Console.WriteLine($"Name Driver and age: {driver[index]} {(year - bornyear[index])} years old.");
        }
        public override void CarBrand(string car)
        {
            this.car = car;
            if (!string.IsNullOrEmpty(car))
            {
                this.cars.Add(car);
            }
            else
            {
                Console.WriteLine("Car Brand invalid value");
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            for (var index = 0; index < consumptions.Count; index++)
            {
                result.Add(consumptions[index]);
            }
            return result;
        }

    }
}
