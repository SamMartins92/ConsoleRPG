using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame.Scripts
{
    internal class Inventory
    {
        int storageCapacity;


        List<Weapon> itensInBag;

        void AddItenToBag(Weapon weapon)
        {
            itensInBag.Add(weapon);
        }
    }
}
