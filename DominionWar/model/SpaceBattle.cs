#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System.Collections.Generic;
using Dominion_War.Model;

#endregion

namespace Dominion_War.model
{
    public class SpaceBattle
    {
        private readonly Fleet fleet1;
        private readonly Fleet fleet2;
        private int battleRounds;
        private readonly List<IBattleObserver> observers = new List<IBattleObserver>();

        public SpaceBattle(Fleet fleet1, Fleet fleet2)
        {
            this.fleet1 = fleet1;
            this.fleet2 = fleet2;
        }

        /// <summary>
        /// Adds an observer that wants to be notified about events
        /// </summary>
        /// <param name="battleObserver"></param>
        public void Subscribe(IBattleObserver battleObserver)
        {
            observers.Add(battleObserver);
        }

        /// <summary>
        /// Remove an observer that no longer wants to be notified about events
        /// </summary>
        /// <param name="battleObserver"></param>
        public void UnSubscribe(IBattleObserver battleObserver)
        {
            observers.Remove(battleObserver);
        }


        /// <summary>
        /// Notifies each fleet that a new battle round is about to commence.
        /// </summary>
        private void NotifyFleetsNewBattleCommencing()
        {
            fleet1.NewBattleCommencing(fleet2.SizeOfActiveFleet);
            fleet2.NewBattleCommencing(fleet1.SizeOfActiveFleet);
        }

        /// <summary>
        /// Each fleet sends targeting missiles it's ships
        /// to attack the enemy fleet ships. 
        /// </summary>
        private void FleetsAttackEachOther()
        {
            List<TargetingMissile> missiles = fleet1.FireTargetingMissiles();
            fleet2.ReceiveFireFromEnemyFleet(missiles);

            missiles = fleet2.FireTargetingMissiles();
            fleet1.ReceiveFireFromEnemyFleet(missiles);
        }


        private void NotifyObserversBattleResults(string fleetName, List<string> shipsDestroyed)
        {
            foreach (IBattleObserver battleObserver in observers)
            {
                battleObserver.NotifyBattleRoundResults(fleetName, battleRounds, shipsDestroyed);
            }
        }


        /// <summary>
        /// Carries out the ceasefire between the two fleets at the end of 
        /// the round. Any ships that have been destroyed in either fleet 
        /// will be reported. 
        /// </summary>
        private void Ceasefire()
        {
            List<string> shipsDestroyed = fleet1.Ceasefire();

            if (shipsDestroyed.Count >= 1)
            {
                NotifyObserversBattleResults(fleet1.FleetName, shipsDestroyed);
            }
            shipsDestroyed = fleet2.Ceasefire();
            if (shipsDestroyed.Count >= 1)
            {
                NotifyObserversBattleResults(fleet2.FleetName, shipsDestroyed);
            }
        }

        /// <summary>
        /// Commences a battle between the two fleets. Will continue until either
        /// one fleet is destroyed or both are destroyed. 
        /// </summary>
        public void CommenceBattle()
        {
            battleRounds = 1;

            while (fleet1.IsFleetOperational() && fleet2.IsFleetOperational())
            {
                NotifyFleetsNewBattleCommencing();

                FleetsAttackEachOther();
                Ceasefire();
                ++battleRounds;
            }
        }


        private void NotifyObserversBattleFinished(Fleet winingFleet, Fleet loosingFleet)
        {
            foreach (IBattleObserver battleObserver in observers)
            {
                battleObserver.NotifyBattleFinished(winingFleet, loosingFleet, battleRounds);
            }
        }

        /// <summary>
        /// Report on the results of the battle between the two fleets
        /// </summary>
        public void ReportBattleResults()
        {
            battleRounds -= 1;
            if (!fleet1.IsFleetOperational() && !fleet2.IsFleetOperational())
            {
                foreach (IBattleObserver battleObserver in observers)
                {
                    battleObserver.NotifyDraw(battleRounds);
                }
            }
            else if (fleet1.IsFleetOperational())
            {
                NotifyObserversBattleFinished(fleet1, fleet2);
            }
            else
            {
                NotifyObserversBattleFinished(fleet2, fleet1);
            }
        }
    }
}