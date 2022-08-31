using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    internal class Weapon
    {
        public enum WeaponType
        {
            Axe,
            Sword,
            Bow,
            Daggers
        }

        public string name;
        int power;
        int durability;

        public WeaponType weaponType;
        
        public Weapon(Player player, WeaponType weaponType)
        {
            player.isArmed = true;

            switch (weaponType)
            {
                case WeaponType.Axe:
                    {
                        name = "";
                        power = 0;
                        break;
                    }
                case WeaponType.Sword:
                    {
                        name = "";
                        power = 0;
                        break;
                    }
            }
        }
    }
}
