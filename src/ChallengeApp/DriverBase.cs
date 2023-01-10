using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public abstract class DriverBase : NameObject, IDriver
    {
        public DriverBase(string name, string surname, string car, char sex) : base(name, surname, car, sex)
        {
        }

        public DriverBase(string name) : base(name)
        {
        }

        public abstract event ConsumptionAddedDelegate ConsumptionAdded;
        public abstract event ConsumptionLowDelegate ConsumptionLow;
        public abstract void AddConsumption(double consumption);
        public abstract void AddConsumption(string consumption);
        public abstract void CarBrand(string car);
        public abstract Statistics GetStatistics();
    }
}