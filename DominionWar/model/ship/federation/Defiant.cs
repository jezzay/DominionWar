using System;

namespace Dominion_War.model.ship
{
    public class Defiant : BaseShip
    {
        private const int DefiantShieldStrength = 60;
        private const int DefiantHullStrength = 20;
        private const int DefiantShieldRegenerationRate = 3;
        private const int DefiantWeaponBase = 7;
        private const int DefiantWeaponRandom = 3;

        public Defiant(Random random)
        {
            Init(random);
        }

        private void Init(Random random)
        {
            this.ShipClassName = "Defiant";
            this.shipsHull = new Hull(DefiantHullStrength);
            this.shipShields = new Shield(DefiantShieldStrength, DefiantShieldRegenerationRate);
            this.shipsWeapons = new Weapons(random, DefiantWeaponBase, DefiantWeaponRandom);
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
