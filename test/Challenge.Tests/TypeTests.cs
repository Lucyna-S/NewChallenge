using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests
{
    public class TypeTests
    { public delegate string WriteMessage(string message);
        
        int counter = 0;
        [Fact]
        public void WriteMessageDelegateCanPointToMethod()
        {
            WriteMessage del = ReturnMessage;
            del += ReturnMessage;
            del += ReturnMessage2;


            var result = del("HELLO");
            Assert.Equal(3, counter);

        }
        string ReturnMessage(string message)
        {
            counter++;
            return message;
        }
        string ReturnMessage2(string message)
        {
            counter++;
            return message.ToUpper();
        }

        [Fact]
        public void GetDriverReturnsDifferentObjects()
        {
            var driv1 = GetDriver("Jan");
            var driv2 = GetDriver("Marek");

        Assert.NotSame(driv1, driv2);
        Assert.False(Object.ReferenceEquals(driv1, driv2));
        }
        [Fact]
        public void TwoVarsCanReferenceSameObjects()
        {
            var driv1 = GetDriver("Jan");
            var driv2 = driv1;

        Assert.Same(driv1, driv2);
        Assert.True(Object.ReferenceEquals(driv1, driv2));
        }
        public void CanSetNameFromReference()
        {
            var driv1 = GetDriver("Jan");
            this.SetName(driv1, "NewName");
            Assert.Equal("NewName", driv1.Name);
        }
        public void CSharpCanPassByRef()
        {
             //Driver driv1 = null; 
            var driv1 = GetDriver("Driver 1");
            GetDriverSetName( out driv1, "NewName");
            Assert.Equal("NewName", driv1.Name);
        }
        private void GetDriverSetName(out Driver driv, string name)
        {
        driv = new Driver(name);
        }
        private Driver GetDriver(string name)
        {
        return new Driver(name);
        }
        public void SetName(Driver driver, string name)
        {
            driver.Name=name;
        }
        
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(3, x);
        }
    
        private void SetInt(ref int x)
        {
            x = 42;
        }
        private int GetInt()
        {
            return 3;
        }
        public void StringsBehaveLikeValueType()
        {
            var x = "Lucy";
            var upper = this.MakeUppercase(x);

            Assert.Equal("Lucy", x);
            Assert.Equal("LUCY", upper);
        }
        private string MakeUppercase( string parameter)
        {
            return parameter.ToUpper();
        }
        
        }
     
    }
// Wszystkie cechy ucznia, które powinny być publiczne wystaw w postaci getter’ów i setter’ów. Przypilnuj, które z nich powinny mieć publiczny 'seter’
//Nazwij i napisz obsługę zdarzenia, które przy każdym dodaniu oceny poniżej 3 wyświetli informacje: „Oh no! We should inform student’s parents about this fact”