﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerberPlayGobang
{
    public partial class GameForm : Form
    {
        private Board board;
        private Game game;
        private Qi[,] qi;

        public GameForm()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            board = new Board();
            game = new Game();

            board.viewOffX = 22;
            board.viewOffY = 22;
            board.viewH = 535;
            board.viewW = 535;
            board.xNum = 15;
            board.yNum = 15;
            board.gridH = 35;
            board.gridW = 35;
            board.chessD = 28;
            qi = new Qi[board.xNum + 1, board.yNum + 1];
            board.board = new int[board.xNum + 1, board.yNum + 1] ;
            game.step = new Step[board.xNum * board.yNum];
            
            for(int x=1;x<=board.xNum;x++)
            {
                for (int y = 1; y <= board.yNum; y++)
                {
                    qi[x,y] = new Qi();

                    qi[x,y].color = Game.BLACK;

                    int viewX = board.getViewX(x);
                    int viewY = board.getViewY(y);
                    qi[x, y].Location = new Point(viewX + pictureBox1.Location.X, viewY + pictureBox1.Location.Y);

                    //qi[x,y].Location = new Point(x + pictureBox1.Location.X, y + pictureBox1.Location.Y);
                    qi[x,y].Hide();
                    this.Controls.Add(qi[x,y]);
                    qi[x,y].BringToFront();
                    board.board[x, y] = Game.NONE;
                }

            }
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            int x = board.getPosX(p.X);
            int y = board.getPosY(p.Y);
            label3.Text = x.ToString();
            label4.Text = y.ToString();

            //如果落子位置越界直接退出
            if (x == -1)
                return;
            if (y == -1)
                return;

            //开始落子
            game.place(x, y, game.player, board);

            //根据当前玩家创建不同颜色的棋子
            qi[x,y].color = game.player;
            qi[x, y].Show();

            //算杀
            int jc = game.judge(board);
            if (jc == Game.BLACK)
                MessageBox.Show("黑赢！");
            else if (jc == Game.WHITE)
                MessageBox.Show("白赢！");

            //切换下一个玩家
            if (game.player == Game.BLACK)
                game.player = Game.WHITE;
            else
                game.player = Game.BLACK;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            string X = (p.X - board.viewOffX).ToString();
            string Y = (p.Y - board.viewOffY).ToString();
            //MessageBox.Show(p.ToString(), X + Y);
            label1.Text = X;
            label2.Text = Y;
        }

        //悔棋
        private void tbBtn_Click(object sender, EventArgs e)
        {
       
            Step s = game.tackBack(board);
            if(s.x>0)
                qi[s.x, s.y].Hide();
            //还原玩家
            if (game.player == Game.BLACK)
                game.player = Game.WHITE;
            else
                game.player = Game.BLACK;
        }
    }
}
