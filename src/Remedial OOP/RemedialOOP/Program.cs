using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemedialOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //DemoBunchOfStrings();
            DemoBunchOfFightingUnits();
        }

        private static void DemoBunchOfFightingUnits()
        {
            var goodGuys = new Bunch<FightingUnit>();
            goodGuys.Add(new AirSquadron(10));
            goodGuys.Add(new TankUnit(10));
        }

        private static void DemoBunchOfStrings()
        {
            var things = new Bunch<string>();
            things.Add("Dan");
            things.Add("Don");
            things.Add("Brad Pitt");
            Console.WriteLine($"There are {things.Count} names in my list");
        }
    }
}
