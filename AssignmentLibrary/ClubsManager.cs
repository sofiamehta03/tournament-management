using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLibrary
{
    public class ClubsManager : IClubsRepository
    {

        public List<Club> Clubs { get; set; } = new List<Club>();

        public void AddClub(Club aClub)
        {
            Clubs.Add(aClub);
        }

        public string formatRecord(Club aClub, String delimiter)
        {
            Club club = aClub;
            return club.ClubNumber+delimiter+club.Name+delimiter+club.ClubAddress.StreetName+delimiter+club.ClubAddress.StreetCity+delimiter+club.ClubAddress.StreetProvince+delimiter+club.ClubAddress.PostalCode+delimiter+club.PhoneNumber;
        }

        public void processClubRecord(string aClub, String delimiter)
        {
            bool x = true;
            string[] words = aClub.Split(delimiter);

            uint i = 0;
            bool isNumber = uint.TryParse(words[0], out i);

            if (!isNumber)
            {
                words[0] = "0";
            }

            if (!isNumber && x)
            {
                x = false;
                
                throw new InvalidOperationException($"Invalid club record Club number is not valid");
            }

            /*if (!words[1].Contains("Club") && x)
            {
                x = false;
                throw new InvalidOperationException($"Invalid club record. Invalid club name");
            }*/
            ulong u = 0;
            bool isPhoneNumber = ulong.TryParse(words[6], out u);

            if (!isPhoneNumber && x)
            {
                x = false;

                throw new InvalidOperationException($"Invalid club record. Phone number wrong format");
            }

            if (!isPhoneNumber)
            {
                words[6] = "0";
            }

            foreach(Club club in Clubs)
            {
                if (isNumber)
                {
                    if (club.ClubNumber == uint.Parse(words[0]))
                    {
                        x = false;
                        throw new InvalidOperationException($"Invalid club record. Club with the registration number already exists");
                    }
                }

                if (club.Name == words[1])
                {
                    x = false;
                    throw new InvalidOperationException($"Invalid club record. Club with this name already exists");
                }
            }

            if (x)
            {
                Clubs.Add(new Club(uint.Parse(words[0]), words[1], new Address(words[2], words[3], words[4], words[5]), ulong.Parse(words[6])));
            }
            

            
        }

        public Club GetCLub(uint regNumber)
        {
            foreach(Club club in Clubs)
            {
                if(club.ClubNumber == regNumber)
                {
                    return club;
                }
            }
            return null;
        }

        public void LoadClubs(string fileName, string delimiter)
        {
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                processClubRecord(line, delimiter);
            }
        }

        public void SaveClubs(string fileName, string delimiter)
        {
            File.WriteAllText(fileName, String.Empty);
            using (StreamWriter sw = File.AppendText(fileName))
            {
                foreach (Club club in Clubs)
                {
                    sw.WriteLine(formatRecord(club,delimiter));
                }
            }
            
        }
    }
}
