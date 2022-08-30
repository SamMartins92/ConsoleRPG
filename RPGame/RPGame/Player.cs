using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    internal class Player : Human
    {
        string name;
        int age;
        int strength;
        int movementSpeed;

        public bool isArmed;

        public string _name { get { return name; } private set { name = value; } }
        public int _strength { get { return strength; } private set { strength = value; } }
        public int _age { get { return age; } private set { age = value; } }
        public int _movementSpeed { get { return movementSpeed; } private set { movementSpeed = value; } }

        public void AddStrength(int powerAdded)
        {
            strength += powerAdded;
        }

        public Weapon MainWeapon;
    }
}
