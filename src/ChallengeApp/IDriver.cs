using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public interface IDriver
    {
        void AddConsumption(double consumption);
        void AddConsumption(string consumption);
        void DriversAge();
        void CarBrand(string car);
        Statistics GetStatistics();
        string Name { get; }
        string Surname { get; }
        string Car { get; }
        char Sex { get; }
        event ConsumptionAddedDelegate ConsumptionAdded;
        event ConsumptionLowDelegate ConsumptionLow;
    }
}

