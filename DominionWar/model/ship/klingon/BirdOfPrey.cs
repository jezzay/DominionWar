#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System;

#endregion

namespace Dominion_War.model.ship
{
    internal class BirdOfPrey : BaseShip
    {
        private const int BirdOfPreyShieldStrength = 60;
        private const int BirdOfPreyHullStrength = 10;
        private const int BirdOfPreyShieldRegenerationRate = 1;
        private const int BirdOfPreyWeaponBase = 6;
        private const int BirdOfPreyWeaponRandom = 3;

        public BirdOfPrey(Random random)
        {
            Init(random);
        }

        private void Init(Random random)
        {
            this.ShipClassName = "Bird of Prey";
            this.shipsHull = new Hull(BirdOfPreyHullStrength);
            this.shipShields = new Shield(BirdOfPreyShieldStrength, BirdOfPreyShieldRegenerationRate);
            this.shipsWeapons = new Weapons(random, BirdOfPreyWeaponBase, BirdOfPreyWeaponRandom);
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