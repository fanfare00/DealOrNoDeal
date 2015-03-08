using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JamesDOND.Data;
using JamesDOND.Controller;

namespace JamesDOND.Game
{
    public partial class MainForm : Form
    {
        Overlay overlay;
        EventForm eventForm;

        public MainForm()
        {
            overlay = new Overlay(this);
            eventForm = new EventForm(this);

            eventForm.Hide();
            overlay.Hide();
            InitializeComponent();
        }

        public void addOverlay()
        {
            //overlay.Alpha = 0.75;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void addCaseOpenScene()
        {
            //eventForm.addCaseOpenScene
        }
    }


}
