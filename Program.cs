using System;

namespace _1
{
    class Program
    {   
        

        static void Main(string[] args)
        {
            /* ResearchTeam obj = new ResearchTeam();
            Console.WriteLine(obj.ToShortString());
            Console.WriteLine(obj[TimeFrame.Year]);
            Console.WriteLine(obj[TimeFrame.TwoYears]);
            Console.WriteLine(obj[TimeFrame.Long]);
            obj.Topic = "Assigned_Topic";
            obj.Org = "Assigned_Org";
            obj.Registration = 3228;
            obj.Duration = TimeFrame.TwoYears;
            Paper one = new Paper("Paper_Name1",new Person("Anatoly","Chulinskyi",new DateTime(1998,10,22)),new DateTime(2019,3,18));
            Paper two = new Paper("Paper_Name2",new Person("Person_Name","Person_Surname",new DateTime(2000,12,10)),new DateTime(2018,5,10));
            obj.AddPapers(one,two);
            Console.WriteLine(obj);
            Console.WriteLine(obj.LastLink.ToString());
            Console.WriteLine("Enter array sizes splited by 'x' of '/'");
            string temp1 = Console.ReadLine();
            string[] temp2 = temp1.Split(new Char[]{'x','/'});
            int rows =Convert.ToInt32(temp2[0]);
            int columns = Convert.ToInt32(temp2[1]);
            Paper[] array1 = new Paper[rows*columns];
            Paper[,] array2 = new Paper[rows,columns];
            Paper[][] array3 = new Paper[rows][];
            for(int i=0;i<rows;i++)array3[i] = new Paper[columns];
            for(int i=0;i<rows*columns;i++)array1[i] = new Paper("Paper_Name"+i,new Person("Person_Name"+i,"Person_Surname"+i,new DateTime(2000,12,10)),new DateTime(2018,5,10));
            for(int i=0;i<rows;i++)
                for(int j=0;j<columns;j++)
                {
                    array2[i,j] = new Paper("Paper_Name"+i+j,new Person("Person_Name"+i+j,"Person_Surname"+i+j,new DateTime(2000,12,10)),new DateTime(2018,5,10));
                }
            for(int i=0;i<rows;i++)
                for(int j=0;j<columns;j++)
                {
                    array3[i][j] = new Paper("Paper_Name"+i+j,new Person("Person_Name"+i+j,"Person_Surname"+i+j,new DateTime(2000,12,10)),new DateTime(2018,5,10));
                }
            
            int before = Environment.TickCount;
            for(int i=0;i<rows*columns;i++)array1[i].Topic = "Assigned_Topic" + i;
            int after = Environment.TickCount;
            int blocktime1 = after-before;

            before = Environment.TickCount;
            for(int i=0;i<rows;i++)
                for(int j=0;j<columns;j++)
                {
                    array2[i,j].Topic = "Assigned_Topic" + i + j;
                }
            after = Environment.TickCount;
            int blocktime2 = after-before;

            before = Environment.TickCount;
            for(int i=0;i<rows;i++)
                for(int j=0;j<columns;j++)
                {
                    array3[i][j].Topic = "Assigned_Topic" + i + j;
                }
            after = Environment.TickCount;
            int blocktime3 = after-before;
            Console.WriteLine("Rows - "+rows+", columns - "+columns);
            Console.WriteLine("One dimensional array - "+ blocktime1);
            Console.WriteLine("Two dimensional array - "+ blocktime2);
            Console.WriteLine("Pointed dimensional array - "+ blocktime3);*/
            Console.WriteLine("task 1");
            Team obj1 = new Team("Gusi","Gusak inc.",322);  // 1 task
            Team obj2 = new Team("Gusi","Gusak inc.",322);
            Console.WriteLine(obj1.GetHashCode() + " = " + obj2.GetHashCode()); 

            Console.WriteLine("task 2");
            try //2 task
            {
                obj1.Registration = -10;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("task 3");
            ResearchTeam obj3 = new ResearchTeam();  //3 task
            Person me = new Person("Anatoly","Chulinskyi",new DateTime(1998,10,22));
            obj3.Participants.Add(me);
            obj3.Participants.Add(new Person("Valia","Sushitska",new DateTime(1998,11,23)));
            Paper one = new Paper("Paper_Name1",me,new DateTime(2019,3,18));
            Paper three = new Paper("Paper_Name3",me,new DateTime(2018,3,18));
            Paper two = new Paper("Paper_Name2",new Person("Person_Name","Person_Surname",new DateTime(2000,12,10)),new DateTime(2015,5,10));
            obj3.AddPapers(one,two,three);
            Console.WriteLine(obj3.ToString());

            Console.WriteLine("task 4");
            Console.WriteLine(obj3.TeamBase);//4 task

            Console.WriteLine("task 5");
            ResearchTeam obj4 = (ResearchTeam)obj3.DeepCopy();//5 task
            obj3.Name = "Changed Name";
            Console.WriteLine(obj3.ToString());     
            Console.WriteLine(obj4.ToString());

            Console.WriteLine("task 6");
            foreach (var p in obj3.NoPublicationsList())//6 task
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("task 7");
            foreach (var p in obj3.LastPublications(2))//6 task
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("additional task 1");
            foreach (var p in obj3.HasPublication())//1 additional
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("additional task 2");
            foreach (var p in obj3.MoreThanOnePublication())//2 additional
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("additional task 3");
            foreach (var p in obj3.LastYearPublications())//3 additional
            {
                Console.WriteLine(p.ToString());
            }

        }
    }
//appl-dpt@chnu.edu.ua

}