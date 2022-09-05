using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    public static class CharacterManagment
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="value"></param>
        static public void AddStrength(int value)
        {
            Player.Instance._strength += value;
        }

        /// <summary>
        /// 
        /// </summary>
        static public void CustomizeCharacter()
        {

        }
    }
}
