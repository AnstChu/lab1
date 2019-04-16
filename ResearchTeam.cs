using System;
using System.Collections;
namespace _1
{
    public enum TimeFrame {Year, TwoYears, Long};    
    public class ResearchTeam : Team, INameAndCopy
    {
        private string _topic;
        private TimeFrame _duration;
        private ArrayList _publications;
        private ArrayList _participants;

        public string Topic { get => _topic; set => _topic = value; }
        public TimeFrame Duration { get => _duration; set => _duration = value; }
        public ArrayList Publications
        {
            get { return _publications; }
            set { _publications = value; }
        }

        public ArrayList Participants
        {
            get { return _participants; }
            set { _participants = value; }
        }

        public ResearchTeam() : base()
        {
            Topic = "Team_Name";
            Duration = 0;
            Participants = new ArrayList();
            Publications = new ArrayList();
        }

        public ResearchTeam(string name, string topic, string org, int registration, TimeFrame duration, ArrayList publications, ArrayList participants) : base(name, org, registration)
        {
            _topic = topic;
            _duration = duration;
            _publications = publications;
            _participants = participants;
        }

        public Paper LastLink
        {
            get 
            {
                if(Publications.Count == 0) return null;
                else
                {
                    int LastPublicationIndex = 0; 
                    for(int i=1; i<Publications.Count;i++)
                    {
                        if((Publications[LastPublicationIndex] as Paper).PublicDate < (Publications[i] as Paper).PublicDate) LastPublicationIndex = i;
                    }
                    return Publications[LastPublicationIndex] as Paper;
                }
            }
        }

        public ArrayList PartisipantsList
        {
            get
            {
                return _participants;
            }
        }

        public Team TeamBase
        {
            get { return new Team(Name, Org, Registration);}
            set
            {
                Name = value.Name;
                Org = value.Org;
                Registration = value.Registration;
            }
        }


        public bool this[TimeFrame value]
        {
            get 
            {  
                return (_duration == value);
            }
        }

        public IEnumerable LastPublications(int YearAmount)
        {
            foreach(Paper item in Publications)
            {
                if(item.PublicDate.Year >= DateTime.Now.Year - YearAmount)yield return item;
            }
        }

        public IEnumerable LastYearPublications()
        {
            foreach(Paper item in this.LastPublications(1))
            {
                yield return item;
            }
        }

        public IEnumerable MoreThanOnePublication()
        {
            foreach(Person pers in Participants)
            {   
                int count = 0;
                foreach(Paper pap in Publications)
                {
                    if(pers == pap.Author)
                    {
                        count +=1;
                        if(count == 2)
                        {
                            yield return pers;
                            break;
                        }
                    }
                    
                }
            }
        }

        public IEnumerable HasPublication()
        {
            foreach(Person pers in Participants)
            {   
                foreach(Paper pap in Publications)
                {
                    if(pers == pap.Author)
                    {
                        yield return pers;
                        break;
                    } 
                } 
            }
        }

        public IEnumerable NoPublicationsList()
        {
            foreach(Person pers in Participants)
            {   
                bool flag = true;
                foreach(Paper pap in Publications)
                {
                    if(pers == pap.Author)
                    {
                        flag = false;
                        break;
                    }
                    
                }
                if(flag) yield return pers;
            }
        }

        public void AddPapers(params Paper[] papers)
        {
            foreach (Paper item in papers)
            {
                _publications.Add(item);
            }
        }

        public override string ToString()
        {
            string temp1 = "";
            string temp2 = "";
            for(int i=0; i<_participants.Count;i++)temp2 += _participants[i].ToString() + "\r\n";
            for(int i=0; i<_publications.Count;i++)temp1 += _publications[i].ToString() + "\r\n";
            return Name + " " + _topic + " " + _org + " " + _registration + " " + _duration+ "\r\n" + temp2 + temp1;
        }

        public virtual string ToShortString(){
            return Name + " " + _topic + " " + _org + " " + _registration + " " + _duration;
        }

        public override object DeepCopy()
        {
            ResearchTeam result = new ResearchTeam();
            result.Topic = String.Copy(Topic);
            result.Duration = Duration;
            result.Org = String.Copy(Org);
            result.Registration = Registration;
            result.Publications = new ArrayList(Publications);
            result.Participants = new ArrayList(Participants);
            return result;
        }
    }
}