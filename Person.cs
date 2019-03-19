using System;
namespace _1
{
    public class Person
    {
        private string _name;
        private string _surname;
        private DateTime _birthdate;
    
        public Person(string name,string surname, DateTime birthdate)
        {
        _name = name;
        _surname = surname;
        _birthdate = birthdate;
        }

        public Person()
        {
            _name = "Default_Name";
            _surname = "Default_Surname";
            _birthdate = new DateTime(1998,11,23);
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }

        public DateTime Birthdate
        {
            get => _birthdate;
            set => _birthdate = value;
        }

        public int Year
        {
            get => _birthdate.Year;
            set => _birthdate=new DateTime(value,_birthdate.Month, _birthdate.Day);
        }

        public override string ToString() => Surname + " " + Name + " " + Birthdate.Day + "/" + Birthdate.Month + "/" + Birthdate.Year;

        public virtual string ToShortString()
        {
            return Surname + " " + Name;
        }
    }
}