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
        int health;
        int movementSpeed;
        public int level;

        public bool isArmed;

        public string _name { get { return name; } private set { name = value; } }
        public int _strength
        {
            get { return strength; } 
            set { if (strength < 101 && strength > -1) { strength = value; } }
        }
        public int _age { get { return age; } private set { age = value; } }
        public int _movementSpeed { get { return movementSpeed; } private set { movementSpeed = value; } }

        public Weapon MainWeapon;
        public Weapon SecondaryWeapon;

        //Combat actions

        /// <summary>
        /// Deal damage to the enemy
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="enemy"></param>
        void Attack(Enemy enemy)
        {
            enemy.health -= Player.Instance.strength;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        void Defend(Enemy enemy)
        {
            Player.Instance.health -= enemy.strength;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="weaponType"></param>
        public void PickUpWeapon(Weapon.WeaponType weaponType)
        {
            MainWeapon = new Weapon(weaponType);
            CharacterManagment.AddStrength(9);
        }
    }
}
