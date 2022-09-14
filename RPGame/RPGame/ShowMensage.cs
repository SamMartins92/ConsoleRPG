using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    public static class ShowMensage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="battleScene"></param>
        public static void IntroduceEnemies(Scene battleScene)
        {

            foreach (var enemy in battleScene.enemyGroup)
            {
                Console.WriteLine("There is an " + enemy._name + "Health: "+ enemy._health + " lvl: " + enemy._level);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void IntroduceBattleScene()
        {
            Scene FisrtBattleScene = new Scene();

            ShowMensage.IntroduceEnemies(FisrtBattleScene);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void IntroduceStartUpScene()
        {
            Player.Instance.PickUpWeapon(Weapon.WeaponType.Axe);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void CustomizeCharacter()
        {
            Console.WriteLine();
        }
    }
}
