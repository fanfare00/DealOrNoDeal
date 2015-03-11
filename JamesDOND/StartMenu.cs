using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JamesDOND.Controller;

namespace JamesDOND.Game
{
    public partial class StartMenu : Form, IStartMenu
    {
        DONDController _controller;

        public StartMenu()
        {
            InitializeComponent();
        }

        public void SetController(DONDController controller)
        {
            _controller = controller;
        }

        public StartMenu(Form tocover)
        {
            tocover.Location = this.Location;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.LocationChanged += (o, e) =>
                {
                    tocover.Location = this.Location;
                };



            InitializeComponent();
            

            this.buttonContinue.MouseEnter += (o, e) =>
                {
                    bool canClose = (comboBoxSign.SelectedIndex > -1) && (textBoxName.Text != "") && (listBoxAge.SelectedIndex != -1);

                    if (canClose)
                    {
                        buttonContinue.BackgroundImage = JamesDOND.Game.Properties.Resources.button_play;
                        this.soundPlayerEffects.URL = @"Resources\mouseOverTick.wav";
                    }
                };

            this.buttonContinue.MouseLeave += (o, e) =>
            {
                buttonContinue.BackgroundImage = JamesDOND.Game.Properties.Resources.button_alt;
            };



            foreach (Control c in this.panelMenuOptions.Controls)
            {
                if (c is Button)
                {
                    c.MouseEnter += (o, e) =>
                        {
                            c.BackgroundImage = JamesDOND.Game.Properties.Resources.button_play;
                            this.soundPlayerEffects.URL = @"Resources\mouseOverTick.wav";
                        };

                    c.MouseLeave += (o, e) =>
                       {
                           c.BackgroundImage = JamesDOND.Game.Properties.Resources.button_alt;
                       };
                }
            }

            this.soundPlayerMainMenu.settings.setMode("loop", true);
            this.soundPlayerMainMenu.settings.volume = 10;
            this.soundPlayerMainMenu.URL = @"Resources\mainMenuTheme.wav";

        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            soundPlayerEffects.URL = @"Resources\click.wav";
            panelLogin.Visible = true;
            panelMenuOptions.Visible = false;
            this.textBoxName.Select();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            bool canClose = (comboBoxSign.SelectedIndex > -1) && (textBoxName.Text != "") && (listBoxAge.SelectedIndex != -1);

            if (canClose)
            {
                soundPlayerEffects.URL = @"Resources\click.wav";
                soundPlayerMainMenu.URL = @"Resources\mainGameTheme.wav";
                //soundPlayerMainMenu.close();
                _controller.addNewUser(textBoxName.Text);
                this.Close();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            soundPlayerEffects.URL = @"Resources\click.wav";
            this.Close();
        }

        private void buttonHighScores_Click(object sender, EventArgs e)
        {
            soundPlayerEffects.URL = @"Resources\click.wav";
            System.Diagnostics.Process.Start("http://i.jdonaldmccarthy.bitnamiapp.com/index/dealornodeal.html");
        }

        public void PlayCaseOpenningSound()
        {
            if (soundPlayerEffects.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                
            }
            else
            {
                soundPlayerEffects.URL = @"Resources\caseOpenning.wav";
            }
        }

        public void PlayCaseOpennedSound()
        {
            soundPlayerEffects.URL = @"Resources\caseOpenned.wav";
        }

        public void PlayTickSound()
        {
            soundPlayerEffects.URL = @"Resources\mouseOverTick.wav";
        }

        public void PlayClickSound()
        {
            soundPlayerEffects.URL = @"Resources\click.wav";
        }

        public void PlayWinTheme()
        {
            soundPlayerEffects.URL = @"Resources\winTheme.wav";
        }

        public void PlayPhoneSound()
        {
            soundPlayerEffects.URL = @"Resources\phone.wav";
        }

        public void PlayCrowdBooSound()
        {
            soundPlayerEffects.URL = @"Resources\crowdBoo.wav";
        }

        public void PlayNoDealSound()
        {
            playerSoundEffects2.settings.volume = 10;
            playerSoundEffects2.URL = @"Resources\noDeal2.wav";
        }

        public void ReturnToMainMenu()
        {
            this.ShowDialog();
            this.panelLogin.Visible = false;
            this.panelMenuOptions.Visible = true;
        }

        private void buttonCredits_Click(object sender, EventArgs e)
        {
            panelMenuOptions.Visible = false;
            panelCredits.Visible = true;
            panelCredits.Select();
           
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            panelHelp.Visible = false;
            panelCredits.Visible = false;
            panelMenuOptions.Visible = true;

        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            panelMenuOptions.Visible = false;
            panelHelp.Visible = true;
            
        }

        private void backMouseEnter(object sender, EventArgs e)
        {
            Button buttonEntered = sender as Button;

            buttonEntered.BackgroundImage = JamesDOND.Game.Properties.Resources.button_play;
        }

        private void backMouseLeave(object sender, EventArgs e)
        {
            Button buttonEntered = sender as Button;

            buttonEntered.BackgroundImage = JamesDOND.Game.Properties.Resources.button_alt;
        }

        
    }
}
