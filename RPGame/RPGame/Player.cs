using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    public class Player 
    {
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
        void Attack(Player player, Enemy enemy)
        {
            enemy.health -= player.strength;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        void Defend(Player player, Enemy enemy)
        {
            player.health -= enemy.strength;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="weaponType"></param>
        public void PickUpWeapon(Player player, Weapon.WeaponType weaponType)
        {
            MainWeapon = new Weapon(player, weaponType);
            CharacterManagment.AddStrength(player, 10);
        }
    }
}
