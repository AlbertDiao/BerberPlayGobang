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
    public partial class LoginForm : Form
    {
        //Form2 gameForm;
        public LoginForm()
        {
            InitializeComponent();
            //gameForm = new Form2();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            GameForm gameForm = new GameForm();
            this.Hide();

            gameForm.ShowDialog();
            this.Close();

        }
    }
}
