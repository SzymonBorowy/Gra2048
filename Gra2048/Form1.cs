﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra2048
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Test t = new Test(Convert.ToInt32(textBoxWielkoscPlanszy.Text));
            t.Show();
            //Gra gra = new Gra(Convert.ToInt32(textBoxWielkoscPlanszy.Text));
            //gra.Show();
        }
    }
}