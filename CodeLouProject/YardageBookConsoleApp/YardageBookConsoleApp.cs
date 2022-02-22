using CodeLouisvilleLibrary;
using System;
using System.Collections.Generic;
using YardageBook;

namespace YardageBookConsoleApp
{
    public class YardageBookConsoleApp : CodeLouisvilleAppBase
    {
        private GolfBag golfBag;

        public YardageBookConsoleApp(string saveFilePath) : base("Yardage Book")
        {
            golfBag = new GolfBag(saveFilePath);
        }

        protected override bool Main()
        {
            DisplayHeaderMenu();

            var menu = new List<KeyValuePair<int, string>>();
            menu.Add(new KeyValuePair<int, string>(1, "View all yardages"));
            menu.Add(new KeyValuePair<int, string>(2, "Choose a club for me"));
            menu.Add(new KeyValuePair<int, string>(3, "Update club yardage"));
            menu.Add(new KeyValuePair<int, string>(4, "Add a new club"));
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
                    RunChooseForMeOption();
                    break;
                case 3:
                    RunUpdateOption();
                    break;
                case 4:
                    RunAddOption();
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
            var clubs = golfBag.GetClubs();
            int clubCount = golfBag.GetClubCount();

            Console.WriteLine($"{clubCount} clubs");

            foreach (GolfClub club in clubs)
            {
                Console.WriteLine($"{club.Name}: {club.Yardage}");
            }

            ReturnToMenu();
        }

        private void RunChooseForMeOption()
        {
            int yardage = Prompt4Integer($"Enter the distance to the hole: ");
            KeyValuePair<string, string> club = golfBag.ChooseMyClub(yardage);

            Console.WriteLine($"\nTo hit {yardage} yards, you should use a {club.Key} at {club.Value} power.");
            ReturnToMenu();
        }

        private void RunUpdateOption()
        {
            var updateMenu = new List<KeyValuePair<int, string>>();
            var clubs = golfBag.GetClubs();

            for (int i = 1; i <= clubs.Count; i++)
            {
                updateMenu.Add(new KeyValuePair<int, string>(i, $"{clubs[i - 1].Name} ({clubs[i - 1].Yardage})"));
            }

            int selection = Prompt4MenuItem<int>("Select a club to update:", updateMenu);
            GolfClub club = clubs[selection - 1];
            int yardage = Prompt4Integer($"Enter new {club.Name} yardage: ");
            club.Yardage = yardage;

            try
            {
                golfBag.UpdateClub(club);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong trying to update the golf bag: {ex.Message}");
            }

            Console.WriteLine($"\nSuccessfully updated {club.Name} to {yardage}.");
            ReturnToMenu();
        }

        private void RunAddOption()
        {
            Console.Write("Enter new club name: ");
            string name = Console.ReadLine();
            int yardage = Prompt4Integer($"Enter yardage for {name}: ");

            golfBag.AddClub(new GolfClub
            {
                Name = name,
                Yardage = yardage
            });

            Console.WriteLine($"\nSuccessfully added new club: {name}.");
            ReturnToMenu();
        }
    }
}
