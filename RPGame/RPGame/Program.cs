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

            BattleScene FisrtBattleScene = new BattleScene(1);

            List<Enemy> EnemyGroup = new List<Enemy>();

            EnemyGroup.Add(new Ogre());
            EnemyGroup.Add(new DarkElf());

            ShowMensage.DescribeEnemies(FisrtBattleScene);
        }
    }
}
