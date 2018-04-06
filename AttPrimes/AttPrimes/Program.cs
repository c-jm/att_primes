/*
 * Filename: Program.cs
 * 
 * Author(s): Kyle A. Kreutzer, Colin J. MIlls
 * 
 * 2018-04-06
 * 
 * Holds the definition for  testing the difference in timing between sequential and paralell processing of times.
 */

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AttPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage AttPrimes.exe [number_to_generate_to]");
                Environment.Exit(-1);
            }

            Int64 n = Convert.ToInt64(args[0]);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            for(int i = 0; i < n; ++i)
            {
                if(IsPrime((i + 1)))
                    Console.WriteLine("{0}", (i + 1));
            }
            sw.Stop();

            Console.WriteLine("Sequential Elapsed Time: {0}/ms", sw.ElapsedMilliseconds);


            sw.Reset();
            sw.Start();
            Parallel.For(0, n, index =>
            {
                if (IsPrime((index + 1)))
                {
                    Console.WriteLine("{0}", (index + 1));
                }

            });
            sw.Stop();
            Console.WriteLine("Parallel Elapsed Time: {0}/ms", sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Determines whether the specified number is prime.
        /// Taken and inspired by: https://stackoverflow.com/questions/5281779/c-how-to-test-easily-if-it-is-prime-number
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns>
        ///   <c>true</c> if the specified n is prime; otherwise, <c>false</c>.
        /// </returns>
        static bool IsPrime(long n)
        {
            bool result = true;

            if (n <= 1)
            {
                result = false;
            }
            else
            {
                if (n % 2 == 0 && n > 2)
                {
                    result = false;
                }
                else
                {
                    for(int i = 3; (i < n / 2); i += 2)
                    {
                        if (n % i == 0)
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }

            return result;
        }

    }
}
