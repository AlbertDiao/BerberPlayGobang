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
    public partial class Form1 : Form
    {
        //Form2 gameForm;
        public Form1()
        {
            InitializeComponent();
            //gameForm = new Form2();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 gameForm = new Form2();
            this.Hide();

            gameForm.ShowDialog();
            this.Close();

        }
    }
}
