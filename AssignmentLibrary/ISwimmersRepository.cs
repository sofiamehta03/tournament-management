using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLibrary
{
    public interface ISwimmersRepository
    {

        public IClubsRepository ClubsManager { get; set; }
        public List<Swimmer> Swimmers { get; }

        public void AddSwimmer(Swimmer aSwimmer);
        public Swimmer GetSwimmer(uint regNumber);
        public void LoadSwimmers(string fileName, string delimiter);
        public void SaveSwimmers(string fileName, string delimiter);
        public void processSwimmerRecord(string aSwimmer, String delimiter);
    }
}
