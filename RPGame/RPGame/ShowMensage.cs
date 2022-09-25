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
            IntroduceShoppingScene();
            do
            {
                BattleTurn("consume", battleScene, enemyGroup);
                BattleTurn("attack", battleScene, enemyGroup);
                BattleTurn("defend", battleScene, enemyGroup);
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

        private static void BattleTurn(string turnType, Scene battleScene, List<Enemy> enemyGroup)
        {
            RefreshBattleScene(battleScene, TurnMsg(turnType));
            int numberChoice = Int32.Parse(Console.ReadLine());

            if (numberChoice == enemyGroup.Count || numberChoice < enemyGroup.Count)
            {
                switch (turnType)
                {
                    case "attack": Player.Instance.Attack(enemyGroup.ElementAt(enemyGroup.Count - numberChoice)); break;
                    case "defend": Player.Instance.Defend(enemyGroup, numberChoice); break;
                    case "consume":
                        HealthPotion  hPotion = new HealthPotion();
                        Player.Instance.TakeConsumable(hPotion); break;
                        break;
                    default: 
                        break;
                }
            }
            else
            {
                RefreshBattleScene(battleScene, "That enemy number doesnt exist! Choose another one");
                numberChoice = Int32.Parse(Console.ReadLine());
                switch (turnType)
                {
                    case "attack": Player.Instance.Attack(enemyGroup.ElementAt(enemyGroup.Count - numberChoice)); break;
                    case "defend": Player.Instance.Defend(enemyGroup, numberChoice); break;
                    default: break;
                }

            }

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

        /// <summary>
        /// 
        /// </summary>
        public static void CustomizeCharacter()
        {
            Console.WriteLine();
        }

        public static string TurnMsg(string turnType)
        {
            switch (turnType)
            {
                case "attack": 
                    return "It´s your turn to attack! Type the enemy number to attack him";
                    break;
                case "defend":
                    return "It´s your turn to defend! Type the enemy number to defend him";
                    break;
                case "consume":
                    return "It´s your turn to use consumables! Type the item number to consume it";
                    break;
                default:
                    return "That doesnt exists";
                    break;
            }
        }
    }
}
