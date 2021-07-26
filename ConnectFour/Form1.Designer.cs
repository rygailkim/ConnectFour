
namespace ConnectFour
{
    partial class Form1
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
            this.pbox_ConnectFourLogo = new System.Windows.Forms.PictureBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.pnl_settings = new System.Windows.Forms.Panel();
            this.lbl_currentTurn = new System.Windows.Forms.Label();
            this.lbl_gameMode = new System.Windows.Forms.Label();
            this.gbox_gameSettings = new System.Windows.Forms.GroupBox();
            this.cmbx_difficultyLevel = new System.Windows.Forms.ComboBox();
            this.rbtn_twoPlayers = new System.Windows.Forms.RadioButton();
            this.rbtn_onePlayer = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_ConnectFourLogo)).BeginInit();
            this.pnl_settings.SuspendLayout();
            this.gbox_gameSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbox_ConnectFourLogo
            // 
            this.pbox_ConnectFourLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbox_ConnectFourLogo.BackgroundImage = global::ConnectFour.Properties.Resources.ConnectFour_Logo;
            this.pbox_ConnectFourLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbox_ConnectFourLogo.Location = new System.Drawing.Point(654, 12);
            this.pbox_ConnectFourLogo.Name = "pbox_ConnectFourLogo";
            this.pbox_ConnectFourLogo.Size = new System.Drawing.Size(358, 212);
            this.pbox_ConnectFourLogo.TabIndex = 0;
            this.pbox_ConnectFourLogo.TabStop = false;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Exit.Location = new System.Drawing.Point(841, 471);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(118, 49);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.Text = "EXIT";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Reset.Location = new System.Drawing.Point(699, 471);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(118, 49);
            this.btn_Reset.TabIndex = 2;
            this.btn_Reset.Text = "RESET";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // pnl_settings
            // 
            this.pnl_settings.BackColor = System.Drawing.Color.White;
            this.pnl_settings.Controls.Add(this.gbox_gameSettings);
            this.pnl_settings.Controls.Add(this.lbl_gameMode);
            this.pnl_settings.Controls.Add(this.lbl_currentTurn);
            this.pnl_settings.Location = new System.Drawing.Point(712, 230);
            this.pnl_settings.Name = "pnl_settings";
            this.pnl_settings.Size = new System.Drawing.Size(237, 225);
            this.pnl_settings.TabIndex = 5;
            // 
            // lbl_currentTurn
            // 
            this.lbl_currentTurn.AutoSize = true;
            this.lbl_currentTurn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currentTurn.Location = new System.Drawing.Point(11, 12);
            this.lbl_currentTurn.Name = "lbl_currentTurn";
            this.lbl_currentTurn.Size = new System.Drawing.Size(77, 30);
            this.lbl_currentTurn.TabIndex = 0;
            this.lbl_currentTurn.Text = "TURN:";
            this.lbl_currentTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_gameMode
            // 
            this.lbl_gameMode.AutoSize = true;
            this.lbl_gameMode.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_gameMode.Location = new System.Drawing.Point(11, 42);
            this.lbl_gameMode.Name = "lbl_gameMode";
            this.lbl_gameMode.Size = new System.Drawing.Size(142, 30);
            this.lbl_gameMode.TabIndex = 3;
            this.lbl_gameMode.Text = "GAME MODE";
            this.lbl_gameMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbox_gameSettings
            // 
            this.gbox_gameSettings.Controls.Add(this.rbtn_onePlayer);
            this.gbox_gameSettings.Controls.Add(this.rbtn_twoPlayers);
            this.gbox_gameSettings.Controls.Add(this.cmbx_difficultyLevel);
            this.gbox_gameSettings.Location = new System.Drawing.Point(19, 85);
            this.gbox_gameSettings.Name = "gbox_gameSettings";
            this.gbox_gameSettings.Size = new System.Drawing.Size(200, 121);
            this.gbox_gameSettings.TabIndex = 4;
            this.gbox_gameSettings.TabStop = false;
            this.gbox_gameSettings.Text = "Game Settings";
            // 
            // cmbx_difficultyLevel
            // 
            this.cmbx_difficultyLevel.FormattingEnabled = true;
            this.cmbx_difficultyLevel.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard"});
            this.cmbx_difficultyLevel.Location = new System.Drawing.Point(19, 85);
            this.cmbx_difficultyLevel.Name = "cmbx_difficultyLevel";
            this.cmbx_difficultyLevel.Size = new System.Drawing.Size(162, 21);
            this.cmbx_difficultyLevel.TabIndex = 2;
            this.cmbx_difficultyLevel.Text = "Select Difficulty Level";
            this.cmbx_difficultyLevel.SelectedIndexChanged += new System.EventHandler(this.cmbx_difficultyLevel_SelectedIndexChanged);
            // 
            // rbtn_twoPlayers
            // 
            this.rbtn_twoPlayers.AutoSize = true;
            this.rbtn_twoPlayers.Checked = true;
            this.rbtn_twoPlayers.Location = new System.Drawing.Point(19, 29);
            this.rbtn_twoPlayers.Name = "rbtn_twoPlayers";
            this.rbtn_twoPlayers.Size = new System.Drawing.Size(110, 17);
            this.rbtn_twoPlayers.TabIndex = 3;
            this.rbtn_twoPlayers.TabStop = true;
            this.rbtn_twoPlayers.Text = "Human vs Human";
            this.rbtn_twoPlayers.UseVisualStyleBackColor = true;
            this.rbtn_twoPlayers.CheckedChanged += new System.EventHandler(this.rbtn_twoPlayers_CheckedChanged);
            // 
            // rbtn_onePlayer
            // 
            this.rbtn_onePlayer.AutoSize = true;
            this.rbtn_onePlayer.Location = new System.Drawing.Point(19, 52);
            this.rbtn_onePlayer.Name = "rbtn_onePlayer";
            this.rbtn_onePlayer.Size = new System.Drawing.Size(121, 17);
            this.rbtn_onePlayer.TabIndex = 4;
            this.rbtn_onePlayer.Text = "Human vs Computer";
            this.rbtn_onePlayer.UseVisualStyleBackColor = true;
            this.rbtn_onePlayer.CheckedChanged += new System.EventHandler(this.rbtn_onePlayer_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 561);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.pnl_settings);
            this.Controls.Add(this.pbox_ConnectFourLogo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect Four";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_ConnectFourLogo)).EndInit();
            this.pnl_settings.ResumeLayout(false);
            this.pnl_settings.PerformLayout();
            this.gbox_gameSettings.ResumeLayout(false);
            this.gbox_gameSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbox_ConnectFourLogo;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Panel pnl_settings;
        private System.Windows.Forms.GroupBox gbox_gameSettings;
        private System.Windows.Forms.RadioButton rbtn_onePlayer;
        private System.Windows.Forms.RadioButton rbtn_twoPlayers;
        private System.Windows.Forms.ComboBox cmbx_difficultyLevel;
        private System.Windows.Forms.Label lbl_gameMode;
        private System.Windows.Forms.Label lbl_currentTurn;
    }
}

