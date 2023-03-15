using SmallTown.Game.Record;

namespace SmallTown.Game.Tests;

[TestClass]
public class RecordStorageTest
{
    [TestMethod]
    public void Add_ShouldAddCorrectly_Gives42()
    {
        var record = new Record.Record
        {
            Id = 42,
            EventId = 42,
        };

        _objectUnderTest.Add(record);

        _objectUnderTest.Record.Should().BeNull();
        _objectUnderTest.Postfix[2].Should().NotBeNull();
        _objectUnderTest.Postfix[2].Record.Should().BeNull();
        _objectUnderTest.Postfix[2].Postfix[4].Record.Should().Be(record);
    }

    [TestMethod]
    public void Add_ShouldAddCorrectly_Gives10()
    {
        var record = new Record.Record
        {
            Id = 10,
            EventId = 10,
        };

        _objectUnderTest.Add(record);

        _objectUnderTest.Record.Should().BeNull();
        _objectUnderTest.Postfix[0].Should().NotBeNull();
        _objectUnderTest.Postfix[0].Record.Should().BeNull();
        _objectUnderTest.Postfix[0].Postfix[1].Record.Should().Be(record);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(42)]
    [DataRow(65536)]
    public void Get_ShouldRetrieveStoredValue(int id)
    {
        var record = new Record.Record
        {
            Id = id
        };

        _objectUnderTest.Add(record);

        var get = _objectUnderTest.Get(id);

        get.Should().Be(record);
    }

    [TestInitialize]
    public void SetUp()
    {
        _objectUnderTest = new RecordStorage();
    }

    private RecordStorage _objectUnderTest;
}