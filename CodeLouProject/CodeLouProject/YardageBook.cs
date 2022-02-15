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
		string clubFile = @"C:\Users\Logan\source\repos\CodeLouisvilleDemo\CodeLouProject\clubs.json";
		List<GolfClub>? golfBag;

		public YardageBook(string appName) : base(appName)
		{
			string jsonString = File.ReadAllText(clubFile);
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
			Console.WriteLine("***********      My Yardage Book      ************");
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
			var updateMenu = new List<KeyValuePair<int, string>>();

			if (golfBag is not null)
			{
				for (int i = 1; i <= golfBag.Count; i++)
				{
					updateMenu.Add(new KeyValuePair<int, string>(i, $"{golfBag[i - 1].Name} ({golfBag[i - 1].Yardage})"));
				}
			}

			int selection = Prompt4MenuItem<int>("Select a club to update:", updateMenu);
			int yardage = Prompt4Integer($"Enter new {golfBag[selection - 1].Name} yardage: ");
			golfBag[selection - 1].Yardage = yardage;

			try
			{
				string jsonString = JsonSerializer.Serialize(golfBag);
				File.WriteAllText(clubFile, jsonString);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Something went wrong trying to save the file: {ex.Message}");	
			}

			Console.WriteLine($"\nSuccessfully updated {golfBag[selection - 1].Name} to {yardage}.");
			ReturnToMenu();
		}
	}
}
