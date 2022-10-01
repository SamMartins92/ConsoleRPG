using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    public class Player 
    {
        //Create a singleton pattern
        private static Player instance = null;
        private static readonly object padlock = new object();

        public static Player Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Player();
                    }
                    return instance;
                }
            }
        }

        string name;
        int age;
        int strength;
        int defense;
        int health = 100;
        int mana = 100;
        int movementSpeed;
        public int level;
        public int score;
        public int wallet;

        public bool isArmed;

        public string _name { get { return name; } private set { name = value; } }
        public int _strength
        {
            get { return strength; } 
            set { if (strength < 101 && strength > -1) { strength = value; } }
        }
        public int _age { get { return age; } private set { age = value; } }
        public int _level { get { return level; } private set { level = value; } }
        public int _health { get { return health; } set { health = value; } }
        public int _defense { get { return defense; } set { defense = value; } }
        public int _movementSpeed { get { return movementSpeed; } private set { movementSpeed = value; } }

        public Weapon mainWeapon;
        public Weapon secondaryWeapon;

        public Inventory inventory;

        Player()
        {
            inventory = new Inventory();
        }

        //Combat actions

        /// <summary>
        /// Deal damage to the enemy
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="enemy"></param>
        public void Attack(Enemy enemy)
        {
            enemy.health -= Player.Instance.strength;

            if (enemy._health <= 0)
            {
                Player.Instance.score += 2; 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public void Defend(List<Enemy> enemyGroup, int enemyNumber)
        {
            if (enemyNumber <= enemyGroup.Count)
            {
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
            }
            else
            {
                Console.WriteLine("Choose a valid enemy number");
            }
            
        }
        /// <summary>
        /// Chose main weapon
        /// </summary>
        /// <param name="player"></param>
        /// <param name="weaponType"></param>
        public void PickUpWeapon(Weapon.WeaponType weaponType)
        {
            mainWeapon = new Weapon(weaponType);
            CharacterManagment.AddStrength(10);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consumable"></param>
        public void TakeConsumable(Consumable consumable)
        {
            beginning:
            if (consumable is HealthPotion)
            {
                bool foundIt = false;

                for (int i = 0; i < inventory.items.Count(); i++)
                {
                    if (inventory.items[i] is HealthPotion)
                    {
                        HealthPotion healthPotion = (HealthPotion)inventory.items[i];
                        Player.Instance._health += healthPotion.heallingPower;
                        inventory.items.RemoveAt(i);
                        Console.WriteLine("You added " + healthPotion.heallingPower.ToString());
                        foundIt = true;
                        break;
                    }
                }
                if (!foundIt) 
                {
                    Console.WriteLine("You dont have any heal potion, press enter to continue or 1 to use another consumable");
                    string response = Console.ReadLine();
                    if (response == "1") goto beginning;
                }
            }
            else if (consumable is StrengthPotion)
            {
                StrengthPotion sPotion = consumable as StrengthPotion;

                Player.Instance._strength += sPotion.fortifyPower;
            }
        }
    }
}
