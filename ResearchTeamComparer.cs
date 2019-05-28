
using System.Collections.Generic;
namespace _1
{
    public class ResearchTeamComparer:IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam first, ResearchTeam second)
        {
            if (first.Publications.Count.CompareTo(second.Publications.Count) != 0)
            {
                return first.Publications.Count.CompareTo(second.Publications.Count);
            }

            return 0;
        }
    }
}