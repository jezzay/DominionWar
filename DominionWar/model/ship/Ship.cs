#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System;
using System.IO;

#endregion

namespace Dominion_War.model.ship
{
    internal class Ship : BaseShip
    {
        private readonly Random rand;


        public Ship(Random r)
        {
            rand = r;
            InitShip();
        }

        private void InitShip()
        {
            shipsHull = new Hull();
            shipsWeapons = new Weapons(rand);
            shipShields = new Shield();
        }

        public void ReadShip(StreamReader fin)
        {
            InitShip();
            this.ShipClassName = fin.ReadLine();
            if (string.IsNullOrEmpty(ShipClassName))
            {
                throw new Exception("Ship class name missing");
            }

            try
            {
                shipShields.ReadShield(fin);
                shipsHull.ReadHull(fin);
                shipsWeapons.ReadWeapon(fin);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + " in ship class " + ShipClassName);
            }
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