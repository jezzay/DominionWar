#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

#region

using System;
using System.IO;
using Dominion_War.util;

#endregion

namespace Dominion_War.model
{
    public class Weapons
    {
        private int weaponBase;
        private int weaponRand;
        private readonly Random rand;

        private void InitWeapons()
        {
            weaponBase = weaponRand = -1;
        }

        public Weapons(Random r)
        {
            rand = r;
            InitWeapons();
        }

        public Weapons(Random r, int weaponBase, int weaponRand)
        {
            this.rand = r;
            this.weaponBase = weaponBase;
            this.weaponRand = weaponRand;
        }


        public int GetDamage()
        {
            return weaponBase + rand.Next(weaponRand);
        }

        public void ReadWeapon(StreamReader fin)
        {
            InitWeapons();

            this.weaponBase = ValidationUtil.ParseStringToNumber(fin.ReadLine());
            // read in weapon base
            if (!ValidationUtil.ValidNumber(weaponBase))
            {
                throw new Exception("Invalid weapon base");
            }
            // read in weapon rand
            this.weaponRand = ValidationUtil.ParseStringToNumber(fin.ReadLine());
            if (!ValidationUtil.ValidNumber(weaponRand))
            {
                throw new Exception("Invalid weapon random");
            }
        }
    }
}