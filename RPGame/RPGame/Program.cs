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

            MainPlayer.PickUpWeapon(MainPlayer, Weapon.WeaponType.Axe);

            StatusManagment.AddStrength(MainPlayer, 10);

            Console.WriteLine(MainPlayer._strength.ToString());

            Console.WriteLine(MainPlayer.MainWeapon.weaponType.ToString());
        }
    }
}
