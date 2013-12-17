using System;
using System.IO;
using Dominion_War.util;

namespace Dominion_War.model
{
    internal enum HullDamagePercent
    {
        VeryHeavyDamage = 0,
        HeavyDamage = 40,
        ModerateDamage = 70,
        LightDamage = 90,
        Undamaged = 100
    }

    public class Hull
    {
        private const int OneHundredPercent = 100;
        private int hullStrength = -1;
        private int hullDamage = 0;

        private void InitHull()
        {
            hullStrength = -1;
            hullDamage = 0;
        }

        public Hull()
        {
            InitHull();
        }

        public Hull(int hullStrength)
        {
            this.hullStrength = hullStrength;
        }

        public void TakeDamage(int damage)
        {
//            Console.WriteLine("damage taken {0}",damage);
            hullDamage += damage;
//            Console.WriteLine("hullDamage is now {0}",hullDamage);
        }


        public bool IsDestroyed()
        {
            return hullDamage >= hullStrength;
        }

        public string DamageRating()
        {
            int undamagedPercent = (hullStrength - hullDamage)*OneHundredPercent/hullStrength;

            if (undamagedPercent == (int) HullDamagePercent.Undamaged)
            {
                return "undamaged";
            }
            if (undamagedPercent >= (int) HullDamagePercent.LightDamage)
            {
                return "lightly damaged";
            }
            if (undamagedPercent >= (int) HullDamagePercent.ModerateDamage)
            {
                return "moderately damaged";
            }
            return undamagedPercent >= (int) HullDamagePercent.HeavyDamage 
                ? "heavily damaged" : "very heavily damaged";
        }

        public void ReadHull(StreamReader fin)
        {
            InitHull();

            this.hullStrength = ValidationUtil.ParseStringToNumber(fin.ReadLine());
            if (!ValidationUtil.ValidNumber(hullStrength))
            {
                throw new Exception("Invalid hull strength");
            }
        }
    }
}