namespace SmallTown.Engine.Core;
public interface IRandom
{
    /// <summary>
    /// Returns a non-negative random integer that is less than 101.
    /// </summary>
    int Next();

    /// <summary>
    /// Returns a collection of non-negative random integer that is less than 101.
    /// </summary>
    IList<int> Get(int count);
}
