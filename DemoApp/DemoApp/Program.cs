using System;
using System.Text;

namespace DemoApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string alphabet = GenerateAlphabetString();

			Console.WriteLine(alphabet);
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
	}
}