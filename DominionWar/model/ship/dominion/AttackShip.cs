using System;

namespace Dominion_War.model.ship
{
    class AttackShip : BaseShip
    {
        private const int AttackShipHullStrength = 8;
        private const int AttackShipShieldStrength = 50;
        private const int AttackShipShieldRegenerationRate = 1;
        private const int AttackShipWeaponBase = 6;
        private const int AttackShipWeaponRandom = 3;

        public AttackShip(Random random)
        {
          Init(random);
        }

        private void Init(Random random)
        {
            this.ShipClassName = "Attack Ship";
            this.shipsHull = new Hull(AttackShipHullStrength);
            this.shipShields = new Shield(AttackShipShieldStrength, AttackShipShieldRegenerationRate);
            this.shipsWeapons = new Weapons(random, AttackShipWeaponBase, AttackShipWeaponRandom);
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
