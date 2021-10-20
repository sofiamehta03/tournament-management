using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLibrary
{
    public class Club
    {
        public Coach coach = null;

        public Address ClubAddress { get; set; }
        public uint ClubNumber { get; set; }
        public Coach Coach
        {
            get
            {
                return coach;
            }
            set { }
        }
        public string Name { get; set; }
        public ulong PhoneNumber { get; set; }
        public List<Registrant> Swimmers { get; set; } = new List<Registrant>();

        public Club()
        {
            ClubNumber = RegistrationNumberGenerator.GetId();
        }

        public Club(string name, Address anAddress, ulong phoneNumber) : this()
        {
            Name = name;
            ClubAddress = anAddress;
            PhoneNumber = phoneNumber;
        }

        public Club(uint regNumber, string name, Address anAddress, ulong phoneNumber)
        {
            ClubNumber = regNumber;

            Name = name;
            ClubAddress = anAddress;
            PhoneNumber = phoneNumber;
        }


        public void AddSwimmer(Registrant aSwimmer)
        {
            Swimmers.Add(new Swimmer(aSwimmer.Name, aSwimmer.DateOfBirth, aSwimmer.Address, aSwimmer.PhoneNumber));

        }

        public override string ToString()
        {
            string swimmerstext = "";

            if (Swimmers != null)
            {
                foreach (Swimmer swimmer in Swimmers)
                {
                    swimmerstext += "\n        " + swimmer.Name;
                }
            }

            if (Coach != null)
            {
                return $"Name: {Name}\nAddress: \n    {ClubAddress.StreetName}\n    {ClubAddress.StreetCity}\n    {ClubAddress.StreetProvince}\n    {ClubAddress.PostalCode}\nPhone: {PhoneNumber}\nReg number: {ClubNumber}\nSwimmers: {swimmerstext}\nCoach: {Coach.Name}";
            }
            return $"Name: {Name}\nAddress: \n    {ClubAddress.StreetName}\n    {ClubAddress.StreetCity}\n    {ClubAddress.StreetProvince}\n    {ClubAddress.PostalCode}\nPhone: {PhoneNumber}\nReg number: {ClubNumber}\nSwimmers: {swimmerstext}\nCoach: Not assigned";
        }

    }
}
