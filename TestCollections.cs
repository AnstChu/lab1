using System.Collections.Generic;
using System;

namespace _1
{
    public class TestCollections
    {
        public List<Team> Teams { get; set; } 
        public List<string> Text { get; set; }
        public Dictionary<Team, ResearchTeam> ResTeamDictionary { get; set; }
        public Dictionary<string, ResearchTeam> StrDictionary { get; set; }

        public static ResearchTeam GetResTeam(int index)
        {
            ResearchTeam team = new ResearchTeam(
                "Name " + index + 2,
                "Topic " + index + 2,
                "Org_Name " + index + 2,
                1234 + index + 2,
                TimeFrame.Year + index % 2,
                new List<Paper>
                {
                    new Paper("Paper_Name " + index + 1,
                        new Person("Person_Name" + index + 1,"Person_Surname " + index + 1,DateTime.Today.AddDays(index - 50)),
                        DateTime.Today.AddDays(index + 5)),
                    new Paper("Paper_Name " + index + 2,
                        new Person("Person_Name" + index + 2,"Person_Surname " + index + 2,DateTime.Today.AddDays(index - 51)),
                        DateTime.Today.AddDays(index + 6)),
                    new Paper("Paper_Name " + index + 3,
                        new Person("Person_Name" + index + 3,"Person_Surname " + index + 3,DateTime.Today.AddDays(index - 52)),
                        DateTime.Today.AddDays(index + 6)),
                },
                new List<Person>
                {
                    new Person("Person_Name " + index + 1,
                        "Person_Surname " + index + 1,
                        DateTime.Today.AddDays(index + 2)),
                    new Person("Person_Name " + index + 2,
                        "Person_Surname " + index + 2,
                        DateTime.Today.AddDays(index + 3)),
                    new Person("Person_Name " + index + 3,
                        "Person_Surname " + index + 3,
                        DateTime.Today.AddDays(index + 4))
                }
                );
            return team;
        }

        public TestCollections(int count)
        {
            Teams = new List<Team>();
            Text = new List<string>();
            ResTeamDictionary = new Dictionary<Team, ResearchTeam>();
            StrDictionary = new Dictionary<string, ResearchTeam>();
            
            for (int i = 0; i < count; i++)
            {
                ResearchTeam resteam = GetResTeam(i);
                Team team = resteam.TeamBase;

                Teams.Add(team);
                Text.Add(team.ToString());
                ResTeamDictionary.Add(team, resteam);
                StrDictionary.Add(team.ToString(), resteam);  
            }           
        }   

        public void MeasureTime()
        {
            int length = Teams.Count - 1;
            int[] indexes = {0, length, length / 2, length + 1};
            foreach (var index in indexes)
            {
                var searcherResTeam = GetResTeam(index);
                var searcherTeam = searcherResTeam.TeamBase;
                
                Console.WriteLine("----------------------------");
                
                var start = new DateTime();
                start =  DateTime.Now;
                var answer = Teams.Contains(searcherTeam);
                var end = DateTime.Now - start;
                Console.WriteLine("List team at index {0}: " + end + " {1}", index, answer); 
                
                start =  DateTime.Now;
                answer = Text.Contains(searcherTeam.ToString());
                end = DateTime.Now - start;
                Console.WriteLine("List team toString at index {0}: " + end + " {1}", index, answer);
                
                start = DateTime.Now;
                answer = ResTeamDictionary.ContainsKey(searcherTeam);
                end = DateTime.Now - start;
                Console.WriteLine("Dictionary<Team, ResearchTeam> key at index {0}: " + end + " {1}", index, answer);
                
                start = DateTime.Now;
                answer = ResTeamDictionary.ContainsValue(searcherResTeam);
                end = DateTime.Now - start;
                Console.WriteLine("Dictionary<Team, ResearchTeam> value at index {0}: " + end + " {1}", index, answer);
                
                start = DateTime.Now;
                answer = StrDictionary.ContainsKey(searcherTeam.ToString());
                end = DateTime.Now - start;
                Console.WriteLine("Dictionary<string, ResearchTeam> key at index {0}: " + end + " {1}", index, answer);
                
                start = DateTime.Now;
                answer = StrDictionary.ContainsValue(searcherResTeam);
                end = DateTime.Now - start;
                Console.WriteLine("Dictionary<string, ResearchTeam> value at index {0}: " + end + " {1}", index, answer);
            }
            
        }
    }
}