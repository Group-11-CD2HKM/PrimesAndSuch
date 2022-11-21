// See https://aka.ms/new-console-template for more information
using PrimesAndSuch;

bool exit = false;
bool notANumber = false;
string input;
uint number = 0;
PrimeHelper.PreCalculatePrimes();
while (!exit)
{
	Console.Write("Write a number (type \"exit\" to exit): ");
    input = Console.ReadLine();
    input = Console.ReadLine();
	try
	{
		notANumber = false;
		number = uint.Parse(input);
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
			}
		}
	}
}
PrimeHelper.StopPrecalculatePrimes();