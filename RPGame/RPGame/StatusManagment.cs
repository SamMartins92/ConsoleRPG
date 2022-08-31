using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    public static class StatusManagment
    {
        static public void AddStrength(Player player, int value)
        {
            player._strength += value;
        }
    }
}
