namespace snakesandladders
{
	public class Player
	{
		public string NickName { get; private set; }
		public Player(string nickName)
		{
			this.NickName = nickName;
		}

		public int RollDice(IDice dice)
		{
			return dice.Roll();
		}
	}
}