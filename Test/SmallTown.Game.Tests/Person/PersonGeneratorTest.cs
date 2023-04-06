using Microsoft.Extensions.Options;
using SmallTown.Engine.Core;
using SmallTown.Game.Config;
using SmallTown.Game.Person;
using SmallTown.Game.Person.Name;

namespace SmallTown.Game.Tests.Person;
[TestClass]
public class PersonGeneratorTest
{
    [TestMethod]
    public void ConfigAge_ShouldAppendAgeAccordingToRandom()
    {
        var rates = Enumerable.Range(0, 10).Select(x => x * 10).ToList();

        _gameSettings.People.AgeTable = new Dictionary<int, float>
        {
            { 00, 0.1f },
            { 10, 0.2f },
            { 20, 0.4f },
            { 30, 0.5f },
            { 40, 0.7f },
            { 50, 0.8f },
            { 60, 0.9f },
            { 70, 1f }
        };
        _random.Setup(x => x.Get(It.IsAny<int>())).Returns(rates);

        var people = _objectUnderTest.Start(10).ConfigAge().Build().ToList();

        people.Count(x => x.Age == 0).Should().Be(2);
        people.Count(x => x.Age == 10).Should().Be(1);
        people.Count(x => x.Age == 20).Should().Be(2);
        people.Count(x => x.Age == 30).Should().Be(1);
        people.Count(x => x.Age == 40).Should().Be(2);
    }

    [TestInitialize]
    public void SetUp()
    {
        _random = new Mock<IRandom>();
        _nameManager = new Mock<INameManager>();
        var gameSettings = new Mock<IOptions<GameSettings>>();
        _gameSettings = new GameSettings { People = new PeopleSettings() };
        gameSettings.Setup(x => x.Value).Returns(_gameSettings);

        _objectUnderTest = new PersonGenerator(gameSettings.Object, _random.Object, _nameManager.Object);
    }

    private Mock<IRandom> _random;
    private Mock<INameManager> _nameManager;
    private GameSettings _gameSettings;
    private PersonGenerator _objectUnderTest;
}
