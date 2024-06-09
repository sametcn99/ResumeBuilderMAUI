namespace ResumeBuilderMAUI.Helpers
{
    internal class Generators
    {
        public static int RandomNumber()
        {
            int digitCount = 6;
            int minValue = (int)Math.Pow(10, digitCount - 1);
            int maxValue = (int)Math.Pow(10, digitCount);
            Random random = new Random();
            return random.Next(minValue, maxValue);
        }
    }
}
