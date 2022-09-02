using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    public class BattleScene
    {
        Environment currentEnvironment;
        public List<Enemy> enemyGroup = new List<Enemy>();


        public BattleScene(int playerLevel)
        {
            switch (playerLevel)
            {
                case int n when (n <= 5):
                    CreateEnemyGroup(playerLevel);
                    break;
                default:
                    break;
            }
        }

        void CreateEnemyGroup(int playerLevel)
        {
            for (int i = 0; i < playerLevel; i++)
            {
                enemyGroup.Add(new Ogre());
            }
        }

    }
}
