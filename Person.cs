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

        public override bool Equals(object obj)
        {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }
                if(obj.GetType() != GetType()) return false;
                Person p = (Person) obj;
                return p.Name == Name  && p.Surname == Surname  &&  p.Birthdate == Birthdate;
        }

        public static bool operator ==(Person obj1, Person obj2)
        {
        if (ReferenceEquals(obj1, obj2))
        {
            return true;
        }

        if (ReferenceEquals(obj1, null) || ReferenceEquals(obj2, null))
        {
            return false;
        }

        return (obj1.Name == obj2.Name
                && obj1.Surname == obj2.Surname
                && obj1.Birthdate == obj2.Birthdate);
        }

        public static bool operator !=(Person obj1, Person obj2)
        {
            return !(obj1 == obj2);
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = (hash * 5) + (!Object.ReferenceEquals(null, Name) ? Name.GetHashCode() : 0);
            hash = (hash * 5) + (!Object.ReferenceEquals(null, Surname) ? Surname.GetHashCode() : 0);
            hash = (hash * 5) + (!Object.ReferenceEquals(null, Birthdate) ? Birthdate.GetHashCode() : 0);
            return hash;
        }

        public virtual object DeepCopy()
        {
            Person result = new Person();
            result.Name = String.Copy(Name);
            result.Surname = String.Copy(Surname);
            result.Birthdate = Birthdate;
            return result;
        }
    }
}