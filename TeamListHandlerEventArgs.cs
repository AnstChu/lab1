using System;
namespace _1
{
    public class TeamListHandlerEventArgs : EventArgs
    {
        public string CollectionName{get;set;}
        public string ChangeType{get;set;}
        public int Index{get;set;}
        
        public TeamListHandlerEventArgs()
        {
            CollectionName = "Default collection name";
            ChangeType = "Default change type";
            Index = new int();
        }

        public TeamListHandlerEventArgs(string name, string changetype, int index)
        {
            CollectionName = name;
            ChangeType = changetype;
            Index = index;
        }

        public override string ToString()
        {
            return CollectionName + " " + ChangeType + " element index - " + Index + "\r\n";
        }

    }
}