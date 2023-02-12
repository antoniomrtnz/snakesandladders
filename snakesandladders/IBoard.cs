namespace snakesandladders
{
    public interface IBoard
    {
        void AddTokenPlayers(List<Player> players);
        int GetTokenPosition(Player player);
        int MoveTokenPosition(Player player, int positions);
        bool IsTokenAtLastSquare(Player player);
    }
}
