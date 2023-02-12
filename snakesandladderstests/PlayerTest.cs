using Moq;
using snakesandladders;
using Xunit;

namespace snakesandladderstests;

public class PlayerTest
{
    [Fact]
    public void RollDiceShouldReturnTheValueProvidedByTheDice()
    {
        const int MOCK_VALUE = 5;
        Player player = new Player("player1");
        Mock<IDice> diceMock = new Mock<IDice>();
        diceMock.Setup(x => x.Roll()).Returns(MOCK_VALUE);

        Assert.Equal(MOCK_VALUE, player.RollDice(diceMock.Object));
    }   
}