using System;
using System.Collections.Generic;
using System.IO;

namespace ChallengeApp
{
    public class SavedDriver : DriverBase
    {
        public const string FIRM = "ITEC";      
        private const string fileName = "consumption.txt";
        private const string audit = "_audit.txt";
        DateTime saveNow = DateTime.Now;
        private List<string> cars;
        public SavedDriver(string name) : base(name)
        {
        }

        public SavedDriver(string name, string surname, string car, char sex) : base(name, surname, car, sex)
        {
        }

        public override event ConsumptionAddedDelegate ConsumptionAdded;
        public override event ConsumptionLowDelegate ConsumptionLow;
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

        public override void InsertCarBrand(string car)
        {
            {
                this.cars = new List<string>();

                if (!string.IsNullOrEmpty(car))
                {
                    this.cars.Add(car);
                }
                else
                {
                    Console.WriteLine("Car Brand invalid value");
                }
            }
        }
     
        public override void AddConsumption(double consumption)
        {
            WriteAddConsumptionInfile(consumption);
            if (consumption >= 4.0 && consumption <= 10.0)
            {    
                if (ConsumptionAdded != null)
                {
                    ConsumptionAdded(this, new EventArgs());
                }
                if (consumption < 6 && ConsumptionLow != null)
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
                WriteAddConsumptionwithPlusInfile(consumption);
                if (ConsumptionAdded != null)
                {
                    ConsumptionAdded(this, new EventArgs());
                }
                if (result < 6 && ConsumptionLow != null)
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
        public void WriteAddConsumptionInfile(double consumption)
        {
            using (var writer = File.AppendText($"{Name}_{fileName}"))
            {
                writer.WriteLine(consumption);
            }
            using (var writer2 = File.AppendText($"{Name}_{audit}"))
            {
                writer2.WriteLine($"{consumption} of {saveNow}");
            }
        }
        public void WriteAddConsumptionwithPlusInfile(string consumption)
        {
            using (var writer = File.AppendText($"{Name}_{fileName}"))
            {
                writer.WriteLine(consumption);
            }
            using (var writer2 = File.AppendText($"{Name}_{audit}"))
            {
                writer2.WriteLine($"{consumption} of {saveNow}");
            }
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            
            using (var reader = File.OpenText($"{Name}_{fileName}"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}
