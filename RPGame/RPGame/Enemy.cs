using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    public class Enemy
    {
        private string name;
        public int health;
        public int strength;
        private int level = 1;
        public Weapon mainWeapon;

        public string _name
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    name = value;
                } 
            } 
        }

        public int _health
        {
            get { return health; }
            set
            {
                if (value > -1 && value < 101)
                {
                    health = value;
                }
            } }

        public void SetName(string myName)
        {
            _name = myName;
        }

        /// <summary>
        /// Create a list with one of all the enemy types.
        /// </summary>
        public static Enemy[] enemyRaces = new Enemy[]
        {
            new Ogre(),
            new DarkElf(),
        };



        public int _level
        {
            get
            {
                return level;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Enemy()
        {
            mainWeapon = new Weapon();
            strength = 5;
        }

        public void Attack(Player player)
        {
            player._health -= strength;
        }
    }
}
