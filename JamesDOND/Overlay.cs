using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using JamesDOND.Controller;

namespace JamesDOND.Game
{
    public partial class Overlay : Form, IOverlay
    {
        DONDController _controller;

        Timer timerFadeIn;
        Timer timerFadeOut;

        public Overlay()
        {

        }

        public Overlay(Form tocover)
        {


            this.DoubleBuffered = true;

            this.BackColor = Color.Black;
            this.Opacity = 0.0;      // Tweak as desired
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.AutoScaleMode = AutoScaleMode.None;
            this.Location = tocover.PointToScreen(Point.Empty);
            this.ClientSize = tocover.ClientSize;
            tocover.LocationChanged += Cover_LocationChanged;
            tocover.ClientSizeChanged += Cover_ClientSizeChanged;
            this.Show(tocover);
            tocover.Focus();
            // Disable Aero transitions, the plexiglass gets too visible
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int value = 1;
                DwmSetWindowAttribute(tocover.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }

            timerFadeIn = new Timer();
            timerFadeIn.Interval = 30;
            
            timerFadeIn.Tick += new EventHandler(timerFadeIn_Tick);      
                        

            timerFadeOut = new Timer();
            timerFadeOut.Interval = 30;
            timerFadeOut.Tick += new EventHandler(timerFadeOut_Tick);



            

        }

        public void timerFadeIn_Tick(object sender, EventArgs e)
        {
            timerFadeOut.Stop();
            if (!lowerOpacity())
            {
                timerFadeIn.Stop();
            }
        }

        public void resetAlpha()
        {
            this.Opacity = 0.00;
        }

        public void timerFadeOut_Tick(object sender, EventArgs e)
        {
            timerFadeIn.Stop();
            if (!increaseOpacity())
            {
                timerFadeOut.Stop();
                this.Visible = false;
            }
        }

        public void SetController(DONDController controller)
        {
            _controller = controller;
        }


        public void fadeIn()
        {
            this.Visible = true;
            this.Opacity = 0.00;
            this.timerFadeOut.Enabled = false;

            if (!timerFadeIn.Enabled)
            {
                timerFadeIn.Start();
            }
            
        }

        public void fadeOut()
        {

            this.Opacity = 0.80;
            this.timerFadeIn.Enabled = false;

            if (!timerFadeOut.Enabled)
            {
                timerFadeOut.Start();
            }
            
        }

        private bool increaseOpacity()
        {
                
            if (this.Opacity >= 0.00)
            {
                 this.Opacity -= 0.04;
                return true;
            }
            else
            {
                this.Opacity = 0.00;
                return false;
            }

        }

        private bool lowerOpacity()
        {

             if (this.Opacity <= 0.80)
             {
                 this.Opacity += 0.04;
                 return true;
             }
             else
             {
                 this.Opacity = 0.80;
                 return false;
             }

        }

        public double Alpha
        {
            get { return Opacity; }
            set
            {
                Opacity = value;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void Cover_LocationChanged(object sender, EventArgs e)
        {
            // Ensure the plexiglass follows the owner
            this.Location = this.Owner.PointToScreen(Point.Empty);
        }
        private void Cover_ClientSizeChanged(object sender, EventArgs e)
        {
            // Ensure the plexiglass keeps the owner covered
            this.ClientSize = this.Owner.ClientSize;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Restore owner
            this.Owner.LocationChanged -= Cover_LocationChanged;
            this.Owner.ClientSizeChanged -= Cover_ClientSizeChanged;
            if (!this.Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
            {
                int value = 1;
                DwmSetWindowAttribute(this.Owner.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
            base.OnFormClosing(e);
        }
        protected override void OnActivated(EventArgs e)
        {
            // Always keep the owner activated instead
            this.BeginInvoke(new Action(() => this.Owner.Activate()));
        }
        //private System.ComponentModel.IContainer components;
        private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);

    }



}