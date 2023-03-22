using SmallTown.Engine.Core;

namespace SmallTown.Engine.Tests;

[TestClass]
public class SmallRandomTest
{
    [TestMethod]
    public void Get_ShouldCorrectGetLength()
    {
        var result = _objectUnderTest.Get(1000);

        result.Count.Should().Be(1000);
        result.Should().OnlyContain(x => x <= 100);
    }

    [TestInitialize]
    public void SetUp()
    {
        _objectUnderTest = new SmallRandom();
    }

    private SmallRandom _objectUnderTest;
}