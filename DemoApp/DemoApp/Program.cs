using System;
using System.Text;
using DemoApp.Utilities;

namespace DemoApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DisplayMenu();
			string userInput = Console.ReadLine().ToLower();

			while (userInput != "q")
			{
				switch (userInput)
				{
					case "1":
						Console.WriteLine(AlphabetUtility.GenerateAlphabetString());
						break;
					case "2":
						Console.WriteLine(AlphabetUtility.GenerateBackwardAlphabetString());
						break;
					case "3":
						Console.Write("Print every Nth letter. Enter a value for N: ");
						string skipInput = Console.ReadLine();
						Console.WriteLine($"Not implemented. Printing every 2nd letter...");
						Console.WriteLine(AlphabetUtility.GenerateSkippedAlphabetString());
						break;
					default:
						break;
				}

				Console.WriteLine("Press enter to return to the menu.");
				Console.ReadLine();
				Console.Clear();
				DisplayMenu();
				userInput = Console.ReadLine().ToLower();
			}
		}

		static void DisplayMenu()
		{
			Console.WriteLine("Welcome to the Code Louisville Alphabet Demo App!");
			Console.WriteLine("Options:");
			Console.WriteLine("  1 - Print full alphabet");
			Console.WriteLine("  2 - Print full alphabet backwards");
			Console.WriteLine("  3 - Print alphabet every Nth letter");
			Console.WriteLine("  q - Exit");
			Console.Write("Enter your selection: ");
		}
	}
}