namespace DynamicProgramming
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int result = GetNumber(n, k);
            Console.WriteLine(result);
        }

        public static int GetNumber(int x, int y)
        {
            if ((x + 1) == 1 || (y + 1) == 1 || x == y)
            {
                return 1;
            }
            else
            {
                return GetNumber(x - 1, y - 1) + GetNumber(x - 1, y);
            }
        }
    }
}
