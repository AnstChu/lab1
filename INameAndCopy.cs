namespace _1
{
    public interface INameAndCopy
    {
        string Name { get; set;}
        object DeepCopy();
    }
}