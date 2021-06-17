using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NP_Config
{
    public partial class Form2 : Form
    {
        public int NPvar = 0;
        public Button[] ButtonNP = new Button[10];
        public Form2()
        {
            InitializeComponent();
            ButtonNP[0] = NP1;
            ButtonNP[1] = NP2;
            ButtonNP[2] = NP3;
            ButtonNP[3] = NP4;
            ButtonNP[4] = NP5;
            ButtonNP[5] = NP6;
            ButtonNP[6] = NP7;
            ButtonNP[7] = NP8;
            ButtonNP[8] = NP9;
            ButtonNP[9] = NP10;

            for (int i = 0; i < 10; i++)
            {
                ButtonNP[i].Visible = false;
            }
        }

        public void Adress_and_UCH (int AdressDat, string UCH, int quantityNP)
        {
            AdressDat_lable.Text = Convert.ToString(AdressDat);
            UCH_Lable.Text = UCH;
            for (int i = 0; i < quantityNP; i++)
            {
                ButtonNP[i].Visible = true;
            }
        }


        private void NP1_Click(object sender, EventArgs e)
        {
            NPvar = 1;
            Close();
        }

        private void NP2_Click(object sender, EventArgs e)
        {
            NPvar = 2;
            Close();
        }

        private void NP3_Click(object sender, EventArgs e)
        {
            NPvar = 3;
            Close();
        }

        private void NP4_Click(object sender, EventArgs e)
        {
            NPvar = 4;
            Close();
        }

        private void NP5_Click(object sender, EventArgs e)
        {
            NPvar = 5;
            Close();
        }

        private void NP6_Click(object sender, EventArgs e)
        {
            NPvar = 6;
            Close();
        }
        private void NP7_Click(object sender, EventArgs e)
        {
            NPvar = 7;
            Close();
        }

        private void NP8_Click(object sender, EventArgs e)
        {
            NPvar = 8;
            Close();
        }

        private void NP9_Click(object sender, EventArgs e)
        {
            NPvar = 9;
            Close();
        }
        private void NP10_Click(object sender, EventArgs e)
        {
            NPvar = 10;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
