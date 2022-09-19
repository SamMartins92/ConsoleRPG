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
                Console.WriteLine("There is an " + enemy._name + " " + "Health:"+ enemy._health + " " + "Weapon:" + enemy.mainWeapon.thisWeaponType.ToString() + " " + " lvl:" + enemy._level);
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// 
        /// </summary>
        public static void IntroducePlayer()
        {
            Console.WriteLine("");
            Console.WriteLine("Player: " + Player.Instance._name + "Health: " + Player.Instance._health + " " + "Weapon: " + Player.Instance.mainWeapon.thisWeaponType.ToString() + " lvl: " + Player.Instance._level);
            Console.WriteLine("");
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Fight(Scene battleScene, List<Enemy> enemyGroup)
        {
            bool turnFinished = false;

            do
            {
                if (!turnFinished)
                {
                    Console.WriteLine("It´s your turn to attack! Type the enemy number to attack him");
                    int enemyNumber = Int32.Parse(Console.ReadLine());
                    Player.Instance.Attack(enemyGroup.ElementAt(enemyNumber - 1));
                    turnFinished = true;
                    Console.Clear();
                    IntroducePlayer();
                    IntroduceEnemies(battleScene);
                }
                else
                {
                    Console.WriteLine("It´s your turn to defend! Type the enemy number to defend him");
                    int enemyNumber = Int32.Parse(Console.ReadLine());

                    foreach (var enemy in enemyGroup)
                    {
                        if (enemy == enemyGroup[enemyNumber - 1])
                        {
                            Player.Instance._defense -= enemy.strength;
                        }
                        else
                        {
                            enemy.Attack(Player.Instance);
                        }
                       
                    }
                    turnFinished = false;
                    Console.Clear();
                    IntroducePlayer();
                    IntroduceEnemies(battleScene);
                }

            } while (battleScene.enemyGroup.Count > 0);
        }

        /// <summary>
        /// The enemies group are presented, the loop of attack/defend rools up until all the enimes health finish
        /// </summary>
        public static void IntroduceBattleScene()
        {
             Scene FisrtBattleScene = new Scene();

            IntroducePlayer();
            IntroduceEnemies(FisrtBattleScene);
            Fight(FisrtBattleScene, FisrtBattleScene.enemyGroup);
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
