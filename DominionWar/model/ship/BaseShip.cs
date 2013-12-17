#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System;

#endregion

namespace Dominion_War.model.ship
{
    public abstract class BaseShip
    {
        // combat factors
        protected Shield shipShields;
        protected Hull shipsHull;
        protected Weapons shipsWeapons;
        protected String ShipClassName;

        public String ShipClass
        {
            get { return ShipClassName; }
        }

        /// <summary>
        ///     Fires the ships weapons, returning the amount of damage that
        ///     the weapons have generated.
        ///     This is made up of the ships base weapon damage and the random generated amount.
        /// </summary>
        /// <returns>The amount of damage that the weapons have generated</returns>
        public abstract int FireWeapons();

        /// <summary>
        ///     Returns the current damage status of the ship
        /// </summary>
        /// <returns></returns>
        public abstract String DamageStatus();

        /// <summary>
        /// Regenerates the ships shields
        /// </summary>
        public abstract void RegenerateShield();

        /// <summary>
        /// Deals the specified amount of damage to the ship. Damage will be applied to the
        ///     ships shield first. If the ships shield is down, or the damage amount is
        ///     greater than the current shield strength, then the hull of the
        ///     ship will take the remaining amount of damage.
        /// </summary>
        /// <param name="damageAmount"></param>
        public abstract void ReceiveDamage(int damageAmount);

        /// <summary>
        /// Returns true if this space ship has been destroyed
        /// </summary>
        /// <returns>True if it has been destroyed, false otherwise</returns>
        public abstract bool IsDestroyed();
    }
}