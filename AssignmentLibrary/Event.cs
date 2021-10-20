using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLibrary
{
    public class Event
    {


        public RegistrantsSwims swimmingEvents;

        public EventDistance Distance { get; set; }
        public Stroke Stroke { get; set; }
        public List<Registrant> Swimmers { get; } = new List<Registrant>();
        


        public void AddSwimmer(Registrant aSwimmer)
        {
            Swimmers.Add(aSwimmer);
        }

        public void EnterSwimmersTime(Registrant aSwimmer, string time)
        {
            Swimmers.Add(new Swimmer(aSwimmer.Id, aSwimmer.Name, aSwimmer.DateOfBirth, aSwimmer.Address, aSwimmer.PhoneNumber, time));
        }

        public Event()
        {

        }

        public Event(EventDistance distance, Stroke stroke)
        {
            Distance = distance;
            Stroke = stroke;
        }

        public void Seed(byte maxLanes)
        {

        }

        public override string ToString()
        {
            return "";
        }



        public class RegistrantsSwims {

            public List<Registrant> swimmers;
            public List<Swim> swims;

            public Swim Swim { get; set; }

            public void AddOrUpdate(Registrant swimmer, Swim swim)
            {

            }

            public bool Contains(Registrant swimmer)
            {
                return false;
            }

            public Swim GetSwimmersSwim(Registrant swimmer)
            {
                return null;
            }
        }

    }
}
