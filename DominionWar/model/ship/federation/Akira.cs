#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System;

#endregion

namespace Dominion_War.model.ship
{
    public class Akira : BaseShip
    {
        private const int AkiraHullStrength = 20;
        private const int AkiraShieldStrength = 90;
        private const int AkiraShieldRegenerationRate = 2;
        private const int AkiraWeaponBase = 8;
        private const int AkiraWeaponRandom = 7;

        public Akira(Random random)
        {
            Init(random);
        }

        private void Init(Random random)
        {
            this.ShipClassName = "Akira";
            this.shipsHull = new Hull(AkiraHullStrength);
            this.shipShields = new Shield(AkiraShieldStrength, AkiraShieldRegenerationRate);
            this.shipsWeapons = new Weapons(random, AkiraWeaponBase, AkiraWeaponRandom);
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