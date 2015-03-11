namespace JamesDOND.Game
{
    partial class StartMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenu));
            this.panelMenuOptions = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonCredits = new System.Windows.Forms.Button();
            this.buttonHighScores = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.panelBanner = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelLoginText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSign = new System.Windows.Forms.ComboBox();
            this.listBoxAge = new System.Windows.Forms.ListBox();
            this.soundPlayerMainMenu = new AxWMPLib.AxWindowsMediaPlayer();
            this.soundPlayerEffects = new AxWMPLib.AxWindowsMediaPlayer();
            this.playerSoundEffects2 = new AxWMPLib.AxWindowsMediaPlayer();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panelCredits = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCredits = new JamesCustomControls.JamesTextBox();
            this.panelHelp = new System.Windows.Forms.Panel();
            this.labelHelpText = new System.Windows.Forms.Label();
            this.jamesTextBox1 = new JamesCustomControls.JamesTextBox();
            this.buttonBack2 = new System.Windows.Forms.Button();
            this.panelMenuOptions.SuspendLayout();
            this.panelBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundPlayerMainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundPlayerEffects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerSoundEffects2)).BeginInit();
            this.panelCredits.SuspendLayout();
            this.panelHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenuOptions
            // 
            this.panelMenuOptions.BackColor = System.Drawing.Color.Transparent;
            this.panelMenuOptions.BackgroundImage = global::JamesDOND.Game.Properties.Resources.panel_main_menu;
            this.panelMenuOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMenuOptions.Controls.Add(this.buttonExit);
            this.panelMenuOptions.Controls.Add(this.buttonHelp);
            this.panelMenuOptions.Controls.Add(this.buttonCredits);
            this.panelMenuOptions.Controls.Add(this.buttonHighScores);
            this.panelMenuOptions.Controls.Add(this.buttonPlay);
            this.panelMenuOptions.Location = new System.Drawing.Point(211, 241);
            this.panelMenuOptions.Name = "panelMenuOptions";
            this.panelMenuOptions.Size = new System.Drawing.Size(384, 284);
            this.panelMenuOptions.TabIndex = 0;
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(203, 200);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(151, 56);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHelp.BackgroundImage")));
            this.buttonHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonHelp.FlatAppearance.BorderSize = 0;
            this.buttonHelp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHelp.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHelp.Location = new System.Drawing.Point(203, 131);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(151, 56);
            this.buttonHelp.TabIndex = 3;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonCredits
            // 
            this.buttonCredits.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCredits.BackgroundImage")));
            this.buttonCredits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCredits.FlatAppearance.BorderSize = 0;
            this.buttonCredits.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonCredits.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonCredits.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonCredits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCredits.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCredits.Location = new System.Drawing.Point(30, 200);
            this.buttonCredits.Name = "buttonCredits";
            this.buttonCredits.Size = new System.Drawing.Size(151, 56);
            this.buttonCredits.TabIndex = 2;
            this.buttonCredits.Text = "Credits";
            this.buttonCredits.UseVisualStyleBackColor = true;
            this.buttonCredits.Click += new System.EventHandler(this.buttonCredits_Click);
            // 
            // buttonHighScores
            // 
            this.buttonHighScores.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHighScores.BackgroundImage")));
            this.buttonHighScores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonHighScores.FlatAppearance.BorderSize = 0;
            this.buttonHighScores.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonHighScores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonHighScores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonHighScores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHighScores.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHighScores.Location = new System.Drawing.Point(30, 131);
            this.buttonHighScores.Name = "buttonHighScores";
            this.buttonHighScores.Size = new System.Drawing.Size(151, 56);
            this.buttonHighScores.TabIndex = 1;
            this.buttonHighScores.Text = "High Scores";
            this.buttonHighScores.UseVisualStyleBackColor = true;
            this.buttonHighScores.Click += new System.EventHandler(this.buttonHighScores_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackgroundImage = global::JamesDOND.Game.Properties.Resources.button_alt;
            this.buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPlay.FlatAppearance.BorderSize = 0;
            this.buttonPlay.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Font = new System.Drawing.Font("Arial Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.Location = new System.Drawing.Point(81, 35);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(219, 71);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.Text = "PLAY";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // panelBanner
            // 
            this.panelBanner.BackColor = System.Drawing.Color.Transparent;
            this.panelBanner.BackgroundImage = global::JamesDOND.Game.Properties.Resources.panel_banner;
            this.panelBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBanner.Controls.Add(this.pictureBox1);
            this.panelBanner.Location = new System.Drawing.Point(-2, 26);
            this.panelBanner.Name = "panelBanner";
            this.panelBanner.Size = new System.Drawing.Size(789, 148);
            this.panelBanner.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::JamesDOND.Game.Properties.Resources.banner;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(103, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(602, 81);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.Transparent;
            this.panelLogin.BackgroundImage = global::JamesDOND.Game.Properties.Resources.panel_main_menu;
            this.panelLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLogin.Controls.Add(this.buttonContinue);
            this.panelLogin.Controls.Add(this.label4);
            this.panelLogin.Controls.Add(this.labelLoginText);
            this.panelLogin.Controls.Add(this.label3);
            this.panelLogin.Controls.Add(this.textBoxName);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.comboBoxSign);
            this.panelLogin.Controls.Add(this.listBoxAge);
            this.panelLogin.Location = new System.Drawing.Point(189, 200);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(430, 339);
            this.panelLogin.TabIndex = 2;
            this.panelLogin.Visible = false;
            // 
            // buttonContinue
            // 
            this.buttonContinue.BackgroundImage = global::JamesDOND.Game.Properties.Resources.button_alt;
            this.buttonContinue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonContinue.FlatAppearance.BorderSize = 0;
            this.buttonContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContinue.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContinue.Location = new System.Drawing.Point(136, 259);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(144, 50);
            this.buttonContinue.TabIndex = 15;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Goldenrod;
            this.label4.Location = new System.Drawing.Point(68, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Choose Your Age";
            // 
            // labelLoginText
            // 
            this.labelLoginText.AutoSize = true;
            this.labelLoginText.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoginText.ForeColor = System.Drawing.Color.Gold;
            this.labelLoginText.Location = new System.Drawing.Point(155, 27);
            this.labelLoginText.Name = "labelLoginText";
            this.labelLoginText.Size = new System.Drawing.Size(112, 38);
            this.labelLoginText.TabIndex = 0;
            this.labelLoginText.Text = "LOGIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Goldenrod;
            this.label3.Location = new System.Drawing.Point(88, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Pick Your Sign";
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(229, 80);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(126, 21);
            this.textBoxName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Goldenrod;
            this.label2.Location = new System.Drawing.Point(68, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Enter Your Name:";
            // 
            // comboBoxSign
            // 
            this.comboBoxSign.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxSign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxSign.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSign.FormattingEnabled = true;
            this.comboBoxSign.Items.AddRange(new object[] {
            "Aries",
            "Taurus",
            "Gemini",
            "Cancer",
            "Leo",
            "Virgo",
            "Libra",
            "Scorpio",
            "Sagittarius",
            "Capricorn",
            "Aquarius",
            "Pisces"});
            this.comboBoxSign.Location = new System.Drawing.Point(229, 115);
            this.comboBoxSign.Name = "comboBoxSign";
            this.comboBoxSign.Size = new System.Drawing.Size(126, 23);
            this.comboBoxSign.TabIndex = 8;
            this.comboBoxSign.Text = "Choose Your Sign";
            // 
            // listBoxAge
            // 
            this.listBoxAge.BackColor = System.Drawing.Color.Gainsboro;
            this.listBoxAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxAge.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAge.ForeColor = System.Drawing.Color.Black;
            this.listBoxAge.FormattingEnabled = true;
            this.listBoxAge.ItemHeight = 15;
            this.listBoxAge.Items.AddRange(new object[] {
            "5 and Under",
            "5 - 12",
            "13 - 17",
            "18 - 65",
            "65 and Up"});
            this.listBoxAge.Location = new System.Drawing.Point(229, 158);
            this.listBoxAge.Name = "listBoxAge";
            this.listBoxAge.Size = new System.Drawing.Size(126, 77);
            this.listBoxAge.TabIndex = 10;
            // 
            // soundPlayerMainMenu
            // 
            this.soundPlayerMainMenu.Enabled = true;
            this.soundPlayerMainMenu.Location = new System.Drawing.Point(27, 496);
            this.soundPlayerMainMenu.Name = "soundPlayerMainMenu";
            this.soundPlayerMainMenu.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("soundPlayerMainMenu.OcxState")));
            this.soundPlayerMainMenu.Size = new System.Drawing.Size(45, 43);
            this.soundPlayerMainMenu.TabIndex = 3;
            this.soundPlayerMainMenu.Visible = false;
            // 
            // soundPlayerEffects
            // 
            this.soundPlayerEffects.Enabled = true;
            this.soundPlayerEffects.Location = new System.Drawing.Point(78, 496);
            this.soundPlayerEffects.Name = "soundPlayerEffects";
            this.soundPlayerEffects.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("soundPlayerEffects.OcxState")));
            this.soundPlayerEffects.Size = new System.Drawing.Size(45, 43);
            this.soundPlayerEffects.TabIndex = 4;
            this.soundPlayerEffects.Visible = false;
            // 
            // playerSoundEffects2
            // 
            this.playerSoundEffects2.Enabled = true;
            this.playerSoundEffects2.Location = new System.Drawing.Point(129, 496);
            this.playerSoundEffects2.Name = "playerSoundEffects2";
            this.playerSoundEffects2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("playerSoundEffects2.OcxState")));
            this.playerSoundEffects2.Size = new System.Drawing.Size(45, 43);
            this.playerSoundEffects2.TabIndex = 5;
            this.playerSoundEffects2.Visible = false;
            // 
            // buttonBack
            // 
            this.buttonBack.BackgroundImage = global::JamesDOND.Game.Properties.Resources.button_alt;
            this.buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(225, 291);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(144, 50);
            this.buttonBack.TabIndex = 15;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            this.buttonBack.MouseEnter += new System.EventHandler(this.backMouseEnter);
            this.buttonBack.MouseHover += new System.EventHandler(this.backMouseLeave);
            // 
            // panelCredits
            // 
            this.panelCredits.BackColor = System.Drawing.Color.Transparent;
            this.panelCredits.BackgroundImage = global::JamesDOND.Game.Properties.Resources.panel_main_menu;
            this.panelCredits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelCredits.Controls.Add(this.label1);
            this.panelCredits.Controls.Add(this.textBoxCredits);
            this.panelCredits.Controls.Add(this.buttonBack);
            this.panelCredits.Location = new System.Drawing.Point(99, 180);
            this.panelCredits.Name = "panelCredits";
            this.panelCredits.Size = new System.Drawing.Size(602, 362);
            this.panelCredits.TabIndex = 16;
            this.panelCredits.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(233, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 38);
            this.label1.TabIndex = 17;
            this.label1.Text = "CREDITS";
            // 
            // textBoxCredits
            // 
            this.textBoxCredits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCredits.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCredits.ForeColor = System.Drawing.Color.Goldenrod;
            this.textBoxCredits.Location = new System.Drawing.Point(90, 76);
            this.textBoxCredits.Name = "textBoxCredits";
            this.textBoxCredits.ReadOnly = true;
            this.textBoxCredits.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.textBoxCredits.Size = new System.Drawing.Size(430, 197);
            this.textBoxCredits.TabIndex = 16;
            this.textBoxCredits.Text = resources.GetString("textBoxCredits.Text");
            // 
            // panelHelp
            // 
            this.panelHelp.BackColor = System.Drawing.Color.Transparent;
            this.panelHelp.BackgroundImage = global::JamesDOND.Game.Properties.Resources.panel_main_menu;
            this.panelHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHelp.Controls.Add(this.labelHelpText);
            this.panelHelp.Controls.Add(this.jamesTextBox1);
            this.panelHelp.Controls.Add(this.buttonBack2);
            this.panelHelp.Location = new System.Drawing.Point(93, 186);
            this.panelHelp.Name = "panelHelp";
            this.panelHelp.Size = new System.Drawing.Size(602, 362);
            this.panelHelp.TabIndex = 18;
            this.panelHelp.Visible = false;
            // 
            // labelHelpText
            // 
            this.labelHelpText.AutoSize = true;
            this.labelHelpText.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHelpText.ForeColor = System.Drawing.Color.Gold;
            this.labelHelpText.Location = new System.Drawing.Point(131, 29);
            this.labelHelpText.Name = "labelHelpText";
            this.labelHelpText.Size = new System.Drawing.Size(371, 38);
            this.labelHelpText.TabIndex = 17;
            this.labelHelpText.Text = "HELP && INSTRUCTIONS";
            // 
            // jamesTextBox1
            // 
            this.jamesTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jamesTextBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jamesTextBox1.ForeColor = System.Drawing.Color.Goldenrod;
            this.jamesTextBox1.Location = new System.Drawing.Point(90, 76);
            this.jamesTextBox1.Name = "jamesTextBox1";
            this.jamesTextBox1.ReadOnly = true;
            this.jamesTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.jamesTextBox1.Size = new System.Drawing.Size(430, 197);
            this.jamesTextBox1.TabIndex = 16;
            this.jamesTextBox1.Text = resources.GetString("jamesTextBox1.Text");
            // 
            // buttonBack2
            // 
            this.buttonBack2.BackgroundImage = global::JamesDOND.Game.Properties.Resources.button_alt;
            this.buttonBack2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBack2.FlatAppearance.BorderSize = 0;
            this.buttonBack2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonBack2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonBack2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack2.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack2.Location = new System.Drawing.Point(225, 291);
            this.buttonBack2.Name = "buttonBack2";
            this.buttonBack2.Size = new System.Drawing.Size(144, 50);
            this.buttonBack2.TabIndex = 15;
            this.buttonBack2.Text = "Back";
            this.buttonBack2.UseVisualStyleBackColor = true;
            this.buttonBack2.Click += new System.EventHandler(this.buttonBack_Click);
            this.buttonBack2.MouseEnter += new System.EventHandler(this.backMouseEnter);
            this.buttonBack2.MouseLeave += new System.EventHandler(this.backMouseLeave);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JamesDOND.Game.Properties.Resources.bkg_main_menu;
            this.ClientSize = new System.Drawing.Size(784, 560);
            this.Controls.Add(this.panelHelp);
            this.Controls.Add(this.playerSoundEffects2);
            this.Controls.Add(this.soundPlayerEffects);
            this.Controls.Add(this.soundPlayerMainMenu);
            this.Controls.Add(this.panelBanner);
            this.Controls.Add(this.panelMenuOptions);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panelCredits);
            this.Location = new System.Drawing.Point(500, 500);
            this.Name = "StartMenu";
            this.Text = "Deal Or No Deal";
            this.panelMenuOptions.ResumeLayout(false);
            this.panelBanner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundPlayerMainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundPlayerEffects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerSoundEffects2)).EndInit();
            this.panelCredits.ResumeLayout(false);
            this.panelCredits.PerformLayout();
            this.panelHelp.ResumeLayout(false);
            this.panelHelp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenuOptions;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonCredits;
        private System.Windows.Forms.Button buttonHighScores;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Panel panelBanner;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelLoginText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSign;
        private System.Windows.Forms.ListBox listBoxAge;
        private AxWMPLib.AxWindowsMediaPlayer soundPlayerMainMenu;
        private AxWMPLib.AxWindowsMediaPlayer soundPlayerEffects;
        private AxWMPLib.AxWindowsMediaPlayer playerSoundEffects2;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Panel panelCredits;
        private JamesCustomControls.JamesTextBox textBoxCredits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelHelp;
        private System.Windows.Forms.Label labelHelpText;
        private JamesCustomControls.JamesTextBox jamesTextBox1;
        private System.Windows.Forms.Button buttonBack2;

    }
}