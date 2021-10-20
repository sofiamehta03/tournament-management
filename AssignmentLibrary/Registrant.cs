using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLibrary
{
    public abstract class Registrant
    {
        private Club club = null;

        public Address Address { get; set; }
        public Club Club
        {
            get
            {
                return club;
            }
            set { }
        }
        public DateTime DateOfBirth { get; set; }
        public uint Id { get; set; }
        public string Name { get; set; }
        public ulong PhoneNumber { get; set; }


        public Registrant()
        {
            Id = RegistrationNumberGenerator.GetId();
        }

        public Registrant(string name, DateTime dateOfBirth, Address anAddress, ulong phoneNumber) : this()
        {

            Name = name;
            DateOfBirth = dateOfBirth;
            Address = anAddress;
            PhoneNumber = phoneNumber;
        }

        public Registrant(uint regNumber, string name, DateTime dateOfBirth, Address anAddress, ulong phoneNumber)
        {
            Id = regNumber;

            Name = name;
            DateOfBirth = dateOfBirth;
            Address = anAddress;
            PhoneNumber = phoneNumber;
        }

        public override abstract string ToString();
    }
}
