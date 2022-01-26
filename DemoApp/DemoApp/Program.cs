using System;
using System.Text;
using DemoApp.Utilities;

namespace DemoApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string fullAlphabet = AlphabetUtility.GenerateAlphabetString();
			string backwardAlphabet = AlphabetUtility.GenerateBackwardAlphabetString();
			string skippedAlphabet = AlphabetUtility.GenerateSkippedAlphabetString();

			Console.WriteLine($"Full alphabet: {fullAlphabet}");
			Console.WriteLine($"Backward alphabet: {backwardAlphabet}");
			Console.WriteLine($"Skipped alphabet: {skippedAlphabet}");
		}
	}
}