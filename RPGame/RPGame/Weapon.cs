using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    public class Weapon
    {
        
        public string name;
        int power;
        int durability;
        public WeaponType thisWeaponType;

        public enum WeaponType
        {
            Axe,
            Sword,
            Bow,
            Daggers
        }

        /// <summary>
        /// Create a specific weapon
        /// </summary>
        /// <param name="myWeaponType"></param>
        public Weapon(WeaponType myWeaponType)
        {
            Player.Instance.isArmed = true;

            switch (myWeaponType)
            {
                case WeaponType.Axe:
                    {
                        thisWeaponType = WeaponType.Axe;
                        name = "";
                        power = 0;
                        break;
                    }
                case WeaponType.Sword:
                    {
                        thisWeaponType = WeaponType.Sword;
                        name = "";
                        power = 0;
                        break;
                    }
                case WeaponType.Bow:
                    {
                        thisWeaponType = WeaponType.Bow;
                        name = "";
                        power = 0;
                        break;
                    }
                case WeaponType.Daggers:
                    {
                        thisWeaponType = WeaponType.Daggers;
                        power = 0;
                        break;
                    }
            }
        }

        public Weapon()
        {
            WeaponType[] randomWeaponType = new WeaponType[] { WeaponType.Axe, WeaponType.Sword, WeaponType.Bow, WeaponType.Daggers};
            thisWeaponType = randomWeaponType[Scene.random.Next(0, randomWeaponType.Length)];
        }  
    }
}
