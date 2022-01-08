using System.Numerics;
using System;

namespace AKS.Services
{
    public class AKSService
    {

        /**
        * @brief Step 1 - If n = a^b for integers a > 1 and b > 1, output composite
        */
        static private bool test1(BigInteger n, ref bool isPrime)
        {

            isPrime = true;

            const double EPSILON = 1E-10;
            for (double b = 2; b < BigInteger.Log(n, 2); ++b)
            {
                var a = Math.Exp(BigInteger.Log(n) / b);
                if (Math.Abs(Math.Floor(a) - a) < EPSILON)
                {
                    isPrime = false;
                    return false;
                }
            }

            return true;
        }

        /**
        * @brief Step 2 - Find the smallest r such that Or(n) > (log2 n)^2
        */
        static private BigInteger step2(BigInteger n)
        {

            BigInteger maxk = new BigInteger(Math.Floor(Math.Pow(BigInteger.Log(n, 2), 2)));
            BigInteger maxr = new BigInteger(Math.Max(3.0, Math.Ceiling(Math.Pow(BigInteger.Log(n, 2), 5))));
            bool nextR = true;
            BigInteger r = 0;

            for (r = 2; nextR && r < maxr; ++r)
            {
                nextR = false;
                for (BigInteger k = 1; (!nextR) && k < maxk; ++k)
                {
                    BigInteger mod = BigInteger.ModPow(n, k, r);
                    nextR = mod == 1 || mod == 0;
                }
            }
            --r;

            return r;
        }

        /**
        * @brief Step 3 - If 1 < gcd(a,n) < n for some a ≤ r, output composite
        */
        static private bool test3(BigInteger n, BigInteger r, ref bool isPrime)
        {

            isPrime = true;

            for (BigInteger i = r; i > 1; --i)
            {
                BigInteger gcd = BigInteger.GreatestCommonDivisor(i, n);

                if (1 < gcd && gcd < n)
                {
                    isPrime = false;
                    return false;
                }
            }

            return true;
        }

        /**
        * @brief Step 4 - If n ≤ r, output prime
        */
        static private bool test4(BigInteger n, BigInteger r, ref bool isPrime)
        {
            isPrime = (n <= r);
            return !isPrime;
        }

        /**
        * @brief Step 5 - check that for every coeficient (ai) in (x-1)^n ai%n == 0
        */
        static private bool test5(BigInteger n, ref bool isPrime)
        {
            isPrime = true;

            BigInteger current = 1;

            for (BigInteger i = 1; i < n / 2 + 1; ++i)
            {
                current *= n + 1 - i;
                current /= i;

                if (current % n != 0)
                {
                    isPrime = false;
                    return false;
                }
            }

            return true;
        }

        static public bool IsPrime(BigInteger candidate)
        {
            bool isPrime = true;

            if (!test1(candidate, ref isPrime)) return isPrime;

            Console.WriteLine("Test 1 finished");

            BigInteger r = step2(candidate);

            Console.WriteLine("Step 2 finished");

            if (!test3(candidate, r, ref isPrime)) return isPrime;

            Console.WriteLine("Test 3 finished");

            if (!test4(candidate, r, ref isPrime)) return isPrime;

            Console.WriteLine("Test 4 finished");

            if (!test5(candidate, ref isPrime)) return isPrime;

            Console.WriteLine("Test 5 finished");

            // test5(candidate, ref isPrime);

            // Step 6 -  Output prime
            return isPrime;
        }
    }
}