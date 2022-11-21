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

		public static List<uint> Primes
		{
			get { return primes; }
		}

		public static bool IsPrime(uint number)
		{
			if (primes.Contains(number))
			{
				return true;
			}
			for (int i = 2; i < number; i++)
			{
				if (number % i == 0)
				{
					return false;
				}
			}
			primes.Add(number);
			return true;
		}
	}
}
