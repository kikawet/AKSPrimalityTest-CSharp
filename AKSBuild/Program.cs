using System;
using System.Numerics;
using System.Diagnostics;
using AKS.Services;

namespace AKSBuild
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            BigInteger candidate = BigInteger.Parse(args[0]);//BigInteger.Parse("35201546659608842026088328007565866231962578784643756647773109869245232364730066609837018108561065242031153677");

            sw.Stop();

            Console.WriteLine("Parse took: {0}ms", sw.Elapsed.TotalMilliseconds);

            sw = Stopwatch.StartNew();

            bool isPrime = AKSService.IsPrime(candidate);

            sw.Stop();

            Console.WriteLine($"Check it took {sw.Elapsed.TotalSeconds}s candidate is {(isPrime ? "":"not ")}PRIME!!");
        }
    }
}
