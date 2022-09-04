using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    public class Scene
    {
        Environment currentEnvironment;

        public List<Enemy> enemyGroup = new List<Enemy>();

        public Scene(Player player)
        {
            switch (player.level)
            {
                case int n when (n <= 5):
                    CreateEnemyGroup(3);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dificult"></param>
        void CreateEnemyGroup(int dificult)
        {
            Random random = new Random();

            for (int i = 0; i < dificult; i++)
            {
                enemyGroup.Add(Enemy.enemyRaces[random.Next(0, Enemy.enemyRaces.Length)]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void CreateEnvironment()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        void CreateBattleScene()
        {

        }


    }
}
