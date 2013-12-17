using System;

namespace Dominion_War.model.ship
{
    class Galor : BaseShip
    {
        private const int GalorHullStrength = 7;
        private const int GalorShieldStrength = 80;
        private const int GalorShieldRegenerationRate = 1;
        private const int GalorWeaponBase = 8;
        private const int GalorWeaponRandom = 3;

        public Galor(Random random)
        {
          Init(random);
        }

        private void Init(Random random)
        {
            this.ShipClassName = "Galor";
            this.shipsHull = new Hull(GalorHullStrength); 
            this.shipShields = new Shield(GalorShieldStrength, GalorShieldRegenerationRate);
            this.shipsWeapons = new Weapons(random, GalorWeaponBase, GalorWeaponRandom);
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
