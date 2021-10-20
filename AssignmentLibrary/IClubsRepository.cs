using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLibrary
{
    public interface IClubsRepository
    {
        public List<Club> Clubs { get; set; }

        public void AddClub(Club aClub);

        public Club GetCLub(uint regNumber);

        public void processClubRecord(string aClub, String delimiter);

        public void LoadClubs(string fileName, string delimiter);

        public void SaveClubs(string fileName, string delimiter);

    }
}
