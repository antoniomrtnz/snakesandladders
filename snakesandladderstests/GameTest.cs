using Moq;
using snakesandladders;
using Xunit;

namespace snakesandladderstests;

public class GameTest
{
    private Player Player1 = new Player("player1");

    [Fact]
    public void WhenGameIsStartedTokenPositionsAreEqualTo1()
    {
        Game game = new Game(new List<Player> { Player1 }, new Board100Squares(), new RegularSixSidesDice());

        Assert.Equal(Board100Squares.INITIAL_SQUARE, game.GetTokenPosition(Player1));
    }

    [Fact]
    public void TokensCanMove()
    {
        Game game = new Game(new List<Player> { Player1 }, new Board100Squares(), new RegularSixSidesDice());

        game.MoveToken(Player1, 3);
        game.MoveToken(Player1, 4);

        Assert.Equal(Board100Squares.INITIAL_SQUARE+7, game.GetTokenPosition(Player1));
    }

    [Fact]
    public void PlayerWinsWhenItsTokenIsExactlyAtTheLastSquare()
    {
        Game game = new Game(new List<Player> { Player1 }, new Board100Squares(), new RegularSixSidesDice());

        game.MoveToken(Player1, Board100Squares.LAST_SQUARE-4);

        Assert.False(game.IsWinner(Player1));

        game.MoveToken(Player1, 3);

        Assert.True(game.IsWinner(Player1));
    }

    [Fact]
    public void TokenStaysAtTheSamePositionWhenItIsTriedToBeMovedBeyondLastSquare()
    {
        Game game = new Game(new List<Player> { Player1 }, new Board100Squares(), new RegularSixSidesDice());

        game.MoveToken(Player1, Board100Squares.LAST_SQUARE - 4);

        Assert.Equal(Board100Squares.LAST_SQUARE - 3, game.MoveToken(Player1, 4));
        Assert.False(game.IsWinner(Player1));
    }

    [Fact]
    public void RollDiceReturnsAResultBetween1And6Inclusive()
    {
        Game game = new Game(new List<Player> { Player1 }, new Board100Squares(), new RegularSixSidesDice());

        int diceResult = game.RollDice(Player1);

        Assert.True(1 <= diceResult  && diceResult <= 6);
    }

    [Fact]
    public void RollDiceDetermineTheNumberOfPositionsToMoveForThePlayerToken()
    {
        int diceResultStub = 4;
        Mock<IDice> diceMock = new Mock<IDice>();
        diceMock.Setup(x => x.Roll()).Returns(diceResultStub);

        Game game = new Game(new List<Player> { Player1 }, new Board100Squares(), diceMock.Object);

        Assert.Equal(Board100Squares.INITIAL_SQUARE + diceResultStub, game.MoveToken(Player1, game.RollDice(Player1)));
    }
}