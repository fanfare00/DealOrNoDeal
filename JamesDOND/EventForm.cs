using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JamesDOND.Game
{
    partial class EventForm : Overlay
    {
        private Panel panelLeftValues;
        private Panel panelRightValues;
        private Label labelKeep;
        private Label labelSwap;
        private PictureBox pictureBoxCase;
        private PictureBox pictureBoxLeftSwap;
        private PictureBox pictureBoxRightSwap;
        private Label[] labelsLeftValues;
        private Label[] labelsRightValues;

        public EventForm(Form tocover) : base(tocover)
        {
            this.Opacity = 1;
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(35, 35, 35);
            this.TransparencyKey = Color.FromArgb(35, 35, 35);

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            for (int i = 0; i < 13; i++)
            {
                //labelsLeftValues[i] = new Label();
                //labelsLeftValues[i].Size = new Size(155, 32);
                //labelsLeftValues[i].Location = new Point(0, 0 + (40 * i));
                //labelsLeftValues[i].Image = JamesDOND.Properties.Resources.money_back_2;
                //labelsLeftValues[i].BackColor = Color.Transparent;
                //labelsLeftValues[i].Text = originalMoneyValues[i].ToString();
                //labelsLeftValues[i].TextAlign = ContentAlignment.MiddleRight;
                //labelsLeftValues[i].Font = new Font("Tahoma", 16, FontStyle.Bold);
                //labelsLeftValues[i].ForeColor = Color.Black;
                //panelLeftValues.Controls.Add(labelsLeftValues[i]);
            }

            for (int i = 0; i < 13; i++)
            {
                //labelsRightValues[i] = new Label();
                //labelsRightValues[i].Size = new Size(155, 32);
                //labelsRightValues[i].Location = new Point(0, 0 + (40 * i));
                //labelsRightValues[i].Image = DealOrNoDeal.Properties.Resources.money_back_2;
                //labelsRightValues[i].BackColor = Color.Transparent;
                //labelsRightValues[i].Text = String.Format("{0:#,##0}", arrMoneyValues[i + 13]);
                //labelsRightValues[i].TextAlign = ContentAlignment.MiddleRight;
                //labelsRightValues[i].Font = new Font("Tahoma", 16, FontStyle.Bold);
                //labelsRightValues[i].ForeColor = Color.Black;
                //panelRightValues.Controls.Add(labelsRightSide[i]);

            }
        }


    }
}
