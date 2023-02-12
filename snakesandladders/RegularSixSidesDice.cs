namespace snakesandladders
{
    public class RegularSixSidesDice : IDice
    {
        private const int NUMBER_OF_SIDES = 6;
        private static Random _random = new Random();

        public int Roll()
        {
            return _random.Next(NUMBER_OF_SIDES) + 1;
        }
    }
}