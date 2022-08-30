using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    internal class Weapon
    {
        public string name;
        int power;
        int durability;

        public Weapon(Player player)
        {
            player.isArmed = true;
            player.AddStrength(1);
        }
    }
}
