namespace AdventOfCode.Day3
{
    internal class PriorityProvider
    {
        public static int GetPriorityOfItem(char item)
        {
            if (char.IsUpper(item))
            {
                var position = item - 64;
                return position + 26;
            }

            return item - 96;
        }
    }
}
