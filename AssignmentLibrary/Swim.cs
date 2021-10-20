using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLibrary
{
    public class Swim
    {

        public ushort Heat { get; set; }
        public byte Lane { get; set; }
        public DateTime Time { get; set; }

        public Swim()
        {

        }

        public Swim(ushort heat, byte lane) : this()
        {

            Heat = heat;
            Lane = lane;

        }

        public override string ToString()
        {
            return "";
        }

    }
}
