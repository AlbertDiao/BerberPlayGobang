using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerberPlayGobang
{
    class Board
    {
        public int viewOffX, viewOffY;//棋盘边缘距离界面边缘的偏移量
        public int viewW, viewH;//棋盘宽度和高度
        public int xNum, yNum;//棋盘棋子最大数量
        
        //viewX转posX
        public int getPosX(int viewX)
        {
            int pos = (viewX - viewOffX + viewW / xNum / 2) / (viewW / xNum);

            if ((pos>xNum)||(pos<1))
                    return -1;
            else
                return pos;
        }
        public int getPosY(int viewY)
        {
            int pos = (viewY - viewOffY + viewH / yNum / 2) / (viewH / yNum);
            if ((pos > yNum) || (pos < 1))
                return -1;
            else
                return pos;
        }
        public int getViewX(int x)
        {
            return x * viewW / xNum - viewW / xNum / 2 + viewOffX -3;
        }
        public int getViewY(int y)
        {
            return y * viewH / yNum - viewH / yNum / 2 + viewOffY -3;
        }
    }
}