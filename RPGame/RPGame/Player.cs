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
        int movementSpeed;
        public int level;
        public int score;

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
            if (consumable is HealthPotion)
            {
                HealthPotion hPotion = consumable as HealthPotion;

                Player.Instance._health += hPotion.heallingPower;
            }
            else if (consumable is StrengthPotion)
            {
                StrengthPotion sPotion = consumable as StrengthPotion;

                Player.Instance._strength += sPotion.fortifyPower;
            }
        }
    }
}
