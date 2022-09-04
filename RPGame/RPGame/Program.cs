using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player MainPlayer = new Player();

            ShowMensage.IntroduceStartUpScene(MainPlayer);
            ShowMensage.IntroduceBattleScene(MainPlayer);


        }
    }
}
