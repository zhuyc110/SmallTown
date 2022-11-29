namespace SmallTown.Extension
{
    internal class DefaultSmallTownOutput : ISmallTownOutput
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}