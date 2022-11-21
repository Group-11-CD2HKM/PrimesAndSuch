// See https://aka.ms/new-console-template for more information
using PrimesAndSuch;
using System.Numerics;

bool exit = false;
bool notANumber = false;
string input;
ulong number = 0;
//PrimeHelper.PreCalculatePrimes();
while (!exit)
	{
	Console.Write("Write a number (type \"exit\" to exit, \"print\" to print all primes): ");
    input = Console.ReadLine();
	try
	{
		notANumber = false;
		number = ulong.Parse(input);
	}
	catch (Exception)
	{
		Console.WriteLine("Not a number.");
		notANumber = true;
	}
	finally
	{
		if (!notANumber)
		{
			if (PrimeHelper.IsPrime(number))
			{
				Console.WriteLine($"{number} is prime.");
			}
			else
			{
				Console.WriteLine($"{number} is not prime.");
			}
		}
		else
		{
			if (input.Contains("exit"))
			{
				exit = true;
			} else if (input.Contains("print"))
			{
				Console.Clear();
				Console.WriteLine("Current precalculated primes:");
				for (int i = 0; i < PrimeHelper.PreCalculatedPrimesCount; i+=20)
				{
					for (int j = 0; j < 20 && j + i < PrimeHelper.PreCalculatedPrimesCount; j++)
					{
						Console.WriteLine($"{PrimeHelper.GetPrecalculatedPrimeAtIndex(i + j)}");
					}
					Console.WriteLine("Enter to continue.");
					Console.ReadLine();
				}
			}
		}
	}
}
PrimeHelper.StopPrecalculatePrimes();