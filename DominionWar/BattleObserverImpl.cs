#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dominion_War.Model;
using Dominion_War.model.ship;

#endregion

namespace Dominion_War
{
    /// <summary>
    /// Battle Observer that will update the text box with the events it recieves 
    /// </summary>
    public class BattleObserverImpl : IBattleObserver
    {
        private readonly TextBox textBox;

        public BattleObserverImpl(TextBox textBox)
        {
            this.textBox = textBox;
            this.textBox.Clear();
        }

        private void WriteNewLine()
        {
            textBox.AppendText(Environment.NewLine);
        }

        public void NotifyBattleRoundResults(string fleetName, int battleRound,
            List<string> destroyedShips)
        {
            WriteNewLine();
            textBox.AppendText("After round " + battleRound + " the " + fleetName +
                               " fleet has lost");
            foreach (string destroyedShip in destroyedShips)
            {
                WriteNewLine();
                textBox.AppendText("  " + destroyedShip + " destroyed");
            }
            WriteNewLine();
        }

        public void NotifyDraw(int battleRounds)
        {
            WriteNewLine();
            textBox.AppendText("After round " + battleRounds +
                               " the battle has been a draw with both sides destroyed");
            WriteNewLine();
        }

        public void NotifyBattleFinished(Fleet winingFleet, Fleet loosingFleet,
            int numberOfBattleRounds)
        {
            WriteNewLine();
            textBox.AppendText("After round " + numberOfBattleRounds
                               + " the " + winingFleet.FleetName + " fleet won");
            WriteNewLine();

            textBox.AppendText("  " + loosingFleet.TotalNumberOfLosses + " enemy ships destroyed");
            WriteNewLine();
            textBox.AppendText("  " + winingFleet.TotalNumberOfLosses + " ships lost");
            WriteNewLine();
            textBox.AppendText("  " + winingFleet.SizeOfActiveFleet + " ships survived");
            WriteNewLine();

            foreach (BaseShip spaceShip in winingFleet.ShipsInService)
            {
                string damage = spaceShip.DamageStatus();
                textBox.AppendText("    " + spaceShip.ShipClass + " - " + damage);
                WriteNewLine();
            }
        }
    }
}