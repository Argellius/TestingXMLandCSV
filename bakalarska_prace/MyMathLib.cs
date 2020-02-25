using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace
{
    static class MyMathLib
    {

        //směrodatná odchylka
        public static double GetStandardDeviation(IEnumerable<double> values)
        {
            double ret = 0;
            int count = values.Count();
            if (count > 1)
            {
                //Compute the Average
                double avg = values.Average();

                //Perform the Sum of (value-avg)^2
                double sum = values.Sum(d => (d - avg) * (d - avg));

                //Put it all together
                ret = Math.Sqrt(sum / count);
            }
            return Math.Round(ret, 5);
        }

        public static double GetMedian(IEnumerable<double> source)
        {
            // Create a copy of the input, and sort the copy
            double[] temp = source.ToArray();
            Array.Sort(temp);

            int count = temp.Length;
            if (count == 0)
            {
                throw new InvalidOperationException("Empty collection");
            }
            else if (count % 2 == 0)
            {
                // count is even, average two middle elements
                double a = temp[count / 2 - 1];
                double b = temp[count / 2];
                return Math.Round((a + b) / 2.0, 5);
            }
            else
            {
                // count is odd, return the middle element
                return Math.Round(temp[count / 2], 5);
            }
        }

        //průměr
        public static double GetAverage(IEnumerable<double> source)
        {
            return Math.Round(source.Average(), 5);
        }

        //rozptyl
        public static double GetVariance(IEnumerable<double> source)
        {
            double variance = 0;

            for (int i = 0; i < source.Count(); i++)
            {
                variance += Math.Pow((source.ElementAt(i) - GetAverage(source)), 2.0);
            }

            return Math.Round(variance / source.Count());

        }

        //vrátí velikost za jednu sekundu
        public static double GetPomer1s(double time, double size)
        {
            return Math.Round(size / time, 5);
        }

    }
}
