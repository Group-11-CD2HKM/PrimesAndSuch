using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrimesAndSuch
{
    internal static class PrimeHelper
    {
        private static List<ulong> primes = new List<ulong>();
        private static object primesLock = new object();
        private static Thread PreCalculationThread;
        private static bool PreCalculationEnabled;
        private static bool PreCalculationPause;

        public static int PreCalculatedPrimesCount { get { return primes.Count; } }
        public static ulong GetPrecalculatedPrimeAtIndex(int i)
        {
            lock (primesLock) { return primes[i]; }
        }

        public static void PreCalculatePrimes()
        {
            PreCalculationEnabled = true;
            PreCalculationPause = false;
            PreCalculationThread = new Thread(new ThreadStart(PreCalculateThread));
            PreCalculationThread.Start();
        }
        public static void StopPrecalculatePrimes()
        {
            PreCalculationEnabled = false;
        }
        public static void PausePrecalculatePrimes()
        {
            PreCalculationPause = true;
        }
        public static void UnPausePrecalculatePrimes()
        {
            PreCalculationPause = false;
        }
        private static void PreCalculateThread()
        {
            uint i = 0;
            while (PreCalculationEnabled)
            {
                IsPrime(i);
                i++;
            }
        }
        public static bool IsPrime(ulong number)
        {
            bool returnValue = true;
            lock (primesLock)
            {
                if (primes.Contains(number))
                {
                    return true;
                }
            }
            if (number == 2)
            {
                returnValue = true;
            }
            else if (number % 2 == 0)
            {
                returnValue = false;
            }
            else
            {
                Parallel.ForEach(SteppedIterator(3, number / 2, 2), i =>
                {
                    if (number % (ulong)i == 0)
                    {
                        returnValue = false;
                    }
                });
            }
            if (!returnValue)
            {
                lock (primesLock)
                {
                    primes.Add(number);
                }
            }
            return returnValue;
        }
        private static IEnumerable<ulong> SteppedIterator(ulong startIndex, ulong endIndex, ulong stepSize)
        {
            for (ulong i = startIndex; i < endIndex; i = i + stepSize)
            {
                yield return i;
            }
        }
    }
}
