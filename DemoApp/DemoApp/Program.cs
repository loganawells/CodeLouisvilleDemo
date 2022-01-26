using System;
using System.Text;

namespace DemoApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string fullAlphabet = GenerateAlphabetString();
			string backwardAlphabet = GenerateBackwardAlphabetString();
			string skippedAlphabet = GenerateSkippedAlphabetString();

			Console.WriteLine($"Full alphabet: {fullAlphabet}");
			Console.WriteLine($"Backward alphabet: {backwardAlphabet}");
			Console.WriteLine($"Skipped alphabet: {skippedAlphabet}");
		}

		private static string GenerateAlphabetString()
		{
			var alphabet = new StringBuilder();

			for (char letter = 'A'; letter <= 'Z'; letter++)
			{
				alphabet.Append(letter);
			}

			return alphabet.ToString();
		}

		private static string GenerateBackwardAlphabetString()
		{
			var alphabet = new StringBuilder();

			for (char letter = 'Z'; letter >= 'A'; letter--)
			{
				alphabet.Append(letter);
			}

			return alphabet.ToString();
		}

		private static string GenerateSkippedAlphabetString()
		{
			var alphabet = new StringBuilder();

			for (char letter = 'A'; letter <= 'Z'; letter++, letter++)
			{
				alphabet.Append(letter);
			}

			return alphabet.ToString();
		}
	}
}