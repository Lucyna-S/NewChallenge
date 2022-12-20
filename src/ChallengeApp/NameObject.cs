using System;
using System.Collections.Generic;
using System.IO;

namespace ChallengeApp
{
    public abstract class NameObject
    {
        public NameObject(string name)
        {
            this.Name = name;
        }
        public NameObject(string name, string surname, string car, char sex)
        {
            this.Name = name;
            this.Surname = surname;
            this.Car = car;
            this.Sex = sex;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Car { get; set; }
        public char Sex { get; }
    }
}
