using System;
namespace _1
{
    public class Paper
    {
        public string Topic{get;set;}
        public Person Author{get;set;}
        public DateTime PublicDate{get;set;}
    
        public Paper(string topic, Person author, DateTime publicdate)
        {
            Topic = topic;
            Author = author;
            PublicDate = publicdate;
        }

        public Paper()
        {
            Topic = "Default_Topic";
            Author = new Person();
            PublicDate =new DateTime(2019,3,18);
        }

        public override string ToString() => Topic + " " + Author.ToShortString() + " " + PublicDate.ToString();
    }
}