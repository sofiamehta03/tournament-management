using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AssignmentLibrary
{
    public class SwimMeet
    {

        public PoolType Course { get; set; }
        public DateTime EndDate { get; set; }
        public List<Event> Events { get; } = new List<Event>();
        public string Name { get; set; }
        public byte NoOfLanes { get; set; }
        public DateTime StartDate { get; set; }

        public string swimmersWithtime = "";

        public void AddEvent(Event anEvent)
        {
            Events.Add(anEvent);
        }

        public void Seed()
        {
            
        }

        public SwimMeet()
        {

        }

        public SwimMeet(string name, DateTime start, DateTime end, PoolType course, byte noOfLanes)
        {
            Name = name;
            StartDate = start;
            EndDate = end;
            Course = course;
            NoOfLanes = noOfLanes;
        }

        public override string ToString()
        {
            

            string eventslist = "";
            foreach(Event e in Events)
            {
                swimmersWithtime = "";

                foreach (Swimmer swimmer in e.Swimmers)
                {
                    swimmersWithtime += $"            {swimmer.Name}\n              time:{swimmer.Time}\n";
                }
                
                eventslist += $"\n	{e.Distance}{e.Stroke}\n        Swimmers:\n {swimmersWithtime}\n ";
            }

            return $"Swim meet name: {Name}\nFrom - to: {StartDate.Date} to {EndDate.Date}\nPool type: {Course}\nNo. of lanes: {NoOfLanes}\nEvents:{eventslist}\n";
        }

    }
}
