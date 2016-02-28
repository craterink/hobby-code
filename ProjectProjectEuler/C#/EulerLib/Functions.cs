using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;

namespace EulerLib
{
    //TODO: Implement "best times" Json file
    public static class Euler
    {
        public delegate String ProblemMethod();

        public static void RunProblem(ProblemMethod problem)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            String output = problem();

            time.Stop();
            Console.WriteLine("Problem: " + Regex.Match(problem.Method.ToString(), "[a-zA-Z0-9]+\\(").ToString().Replace("(", ""));
            Console.WriteLine("Output: " + output);
            Console.WriteLine("Time Elapsed: " + time.ElapsedMilliseconds + " ms");
            Console.ReadKey();
        }
    }

    public static class Primes
    {
        public static List<long> findPrimes(Func<long, long, bool> logicFunc)
        {
            List<long> primes = new List<long>();
            primes.Add(2);
            long index = 2, cand = 3;
            while (logicFunc(index, cand))
            {
                bool p = true;
                foreach(long prime in primes)
                {
                    if (Fn.isFactor(prime, cand)) {
                        p = false;
                        break;
                    }
                }
                if(p)
                {
                    primes.Add(cand);
                    index += 1;
                }
                cand += 2;
            }
            return primes;
        }

        public static List<long> primeFactors(long number)
        {
            List<long> factors = Fn.findFactors(number);
            List<long> primes = findPrimes((n, pr) => pr <= factors.Last());
            return primes.Intersect(factors).ToList();
        }

        public static long nthPrime(long n)
        {
            return findPrimes((ind, pr) => ind <= n).Last();
        }

        public static bool isPrime(long number)
        {
            List<long> primesRange = findPrimes((ind, pr) => pr <= Math.Sqrt(number));
            for (int i = 0; i < primesRange.Count; i++)
            {
                if (Fn.isFactor(primesRange.ElementAt(i), number)) return false;
            }
            return true;
        }
    }

    public static class Fn
    {
        /// <summary>
        /// Returns a certain indexed fibonacci number
        /// </summary>
        /// <param name="index">Index (where first Fib number is index 1)</param>
        /// <returns></returns>
        public static int fib(int index)
        {
            if (index < 3) return 1;
            int back1 = 1, back2 = 1, current = 0;
            for (int i = 3; i <= index; i++)
            {
                current = back1 + back2;
                back2 = back1;
                back1 = current;
            }
            return current;
        }

        /// <summary>
        /// Is a number even
        /// </summary>
        /// <param name="num">Any integer num</param>
        /// <returns>Whether num is even</returns>
        public static bool even(int num)
        {
            return (num / 2) == ((double)num) / 2.0;
        }

        public static List<long> findFactors(long number)
        {
            List<long> factors = new List<long>();
            long end = number;
            for (long i = 2; i < end; i += 1)
            {
                if (isFactor(i, number))
                {
                    factors.Add(i);
                    factors.Add(number / i);
                    end = number / i;
                }
            }
            factors.Sort();
            return factors;
        }
        public static bool isFactor(long factor, long number)
        {
            return number % factor == 0;
        }

        public static bool isPalindromic(long number)
        {
            Char[] num = Math.Abs(number).ToString().ToCharArray();
            int length = num.Length;
            for(int i = 0; i <= length / 2; i++)
            {
                if (!num[i].Equals(num[length - i - 1])) return false;
            }
            return true;
        }

        public static long sumRange(long start, long end)
        {
            long sum = 0;
            for(long i = start; i <= end; i++)
            {
                sum += i;
            }
            return sum;
        }

        public static long sumSquaresInRange(long start, long end)
        {
            long sum = 0;
            for (long i = start; i <= end; i++)
            {
                sum += i*i;
            }
            return sum;
        }

        public static bool isPythagTriplet(long a, long b, long c)
        {
            return a * a + b * b == c * c;
        }
        
        public static long prod13digits(String thirteen)
        {
            long prod = 1;
            foreach(char c in thirteen.ToCharArray())
            {
                prod *= Int32.Parse(c.ToString());
            }
            return prod;
        }
    }

    public static class IO
    {
        public static String getTextFile(String fileName)
        {
            return File.ReadAllText(@"C:\Users\Cooper\Documents\Programming\Project Euler\Euler\" + fileName);
        }
    }

}
