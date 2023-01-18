using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests
{
    public class TypeTests
    {
    
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

        [Fact]
        public void CanSetNameFromReference()
        {
            var driv1 = GetDriver("Jan");
            this.SetName(driv1, "NewName");
            Assert.Equal("NewName", driv1.Name);
        }

        public void CSharpCanPassByRef()
        {
            var driv1 = GetDriver("Driver 1");
            GetDriverSetName(out driv1, "NewName");
            Assert.Equal("NewName", driv1.Name);
        }

        private void GetDriverSetName(out InMemoryDriver driv, string name)
        {
            driv = new InMemoryDriver(name);
        }

        private InMemoryDriver GetDriver(string name)
        {
            return new InMemoryDriver(name);
        }

        public void SetName(InMemoryDriver driver, string name)
        {
            driver.Name = name;
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

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }
    }
}
