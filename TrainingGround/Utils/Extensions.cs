using System;

namespace TrainingGround.Utils
{
    public static class Extensions
    {
        public static void TestMethod()
        {
            var text = "something";
            if (NotEmpty(text))
            {
                Console.WriteLine(text);
            }
        }

        public static bool Empty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool NotEmpty(this string value)
        {
            return !value.Empty();
        }
    }
}
