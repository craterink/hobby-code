using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using EulerLib;

namespace Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            //Euler.RunProblem(Problem1);
            //Euler.RunProblem(Problem2);
            //Euler.RunProblem(Problem3);
            //Euler.RunProblem(Problem4);
            //Euler.RunProblem(Problem5);
            //Euler.RunProblem(Problem7);
            Euler.RunProblem(Problem8);
            //Euler.RunProblem(Problem9);
            //Euler.RunProblem(Problem10);
        }

        //TODO
        public static String Problem1()
        {
            return "";
        }

        public static String Problem2()
        {
            int MAX = 4000000;

            int value = 0, sum = 0, i = 3;
            while (value <= MAX)
            {
                value = Fn.fib(i++);
                if (value > MAX) break;
                if (Fn.even(value))
                {
                    sum += value;
                }
            }

            return sum.ToString();
        }

        public static String Problem3()
        {
            long NUM = 600851475143;
            long NUM_T = 1319573735;

            List<long> factors = Fn.findFactors(NUM);
            return factors.FindLast(f => Primes.isPrime(f)).ToString();
        }

        public static String Problem4()
        {
            long largest = 0;
            for(int i = 999; i >= 100; i--)
            {
                for (int j = 999; j >= 100; j--)
                {
                    if(i*j > largest && Fn.isPalindromic(i*j))
                    {
                        largest = i * j;
                    }
                }
            }
            return largest.ToString();
        }

        public static String Problem5()
        {
            //TODO: implement divisor methods?
            return (5 * 7 * Math.Pow(3, 2) * 11 * 13 * Math.Pow(2,4) * 17 * 19).ToString();
        }

        public static String Problem6()
        {
            return (Math.Pow(Fn.sumRange(1, 100), 2) - Fn.sumSquaresInRange(1, 100)).ToString();
        }

        public static String Problem7()
        {
            List<long> list = Primes.findPrimes((n, pr) => n <= 10001);
            return list.Last().ToString();
        }

        public static String Problem8()
        {
            String number = IO.getTextFile("Problem8.txt");
            number = number.Replace("\r\n", "");
            long max = 0;
            for(int i = 0; i < number.Length - 13; i++)
            {
                if ((Fn.prod13digits(number.Substring(i, 13))) > max)
                {
                    max = Fn.prod13digits(number.Substring(i, 13));
                }
            }
            return max.ToString();
        }

        public static String Problem9()
        {
            for(int i = 1; i <= 1000; i++)
            {
                for (int j = i; j <= 1000; j++)
                {
                    for (int k = j; k <= 1000; k++)
                    {
                        if (i + j + k == 1000 && Fn.isPythagTriplet(i, j, k))
                            return "" + i*j*k;
                    }
                }
            }
            return "Nothing found.";
        }

        public static String Problem10()
        {
            List<long> list = Primes.findPrimes((n, pr) => pr < 2000000);
            long sum = 0;
            foreach(long l in list)
            {
                sum += l;
            } 
            return sum.ToString();
        }
    }
}
