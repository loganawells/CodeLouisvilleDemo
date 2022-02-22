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
            FileUtility.SaveJsonFile(clubs, saveFile);
        }
    }
}
