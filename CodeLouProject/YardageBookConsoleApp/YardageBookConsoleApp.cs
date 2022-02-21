using CodeLouisvilleLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var clubs = golfBag.GetClubs();

            foreach (GolfClub club in clubs)
            {
                Console.WriteLine($"{club.Name}: {club.Yardage}");
            }

            ReturnToMenu();
        }

        private void RunUpdateOption()
        {
            var updateMenu = new List<KeyValuePair<int, string>>();
            var updateList = new Dictionary<int, GolfClub>();
            var clubs = golfBag.GetClubs();

            for (int i = 1; i <= clubs.Count; i++)
            {
                updateList.Add(i, clubs[i-1]);
                updateMenu.Add(new KeyValuePair<int, string>(i, $"{clubs[i - 1].Name} ({clubs[i - 1].Yardage})"));
            }

            int selection = Prompt4MenuItem<int>("Select a club to update:", updateMenu);
            int yardage = Prompt4Integer($"Enter new {updateList[selection].Name} yardage: ");

            try
            {
                golfBag.UpdateClub(new GolfClub
                {
                    Name = updateList[selection].Name,
                    Yardage = yardage
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong trying to update the golf bag: {ex.Message}");
            }

            Console.WriteLine($"\nSuccessfully updated {updateList[selection].Name} to {yardage}.");
            ReturnToMenu();
        }
    }
}
