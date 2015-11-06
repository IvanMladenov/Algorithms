namespace EgyptianFractions
{
    using System;
    using System.Collections.Generic;

    class FractionsProgram
    {
        private static List<Fraction> result = new List<Fraction>();

        static void Main(string[] args)
        {
            string[] inputParams = Console.ReadLine().Split('/');
            if (int.Parse(inputParams[0]) >= int.Parse(inputParams[1]))
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            Fraction target = new Fraction(int.Parse(inputParams[0]), int.Parse(inputParams[1]));
            Fraction bigestEgyptian = new Fraction(1, 2);

            CalculateFractions(target, bigestEgyptian);

            Console.WriteLine("{0} = {1}", target, string.Join(" + ", result));
        }

        private static void CalculateFractions(Fraction target, Fraction fraction)
        {
            while (target.CompareTo(fraction) != 0)
            {
                if (target.CompareTo(fraction)<0)
                {
                    while (target.CompareTo(fraction)<0)
                    {
                        Fraction newFraction = new Fraction(fraction.Nominator, fraction.Denominator+1);
                        fraction = newFraction;
                    }
                }
                else
                {
                    result.Add(fraction);
                    target = target - fraction;
                }
            }

            result.Add(fraction);
        }

        //WORKS BUT STACKOVERFLOW WITH THIS RECURSIVE METHOD ON BIGEST DENOMINATORS
        //private static void CalculateFractions(Fraction target, Fraction fraction)
        //{
        //    if (target.CompareTo(fraction)==0)
        //    {
        //        result.Add(fraction);
        //        return;
        //    }

        //    if (target.CompareTo(fraction)<0)
        //    {
        //        CalculateFractions(target, new Fraction(fraction.Nominator, fraction.Denominator+1));
        //    }
        //    else
        //    {
        //        result.Add(fraction);
        //        Fraction redused = target - fraction;
        //        CalculateFractions(redused, fraction);
        //    }
        //}
    }
}
