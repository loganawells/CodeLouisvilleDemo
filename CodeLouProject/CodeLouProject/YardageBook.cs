using CodeLouisvilleLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeLouProject
{
	internal class YardageBook : CodeLouisvilleAppBase
	{
		List<GolfClub>? golfBag;

		public YardageBook(string appName) : base(appName)
		{
			string jsonString = File.ReadAllText(@"C:\Users\Logan\source\repos\CodeLouisvilleDemo\CodeLouProject\clubs.json");
			golfBag = JsonSerializer.Deserialize<List<GolfClub>>(jsonString);
		}

		protected override bool Main()
		{
			DisplayHeaderMenu();

			var menu = new List<KeyValuePair<int, string>>();
			menu.Add(new KeyValuePair<int, string>(1, "View yardages"));
			menu.Add(new KeyValuePair<int, string>(2, "Update club yardage"));
			menu.Add(new KeyValuePair<int, string>(9, "Exit"));

			int selection = Prompt4MenuItem<int>("What would you like to do? Please select a number:", menu);
			Console.WriteLine();

			switch (selection)
			{
				case 0:
					Console.WriteLine("Selection was not recognized. Bad user.");
					ReturnToMenu();
					break;
				case 1:
					RunViewOption();
					break;
				case 2:
					RunUpdateOption();
					break;
				case 9:
					return false;
				default:
					Console.Clear();
					break;
			}

			return true;
		}

		private void DisplayHeaderMenu()
		{
			Console.WriteLine("**************************************************");
			Console.WriteLine("*******    Welcome to your Yardage Book    *******");
			Console.WriteLine("**************************************************");
			Console.WriteLine();
		}
		private void ReturnToMenu()
		{
			Console.WriteLine("Press any key to return to the menu...");
			Console.ReadLine();
			Console.Clear();
		}

		private void RunViewOption()
		{
			if (golfBag is not null)
			{
				foreach (GolfClub club in golfBag)
				{
					Console.WriteLine($"{club.Name}: {club.Yardage}");
				}
			}
			
			ReturnToMenu();
		}

		private void RunUpdateOption()
		{
			Console.WriteLine("Update selected");
			ReturnToMenu();
		}
	}
}
