#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System;

#endregion

namespace Dominion_War.model.ship
{
    public class BattleCruiser : BaseShip
    {
        private const int BattleCruiserHullStrength = 25;
        private const int BattleCruiserShieldStrength = 90;
        private const int BattleCruiserShieldRegenerationRate = 2;
        private const int BattleCruiserWeaponBase = 13;
        private const int BattleCruiserWeaponRandom = 5;

        public BattleCruiser(Random random)
        {
            Init(random);
        }

        private void Init(Random random)
        {
            this.ShipClassName = "Battle Cruiser";
            this.shipsHull = new Hull(BattleCruiserHullStrength);
            this.shipShields = new Shield(BattleCruiserShieldStrength, BattleCruiserShieldRegenerationRate);
            this.shipsWeapons = new Weapons(random, BattleCruiserWeaponBase, BattleCruiserWeaponRandom);
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