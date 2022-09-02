using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    public static class ShowMensage
    {
        public static void DescribeEnemies(BattleScene battleScene)
        {
            
            foreach (var enemy in battleScene.enemyGroup)
            {
                Console.WriteLine("There is an " + enemy._name);
            }
        }

    }
}
