using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLibrary
{
    public class SwimmersManager : ISwimmersRepository
    {
        public IClubsRepository ClubsManager { get; set; }

        public List<Swimmer> Swimmers { get; } = new List<Swimmer>();

        public void AddSwimmer(Swimmer aSwimmer)
        {
            Swimmers.Add(aSwimmer);
        }

        public Swimmer GetSwimmer(uint regNumber)
        {
            foreach(Swimmer swimmer in Swimmers)
            {
                if(swimmer.Id == regNumber)
                {
                    return swimmer;
                }
            }
            return null;
        }

        public string formatRecord(Swimmer aSwimmer, String delimiter)
        {
            return aSwimmer.Id + delimiter + aSwimmer.Name + delimiter + aSwimmer.DateOfBirth + delimiter + aSwimmer.Address.StreetName + delimiter + aSwimmer.Address.StreetCity + delimiter + aSwimmer.Address.StreetProvince + delimiter + aSwimmer.Address.PostalCode + delimiter + aSwimmer.PhoneNumber;
        }

        public void processSwimmerRecord(string aSwimmer, String delimiter)
        {
            bool x = true;
            string[] words = aSwimmer.Split(delimiter);

            uint i = 0;
            bool isNumber = uint.TryParse(words[0], out i);

            if (!isNumber)
            {
                words[0] = "0";
            }

            if (!isNumber && x)
            {
                x = false;

                throw new InvalidOperationException($"Invalid swimmer record. Invalid registration number:\n                {aSwimmer}");
            }

            /*if (!words[1].Contains("Swimmer") && x)
            {
                x = false;
                throw new InvalidOperationException(($"Invalid swimmer record. Invalid swimmer name:\n                {aSwimmer}");
            }*/
            ulong u = 0;
            bool isPhoneNumber = ulong.TryParse(words[7], out u);

            if (!isPhoneNumber && x)
            {
                x = false;

                throw new InvalidOperationException($"Invalid swimmer record. Phone number wrong format:\n                {aSwimmer}");
            }

            if (!isPhoneNumber)
            {
                words[7] = "0";
            }

            foreach (Swimmer swimmer in Swimmers)
            {
                if (isNumber)
                {
                    if (swimmer.Id == uint.Parse(words[0]))
                    {
                        x = false;
                        throw new InvalidOperationException($"Invalid swimmer record. Swimmer with the registration number already exists:\n                {aSwimmer}");
                    }
                }
                if (swimmer.Name == words[1])
                {
                    x = false;
                    throw new InvalidOperationException($"Invalid swimmer record. Swimmer with this name already exists:\n                {aSwimmer}");
                }
            }
            DateTime datevalue;
            DateTime dateTime = new DateTime(2001,01,01);
            string dateString = words[2];

            if(DateTime.TryParse(dateString, out datevalue))
            {
                dateTime = DateTime.Parse(dateString);
            }
            else
            {
                x = false;
                throw new InvalidOperationException($"Invalid swimmer record.Birth date is invalid:\n                {aSwimmer}");
            }

            if (x)
            {
                Swimmers.Add(new Swimmer(uint.Parse(words[0]), words[1],dateTime, new Address(words[3], words[4], words[5], words[6]), ulong.Parse(words[7])));
            }



        }

        public void LoadSwimmers(string fileName, string delimiter)
        {
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                processSwimmerRecord(line, delimiter);
            }
        }

        public void SaveSwimmers(string fileName, string delimiter)
        {
            File.WriteAllText(fileName, String.Empty);
            using (StreamWriter sw = File.AppendText(fileName))
            {
                foreach (Swimmer swimmer in Swimmers)
                {
                    sw.WriteLine(formatRecord(swimmer, delimiter));
                }
            }
        }
    }
}
