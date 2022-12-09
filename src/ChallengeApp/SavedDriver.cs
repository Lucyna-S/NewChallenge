using System;
using System.Collections.Generic;
using System.IO;

namespace ChallengeApp
{
    public class SavedDriver : DriverBase
    {
        private List<double> consumptions = new List<double>();
        private const string fileName = "consumption.txt";
        private const string audit = "_audit.txt";
        DateTime saveNow = DateTime.Now;

        public SavedDriver(string name) : base(name)
        {
            consumptions = new List<double>();
        }

        public SavedDriver(string name, string surname, string car, char sex) : base(name, surname, car, sex)
        {
        }

        public override event ConsumptionAddedDelegate ConsumptionAdded;
        public override event ConsumptionLowDelegate ConsumptionLow;

        public override void AddConsumption(double consumption)
        {
            {
                if (consumption >= 4.0 && consumption <= 10.0)
                {
                    this.consumptions.Add(consumption);

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

            using (var writer = File.AppendText($"{Name}_{fileName}"))
            {
                writer.WriteLine(consumption);
                if (ConsumptionAdded != null)
                {
                    ConsumptionAdded(this, new EventArgs());
                }
            }   
        }
        public override void AddConsumption(string consumption)
        {
            int result;
            int.TryParse(consumption, out result);
            if (result >= 4 && result <= 10)
            {
                this.consumptions.Add(result);
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
            using (var writer = File.AppendText($"{Name}_{audit}"))
            {
                writer.WriteLine($"{consumption} of {saveNow}");
                if (ConsumptionAdded != null)
                {
                    ConsumptionAdded(this, new EventArgs());
                }
            }
        }
        public override void CarBrand(string car)
        {
            throw new NotImplementedException();
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}_{audit}"))
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
