using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests
{
    public class DriverTest
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var driv = new InMemoryDriv("Jan");
            driv.AddConsumption(5.2);
            driv.AddConsumption(5.7);
            driv.AddConsumption(6.4);

            // act
            var result = driv.GetStatistics();

            // assert
            Assert.Equal(5.8, result.Average, 1);
            Assert.Equal(6.4, result.High);
            Assert.Equal(5.2, result.Low);

        }
    }
}
