namespace SmallTown.Engine.Core;
public interface IRandom
{
    /// <summary>
    /// Returns a non-negative random integer that is less than <paramref name="max"/>.
    /// </summary>
    int Next(int max = 101);

    /// <summary>
    /// Returns a collection of non-negative random integer that is less than 101.
    /// </summary>
    IList<int> Get(int count);
}
