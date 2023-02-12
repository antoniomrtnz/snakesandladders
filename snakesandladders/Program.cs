namespace snakesandladders
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter Number of Players: ");
            int numberOfPlayers = int.Parse(Console.ReadLine());
            bool hasSomeoneWon = false;

            List<Player> players = new List<Player>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player("Player" + (i+1)));
            }

            Game game = new Game(players, new Board100Squares(), new RegularSixSidesDice());
            
            while (!hasSomeoneWon) { 
                foreach (Player player in game.Players)
                {
                    int positionsToMove = game.RollDice(player);
                    int positionAfterMoving = game.MoveToken(player, positionsToMove);

                    Console.WriteLine("Turn for " + player.NickName + " that has got " + positionsToMove + " rolling the dice.");
                    Console.WriteLine(player.NickName + " is now at position " + positionAfterMoving + ".");
                    Console.WriteLine("------------------------------------------------------------------");

                    if (game.IsWinner(player))
                    {
                        Console.WriteLine(player.NickName + " HAS WON THE GAME!!!!.");
                        hasSomeoneWon = true;
                    }
                }
            }
        }
    }
}