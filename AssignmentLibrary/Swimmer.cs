using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLibrary
{
    public class Swimmer : Registrant
    {
        public new Club Club = null;
        public string Time;

        
        public Swimmer()
        {
            Id = RegistrationNumberGenerator.GetId();
        }

        public Swimmer(string name, DateTime dateOfBirth, Address anAddress, ulong phoneNumber)
        {
            new Swimmer();
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = anAddress;
            PhoneNumber = phoneNumber;

        }

        public Swimmer(uint regNumber, string name, DateTime dateOfBirth, Address anAddress, ulong phoneNumber)
        {
            Id = regNumber;


            Name = name;
            DateOfBirth = dateOfBirth;
            Address = anAddress;
            PhoneNumber = phoneNumber;

        }

        public Swimmer(uint regNumber, string name, DateTime dateOfBirth, Address anAddress, ulong phoneNumber, string time)
        {
            Id = regNumber;


            Name = name;
            DateOfBirth = dateOfBirth;
            Address = anAddress;
            PhoneNumber = phoneNumber;

            Time = time;
        }

        public string Display()
        {
            return $"{Name}";
        }

        public override string ToString()
        {
            string clubname = "not assigned";
            if(Club != null)
            {
                clubname = Club.Name;
            }
            return Display();
            //return $"Name: {Name}\nAddress: \n    {Address.StreetName}\n    {Address.StreetCity}\n    {Address.StreetProvince}\n    {Address.PostalCode}\nPhone: {PhoneNumber} \nDOB: {DateOfBirth}\nId: {Id}\nClub: {clubname}";
        }
    }
}
