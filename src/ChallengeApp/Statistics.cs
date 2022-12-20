using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class Statistics
    {
        public double High;

        public double Low;

        public double Sum;

        public int Count;
        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d <= 6:
                        return 'A';

                    case var d when d <= 8:
                        return 'B';

                    case var d when d <= 10:
                        return 'C';

                    default:
                        return 'Z';
                }
            }
        }
        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);

        }
    }
}