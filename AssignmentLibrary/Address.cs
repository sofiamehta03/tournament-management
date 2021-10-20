using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLibrary
{
    public struct Address
    {
        public Address(string streetName, string streetCity, string streetProvince, string postalCode)
        {
            StreetName = streetName;
            StreetCity = streetCity;
            StreetProvince = streetProvince;
            PostalCode = postalCode;
        }

        public string StreetName { get; }
        public string StreetCity { get; }
        public string StreetProvince { get; }
        public string PostalCode { get; }

        public override string ToString() => $"{StreetName}\n{StreetCity}\n{StreetProvince}\n{PostalCode}";
    }
}
