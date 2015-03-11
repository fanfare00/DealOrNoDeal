using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using JamesDOND.Data;
using JamesDOND.Controller;

namespace JamesDOND.Game
{
    public partial class MainForm : Form, IMainForm
    {

        DONDController _controller;
        private int _caseNumber;
        private int _turnNumber;
        private int _TurnsBeforeOffer;
        private Stopwatch elapsedTime;

        public MainForm()
        {


            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.DoubleBuffered = true;

            InitializeComponent();


            elapsedTime = new Stopwatch();
            elapsedTime.Start();
            timerElapsed.Start();

            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {                 
                    c.MouseEnter += (sender, eventArgs) =>
                        {
                            
                            c.BackgroundImage = JamesDOND.Game.Properties.Resources.case_only_small_alt;
                            _controller.playTickSound();
                            
                        };

                    c.MouseLeave += (sender, eventArgs) =>
                        {
                          
                            c.BackgroundImage = JamesDOND.Game.Properties.Resources.case_only_small;
                        };
                }
            }


        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (UserName == "")
            {
                this.Close();
            }
        }

        public void SetController(DONDController controller)
        {
            _controller = controller;
        }

        public void ResetForm()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    c.Visible = true;
                }
            }

            UpdateGameInfo();

            labelPickAText.Visible = true;
            labelCaseText.Visible = true;
            labelCaseCount.Visible = false;
            labelCasesText.Visible = false;
            labelToOpenText.Visible = false;
            buttonMyCase.Text = "?";
        }

        public void UpdateGameInfo()
        {
            _turnNumber = 6;
            _TurnsBeforeOffer = 6;
            
           // labelGamesPlayed.Text = (_GamesPlayed+1).ToString();
        }

        public void SetInitialCase(int caseNumberOriginal)
        {
            buttonMyCase.Text = caseNumberOriginal.ToString();
            labelPickAText.Visible = false;
            labelCaseText.Visible = false;
            labelCaseCount.Visible = true;
            labelCasesText.Visible = true;
            labelToOpenText.Visible = true;
        }

        public void ShutDown()
        {
            this.Visible = false;
        }


        public int TurnsBeforeOffer
        {
            get { return this._TurnsBeforeOffer;}
            set {this._TurnsBeforeOffer = value;}
        }

        public string UserName
        {
            get { return this.labelUserName.Text; }
            set { this.labelUserName.Text = value; }
        }

        public int TurnNumber
        {
            get { return this._turnNumber; }
            set { this._turnNumber = value;
                  if (value == -1) { value += 1; }
                  this.labelCaseCount.Text = value.ToString();
                }
        }

        public int GamesPlayed
        {
            get { return Int32.Parse(this.labelGamesPlayed.Text); }
            set { this.labelGamesPlayed.Text = value.ToString(); }
        }

        public int CaseNumber
        {
            get { return this._caseNumber; }
            set { this._caseNumber = value; }
        }

        public int TotalWinnings
        {
            get { return Int32.Parse(this.labelMoneyEarned.Text); }
            set {this.labelMoneyEarned.Text = value.ToString("c0"); }
        }

        private void buttonCase_Click(object sender, EventArgs e)
        {
            _controller.playClickSound();

            Button caseClicked = sender as Button;

            caseClicked.Visible = false;

            _caseNumber = Int32.Parse(caseClicked.Text);
            _controller.selectNewCase();

            if (_turnNumber == 0)
            {

                _controller.getNewOfferValue();
                _controller.addOfferScene();

                _TurnsBeforeOffer -= 1;
                if (_TurnsBeforeOffer < 1)
                {
                    _TurnsBeforeOffer = 1;
                }

                _turnNumber = _TurnsBeforeOffer;
                if (_turnNumber == 1)
                {
                    _turnNumber = 1;
                }
               
                this.labelCaseCount.Text = _turnNumber.ToString();
            }
            else if ((_turnNumber != _TurnsBeforeOffer) && (_turnNumber != -1))
            {
                _controller.addCaseScene();
            }
            else if (_turnNumber == -1)
            {

                //   
                _controller.addFinalScene();
            }

        }

        private void timerElapsed_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = elapsedTime.Elapsed;
            string elapsed = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

            labelTimeElapsed.Text = elapsed;


        }






    }


}
