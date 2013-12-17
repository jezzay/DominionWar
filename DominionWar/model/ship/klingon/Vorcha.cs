#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System;

#endregion

namespace Dominion_War.model.ship
{
    public class VorCha : BaseShip
    {
        private const int VorChaShieldStrength = 90;
        private const int VorChaHullStrength = 20;
        private const int VorChaShieldRegenerationRate = 1;
        private const int VorChaWeaponBase = 7;
        private const int VorChaWeaponRandom = 5;

        public VorCha(Random random)
        {
            Init(random);
        }

        private void Init(Random random)
        {
            this.ShipClassName = "Vor'cha";
            this.shipsHull = new Hull(VorChaHullStrength);
            this.shipShields = new Shield(VorChaShieldStrength, VorChaShieldRegenerationRate);
            this.shipsWeapons = new Weapons(random, VorChaWeaponBase, VorChaWeaponRandom);
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