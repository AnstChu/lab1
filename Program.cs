using System;
using System.Linq;

namespace _1
{
    class Program
    {   
        

        static void Main(string[] args)
        {
            ResearchTeamCollection research1 = new ResearchTeamCollection();
            ResearchTeamCollection research2 = new ResearchTeamCollection();

            research1.CollectionName = "research1";
            research2.CollectionName = "research2";

            TeamsJournal teams1 = new TeamsJournal();
            research1.ResearchTeamAdded += teams1.AddEvent;
            research2.ResearchTeamInserted += teams1.AddEvent;

            TeamsJournal teams2 = new TeamsJournal();
            research1.ResearchTeamAdded += teams2.AddEvent;
            research2.ResearchTeamAdded += teams2.AddEvent; 
            research1.ResearchTeamInserted += teams2.AddEvent;
            research2.ResearchTeamInserted += teams2.AddEvent;

            research1.AddResearchTeams(new ResearchTeam());
            research2.AddResearchTeams(new ResearchTeam());
            research1.AddDefaults();
            research2.AddDefaults();

            research1.ResearchTeams.Remove(research1[1]);
            research2.ResearchTeams.Remove(research2[1]);

            research1.AddDefaults();
            research2.AddDefaults();

            research1[1] = new ResearchTeam();
            research1.insertAt(1, new ResearchTeam());
            research2[1] = new ResearchTeam();
            research2.insertAt(3, new ResearchTeam());

            Console.WriteLine("----------------TeamsJournal-1:--------------");
            Console.WriteLine(teams1);
            Console.WriteLine("----------------TeamsJournal-2:--------------");
            Console.WriteLine(teams2);
        }
    }
//appl-dpt@chnu.edu.ua

}