using System;
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
<<<<<<< HEAD
            Test t = new Test(Convert.ToInt32(textBoxWielkoscPlanszy.Text));
            t.Show();
=======
            if (Convert.ToInt32(textBoxWielkoscPlanszy.Text)>=3 && Convert.ToInt32(textBoxWielkoscPlanszy.Text)<=20)
            {
                Test t = new Test(Convert.ToInt32(textBoxWielkoscPlanszy.Text));
                t.Show();
            }
            else
            {
                MessageBox.Show("Wymiary planszy sa nie właściwe ac<3,20>");
            }
                
            
            
>>>>>>> d293dc3c58c0642602467095f0925f12b0e638df
            //Gra gra = new Gra(Convert.ToInt32(textBoxWielkoscPlanszy.Text));
            //gra.Show();
        }
    }
}
