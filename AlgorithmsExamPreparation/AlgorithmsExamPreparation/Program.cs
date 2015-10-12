namespace AlgorithmsExamPreparation
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] cn = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            string[] proba = Console.ReadLine().Split(' ');
            int arrayLenght = proba.Length;
            int[] array = new int[arrayLenght];

            int minNumber = Int32.MaxValue;
            int maxNumber = Int32.MinValue;
            int maxNumberPosition = -1;

            for (int i = 0; i < arrayLenght; i++)
            {
                int current = int.Parse(proba[i]);
                if (current < minNumber && current != 0)
                {
                    minNumber = current;
                }
                if (maxNumber <= current && current != 0)
                {
                    maxNumber = current;
                    maxNumberPosition = i;
                }
                array[i] = current;
            }

            int[] needles = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < needles.Length; i++)
            {
                int needle = needles[i];
                if (needle <= minNumber)
                {
                    Console.Write(0 + " ");
                    continue;
                }
                else if (needle > maxNumber)
                {
                    Console.Write(maxNumberPosition + 1 + " ");
                    continue;
                }
                for (int j = 0; j < arrayLenght; j++)
                {
                    if (needle == array[j])
                    {
                        while (array[j - 1] == 0)
                        {
                            j--;
                        }

                        Console.Write(j + " ");
                        break;
                    }
                    else if (array[j] > needle)
                    {
                        while (array[j - 1] == 0)
                        {
                            j--;
                        }

                        Console.Write(j + " ");
                        break;
                    }
                }
            }

        }
    }
}
