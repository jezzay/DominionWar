#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System;
using System.Collections.Generic;
using System.IO;
using Dominion_War.model;
using Dominion_War.model.ship;
using Dominion_War.util;

#endregion

namespace Dominion_War.Model
{
    public class Fleet
    {
        private const string VersionTwoFleet = "#2";
        private readonly Random rand;
        private int enemyFleetSize;
        private readonly List<string> validShipClassNames = new List<string>();

        public Fleet(Random rand)
        {
            this.rand = rand;
            this.ShipsInService = new List<BaseShip>();
            this.DestroyedShips = new List<BaseShip>();
            Init();
        }

        private void Init()
        {
            validShipClassNames.Add("Defiant");
            validShipClassNames.Add("Akira");
            validShipClassNames.Add("Galaxy");
            validShipClassNames.Add("Bird of Prey");
            validShipClassNames.Add("Vor'cha");
            validShipClassNames.Add("Attack Ship");
            validShipClassNames.Add("Battle Cruiser");
            validShipClassNames.Add("Galor");
        }

        private Random Rand
        {
            get { return rand; }
        }

        private int EnemyFleetSize
        {
            get { return enemyFleetSize; }
            set
            {
                if (value >= 1)
                {
                    enemyFleetSize = value;
                }
            }
        }

        public List<BaseShip> ShipsInService { get; private set; }

        public List<BaseShip> DestroyedShips { get; private set; }

        public string FleetName { get; private set; }


        /// <summary>
        /// The number of ships that are active in this fleet, ie not destroyed
        /// </summary>
        public int SizeOfActiveFleet
        {
            get { return ShipsInService.Count; }
        }

        /// <summary>
        /// Total number of ships this fleet has lost
        /// </summary>
        public int TotalNumberOfLosses
        {
            get { return DestroyedShips.Count; }
        }


        /// <summary>
        /// Fires the fleet's targeting missiles. 
        /// </summary>
        /// <returns></returns>
        public List<TargetingMissile> FireTargetingMissiles()
        {
            List<TargetingMissile> attackMissiles = new List<TargetingMissile>();
            foreach (BaseShip ship in ShipsInService)
            {
                int damagePayload = ship.FireWeapons();
                int enemyTargetPosition = DetermineEnemyTargetPosition();

                attackMissiles.Add(new TargetingMissile(damagePayload, enemyTargetPosition));
            }
            return attackMissiles;
        }

        private int DetermineEnemyTargetPosition()
        {
            int random = Rand.Next(EnemyFleetSize);
            return random;
        }

        public bool IsFleetOperational()
        {
            return ShipsInService.Count >= 1;
        }

        /// <summary>
        /// Receives an list of incoming missile from the enemy fleet.
        /// The missiles will deal their specified damage to the target ships 
        /// in this fleet. Will have no effect if missile targets invalid ships
        /// </summary>
        /// <param name="incomingMissiles"></param>
        public void ReceiveFireFromEnemyFleet(List<TargetingMissile> incomingMissiles)
        {
            foreach (TargetingMissile targetingMissile in incomingMissiles)
            {
                ReceiveFireFromEnemyFleet(targetingMissile);
            }
        }

        /// <summary>
        /// Receives a incoming missile from the enemy fleet. The missile will
        /// deal it's specified damage to the target ship in this 
        /// fleet. Will have no effect if missile targets invalid ship
        /// </summary>
        /// <param name="incomingMissile"></param>
        private void ReceiveFireFromEnemyFleet(TargetingMissile incomingMissile)
        {
            if (incomingMissile.TargetShipPosition > ShipsInService.Count ||
                incomingMissile.TargetShipPosition < 0)
            {
                return;
            }
            BaseShip ship = ShipsInService[incomingMissile.TargetShipPosition];
            ship.ReceiveDamage(incomingMissile.DamageAmount);
        }


        /// <summary>
        /// Allows a fleet to be notified that a new battle is about to commence
        /// </summary>
        /// <param name="updatedEnemyFleetSize">The size of the enemy fleet</param>
        public void NewBattleCommencing(int updatedEnemyFleetSize)
        {
            this.EnemyFleetSize = updatedEnemyFleetSize;
        }

        /// <summary>
        /// A ceasefire is carried out between Fleets, giving each fleet time to 
        /// allow ships that have not been hit in the last round to regenerate. 
        /// Also allows the fleet to update it's list of ships which have
        /// been destroyed.
        /// </summary>
        public List<string> Ceasefire()
        {
            RegenerateShields();
            return UpdateBattleInformation();
        }

        /// <summary>
        /// Updates the list of ships destroyed and still in service. 
        /// Returns the list of ships class names which have been destroyed.  
        /// </summary>
        private List<string> UpdateBattleInformation()
        {
            List<string> destroyedShipNames = RemoveDestroyedShips();
            destroyedShipNames.Reverse();
            return destroyedShipNames;
        }

