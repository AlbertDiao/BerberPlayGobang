using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerberPlayGobang
{
    //保存游戏有关的规则、行为
    class Game
    {
        public const int WHITE = 1;
        public const int BLACK = -1;
        public int player;//表示当前准备落子的玩家
        public Step[] step;//保存步数
        private int sNum = 0;
        public Game()
        {
            player = BLACK;
        }

        public void place(int x,int y, int color)
        {
            step[sNum] = new Step(x, y,color);
            sNum++;
        }

        public Step tackBack()
        {
            if (sNum < 1)
                return new Step(-1,-1,-1);
            sNum--;
            return step[sNum];
        }
    }

}
