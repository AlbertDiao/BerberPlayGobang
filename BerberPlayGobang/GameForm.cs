using System;
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

            board.viewOffX = 45;
            board.viewOffY = 45;
            board.viewH = 510;
            board.viewW = 510;
            board.xNum = 17;
            board.yNum = 17;
            qi = new Qi[board.xNum + 1, board.yNum + 1];

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
            //根据当前玩家创建不同颜色的棋子
            qi[x,y].color = game.player;
            qi[x, y].Show();

            //切换下一个玩家
            game.player *= -1;
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
    }
}
