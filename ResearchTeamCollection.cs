using System;
using System.Collections.Generic;
using System.Linq;
namespace _1
{
    public class ResearchTeamCollection
    {
        private List<ResearchTeam> _researchteams;
        
        public string CollectionName{get;set;}

        public event TeamListHandler ResearchTeamAdded;
        public event TeamListHandler ResearchTeamInserted;

        public List<ResearchTeam> ResearchTeams
        {
            get { return _researchteams; }
            set { _researchteams = value; }
        }

        public ResearchTeamCollection()
        {
            ResearchTeams = new List<ResearchTeam>();
        }

        public void AddDefaults()
        {
            ResearchTeams.Add(new ResearchTeam());
            ResearchTeams.Add(new ResearchTeam());
            ResearchTeams.Add(new ResearchTeam());
            ResearchTeamAdded(this, new TeamListHandlerEventArgs(CollectionName, "Element was added by AddDefaults", ResearchTeams.Count - 1));
            
        }
        
        public void AddResearchTeams(params ResearchTeam[] teams)
        {
            foreach (ResearchTeam team in teams)
            {
                ResearchTeams.Add(team);
            }
            ResearchTeamAdded(this, new TeamListHandlerEventArgs(CollectionName, "Element was added by AddResearchTeams", ResearchTeams.Count - 1));
        }

        public override string ToString()
        {
            string temp1 = "";
            foreach(ResearchTeam team in ResearchTeams)
            {
                temp1 += team.ToString() + "\r\n";
            }
            return temp1;
        }

        public virtual string ToShortString(){
            string temp1 = "";
            foreach(ResearchTeam team in ResearchTeams)
            {
                temp1 += team.ToShortString() + "publication amount - " + team.Publications.Count + ", participants amount - " + team.Participants.Count + "\r\n";
            }
            return temp1;
        }

        public void SortByRegistration()
        {
            ResearchTeams.Sort();
        }

        public void SortByTopic()
        {
           ResearchTeams.Sort(new ResearchTeam().Compare);
        }

        public void SortByPublications()
        {
            ResearchTeams.Sort(new ResearchTeamComparer());  
        }

        public int GetMinRegistration()
        {           
            return ResearchTeams.Count != 0 ? ResearchTeams.Select(x => x.Registration).Min() : 0;
        }

        public IEnumerable<ResearchTeam> GetTwoYearDuration()
        {
            return ResearchTeams.Where(x => x.Duration == TimeFrame.TwoYears);
        }

        public List<ResearchTeam> GetNGroup(int value)
        {
            return ResearchTeams.Where(x => x.Participants.Count == value).ToList();
        }

        public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);

        public void insertAt(int j, ResearchTeam researchTeam)
        {
            if(ResearchTeams[j]!=null)
            {
                ResearchTeams.Insert(j,researchTeam);
                ResearchTeamInserted(this, new TeamListHandlerEventArgs(CollectionName, "Element was added by InsertAt", j));
            }
            else 
            {
                ResearchTeams.Add(researchTeam);
                ResearchTeamAdded(this, new TeamListHandlerEventArgs(CollectionName, "Element was added by InsertAt", ResearchTeams.Count - 1));
            }
        }

        public ResearchTeam this[int index]
        {
            get { return ResearchTeams[index]; }
            set { ResearchTeams[index] = value; }
        }
    }

}