using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public delegate void ConsumptionAddedDelegate(object sender, EventArgs args);
    public delegate void ConsumptionLowDelegate(object sender, EventArgs args);
    public class InMemoryDriver : DriverBase
     {
       private List<string> cars = new List<string>();
       private string name; 
       private string surname;
       readonly char sex;
       private string car;
       public const string FIRM = "ITEC";

        public override event ConsumptionAddedDelegate ConsumptionAdded;
        public override event ConsumptionLowDelegate ConsumptionLow;

        public InMemoryDriver(string name): base(name)
        {   
        }
        public InMemoryDriver(string name, string surname, string car, char sex): base(name, surname, car, sex)
        {
          this.sex = 'M';
        }
        public override void CarBrand(string car)
        {  
          this.car = car;
          if(!string.IsNullOrEmpty(car))
           {
            this.cars.Add(car);
           }
           else
           {
             Console.WriteLine("Car Brand invalid value");
           }         
         }
         public string NewName
         {
          get
          {
            return this.name.ToLower();
          }
          set
          {
            if(!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
            {
              this.name = value;
            }
          }
        }
      public string Fullname
        { 
          get
          {
           return this.name + "" + this.surname;
          } 
          set
          {
           this.name=value;
          }         
        }
      public void ChangeName(string name)
        {
          bool digit = false;
          foreach (char c in name)
          {
            if(char.IsDigit(c))
            {
              digit = true;
            }
          }
            if(!digit)
            {
              this.Name=name;
              Console.WriteLine($"New Name is: {Name}");
            }
            else
            {
               Console.WriteLine($"New Name have digit");
            }
        }
        public override void DriversAge()
        {
          const int year = 2022;
          var bornyear = new []{1997, 1986, 1995, 1989, 2000, 1981, 2002, 2004, 1983, 2001};
          var driver = new []{"Piotr", "Szymon", "Tadeusz", "Jan", "Jakub", "Andrzej", "Filip", "Bartłomiej", "Tomasz", "Mateusz"};
  
          for (var index = 0; index < driver.Length; index ++)

          Console.WriteLine($"Name Driver and age: {driver[index]} {(year - bornyear[index])} years old.");       
        }        
        public override void AddConsumption(double consumption)
        {
          Console.WriteLine($"Add New Consumption");
        } 
        public override void AddConsumption(string consumption)
        {
          Console.WriteLine($"Add New Consumption");
        }
      }
}





//Console.WriteLine($"The average is:{lowConsumption:N1}");
             //Console.WriteLine($"The average is:{highConsumption:N1}");

// public void AddConsumption(double consumption)
        // {
        //   bool result = true;
        //   if(!result)
        //   {
        //     this.consumptions.Add(consumption);
        //   }
        //   else
        //   {
        //     Console.WriteLine("Invalid value");
        //   }
        // }
      
        
        //   if(consumption == "A")
        //   {
        //     this.AddConsumptionLet(100);
        //   }
        //   else if(consumption == "B")
        //   {
        //     this.AddConsumptionLet(80);
        //   }
        //   else if(consumption == "C")
        //   {
        //     this.AddConsumptionLet(60);
        //   }
        //   else
        //   {
        //     this.AddConsumptionLet(0);
        //   }
        // }

 // public Student (string name)
        // {
        //   this.Name = name;
        // }
        // public Ages (int age)
        // {
        //   this.Age = age;
        // }
        // public void StudentsAge(string name, int age)

        // for (var index = 0; index < students.Count; index ++ )
        // Console.WriteLine($"NameStudent and AgeStudent: {name, age }");
   