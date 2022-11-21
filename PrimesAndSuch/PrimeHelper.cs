using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesAndSuch
{
    internal static class PrimeHelper
    {
        private static List<uint> primes = new List<uint>();
        private static object primesLock = new object();
        private static Thread PreCalculationThread;
        private static bool PreCalculationEnabled;

        public static List<uint> Primes
        {
            get { return primes; }
        }
        public static void PreCalculatePrimes()
        {
            PreCalculationEnabled = true;
            PreCalculationThread = new Thread(new ThreadStart(PreCalculateThread));
            PreCalculationThread.Start();
        }
        public static void StopPrecalculatePrimes()
        {
            PreCalculationEnabled = false;
        }
        private static void PreCalculateThread()
        {
            uint i = 0;
            while (PreCalculationEnabled)
            {
                if (IsPrime(i))
                {
                    lock (primesLock)
                    {
                        primes.Add(i);
                    }
                }
                i++;
            }
        }
        public static bool IsPrime(uint number)
        {
            lock (primesLock)
            {
                if (primes.Contains(number))
                {
                    return true;
                }
            }
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            lock (primesLock)
            {
                primes.Add(number);
            }
            return true;
        }
    }
}
