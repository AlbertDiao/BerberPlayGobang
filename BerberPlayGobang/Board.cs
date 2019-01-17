using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerberPlayGobang
{
    class Board
    {
        public int viewOffX, viewOffY;//格子与棋盘边缘的距离
        public int viewW, viewH;//棋盘宽度和高度
        public int gridW, gridH;//棋盘每个格子的长宽
        public int chessD;//棋子的直径
        public int xNum, yNum;//棋盘棋子最大数量
        public int[,] board;
        
        //viewX转posX
        public int getPosX(int viewX)
        {
            int pos = (viewX - viewOffX + chessD / 2) / gridW + 1;

            if ((pos>xNum)||(pos<1))
                    return -1;
            else
                return pos;
        }
        public int getPosY(int viewY)
        {
            int pos = (viewY - viewOffY + chessD / 2) / gridH + 1;
            if ((pos > yNum) || (pos < 1))
                return -1;
            else
                return pos;
        }
        public int getViewX(int x)
        {
            return (x - 1) * gridW - chessD / 2 + viewOffX;
        }
        public int getViewY(int y)
        {
            return (y - 1) * gridH - chessD / 2 + viewOffY;
        }
    }
}