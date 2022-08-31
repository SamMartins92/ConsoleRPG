using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    internal static class StatusManagement
    {
        public static void AddStrength(Player player, int powerAdded)
        {
            player._strength += powerAdded;
        }

        public static void AddStrength(Enemy enemy, int powerAdded)
        {
            enemy.strength += powerAdded;
        }
    }
}
