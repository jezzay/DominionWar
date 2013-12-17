#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System.Collections.Generic;
using Dominion_War.Model;
using Dominion_War.model.ship;

#endregion

namespace Dominion_War
{
    /// <summary>
    /// Interface to be notified about battle results
    /// </summary>
    public interface IBattleObserver
    {
        /// <summary>
        /// Notify battle round results
        /// </summary>
        /// <param name="fleetName"></param>
        /// <param name="battleRound"></param>
        /// <param name="destroyedShips"></param>
        void NotifyBattleRoundResults(string fleetName, int battleRound, List<string> destroyedShips);

        /// <summary>
        /// Notify a draw
        /// </summary>
        /// <param name="battleRounds"></param>
        void NotifyDraw(int battleRounds);

        /// <summary>
        /// Notify when a battle is finished
        /// </summary>
        /// <param name="winingFleet"></param>
        /// <param name="loosingFleet"></param>
        /// <param name="numberOfBattleRounds"></param>
        void NotifyBattleFinished(Fleet winingFleet, Fleet loosingFleet,
            int numberOfBattleRounds);

    }
}