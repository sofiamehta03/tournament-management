using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLibrary
{
    public static class RegistrationNumberGenerator
    {
        public static uint RegistrationNoId = 999;

        public static uint GetId()
        {
            RegistrationNoId++;
            return RegistrationNoId;
        }
    }
}