        private List<string> RemoveDestroyedShips()
        {
            List<string> destroyedShipNames = new List<string>();
            //  loop backwards to remove elements
            for (int i = ShipsInService.Count - 1; i >= 0; i--)
            {
                BaseShip ship = ShipsInService[i];
                if (!ship.IsDestroyed())
                {
                    continue;
                }
                RemoveDestroyedShipFromService(ship, i);
                destroyedShipNames.Add(ship.ShipClass);
            }
            return destroyedShipNames;
        }

        /// <summary>
        /// Each ship which is still in service and has not been hit 
        /// in the current battle regenerates it's
        /// shields. 
        /// </summary>
        private void RegenerateShields()
        {
            foreach (BaseShip ship in ShipsInService)
            {
                ship.RegenerateShield();
            }
        }

        private void RemoveDestroyedShipFromService(BaseShip destroyedShip, int index)
        {
            DestroyedShips.Add(destroyedShip);
            ShipsInService.RemoveAt(index);
        }

        private void CreateVersionTwoFleet(StreamReader fin)
        {
            this.FleetName = fin.ReadLine();
            if (string.IsNullOrEmpty(FleetName))
            {
                throw new Exception("Missing fleet name");
            }
            while (!fin.EndOfStream)
            {
                CreateFleetShips(fin);
            }
        }

        private void CreateFleetShips(StreamReader fileReader)
        {
            string shipClassName = fileReader.ReadLine();
            int numberRequired = ValidationUtil.ParseStringToNumber(fileReader.ReadLine());
            if (!ValidationUtil.ValidNumber(numberRequired))
            {
                throw new Exception("Invalid number of ships");
            }
            if (String.IsNullOrEmpty(shipClassName) || !IsValidShipClass(shipClassName))
            {
                throw new Exception(shipClassName + " is not a valid ship class name");
            }
            // create ship
            CreateShip(shipClassName, numberRequired);
        }

        private BaseShip CreateShip(string shipClassName)
        {
            if ("Defiant".Equals(shipClassName))
            {
                return new Defiant(rand);
            }
            if ("Akira".Equals(shipClassName))
            {
                return new Akira(rand);
            }
            if ("Galaxy".Equals(shipClassName))
            {
                return new Galaxy(rand);
            }
            if ("Bird of Prey".Equals(shipClassName))
            {
                return new BirdOfPrey(rand);
            }
            if ("Vor'cha".Equals(shipClassName))
            {
                return new VorCha(rand);
            }
            if ("Attack Ship".Equals(shipClassName))
            {
                return new AttackShip(rand);
            }
            if ("Battle Cruiser".Equals(shipClassName))
            {
                return new BattleCruiser(rand);
            }
            if ("Galor".Equals(shipClassName))
            {
                return new Galor(rand);
            }
            throw new Exception(shipClassName + " is not a valid ship class name");
        }

        private void CreateShip(string shipClassName, int numberRequired)
        {
            for (int i = 0; i < numberRequired; i++)
            {
                ShipsInService.Add(CreateShip(shipClassName));
            }
        }

        private bool IsValidShipClass(string shipClassName)
        {
            return validShipClassNames.Contains(shipClassName);
        }

        private void CreateVersionOneFleet(StreamReader fin)
        {
            if (string.IsNullOrEmpty(FleetName))
            {
                throw new Exception("Missing fleet name");
            }
            ReadShipsVersionOne(fin);
            if (!EndOfFleetFile(fin))
            {
                throw new Exception("More ships than stated");
            }
        }

        public void ReadFleet(string filename)
        {
            // open stream to fleet file
            StreamReader fin = FileUtil.ReadFile(filename);
            try
            {
                string versionOrFleetName = fin.ReadLine();

                if (versionOrFleetName != null && versionOrFleetName.StartsWith(VersionTwoFleet))
                {
                    CreateVersionTwoFleet(fin);
                }
                else
                {
                    this.FleetName = versionOrFleetName;
                    CreateVersionOneFleet(fin);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + " in " + filename);
            }
            finally
            {
                fin.Close();
            }
        }

        private void ReadShipsVersionOne(StreamReader fin)
        {
            // read number of ships in fleet
            int numberOfShips = ValidationUtil.ParseStringToNumber(fin.ReadLine());
            if (!ValidationUtil.ValidNumber(numberOfShips))
            {
                throw new Exception("Invalid number of ships");
            }

            // create required ships
            for (int i = 0; i < numberOfShips; i++)
            {
                Ship ship = new Ship(rand);
                ship.ReadShip(fin);
                ShipsInService.Add(ship);
            }
        }

        private bool EndOfFleetFile(StreamReader fin)
        {
            string line = null;

            while (!fin.EndOfStream)
            {
                string readLine = fin.ReadLine();
                if (readLine != null)
                {
                    line = readLine.Trim();
                }
                // see if there is any text other than spaces left in file
                if (!string.IsNullOrEmpty(line))
                {
                    return false;
                }
            }
            return true;
        }
    }
}