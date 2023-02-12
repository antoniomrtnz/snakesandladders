namespace snakesandladders
{
    public class Board100Squares : IBoard
    {
        public const int LAST_SQUARE = 100;
        public const int INITIAL_SQUARE = 1;
        private Dictionary<Player, int> PlayerTokenPositions = new Dictionary<Player, int>();

        public void AddTokenPlayers(List<Player> players)
        {
            foreach (Player player in players)
            {
                PlayerTokenPositions.Add(player, INITIAL_SQUARE);
            }
        }

        public int GetTokenPosition(Player player)
        {
            return this.PlayerTokenPositions[player];
        }

        public int MoveTokenPosition(Player player, int positions)
        {
            int positionBeforeMoving = this.PlayerTokenPositions[player];

            if (positionBeforeMoving + positions <= LAST_SQUARE)
            {
                return this.PlayerTokenPositions[player] += positions;
            }
            else
            {
                return positionBeforeMoving;
            }
        }

        public bool IsTokenAtLastSquare(Player player)
        { 
            return this.GetTokenPosition(player) == LAST_SQUARE;
        }
    }
}