using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemedialOOP
{
    public enum BattleDomain { Air, Land, Sea }
    public interface FightingUnit
    {
        int Count { get; }
        BattleDomain Domain { get; }
    }

    public class AirSquadron : FightingUnit
    {
        public BattleDomain Domain => BattleDomain.Air;
        public int Count { get; private set; }
    }

    public class TankUnit : FightingUnit
    {
        public BattleDomain Domain => BattleDomain.Land;
        public int Count { get; private set; }
    }

    public abstract class Ship
    {
        public int CrewCount { get; protected set; }
    }

    public class Submarine : Ship
    {

    }

    public class Destroyer : Ship
    {

    }

    public class AircraftCarrier : Ship
    {

    }

    public class Fleet : List<FightingUnit>, FightingUnit
    {
        public BattleDomain Domain => BattleDomain.Sea;
    }
}
