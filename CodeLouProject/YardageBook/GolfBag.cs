using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardageBook
{
    public class GolfBag
    {
        private string saveFile;
        private List<GolfClub> clubs;

        public GolfBag(string saveFilePath)
        {
            saveFile = saveFilePath;
            clubs = FileUtility.ReadJsonFile<List<GolfClub>>(saveFile);
        }

        public List<GolfClub> GetClubs()
        {
            return clubs;
        }

        public int GetClubCount()
        {
            return clubs.Count;
        }

        public void UpdateClub(GolfClub updatedClub)
        {
            var club = clubs.First(c => c.Name == updatedClub.Name);
            if (club is not null)
            {
                club.Yardage = updatedClub.Yardage;
            }

            FileUtility.SaveJsonFile(clubs, saveFile);
        }

        public void AddClub(GolfClub club)
        {
            clubs.Add(club);
            clubs = clubs.OrderByDescending(c => c.Yardage).ToList();
            FileUtility.SaveJsonFile(clubs, saveFile);
        }

        public KeyValuePair<string, string> ChooseMyClub(int yardage)
        {
            var clubsInYardOrder = clubs.OrderBy(c => c.Yardage);
            GolfClub club = clubsInYardOrder.FirstOrDefault(c => c.Yardage >= yardage) ?? clubsInYardOrder.Last();
            double swingPower = (double)yardage / (double)club.Yardage;

            if (swingPower > 1)
                swingPower = 1;

            return new KeyValuePair<string, string>(club.Name, swingPower.ToString("P0"));
        }
    }
}
