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
        public const int NONE = 0;
        public const int BLACK = 1;
        public const int WHITE = 2;
        public int player;//表示当前准备落子的玩家
        public Step[] step;//保存步数
        private int sNum = 0;
        public Game()
        {
            player = BLACK;
        }

        public void place(int x,int y, int color, Board board)
        {
            step[sNum] = new Step(x, y,color);
            board.board[x, y] = color;
            sNum++;
        }

        public Step tackBack(Board board)
        {
            if (sNum < 1)
                return new Step(-1,-1,-1);
            sNum--;
            board.board[step[sNum].x, step[sNum].y] = NONE;
            return step[sNum];
        }

        private int checkLeft(int x, int y, int color, Board board)
        {
            x--;
            if (x < 1)
                return 0;

            if (board.board[x, y] != color)
                return 0;

            return 1 + checkLeft(x, y, color, board);
        }

        private int checkRight(int x, int y, int color, Board board)
        {
            x++;
            if (x > board.xNum)
                return 0;

            if (board.board[x, y] != color)
                return 0;

            return 1 + checkRight(x, y, color, board);
        }

        private int checkTop(int x, int y, int color, Board board)
        {
            y--;
            if (y < 1)
                return 0;

            if (board.board[x, y] != color)
                return 0;

            return 1 + checkTop(x, y, color, board);
        }

        private int checkBottom(int x, int y, int color, Board board)
        {
            y++;
            if (y > board.yNum)
                return 0;

            if (board.board[x, y] != color)
                return 0;

            return 1 + checkBottom(x, y, color, board);
        }

        private int checkTopLeft(int x, int y, int color, Board board)
        {
            x--; y--;
            if (x < 1 || y < 1)
                return 0;

            if (board.board[x, y] != color)
                return 0;

            return 1 + checkTopLeft(x, y, color, board);
        }

        private int checkBottomRight(int x, int y, int color, Board board)
        {
            x++; y++;
            if (x > board.xNum || y > board.yNum)
                return 0;

            if (board.board[x, y] != color)
                return 0;

            return 1 + checkBottomRight(x, y, color, board);
        }

        private int checkTopRight(int x, int y, int color, Board board)
        {
            x++; y--;
            if (x > board.xNum || y < 1)
                return 0;

            if (board.board[x, y] != color)
                return 0;

            return 1 + checkTopRight(x, y, color, board);
        }

        private int checkBottomLeft(int x, int y, int color, Board board)
        {
            x--; y++;
            if (x <1 || y > board.yNum)
                return 0;

            if (board.board[x, y] != color)
                return 0;

            return 1 + checkBottomLeft(x, y, color, board);
        }

        //算杀
        public int judge(Board board)
        {
            for (int x = 1; x <= board.xNum; x++)
            {
                for (int y = 1; y <= board.yNum; y++)
                {
                    if(board.board[x,y]==BLACK)
                    {
                        //计算横着的是否有五个字
                        if (1+ checkLeft(x, y, BLACK, board) + checkRight(x, y, BLACK, board) >= 5)
                            return BLACK;

                        if (1 + checkTop(x, y, BLACK, board) + checkBottom(x, y, BLACK, board) >= 5)
                            return BLACK;

                        if (1 + checkTopLeft(x, y, BLACK, board) + checkBottomRight(x, y, BLACK, board) >= 5)
                            return BLACK;

                        if (1 + checkTopRight(x, y, BLACK, board) + checkBottomLeft(x, y, BLACK, board) >= 5)
                            return BLACK;
                    }
                    else if(board.board[x,y]==WHITE)
                    {
                        //计算横着的是否有五个字
                        if (1 + checkLeft(x, y, WHITE, board) + checkRight(x, y, WHITE, board) >= 5)
                            return WHITE;

                        if (1 + checkTop(x, y, WHITE, board) + checkBottom(x, y, WHITE, board) >= 5)
                            return WHITE;

                        if (1 + checkTopLeft(x, y, WHITE, board) + checkBottomRight(x, y, WHITE, board) >= 5)
                            return WHITE;

                        if (1 + checkTopRight(x, y, WHITE, board) + checkBottomLeft(x, y, WHITE, board) >= 5)
                            return WHITE;
                    }
                }
            }
            return NONE;
        }
    }

}
