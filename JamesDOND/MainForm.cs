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
    public partial class MainForm : Form, IMainForm
    {
        Overlay overlay;
        //EventForm eventForm;
        DONDController _controller;
        private int _caseNumber;
        private int _turnNumber;
        private int _TurnsBeforeOffer;
        //private int caseNumberOriginal;
        //private int caseNumberFinal;

        public MainForm()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            //overlay = new Overlay(this);

            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {                 
                    c.MouseEnter += (sender, eventArgs) =>
                        {
                            
                            c.BackgroundImage = JamesDOND.Game.Properties.Resources.case_only_small_alt;
                            
                        };

                    c.MouseLeave += (sender, eventArgs) =>
                        {
                          
                            c.BackgroundImage = JamesDOND.Game.Properties.Resources.case_only_small;
                        };
                }
            }
        }

        public void SetController(DONDController controller)
        {
            _controller = controller;
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

        private void button1_Click(object sender, EventArgs e)
        {
            //overlay.Show();
            //overlay.fade(Overlay.fadeIn);
            _controller.getNewCaseValue();
            _controller.addCaseScene();
            
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

        private void button2_Click(object sender, EventArgs e)
        {
            this._controller.addNewUser("check");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //overlay.Show();
            //overlay.fade(Overlay.fadeIn);
            _controller.getNewCaseValue();
            _controller.getNewOfferValue();
            _controller.addOfferScene();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //overlay.Show();
            //overlay.fade(Overlay.fadeIn);
            _controller.getNewCaseValue();
            _controller.addFinalScene();
        }

        private void buttonCase_Click(object sender, EventArgs e)
        {
            Button caseClicked = sender as Button;

            caseClicked.Visible = false;

            _caseNumber = Int32.Parse(caseClicked.Text);
            _controller.selectNewCase();

            if (_turnNumber == 0)
            {
                _turnNumber = _TurnsBeforeOffer-1;
                _TurnsBeforeOffer -= 1;

                if (_TurnsBeforeOffer < 1)
                {
                    _TurnsBeforeOffer = 1;
                }

                _controller.getNewOfferValue();
                _controller.addOfferScene();
               
                this.labelCaseCount.Text = _turnNumber.ToString();
            }
            else if ((_turnNumber != _TurnsBeforeOffer) && (_turnNumber != -1))
            {
                _controller.addCaseScene();
            }
            else
            {
                
                // if (_turnNumber == -1)
                _controller.addFinalScene();
            }

        }


    }


}
