using Microsoft.Extensions.Options;
using SmallTown.Engine.Core;
using SmallTown.Game.Config;
using SmallTown.Game.Person;

namespace SmallTown.Game.Tests.Person;
[TestClass]
public class PersonGeneratorTest
{
    [TestMethod]
    public void ConfigSex_ShouldAppendSexAccordingToRandom()
    {
        var sexRate = Enumerable.Range(0, 10).Select(x => x * 10).ToList();

        _gameSettings.People.SexRate = 52;
        _random.Setup(x => x.Get(It.IsAny<int>())).Returns(sexRate);

        var people = _objectUnderTest.Start(10).ConfigSex().Build().ToList();

        people.Take(6).Should().OnlyContain(x => x.Sex == Sex.Male);
        people.Skip(6).Should().OnlyContain(x => x.Sex == Sex.Female);
    }

    [TestInitialize]
    public void SetUp()
    {
        _random = new Mock<IRandom>();

        var gameSettings = new Mock<IOptions<GameSettings>>();
        _gameSettings = new GameSettings { People = new PeopleSettings() };
        gameSettings.Setup(x => x.Value).Returns(_gameSettings);

        _objectUnderTest = new PersonGenerator(gameSettings.Object, _random.Object);
    }

    private Mock<IRandom> _random;
    private GameSettings _gameSettings;
    private PersonGenerator _objectUnderTest;
}
