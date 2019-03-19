using System;
namespace _1
{
    public enum TimeFrame {Year, TwoYears, Long};    
    public class ResearchTeam
    {
        private string _topic;
        private string _org;
        private int _registration;
        private TimeFrame _duration;
        private Paper[] _publications;

        public string Topic { get => _topic; set => _topic = value; }
        public string Org { get => _org; set => _org = value; }
        public int Registration { get => _registration; set => _registration = value; }
        public TimeFrame Duration { get => _duration; set => _duration = value; }
        public Paper[] Publications { get => _publications; set => _publications = value; }

        public ResearchTeam()
        {
            Topic = "Team_Name";
            Org = "Organisation_Name";
            Registration = 1234;
            Duration = 0;
            Publications = new Paper[0];
        }

        public ResearchTeam(string topic, string org, int registration, TimeFrame duration, Paper[] publications)
        {
            _topic = topic;
            _org = org;
            _registration = registration;
            _duration = duration;
            _publications = publications;
        }

        public Paper LastLink
        {
            get 
            {
                if(_publications.Length == 0) return null;
                else
                {
                    int last_publication_index = 0; 
                    for(int i=1; i<_publications.Length;i++)
                    {
                        if(_publications[last_publication_index].PublicDate < _publications[i].PublicDate) last_publication_index = i;
                    }
                    return _publications[last_publication_index];
                }
            }
        }

        public bool this[TimeFrame value]
        {
            get 
            {  
                return (_duration == value);
            }
        }

        public void AddPapers(params Paper[] papers)
        {
            if(papers.Length!=0)
            {   
                int prevsize = _publications.Length;
                Array.Resize(ref _publications, _publications.Length + papers.Length);
                for(int i=0; i<papers.Length;i++)
                {
                    _publications[prevsize + i] = papers[i];
                }
            }
        }

        public override string ToString()
        {
            string temp = "";
            for(int i=0; i<_publications.Length;i++)temp += _publications[i].ToString() + "\r\n";
            return _topic + " " + _org + " " + _registration + " " + _duration+ "\r\n" + temp;
        }

        public virtual string ToShortString(){
            return _topic + " " + _org + " " + _registration + " " + _duration;
        }
    }
}