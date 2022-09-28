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
        public static void IntroducePlayer()
        {
<<<<<<< HEAD
            foreach (var enemy in battleScene.enemyGroup)
            {
                Console.WriteLine("There is an " + enemy._name + " " + "Health: "+ enemy._health + "   Weapon: " + enemy.mainWeapon.thisWeaponType.ToString() + " " + " lvl: " + enemy._level);
            }
=======
            Console.WriteLine("");
            Console.WriteLine("Player: " + Player.Instance._name + "Health: " + Player.Instance._health + " " + "Weapon: " + Player.Instance.mainWeapon.thisWeaponType.ToString() + " lvl: " + Player.Instance._level + "                 " + "Score:" + Player.Instance.score + "   " + "Money:" + Player.Instance.wallet.ToString());
            Console.WriteLine("");
>>>>>>> feature/RPG-9-create-attack-and-defend-turns
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
            Console.WriteLine("Shopping turn: \nBuy something that you think can help you");
            Console.WriteLine("(1)Health potion" + "  " + "(2)Strengh potion");

            string itemToBuy = Console.ReadLine();

            switch (itemToBuy)
            {
                case "1":
                    Player.Instance.inventory.items.Add(new HealthPotion());
                    break;
                case "2":
                    Player.Instance.inventory.items.Add(new StrengthPotion());
                    break;
            }
        }

        #region Battle Scene

        /// <summary>
        /// The enemies group are presented, the loop of attack/defend rools up until all the enimes health finish
        /// </summary>
        public static void IntroduceNewBattleScene()
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
        /// 
        /// </summary>
        /// <param name="turnType"></param>
        /// <param name="battleScene"></param>
        /// <param name="enemyGroup"></param>
        /// <param name="numberChoice"></param>
        private static void AttackTurn(string turnType, Scene battleScene, List<Enemy> enemyGroup)
        {
            int numberChoice = Int32.Parse(Console.ReadLine());
            if (numberChoice == enemyGroup.Count || numberChoice < enemyGroup.Count)
            {
                Player.Instance.Attack(enemyGroup.ElementAt(enemyGroup.Count - numberChoice));
            }
            else
            {
                RefreshBattleScene(battleScene, "That enemy number doesnt exist! Choose another one");
                numberChoice = Int32.Parse(Console.ReadLine());

                Player.Instance.Attack(enemyGroup.ElementAt(enemyGroup.Count - numberChoice));

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enemyGroup"></param>
        private static void DefendTurn(List<Enemy> enemyGroup)
        {
        start: int numberChoice = Int32.Parse(Console.ReadLine());

            if (numberChoice <= enemyGroup.Count) { Player.Instance.Defend(enemyGroup, numberChoice); }
            else { Console.WriteLine("Choose a valid enemy"); goto start; }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void ConsumeTurn(List<Enemy> enemyGroup, Scene battleScene)
        {
        Start:
            Console.WriteLine("(1)HealthPotion" + "  " + "(2)StrenghtPotion");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                var consumable = new HealthPotion();
                Player.Instance.TakeConsumable(consumable);
            }
            else
            {
                Console.Clear();
                IntroducePlayer();
                IntroduceEnemies(battleScene);
                Console.WriteLine("Chosse a valid option!, press 1 to choose again or 2 to continue to the skip turn");
                choice = Console.ReadLine(); if (choice == "1") { goto Start; }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Fight(Scene battleScene, List<Enemy> enemyGroup)
        {
            do
            {
                BattleTurn("attack", battleScene, enemyGroup);
                BattleTurn("defend", battleScene, enemyGroup);
                BattleTurn("consume", battleScene, enemyGroup);
            } while (battleScene.enemyGroup.Count > 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="turnType"></param>
        /// <param name="battleScene"></param>
        /// <param name="enemyGroup"></param>
        private static void BattleTurn(string turnType, Scene battleScene, List<Enemy> enemyGroup)
        {
            RefreshBattleScene(battleScene, TurnMsg(turnType));

            switch (turnType)
            {
                case "attack": AttackTurn(turnType, battleScene, enemyGroup); break;
                case "defend": DefendTurn(enemyGroup); break;
                case "consume": ConsumeTurn(enemyGroup, battleScene); break;
                default: break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="battleScene"></param>
        public static void IntroduceEnemies(Scene battleScene)
        {
            int enemyIndex = 0;
            Console.WriteLine("Enemies:");
            for (int i = battleScene.enemyGroup.Count - 1; i >= 0; i--)
            {
                enemyIndex++;
                if (battleScene.enemyGroup[i]._health > 0)
                {
                    Console.WriteLine("(" + enemyIndex.ToString() + ")" + " " + battleScene.enemyGroup[i]._name + " " + "Health:" + battleScene.enemyGroup[i]._health + " " + "Weapon:" + battleScene.enemyGroup[i].mainWeapon.thisWeaponType.ToString() + " " + " lvl:" + battleScene.enemyGroup[i]._level);
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
        /// <param name="battleScene"></param>
        private static void ConsumablesTurn(Scene battleScene)
        {
            RefreshBattleScene(battleScene, "It´s your turn to use consumables! Type the consumable number to consume it");
            int consumableNumber = Int32.Parse(Console.ReadLine());
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public static void CustomizeCharacter()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="turnType"></param>
        /// <returns></returns>
        public static string TurnMsg(string turnType)
        {
            switch (turnType)
            {
                case "attack": 
                    return "Attack turn: \nIt´s your turn to attack! Type the enemy number to attack him";
                    break;
                case "defend":
                    return "Defend turn: \nIt´s your turn to defend! Type the enemy number to defend him";
                    break;
                case "consume":
                    return "Consume turn \nIt´s your turn to use consumables! Type the item number to consume it";
                    break;
                default:
                    return "That doesnt exists";
                    break;
            }
        }
    }
}
