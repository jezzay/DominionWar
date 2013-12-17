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
    public class Shield
    {
        private int shieldStrength;
        private int regenerationRate;
        private int shieldDamage;
        private bool shieldHit;

        private void InitShield()
        {
            shieldStrength = regenerationRate = -1;
            shieldDamage = 0;
            shieldHit = false;
        }

        public Shield()
        {
            InitShield();
        }

        public Shield(int shieldStrength, int regenerationRate)
        {
            this.shieldStrength = shieldStrength;
            this.regenerationRate = regenerationRate;
        }

        public bool IsShieldDown()
        {
            return shieldDamage >= shieldStrength;
        }

        /// <summary>
        /// The shields try to absorb the damage amount given. If the damage 
        /// amount is larger than the current shield capacity, the amount 
        /// not absorbed by the shield will be returned
        /// </summary>
        /// <param name="damage"></param>
        /// <returns>Amount of damage not absorbed by the shield</returns>
        public int AbsorbDamage(int damage)
        {
            int shieldRemaining = shieldStrength - shieldDamage;

            shieldHit = true;
            if (shieldRemaining >= damage)
            {
                shieldDamage += damage;
//                Console.WriteLine("absorbed damage, shield damage at {0}",shieldDamage);
                return 0;
            }
            shieldDamage = shieldStrength;
            return (damage - shieldRemaining);
        }


        /// <summary>
        /// Increases the current shield strength by the regeneration amount. The shields will 
        /// only be regenerated up to the shield maximum strength rate.
        /// </summary>
        public void RegenerateShield()
        {
            if (!shieldHit && shieldDamage > 0)
            {
//                Console.WriteLine("regen shield for {0}, was {1}",name, shieldDamage);
                shieldDamage -= regenerationRate;
                if (shieldDamage < 0)
                {
                    shieldDamage = 0;
                }
//                Console.WriteLine("shield damage is now {0}",shieldDamage);
            }
            shieldHit = false;
        }


        public void ReadShield(StreamReader fin)
        {
            InitShield();

            this.shieldStrength = ValidationUtil.ParseStringToNumber(fin.ReadLine());
            if (!ValidationUtil.ValidNumber(shieldStrength))
            {
                throw new Exception("Invalid shield strength");
            }

            this.regenerationRate = ValidationUtil.ParseStringToNumber(fin.ReadLine());
            if (!ValidationUtil.ValidNumber(regenerationRate) 
                || (regenerationRate > shieldStrength))
            {
                throw new Exception("Invalid regen rate");
            }
        }
    }
}