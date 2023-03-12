namespace SmallTown.Platform
{
    internal class DefaultSmallTownOutput : ISmallTownOutput
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}