using System.Security.Cryptography;

namespace SmallTown.Engine.Core;
internal class SmallRandom : IRandom
{
    public IList<int> Get(int count)
    {
        // Create a new instance of Random
        var ran = new Random(Next());

        // Create an array of numbers
        var numbers = Enumerable.Range(1, count << 1).ToArray();

        // Loop through the array from the last element to the second element
        for (var i = numbers.Length - 1; i > 0; i--)
        {
            // Pick a random index from 0 to i
            var j = ran.Next(i + 1);

            // Swap the elements at i and j
            (numbers[j], numbers[i]) = (numbers[i], numbers[j]);
        }

        // Take the first count elements of the shuffled array
        return numbers.Take(count).Select(x => x % 101).ToList();
    }

    public IList<float> GetFloat(int count)
    {
        // Create a new instance of Random
        var ran = new Random(Next());

        // Create an array of numbers
        var numbers = Enumerable.Range(1, count << 1).Select(x => ran.NextSingle() * 100).ToArray();

        // Loop through the array from the last element to the second element
        for (var i = numbers.Length - 1; i > 0; i--)
        {
            // Pick a random index from 0 to i
            var j = ran.Next(i + 1);

            // Swap the elements at i and j
            (numbers[j], numbers[i]) = (numbers[i], numbers[j]);
        }

        // Take the first count elements of the shuffled array
        return numbers.Take(count).ToList();
    }

    public int Next(int max = 101)
    {
        return RandomNumberGenerator.GetInt32(1, max);
    }

    public float NextFloat(int max = 101)
    {
        return RandomNumberGenerator.GetInt32(1, max * max) * 1f / max;
    }

    public static int NextNonNegative(int max)
    {
        return RandomNumberGenerator.GetInt32(1, max);
    }
}
