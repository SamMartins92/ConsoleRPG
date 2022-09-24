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
            for (int i = battleScene.enemyGroup.Count - 1; i >= 0; i--)
            {
                if (battleScene.enemyGroup[i]._health > 0)
                {
                    Console.WriteLine("There is an " + battleScene.enemyGroup[i]._name + " " + "Health:" + battleScene.enemyGroup[i]._health + " " + "Weapon:" + battleScene.enemyGroup[i].mainWeapon.thisWeaponType.ToString() + " " + " lvl:" + battleScene.enemyGroup[i]._level);
                }
                else
                {
                    battleScene.enemyGroup.Remove(battleScene.enemyGroup[i]);
                }
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// 
        /// </summary>
        public static void IntroducePlayer()
        {
            Console.WriteLine("");
            Console.WriteLine("Player: " + Player.Instance._name + "Health: " + Player.Instance._health + " " + "Weapon: " + Player.Instance.mainWeapon.thisWeaponType.ToString() + " lvl: " + Player.Instance._level + "                 " + "Score:" + Player.Instance.score);
            Console.WriteLine("");
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Fight(Scene battleScene, List<Enemy> enemyGroup)
        {
            do
            {
                AttackTurn(battleScene, enemyGroup);
                DefendTurn(battleScene, enemyGroup);
                ConsumablesTurn(battleScene);

            } while (battleScene.enemyGroup.Count > 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="battleScene"></param>
        private static void ConsumablesTurn(Scene battleScene)
        {
            RefreshBattleScene(battleScene, "It´s your turn to use consumables! Type the consumable number to consume it");
            int consumableNumber = Int32.Parse(Console.ReadLine());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="battleScene"></param>
        /// <param name="enemyGroup"></param>
        private static void DefendTurn(Scene battleScene, List<Enemy> enemyGroup)
        {
            int enemyNumber;

            RefreshBattleScene(battleScene, "It´s your turn to defend! Type the enemy number to defend him");
            enemyNumber = Int32.Parse(Console.ReadLine());
            Player.Instance.Defend(enemyGroup, enemyNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="battleScene"></param>
        /// <param name="enemyGroup"></param>
        /// <returns></returns>
        private static int AttackTurn(Scene battleScene, List<Enemy> enemyGroup)
        {
            RefreshBattleScene(battleScene, "It´s your turn to attack! Type the enemy number to attack him");
            int enemyNumber = Int32.Parse(Console.ReadLine());

            if (enemyNumber == enemyGroup.Count || enemyNumber < enemyGroup.Count)
            {
                Player.Instance.Attack(enemyGroup.ElementAt(enemyGroup.Count - enemyNumber));
            }
            else
            {
                RefreshBattleScene(battleScene, "That enemy number doesnt exist! Choose another one");
                enemyNumber = Int32.Parse(Console.ReadLine());
                Player.Instance.Attack(enemyGroup.ElementAt(enemyGroup.Count - enemyNumber));
            }

            return enemyNumber;
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
        public static void RefreshBattleScene(Scene battleScene, string msg)
        {
            Console.Clear();
            IntroducePlayer();
            IntroduceEnemies(battleScene);
            Console.WriteLine(msg);
        }

        /// <summary>
        /// The player should choose a main weapon where
        /// </summary>
        public static void IntroduceStartUpScene()
        {
            Player.Instance.PickUpWeapon(Weapon.WeaponType.Axe);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void IntroduceShoppingScene()
        {
            Console.WriteLine("Buy something that you think can help you");
            string itemToBuy = Console.ReadLine();

            switch (itemToBuy)
            {
                case "1":

                    break;

            }
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
