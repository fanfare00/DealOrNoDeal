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
        private Panel panelBankOffer;
        private Panel panelSwapScene;
        private Panel panelLeftValues;
        private Panel panelRightValues;
        private Panel panelGameOver;
        private Label labelCongratulations;
        private Label labelOffer;
        private PictureBox pictureBoxCase;
        private PictureBox pictureBoxOriginalCase;
        private PictureBox pictureBoxSwapCase;
        private Label[] labelsLeftValues;
        private Label[] labelsRightValues;
        private Button buttonDeal;
        private Button buttonNoDeal;
        //private Button buttonPlayAgain;

        private Timer timerFadeInE;
        private Timer timerFadeOutE;
        private Timer timerCaseOpen;
        private Timer timerEndScene;
        private Timer timerBankOffer;
        private Timer timerEndGame;
        private Timer timerExit;

        private DONDController _controller;
        private PaintEventHandler drawCaseNumber;

        const int panelLeftStartX = -200;
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
        private bool test;

        public EventForm(Form tocover) : base(tocover)
        {
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
        
        private void InitializeComponent()
        {
            

            this.SuspendLayout();

            int[] originalMoneyValues = { 1, 5, 10, 15, 25, 50, 75, 100, 200, 300, 
                                          400, 500, 750, 1000, 5000, 10000, 25000, 
                                          50000, 75000, 100000, 200000, 300000, 
                                          400000, 500000, 750000, 1000000 };



            ////////////////////////////////////////////////////////////////////
            ////    SET UP OFFER SCENE PANEL
            ////////////////////////////////////////////////////////////////////

            this.panelBankOffer = new Panel();
            this.panelBankOffer.Location = new Point(190, 25);
            this.panelBankOffer.Size = new Size(400, 520);
            this.panelBankOffer.BackColor = Color.Transparent;

            PictureBox pictureBoxRedButton = new PictureBox();
            pictureBoxRedButton.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRedButton.Image = JamesDOND.Game.Properties.Resources.redbutton;
            pictureBoxRedButton.Size = new Size(230, 235);
            pictureBoxRedButton.Location = new Point((this.panelBankOffer.Size.Width/2) - (pictureBoxRedButton.Size.Width/2), 135);
            pictureBoxRedButton.BackColor = Color.Transparent;
            this.panelBankOffer.Controls.Add(pictureBoxRedButton);

            labelOffer = new Label();
            labelOffer.TextAlign = ContentAlignment.MiddleCenter;
            labelOffer.BackColor = Color.Transparent;
            labelOffer.ForeColor = Color.Black;
            labelOffer.Font = new Font("Arial Black", 30, FontStyle.Bold);
            labelOffer.Size = new Size(350, 70);
            labelOffer.Location = new Point((this.panelBankOffer.Size.Width / 2) - (labelOffer.Size.Width / 2), 20);
            labelOffer.Image = JamesDOND.Game.Properties.Resources.info_panel;
            this.panelBankOffer.Controls.Add(labelOffer);

            buttonDeal = new Button();


            buttonDeal.Size = new Size(162, 38);
            buttonDeal.Location = new Point(20, 420);
            buttonDeal.BackgroundImage = JamesDOND.Game.Properties.Resources.button_deal;


            buttonNoDeal = new Button();
            buttonNoDeal.Size = new Size(162, 38);
            buttonNoDeal.Location = new Point(220, 420);
            buttonNoDeal.BackgroundImage = JamesDOND.Game.Properties.Resources.button_noDeal;

            
            this.panelBankOffer.Controls.Add(buttonNoDeal);
            this.panelBankOffer.Controls.Add(buttonDeal);



            foreach (Control c in this.panelBankOffer.Controls)
            {
                if (c is Button)
                {
                    Button aButton = c as Button;
                    aButton.ImageAlign = ContentAlignment.MiddleCenter;
                    aButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    aButton.BackgroundImageLayout = ImageLayout.Center;
                    aButton.Anchor = AnchorStyles.None;
                    aButton.FlatStyle = FlatStyle.Flat;
                    aButton.FlatAppearance.BorderSize = 0;
                    aButton.MouseHover += (sender, EventArgs) =>
                        {
                            aButton.BackColor = Color.Red;
                            aButton.Size = new Size(171, 44);
                        };
                    aButton.MouseLeave += (sender, EventArgs) =>
                        {
                            aButton.BackColor = Color.Transparent;
                            aButton.Size = new Size(162, 38);
                        };
                }
            }

            buttonNoDeal.MouseDown += (sender, EventArgs) =>
            {
                endBankOfferScene();
            };


            buttonDeal.MouseDown += (sender, EventArgs) =>
            {
                dealAccepted();
            };



            
            

            this.panelBankOffer.Visible = false;
            this.Controls.Add(panelBankOffer);
            ////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////
            ////    SET UP SWAP SCENE PANEL
            ////////////////////////////////////////////////////////////////////

            this.panelSwapScene = new Panel();
            this.panelSwapScene.Location = new Point(190, 25);
            this.panelSwapScene.Size = new Size(400, 540);
            this.panelSwapScene.BackColor = Color.Transparent;


            Button buttonKeep = new Button();
            buttonKeep.Size = new Size(162, 37);
            buttonKeep.Location = new Point(20, 250);
            buttonKeep.BackgroundImage = JamesDOND.Game.Properties.Resources.button_keep;
            this.panelSwapScene.Controls.Add(buttonKeep);

            Button buttonSwap = new Button();
            buttonSwap.Size = new Size(162, 37);
            buttonSwap.Location = new Point(220, 250);
            buttonSwap.BackgroundImage = JamesDOND.Game.Properties.Resources.button_swap;
            this.panelSwapScene.Controls.Add(buttonSwap);

            foreach (Control c in this.panelSwapScene.Controls)
            {
                if (c is Button)
                {
                    Button aButton = c as Button;
                    aButton.ImageAlign = ContentAlignment.MiddleCenter;
                    aButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    aButton.BackgroundImageLayout = ImageLayout.Center;
                    aButton.Anchor = AnchorStyles.None;
                    aButton.FlatStyle = FlatStyle.Flat;
                    aButton.FlatAppearance.BorderSize = 0;
                    aButton.MouseHover += (sender, EventArgs) =>
                    {
                        aButton.BackColor = Color.Red;
                        aButton.Size = new Size(171, 44);
                    };
                    aButton.MouseLeave += (sender, EventArgs) =>
                    {
                        aButton.BackColor = Color.Transparent;
                        aButton.Size = new Size(162, 38);
                    };
                }

            }

            buttonKeep.MouseDown += (sender, EventArgs) =>
            {
                keepCase();
            };


            buttonSwap.MouseDown += (sender, EventArgs) =>
            {
                swapCase();
            };

            Label labelSwap = new Label();
            labelSwap.TextAlign = ContentAlignment.MiddleCenter;
            labelSwap.BackColor = Color.Transparent;
            labelSwap.ForeColor = Color.Black;
            labelSwap.Font = new Font("Arial Black", 21, FontStyle.Bold);
            labelSwap.Size = new Size(350, 70);
            labelSwap.Location = new Point((this.panelBankOffer.Size.Width / 2) - (labelOffer.Size.Width / 2), 20);
            labelSwap.Image = JamesDOND.Game.Properties.Resources.info_panel;
            labelSwap.Text = "Final Decision";
            this.panelSwapScene.Controls.Add(labelSwap);

            pictureBoxOriginalCase = new PictureBox();
            pictureBoxOriginalCase.Image = Properties.Resources.case_closed_alt;
            pictureBoxOriginalCase.Size = new Size(160, 240);
            pictureBoxOriginalCase.Location = new Point(20, 320);
            pictureBoxOriginalCase.SizeMode = PictureBoxSizeMode.StretchImage;
            this.panelSwapScene.Controls.Add(pictureBoxOriginalCase);

            pictureBoxSwapCase = new PictureBox();
            pictureBoxSwapCase.Image = Properties.Resources.case_closed_alt;
            pictureBoxSwapCase.Size = new Size(160, 240);
            pictureBoxSwapCase.Location = new Point(220, 320);
            pictureBoxSwapCase.SizeMode = PictureBoxSizeMode.StretchImage;
            this.panelSwapScene.Controls.Add(pictureBoxSwapCase);

            this.panelSwapScene.Visible = false;
            this.Controls.Add(panelSwapScene);
            ////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////
            ////   SET UP GAME OVER PANEL
            ////////////////////////////////////////////////////////////////////
            this.panelGameOver = new Panel();
            this.panelGameOver.Location = new Point(190, 175);
            this.panelGameOver.Size = new Size(400, 200);
            this.panelGameOver.BackColor = Color.Transparent;
            this.panelGameOver.BackgroundImageLayout = ImageLayout.Stretch;
            this.panelGameOver.BackgroundImage = JamesDOND.Game.Properties.Resources.panel_main_menu;

            labelCongratulations = new Label();
            labelCongratulations.Location = new Point(5, 7);
            labelCongratulations.Size = new Size(390, 90);
            labelCongratulations.TextAlign = ContentAlignment.MiddleCenter;
            labelCongratulations.ForeColor = Color.Gold;
            labelCongratulations.BackColor = Color.Transparent;
            //labelCongratulations.Text = "Congratualtions " + userName + "!\n You just won " + winningAmount.ToString("c0")+"!";
            labelCongratulations.Font = new Font("Arial Black", 14, FontStyle.Bold);
            this.panelGameOver.Controls.Add(labelCongratulations);


            Label labelGameOverInstructions = new Label();
            labelGameOverInstructions.Location = new Point(5, 90);
            labelGameOverInstructions.Size = new Size(390, 50);
            labelGameOverInstructions.TextAlign = ContentAlignment.MiddleCenter;
            labelGameOverInstructions.Text = "Play again or Return to Main Menu?";
            labelGameOverInstructions.ForeColor = Color.Goldenrod;
            labelGameOverInstructions.BackColor = Color.Transparent;
            labelGameOverInstructions.Font = new Font("Arial Black", 12, FontStyle.Bold);
            this.panelGameOver.Controls.Add(labelGameOverInstructions);

            //buttonPlayAgain = new Button();
            //buttonPlayAgain.Size = new Size(130, 45);
            //buttonPlayAgain.Location = new Point(50, 140);
            //buttonPlayAgain.Text = "Play Again";
            //this.panelGameOver.Controls.Add(buttonPlayAgain);

            Button buttonQuit = new Button();
            buttonQuit.Size = new Size(130, 45);
            buttonQuit.Location = new Point(215, 140);
            buttonQuit.Text = "Main Menu";
            this.panelGameOver.Controls.Add(buttonQuit);

            foreach (Control c in this.panelGameOver.Controls)
            {
                if (c is Button)
                {
                    Button aButton = c as Button;
                    aButton.BackColor = Color.Transparent;
                    aButton.ImageAlign = ContentAlignment.MiddleCenter;
                    aButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    aButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    aButton.BackgroundImageLayout = ImageLayout.Stretch;
                    aButton.Anchor = AnchorStyles.Top;
                    aButton.FlatStyle = FlatStyle.Flat;
                    aButton.FlatAppearance.BorderSize = 0;
                    aButton.BackgroundImage = JamesDOND.Game.Properties.Resources.button_play;
                    aButton.TextAlign = ContentAlignment.MiddleCenter;
                    aButton.Font = new Font("Arial Black", 12, FontStyle.Bold);
                    aButton.MouseHover += (sender, EventArgs) =>
                    {
                        aButton.Size = new Size(143, 49);
                        aButton.Font = new Font("Arial Black", 13, FontStyle.Bold);
                    };
                    aButton.MouseLeave += (sender, EventArgs) =>
                    {
                        aButton.Size = new Size(130, 45);
                        aButton.Font = new Font("Arial Black", 12, FontStyle.Bold);
                        
                    };
                }

            }

            this.panelGameOver.Visible = false;
            this.Controls.Add(panelGameOver);
            ////////////////////////////////////////////////////////////////////


            ////////////////////////////////////////////////////////////////////
            ////    SET UP LEFT MONEY VALUES PANEL
            ////////////////////////////////////////////////////////////////////
            this.panelLeftValues = new Panel();
            this.panelLeftValues.Location = new Point(panelLeftStartX, 23);
            this.panelLeftValues.Size = new Size(180, 540);

            labelsLeftValues = new Label[13];

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

            this.Controls.Add(panelLeftValues);
            ////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////
            ////    SET UP RIGHT MONEY VALUES PANEL
            ////////////////////////////////////////////////////////////////////

            this.panelRightValues = new Panel();
            this.panelRightValues.Location = new Point(panelRightStartX, 23);
            this.panelRightValues.Size = new Size(180, 540);

            labelsRightValues = new Label[13];

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
            ////////////////////////////////////////////////////////////////////

            pictureBoxCase = new PictureBox();
            pictureBoxCase.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCase.Image = JamesDOND.Game.Properties.Resources.case_closed_alt;
            pictureBoxCase.BackColor = Color.Transparent;
            pictureBoxCase.Size = new Size(300, 450);
            pictureBoxCase.Location = new Point(240, 185);
            pictureBoxCase.ForeColor = Color.Red;
            pictureBoxCase.Visible = false;
            pictureBoxCase.Click += (o, e) =>
                {
                    skipEvent();
                };


            this.Controls.Add(pictureBoxCase);


            timerFadeInE = new Timer();
            timerFadeInE.Interval = 30;
            timerFadeInE.Tick += new EventHandler(timerFadeInE_Tick);

            timerFadeOutE = new Timer();
            timerFadeOutE.Interval = 30;
            timerFadeOutE.Tick += new EventHandler(timerFadeOutE_Tick);

            timerCaseOpen = new Timer();
            timerCaseOpen.Interval = 4000;
            timerCaseOpen.Tick += new EventHandler(timerCaseOpen_Tick);

            timerEndScene = new Timer();
            timerEndScene.Interval = 4000;
            timerEndScene.Tick += new EventHandler(timerEndScene_Tick);

            timerBankOffer = new Timer();
            timerBankOffer.Interval = 8000;
            timerBankOffer.Tick += new EventHandler(timerBankOffer_Tick);

            timerEndGame = new Timer();
            timerEndGame.Interval = 8000;
            timerEndGame.Tick += new EventHandler(timerEndGame_Tick);

            timerExit = new Timer();
            timerExit.Interval = 8000;
            timerExit.Tick += new EventHandler(timerExit_Tick);

            timerToSkip = 0;

            this.ResumeLayout(false);
        }

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
            timerCaseOpen.Interval = 4000;
            timerEndScene.Interval = 4000;
            timerBankOffer.Interval = 8000;
            timerEndGame.Interval = 8000;
            timerExit.Interval = 8000;
        }

        public void timerExit_Tick(object sender, EventArgs e)
        {


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

            

            //buttonPlayAgain.Click += new EventHandler(delegate(object bSender, EventArgs bE)
            //    {
            //        this.panelGameOver.Visible = false;
            //        hideForm();
            //        _controller.updateWinnings();
            //        _controller.updateGamesPlayed();
            //        _controller.returnToMain();
            //        _controller.restartGame();
            //    });
            timerEndGame.Stop();
        }

        public void timerCaseOpen_Tick(object sender, EventArgs e)
        {
            Timer aTimer = sender as Timer;

            if (aTimer.Enabled)
            {
                pictureBoxCase.Visible = true;
                pictureBoxCase.Image = JamesDOND.Game.Properties.Resources.case_open_alt;
                hideRemovedValues(test);
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
            pictureBoxCase.Visible = false;
            panelBankOffer.Visible = true;
            timerBankOffer.Stop();
        }

        private void endCaseScene()
        {
            timerEndScene.Stop();
            timerEndScene.Interval = 4000;
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
            resetTimers();

            pictureBoxCase.Visible = true;
            timerCaseOpen.Stop();
            timerCaseOpen.Interval = 4000;
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
            panelBankOffer.Visible = false;
            timerFadeOutE.Start();
            _controller.returnToMain();
        }

        private void dealAccepted()
        {
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
            test = true;

            _controller.getNewCaseValue();
            caseNumberPicked = caseNumberFinal;
            addCaseOpenScene();

            addExitScene();
        }

        private void keepCase()
        {
            test = true;

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
            if ((panelLeftValues.Location.X >= 10) || (panelRightValues.Location.X <= 615))
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
