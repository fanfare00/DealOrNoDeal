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
            this.SuspendLayout();

            int[] originalMoneyValues = { 1, 5, 10, 15, 25, 50, 75, 100, 200, 300, 
                                          400, 500, 750, 1000, 5000, 10000, 25000, 
                                          50000, 75000, 100000, 200000, 300000, 
                                          400000, 500000, 750000, 1000000 };

            this.panelLeftValues = new Panel();
            this.panelLeftValues.Location = new Point(10, 23);
            this.panelLeftValues.Size = new Size(180, 540);
           

            this.panelRightValues = new Panel();
            this.panelRightValues.Location = new Point((615), 23);
            this.panelRightValues.Size = new Size(180, 540);
            

            labelsLeftValues = new Label[13];
            labelsRightValues = new Label[13];

            for (int i = 0; i < 13; i++)
            {
                this.labelsLeftValues[i] = new Label();
                this.labelsLeftValues[i].Size = new Size(155, 32);
                this.labelsLeftValues[i].Location = new Point(0, 0 + (40 * i));
                this.labelsLeftValues[i].Image = JamesDOND.Game.Properties.Resources.money_back_2;
                this.labelsLeftValues[i].BackColor = Color.Transparent;
                this.labelsLeftValues[i].Text = originalMoneyValues[i].ToString();
                this.labelsLeftValues[i].TextAlign = ContentAlignment.MiddleRight;
                this.labelsLeftValues[i].Font = new Font("Tahoma", 16, FontStyle.Bold);
                this.labelsLeftValues[i].ForeColor = Color.Black;
                this.panelLeftValues.Controls.Add(labelsLeftValues[i]);
            }

            for (int i = 0; i < 13; i++)
            {
                this.labelsRightValues[i] = new Label();
                this.labelsRightValues[i].Size = new Size(155, 32);
                this.labelsRightValues[i].Location = new Point(0, 0 + (40 * i));
                this.labelsRightValues[i].Image = JamesDOND.Game.Properties.Resources.money_back_2;
                this.labelsRightValues[i].BackColor = Color.Transparent;
                this.labelsRightValues[i].Text = String.Format("{0:#,##0}", originalMoneyValues[i + 13]);
                this.labelsRightValues[i].TextAlign = ContentAlignment.MiddleRight;
                this.labelsRightValues[i].Font = new Font("Tahoma", 16, FontStyle.Bold);
                this.labelsRightValues[i].ForeColor = Color.Black;
                this.panelRightValues.Controls.Add(labelsRightValues[i]);

            }

            this.Controls.Add(panelRightValues);
            this.Controls.Add(panelLeftValues);

            pictureBoxCase = new PictureBox();
            pictureBoxCase.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCase.Image = JamesDOND.Game.Properties.Resources.case_closed_alt;
            pictureBoxCase.BackColor = Color.Transparent;
            pictureBoxCase.Size = new Size(300, 450);
            pictureBoxCase.Location = new Point(240, 185);
            pictureBoxCase.ForeColor = Color.Red;
            pictureBoxCase.Visible = false;
            this.Controls.Add(pictureBoxCase);

            //pictureBoxCase.Click += new EventHandler(DealForm_Click);
            //pictureBoxCase.Paint += new PaintEventHandler(addTextToCase);

            this.ResumeLayout(false);
        }
        
        public void addCaseOpenScene()
        {

        }
    }
}
