using System.Collections.Generic;
using System.Linq;
namespace _1
{
    public class ResearchTeamCollection
    {
        private List<ResearchTeam> _researchteams;

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
        }
        
        public void AddResearchTeams(params ResearchTeam[] teams)
        {
            foreach (ResearchTeam team in teams)
            {
                ResearchTeams.Add(team);
            }
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
    }
}