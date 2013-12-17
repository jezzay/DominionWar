#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System;

#endregion

namespace Dominion_War.model.ship
{
    public class Galaxy : BaseShip
    {
        private const int GalaxyShieldStrength = 100;
        private const int GalaxyHullStrength = 15;
        private const int GalaxyShieldRegenerationRate = 2;
        private const int GalaxyWeaponBase = 8;
        private const int GalaxyWeaponRandom = 5;

        public Galaxy(Random random)
        {
            Init(random);
        }

        private void Init(Random random)
        {
            this.ShipClassName = "Galaxy";
            this.shipsHull = new Hull(GalaxyHullStrength);
            this.shipShields = new Shield(GalaxyShieldStrength, GalaxyShieldRegenerationRate);
            this.shipsWeapons = new Weapons(random, GalaxyWeaponBase, GalaxyWeaponRandom);
        }


        public override int FireWeapons()
        {
            return shipsWeapons.GetDamage();
        }

        public override string DamageStatus()
        {
            return shipsHull.DamageRating();
        }

        public override void RegenerateShield()
        {
            shipShields.RegenerateShield();
        }

        public override void ReceiveDamage(int damageAmount)
        {
            shipsHull.TakeDamage(shipShields.AbsorbDamage(damageAmount));
        }

        public override bool IsDestroyed()
        {
            return shipsHull.IsDestroyed();
        }
    }
}