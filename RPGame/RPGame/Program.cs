using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player MainPlayer = new Player();

            MainPlayer.MainWeapon = new Weapon(MainPlayer);
        }
    }
}
