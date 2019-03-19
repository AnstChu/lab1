using System;

namespace _1
{
    class Program
    {   
        

        static void Main(string[] args)
        {
            ResearchTeam obj = new ResearchTeam();
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
            Console.WriteLine("Pointed dimensional array - "+ blocktime3);
        }
    }
//appl-dpt@chnu.edu.ua

}
