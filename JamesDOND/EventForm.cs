using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using JamesDOND.Data;
using JamesDOND.Controller;

namespace JamesDOND.Game
{
    public partial class EventForm : Overlay, IEventForm
    {

        private DONDController _controller;
        private PaintEventHandler drawCaseNumber;

        const int panelLeftStartX = -192;
        const int panelRightStartX = 820;


        const int panelStartY = 23;

        //public const bool fadeIn = true;
        //public const bool fadeOut = false;

        private string userName;
        private int caseValue;
        private int caseNumberPicked;
        private int caseNumberFinal;
        private int caseNumberOriginal;
        private int offerValue;
        private int timerToSkip;

        private bool pause;
        private bool gameOver;
        private bool lastCase;
        private bool pauseInput;

        public EventForm(Form tocover) : base(tocover)
        {
            this.Focus();
            this.Opacity = 1;
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(35, 35, 35);
            this.TransparencyKey = Color.FromArgb(35, 35, 35);

            InitializeComponent();

        }

        public void StartCaseOpenEvent()
        {
            this.Visible = true;
            this.pause = false;


            addCaseOpenScene();
        }

        public void StartBankOfferEvent()
        {
            this.Visible = true;
            this.pause = true;
 

            addCaseOpenScene();
            addBankOfferScene();

        }

        public void StartFinalEvent()
        {
            this.Visible = true;
            this.pause = true;


            addCaseOpenScene();
            addFinalScene();
        }

        public void SetController(DONDController controller)
        {
            _controller = controller;
        }

        public int CaseNumberPicked
        {
            get { return this.caseNumberPicked; }
            set { this.caseNumberPicked = value; }
        }

        public int CaseNumberOriginal
        {
            get { return this.caseNumberOriginal; }
            set { this.caseNumberOriginal = value; }
        }

