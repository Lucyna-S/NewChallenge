using System;
using System.Collections.Generic;
using System.IO;

namespace ChallengeApp
{
    public class SavedDriver : DriverBase
    {
        private const string fileName = "consumption.txt";
        private const string audit = "_audit.txt";
        DateTime saveUtcNow = DateTime.UtcNow;

        public SavedDriver(string name) : base(name)
        {
        }

        public SavedDriver(string name, string surname, string car, char sex) : base(name, surname, car, sex)
        {
        }

        public override event ConsumptionAddedDelegate ConsumptionAdded;
        public override event ConsumptionLowDelegate ConsumptionLow;

        public override void AddConsumption(double consumption)
        {
          using(var writer = File.AppendText($"{Name}_{fileName}"))
          {
            writer.WriteLine(consumption);
            if(ConsumptionAdded != null)
            {
              ConsumptionAdded(this, new EventArgs());
            }
          }         
          //writer.Dispose();
        }
        public override void AddConsumption(string consumption)
        {
            using(var writer = File.AppendText($"{Name}_{audit}"))
          {
            writer.WriteLine(consumption);
            writer.WriteLine(saveUtcNow);
            if(ConsumptionAdded != null)
            {
              ConsumptionAdded(this, new EventArgs());
            }
          }         
        }
        public override void CarBrand(string car)
        {
            throw new NotImplementedException();
        }
    }
}
// Zrób dwie implementacje Twojej bazowej klasy StudentBase (pierwsza ma przechowywać dane tylko w pamięci, a druga tylko w pliku)
// W klasie operującej na pliku stwórz zmienną const z nazwą pliku, w której przechowujesz nazwę pliku i używaj jej w podczas wywołania operacji na tym pliku
// W implementacji z obsługą pliku dodaj automatyczny zapis do drugiego pliku audytowego „audit.txt”, w którym oprócz ocen dodasz w każdej linii datę i godzinę ich wprowadzenia (użyj DateTime.UtcNow)