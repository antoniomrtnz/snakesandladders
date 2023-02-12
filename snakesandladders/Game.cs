namespace snakesandladders
{
    public class Game
    {
        public readonly List<Player> Players;
        private readonly IDice _dice;
        private readonly IBoard _board;

        public Game(List<Player> players, IBoard board, IDice dice)
        {
            Players = players;
            _board = board;
            _board.AddTokenPlayers(players);
            _dice = dice;
        }

        public int GetTokenPosition(Player player)
        {
            return _board.GetTokenPosition(player);
        }

        public int MoveToken(Player player, int position)
        {
            return _board.MoveTokenPosition(player, position);
        }

        public bool IsWinner(Player player)
        {
            return _board.IsTokenAtLastSquare((player));
        }

        public int RollDice(Player player)
        {
            return player.RollDice(_dice);
        }
    }
}