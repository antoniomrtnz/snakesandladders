using snakesandladders;
using Xunit;

namespace snakesandladderstests;

public class Board100SquaresTest
{
    private static readonly Player Player1 = new Player("player1");
    private static readonly List<Player> Players = new List<Player> { Player1 };

    [Fact]
    public void GetTokenPositionShouldReturnTheTokenPosition()
    {
        Board100Squares board = new Board100Squares();
        board.AddTokenPlayers(Players);

        Assert.Equal(Board100Squares.INITIAL_SQUARE, board.GetTokenPosition(Player1));
    }

    [Fact]
    public void MoveTokenPositionShouldUpdateTheTokenWithNewPositionWhenMovingInsideTheBoard()
    {
        Board100Squares board = new Board100Squares();
        board.AddTokenPlayers(Players);

        board.MoveTokenPosition(Player1, 3);
        board.MoveTokenPosition(Player1, 4);

        Assert.Equal(8, board.GetTokenPosition(Player1));
    }

    [Fact]
    public void MoveTokenPositionShouldNotChangeTokenPositionWhenTryingToMoveItBeyondLastSquare()
    {
        Board100Squares board = new Board100Squares();
        board.AddTokenPlayers(Players);

        int positionBefore = board.MoveTokenPosition(Player1, Board100Squares.LAST_SQUARE-4);

        Assert.Equal(positionBefore, board.MoveTokenPosition(Player1, 4));
    }

    [Fact]
    public void IsTokenAtLastSquareShouldReturnTrueWhenTheTokenIsAtLastSquare()
    {
        Board100Squares board = new Board100Squares();
        board.AddTokenPlayers(Players);

        board.MoveTokenPosition(Player1, Board100Squares.LAST_SQUARE - 1);

        Assert.True(board.IsTokenAtLastSquare(Player1));
    }

    [Fact]
    public void IsTokenAtLastSquareShouldReturnFalseWhenTheTokenIsNotAtLastSquare()
    {
        Board100Squares board = new Board100Squares();
        board.AddTokenPlayers(Players);

        board.MoveTokenPosition(Player1, Board100Squares.LAST_SQUARE - 2);

        Assert.False(board.IsTokenAtLastSquare(Player1));
    }
}