using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerberPlayGobang
{
    class Game
    {
        public const int WHITE = 1;
        public const int BLACK = -1;
        public int player;//表示当前准备落子的玩家
        public Game()
        {
            player = BLACK;
        }
    }

}
