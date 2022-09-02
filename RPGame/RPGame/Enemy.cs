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
        private int level;

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

        public void SetName(string myName)
        {
            _name = myName;
        }


    }
}
