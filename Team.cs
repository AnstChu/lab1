using System;
namespace _1
{
    public class Team : INameAndCopy
    {
        protected string _org;
        protected int _registration;
        
        public string Name{get;set;}
        public string Org { get => _org; set => _org = value; }
        public int Registration { get => _registration; 
                                    set
                                    {
                                        if (value < 0)
                                        {
                                            throw new Exception("Registration number must be more then 0");
                                        }
                                        _registration = value;
                                    }
                                }

        public Team()
        {
            Name = "Default_Name";
            Org = "Organization_Name";
            Registration = 1234;    
        }

        public Team(string name, string org, int registration)
        {
            Name = name;
            _org = org;
            _registration = registration;
        }

        public virtual object DeepCopy()
        {
            Team result = new Team();
            result.Name = String.Copy(Name);
            result.Org = String.Copy(Org);
            result.Registration = Registration;
            return result;
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
                Team t = (Team) obj;
                return t.Name == Name  && t.Org == Org;
        }

        public static bool operator ==(Team obj1, Team obj2)
        {
        if (ReferenceEquals(obj1, obj2))
        {
            return true;
        }

        if (ReferenceEquals(obj1, null))
        {
            return false;
        }
        if (ReferenceEquals(obj2, null))
        {
            return false;
        }

        return (obj1.Name == obj2.Name
                && obj1.Org == obj2.Org);
        }

        public static bool operator !=(Team obj1, Team obj2)
        {
            return !(obj1 == obj2);
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = (hash * 7) + (!Object.ReferenceEquals(null, Name) ? Name.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, Org) ? Org.GetHashCode() : 0);
            return hash;
        }

        public override string ToString()
        {
            return "Організація "+Org+", номер реєстрації - "+Registration;
        }
    }
}