        public int CaseNumberFinal
        {
            get { return this.caseNumberFinal; }
            set { this.caseNumberFinal = value; }
        }

        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value;
                  UpdateEventData();
                }
        }

        public int OfferValue
        {
            get { return this.offerValue; }
            set { this.offerValue = value; }
        }

        public int CaseValue
        {
            get { return this.caseValue; }
            set { this.caseValue = value;
                  UpdateEventData();
                }
        }

        public void UpdateEventData()
        {
            this.labelCongratulations.Text = "Congratulations " + userName + "! \n You just won " + caseValue.ToString("c0");
            
        }
        
        //private void InitializeComponent()
        //{
            

        //}

        private void skipEvent()
        {
            switch(timerToSkip)
            {
                case 0:
                    timerCaseOpen.Interval = 1;
                    break;

                case 1:
                    timerFadeInE.Stop();
                    timerEndScene.Interval = 1;
                    timerBankOffer.Interval = 1;
                    if (gameOver)
                    {
                        timerEndGame.Interval = 1;
                    }
                    break;
                case 2:
                    timerExit.Interval = 1;
                    break;
  
            }
            timerToSkip += 1;
        }

        private void resetTimers()
        {
            timerToSkip = 0;

            timerFadeInE.Interval = 30;
            timerFadeOutE.Interval = 30;
            timerCaseOpen.Interval = 3300;
            timerEndScene.Interval = 3300;
            timerBankOffer.Interval = 6600;
            timerEndGame.Interval = 6600;
            timerExit.Interval = 6600;
        }

        public void timerExit_Tick(object sender, EventArgs e)
        {

            _controller.playWinTheme();
            pictureBoxCase.Visible = false;

            labelCongratulations.Text = this.labelCongratulations.Text = "Congratulations " + userName + "! \n You just won " + caseValue.ToString("c0");

            panelGameOver.Visible = true;
            timerExit.Stop();
        }

        public void timerEndGame_Tick(object sender, EventArgs e)
        {
            pictureBoxCase.Visible = false;
            panelSwapScene.Visible = true;

            pictureBoxOriginalCase.Paint += new PaintEventHandler(paintKeepNumber);
            pictureBoxSwapCase.Paint += new PaintEventHandler(paintSwapNumber);

            
            
            buttonPlayAgain.MouseUp += new MouseEventHandler(delegate(object bSender, MouseEventArgs bE)
                {
                    if (!pauseInput)
                    {
                        gameOver = false;
                        this.panelGameOver.Visible = false;
                        hideForm();
                        _controller.postToServer(caseValue.ToString());
                        _controller.updateWinnings(caseValue);
                        _controller.updateGamesPlayed();
                        _controller.returnToMain();
                        _controller.restartGame();
                        pauseInput = true;
                    }
                });

            buttonQuit.MouseUp += new MouseEventHandler(delegate(object bSender, MouseEventArgs bE)
                {
                    if(!pauseInput)
                    {
                        gameOver = false;
                        this.panelGameOver.Visible = false;
                        hideForm();
                        _controller.postToServer(caseValue.ToString());
                        _controller.updateWinnings(caseValue);
                        _controller.updateGamesPlayed();
                        _controller.returnToMain();
                        _controller.returnToMainMenu();
                        pauseInput = true;
                    }


                });

            timerEndGame.Stop();
        }

        public void timerCaseOpen_Tick(object sender, EventArgs e)
        {
            Timer aTimer = sender as Timer;
            _controller.playCaseOpennedSound();

            if (aTimer.Enabled)
            {
                pictureBoxCase.Visible = true;
                pictureBoxCase.Image = JamesDOND.Game.Properties.Resources.case_open_alt;
                hideRemovedValues(lastCase);
                endCaseScene();
                aTimer.Stop();
            }
        }
        
        public void timerFadeOutE_Tick(object sender, EventArgs e)
        {
            if (timerFadeOutE.Enabled)
            {
                if (!panelsMoveOut())
                {
                    hideForm();
                    timerFadeOutE.Stop();
                    timerFadeOutE.Enabled = false;

                }
            }

        }

        public void timerFadeInE_Tick(object sender, EventArgs e)
        {
            if (timerFadeInE.Enabled)
            {

                if (!panelsMoveIn())
                {

                       _controller.playCaseOpenningSound();

                    timerFadeInE.Stop();
                    timerFadeInE.Enabled = false;
                }
            }
        }

        public void timerEndScene_Tick(object sender, EventArgs e)
        {
            timerToSkip = 2;
            skipEvent();

            if (timerEndScene.Enabled)
            {
                pictureBoxCase.Visible = false;

                if(!pause)
                {
                    _controller.returnToMain();
                    timerFadeOutE.Start();
                    
                    //timerEndScene.Enabled = false;
                }
                timerEndScene.Stop();

            }
        }

        public void timerBankOffer_Tick(object sender, EventArgs e)
        {
            _controller.playPhoneSound();
            pictureBoxCase.Visible = false;
            panelBankOffer.Visible = true;
            timerBankOffer.Stop();
        }

        private void endCaseScene()
        {
            timerEndScene.Stop();
            timerEndScene.Interval = 3300;
            pictureBoxCase.Paint -= drawCaseNumber;
            drawCaseNumber = paintCaseValue;
            pictureBoxCase.Paint += drawCaseNumber;

            if (!timerEndScene.Enabled)
            {
                timerEndScene.Start();
            }
            
        }

        private void addCaseOpenScene()
        {
           

            pauseInput = false;
            resetTimers();

            pictureBoxCase.Visible = true;
            timerCaseOpen.Stop();
            timerCaseOpen.Interval = 3300;
            if ((!timerFadeInE.Enabled) && (!gameOver))
            {
                panelLeftValues.Location = new Point(panelLeftStartX, panelStartY);
                panelRightValues.Location = new Point(panelRightStartX, panelStartY);
                timerFadeInE.Start();
            }

            pictureBoxCase.Paint -= drawCaseNumber;
            drawCaseNumber = paintCaseNumber;

            pictureBoxCase.Paint += drawCaseNumber;

            if (!timerCaseOpen.Enabled)
            {
                timerCaseOpen.Start();
            }
            
           
        }

        private void paintSwapNumber(object sender, PaintEventArgs e)
        {
            pictureBoxSwapCase.Invalidate();

            SizeF size = e.Graphics.MeasureString(caseNumberFinal.ToString(), new Font("Tahoma", 30, FontStyle.Bold));
            int center = (pictureBoxSwapCase.Size.Width / 2);
            center -= (int)size.Width / 2;
            e.Graphics.DrawString(caseNumberFinal.ToString(), new Font("Tahoma", 30, FontStyle.Bold), Brushes.Black, new Point(center, 32));
        }

        private void paintKeepNumber(object sender, PaintEventArgs e)
        {
            pictureBoxOriginalCase.Invalidate();

            SizeF size = e.Graphics.MeasureString(caseNumberOriginal.ToString(), new Font("Tahoma", 30, FontStyle.Bold));
            int center = (pictureBoxOriginalCase.Size.Width / 2);
            center -= (int)size.Width / 2;
            e.Graphics.DrawString(caseNumberOriginal.ToString(), new Font("Tahoma", 30, FontStyle.Bold), Brushes.Black, new Point(center, 32));
        }

        private void paintCaseNumber(object sender, PaintEventArgs e)
        {
            pictureBoxCase.Invalidate();

            SizeF size = e.Graphics.MeasureString(caseNumberPicked.ToString(), new Font("Tahoma", 45, FontStyle.Bold));
            int center = (pictureBoxCase.Size.Width / 2);
            center -= (int)size.Width / 2;
            e.Graphics.DrawString(caseNumberPicked.ToString(), new Font("Tahoma", 45, FontStyle.Bold), Brushes.Black, new Point(center, 70));
        }

        private void paintCaseValue(object sender, PaintEventArgs e)
        {
            pictureBoxCase.Invalidate();

            SizeF size = e.Graphics.MeasureString(caseValue.ToString("c0"), new Font("Tahoma", 30));
            int center = (pictureBoxCase.Size.Width / 2);
            center -= (int)size.Width / 2;
            e.Graphics.DrawString(caseValue.ToString("c0"), new Font("Tahoma", 30), Brushes.Gainsboro, new Point(center, 85));
        }

        private void addBankOfferScene()
        {
            labelOffer.Text = offerValue.ToString("c0");

            if (!timerBankOffer.Enabled)
            {
                timerBankOffer.Start();
            }
            
        }

        private void endBankOfferScene()
        {
            _controller.playNoDealSound();
            panelBankOffer.Visible = false;
            timerFadeOutE.Start();
            _controller.returnToMain();
        }

        private void dealAccepted()
        {
            buttonPlayAgain.MouseUp += new MouseEventHandler(delegate(object bSender, MouseEventArgs bE)
            {
                if (!pauseInput)
                {
                    gameOver = false;
                    this.panelGameOver.Visible = false;
                    hideForm();
                    _controller.postToServer(offerValue.ToString());
                    _controller.updateWinnings(offerValue);
                    _controller.updateGamesPlayed();
                    _controller.returnToMain();
                    _controller.restartGame();
                    pauseInput = true;
                }
            });


            buttonQuit.MouseUp += new MouseEventHandler(delegate(object bSender, MouseEventArgs bE)
            {
                if (!pauseInput)
                {
                    gameOver = false;
                    this.panelGameOver.Visible = false;
                    hideForm();
                    _controller.postToServer(caseValue.ToString());
                    _controller.updateWinnings(caseValue);
                    _controller.updateGamesPlayed();
                    _controller.returnToMain();
                    _controller.returnToMainMenu();
                    pauseInput = true;
                }


            });

            _controller.playCrowdBooSound();
            this.panelBankOffer.Visible = false;
            this.panelGameOver.Visible = true;
            this.labelCongratulations.Text = "Congratulations " + userName + "! \n You just won " + offerValue.ToString("c0");
        }

        private void addFinalScene()
        {
            this.gameOver = true;

            if (!timerEndGame.Enabled)
            {
                timerEndGame.Start();
            }         
        }

        private void addExitScene()
        {
            //
            this.panelSwapScene.Visible = false;
            this.pictureBoxCase.Image = JamesDOND.Game.Properties.Resources.case_closed_alt;
            if (!timerExit.Enabled)
            {
                timerExit.Start();
            }
        }

        private void swapCase()
        {
            lastCase = true;

            _controller.getNewCaseValue();
            caseNumberPicked = caseNumberFinal;
            addCaseOpenScene();

            addExitScene();
        }

        private void keepCase()
        {
            lastCase = true;

            _controller.getNewCaseValue();     
            caseNumberPicked = caseNumberOriginal;
            addCaseOpenScene();
            addExitScene();
        }

        private void hideForm()
        {
            timerCaseOpen.Stop();
            timerFadeInE.Stop();
            timerFadeOutE.Stop();
            
            pictureBoxCase.Image = JamesDOND.Game.Properties.Resources.case_closed_alt;
            panelLeftValues.Location = new Point(panelLeftStartX, panelStartY);
            panelRightValues.Location = new Point(panelLeftStartX, panelStartY);

            this.Visible = false;
        }

        private bool panelsMoveIn()
        {
            if ((panelLeftValues.Location.X >= 15) || (panelRightValues.Location.X <= 615))
            {
                return false;
            }

            panelLeftValues.Location = new Point(panelLeftValues.Location.X + 10, panelLeftValues.Location.Y);
            panelRightValues.Location = new Point(panelRightValues.Location.X - 10, panelRightValues.Location.Y);

            return true;
        }

        private bool panelsMoveOut()
        {
            if ((panelLeftValues.Location.X < panelLeftStartX) || (panelRightValues.Location.X > panelRightStartX))
            {
                return false;
            }

            panelLeftValues.Location = new Point(panelLeftValues.Location.X - 10, panelLeftValues.Location.Y);
            panelRightValues.Location = new Point(panelRightValues.Location.X + 10, panelRightValues.Location.Y);

            return true;
        }

        private void hideRemovedValues(bool finalCase)
        {
            for (int i = 0; i < labelsLeftValues.Length; i++)
            {
                if (finalCase)
                {
                    labelsLeftValues[i].Image = JamesDOND.Game.Properties.Resources.money_back_2_gray;
                }

                if (decimal.Parse(labelsLeftValues[i].Text, NumberStyles.Currency) == caseValue)
                {
                    labelsLeftValues[i].Image = JamesDOND.Game.Properties.Resources.money_back_2_gray;

                    if (finalCase)
                    {
                        labelsLeftValues[i].Image = JamesDOND.Game.Properties.Resources.money_back_2;
                    }
                }


            }

            for (int i = 0; i < labelsRightValues.Length; i++)
            {
                if (finalCase)
                {
                    labelsRightValues[i].Image = JamesDOND.Game.Properties.Resources.money_back_2_gray;
                }

                if (decimal.Parse(labelsRightValues[i].Text, NumberStyles.Currency) == caseValue)
                {
                    labelsRightValues[i].Image = JamesDOND.Game.Properties.Resources.money_back_2_gray;

                    if (finalCase)
                    {
                        labelsRightValues[i].Image = JamesDOND.Game.Properties.Resources.money_back_2;
                    }
                }
            }
        }
    }
}
