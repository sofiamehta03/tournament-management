using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLibrary
{
    public class Coach : Registrant
    {

        public string Credentials { get; set; }

        public Coach()
        {
            Id = RegistrationNumberGenerator.GetId();
        }

        public Coach(string name, DateTime dateOfBirth, Address anAddress, ulong phoneNumber, string credentials) 
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = anAddress;
            PhoneNumber = phoneNumber;

            Credentials = credentials;
        }


        public override string ToString()
        {
            return $"Name: {Name}\nAddress: \n    {Address.StreetName}\n    {Address.StreetCity}\n    {Address.StreetProvince}\n    {Address.PostalCode}\nPhone: {PhoneNumber} \nDOB: {DateOfBirth}\nId: {Id}\nClub: not assigned\nCredentials: {Credentials}";
        }
    }
}
