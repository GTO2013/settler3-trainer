namespace Settlers3Trainer
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.manaBTN = new System.Windows.Forms.Button();
            this.manaLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.lvlLabel = new System.Windows.Forms.Label();
            this.UpdateMemoryTMR = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.GameAvailTMR = new System.Windows.Forms.Timer(this.components);
            this.levelLabel = new System.Windows.Forms.Label();
            this.winGameBTN = new System.Windows.Forms.Button();
            this.loseGameBTN = new System.Windows.Forms.Button();
            this.ExplainLabel = new System.Windows.Forms.Label();
            this.gameStateLabel = new System.Windows.Forms.Label();
            this.soldierIDLabel = new System.Windows.Forms.Label();
            this.superSoldierBTN = new System.Windows.Forms.Button();
            this.charDefLabel = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.groupBoxSelection = new System.Windows.Forms.GroupBox();
            this.selAllAll = new System.Windows.Forms.RadioButton();
            this.selAll = new System.Windows.Forms.RadioButton();
            this.selOne = new System.Windows.Forms.RadioButton();
            this.typeLabel = new System.Windows.Forms.Label();
            this.teamLabel = new System.Windows.Forms.Label();
            this.comboBoxTeam = new System.Windows.Forms.ComboBox();
            this.manualSelLabel = new System.Windows.Forms.Label();
            this.gameModeLabel = new System.Windows.Forms.Label();
            this.selectedCharLabel = new System.Windows.Forms.Label();
            this.groupBoxSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // manaBTN
            // 
            this.manaBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.manaBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manaBTN.Location = new System.Drawing.Point(16, 96);
            this.manaBTN.Name = "manaBTN";
            this.manaBTN.Size = new System.Drawing.Size(115, 34);
            this.manaBTN.TabIndex = 0;
            this.manaBTN.Text = "(4) AUS";
            this.manaBTN.UseVisualStyleBackColor = true;
            this.manaBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // manaLabel
            // 
            this.manaLabel.AutoSize = true;
            this.manaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manaLabel.Location = new System.Drawing.Point(12, 73);
            this.manaLabel.Name = "manaLabel";
            this.manaLabel.Size = new System.Drawing.Size(157, 20);
            this.manaLabel.TabIndex = 1;
            this.manaLabel.Text = "Unendliches Mana";
            this.manaLabel.Click += new System.EventHandler(this.manaLabel_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(11, 9);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(270, 24);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "Trainer Status: Game not found";
            this.statusLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // lvlLabel
            // 
            this.lvlLabel.AutoSize = true;
            this.lvlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlLabel.Location = new System.Drawing.Point(221, 73);
            this.lvlLabel.Name = "lvlLabel";
            this.lvlLabel.Size = new System.Drawing.Size(172, 20);
            this.lvlLabel.TabIndex = 10;
            this.lvlLabel.Text = "Krieger Stufe (1,2,3)";
            this.lvlLabel.Click += new System.EventHandler(this.lvl1Label_Click);
            // 
            // UpdateMemoryTMR
            // 
            this.UpdateMemoryTMR.Enabled = true;
            this.UpdateMemoryTMR.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GameAvailTMR
            // 
            this.GameAvailTMR.Enabled = true;
            this.GameAvailTMR.Interval = 250;
            this.GameAvailTMR.Tick += new System.EventHandler(this.GameAvailTMR_Tick);
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.Location = new System.Drawing.Point(258, 101);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(80, 25);
            this.levelLabel.TabIndex = 12;
            this.levelLabel.Text = "Stufe 1";
            this.levelLabel.Click += new System.EventHandler(this.label2_Click_2);
            // 
            // winGameBTN
            // 
            this.winGameBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.winGameBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winGameBTN.Location = new System.Drawing.Point(16, 176);
            this.winGameBTN.Name = "winGameBTN";
            this.winGameBTN.Size = new System.Drawing.Size(153, 34);
            this.winGameBTN.TabIndex = 13;
            this.winGameBTN.Text = "(5) Gewinne Spiel";
            this.winGameBTN.UseVisualStyleBackColor = true;
            this.winGameBTN.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // loseGameBTN
            // 
            this.loseGameBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loseGameBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loseGameBTN.Location = new System.Drawing.Point(225, 176);
            this.loseGameBTN.Name = "loseGameBTN";
            this.loseGameBTN.Size = new System.Drawing.Size(153, 34);
            this.loseGameBTN.TabIndex = 14;
            this.loseGameBTN.Text = "(6) Verliere Spiel";
            this.loseGameBTN.UseVisualStyleBackColor = true;
            this.loseGameBTN.Click += new System.EventHandler(this.loseGameBTN_Click);
            // 
            // ExplainLabel
            // 
            this.ExplainLabel.AutoSize = true;
            this.ExplainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExplainLabel.Location = new System.Drawing.Point(12, 143);
            this.ExplainLabel.Name = "ExplainLabel";
            this.ExplainLabel.Size = new System.Drawing.Size(153, 20);
            this.ExplainLabel.TabIndex = 15;
            this.ExplainLabel.Text = "Spielendergebnis:";
            // 
            // gameStateLabel
            // 
            this.gameStateLabel.AutoSize = true;
            this.gameStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameStateLabel.Location = new System.Drawing.Point(171, 143);
            this.gameStateLabel.Name = "gameStateLabel";
            this.gameStateLabel.Size = new System.Drawing.Size(197, 20);
            this.gameStateLabel.TabIndex = 16;
            this.gameStateLabel.Text = "Noch nicht entschieden";
            this.gameStateLabel.Click += new System.EventHandler(this.label2_Click_3);
            // 
            // soldierIDLabel
            // 
            this.soldierIDLabel.AutoSize = true;
            this.soldierIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soldierIDLabel.Location = new System.Drawing.Point(128, 394);
            this.soldierIDLabel.Name = "soldierIDLabel";
            this.soldierIDLabel.Size = new System.Drawing.Size(19, 20);
            this.soldierIDLabel.TabIndex = 20;
            this.soldierIDLabel.Text = "1";
            // 
            // superSoldierBTN
            // 
            this.superSoldierBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.superSoldierBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superSoldierBTN.Location = new System.Drawing.Point(15, 235);
            this.superSoldierBTN.Name = "superSoldierBTN";
            this.superSoldierBTN.Size = new System.Drawing.Size(153, 34);
            this.superSoldierBTN.TabIndex = 21;
            this.superSoldierBTN.Text = "(8) Umwandeln";
            this.superSoldierBTN.UseVisualStyleBackColor = true;
            this.superSoldierBTN.Click += new System.EventHandler(this.superSoldierBTN_Click);
            // 
            // charDefLabel
            // 
            this.charDefLabel.AutoSize = true;
            this.charDefLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charDefLabel.Location = new System.Drawing.Point(388, 13);
            this.charDefLabel.Name = "charDefLabel";
            this.charDefLabel.Size = new System.Drawing.Size(39, 20);
            this.charDefLabel.TabIndex = 22;
            this.charDefLabel.Text = "500";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DisplayMember = "0x500";
            this.comboBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Soldat",
            "Soldat Stufe 2",
            "Soldat Stufe 3"});
            this.comboBoxType.Location = new System.Drawing.Point(219, 249);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(149, 24);
            this.comboBoxType.TabIndex = 23;
            this.comboBoxType.Tag = "Soldat";
            this.comboBoxType.ValueMember = "0x500";
            // 
            // groupBoxSelection
            // 
            this.groupBoxSelection.Controls.Add(this.selAllAll);
            this.groupBoxSelection.Controls.Add(this.selAll);
            this.groupBoxSelection.Controls.Add(this.selOne);
            this.groupBoxSelection.Location = new System.Drawing.Point(16, 284);
            this.groupBoxSelection.Name = "groupBoxSelection";
            this.groupBoxSelection.Size = new System.Drawing.Size(149, 87);
            this.groupBoxSelection.TabIndex = 24;
            this.groupBoxSelection.TabStop = false;
            this.groupBoxSelection.Text = "Anwenden auf";
            this.groupBoxSelection.Enter += new System.EventHandler(this.groupBoxSelection_Enter);
            // 
            // selAllAll
            // 
            this.selAllAll.AutoSize = true;
            this.selAllAll.Location = new System.Drawing.Point(6, 66);
            this.selAllAll.Name = "selAllAll";
            this.selAllAll.Size = new System.Drawing.Size(106, 17);
            this.selAllAll.TabIndex = 2;
            this.selAllAll.TabStop = true;
            this.selAllAll.Text = "Alle auf der Karte";
            this.selAllAll.UseVisualStyleBackColor = true;
            // 
            // selAll
            // 
            this.selAll.AutoSize = true;
            this.selAll.Checked = true;
            this.selAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.selAll.Location = new System.Drawing.Point(7, 43);
            this.selAll.Name = "selAll";
            this.selAll.Size = new System.Drawing.Size(95, 17);
            this.selAll.TabIndex = 1;
            this.selAll.TabStop = true;
            this.selAll.Text = "Selektion (Alle)";
            this.selAll.UseVisualStyleBackColor = true;
            // 
            // selOne
            // 
            this.selOne.AutoSize = true;
            this.selOne.Location = new System.Drawing.Point(7, 20);
            this.selOne.Name = "selOne";
            this.selOne.Size = new System.Drawing.Size(105, 17);
            this.selOne.TabIndex = 0;
            this.selOne.TabStop = true;
            this.selOne.Text = "Selektion (Einen)";
            this.selOne.UseVisualStyleBackColor = true;
            this.selOne.CheckedChanged += new System.EventHandler(this.selOne_CheckedChanged);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.Location = new System.Drawing.Point(221, 226);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(95, 20);
            this.typeLabel.TabIndex = 25;
            this.typeLabel.Text = "Neuer Typ:";
            this.typeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // teamLabel
            // 
            this.teamLabel.AutoSize = true;
            this.teamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamLabel.Location = new System.Drawing.Point(221, 295);
            this.teamLabel.Name = "teamLabel";
            this.teamLabel.Size = new System.Drawing.Size(114, 20);
            this.teamLabel.TabIndex = 27;
            this.teamLabel.Text = "Neues Team:";
            // 
            // comboBoxTeam
            // 
            this.comboBoxTeam.DisplayMember = "0x500";
            this.comboBoxTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTeam.FormattingEnabled = true;
            this.comboBoxTeam.Items.AddRange(new object[] {
            "Soldat",
            "Soldat Stufe 2",
            "Soldat Stufe 3"});
            this.comboBoxTeam.Location = new System.Drawing.Point(219, 318);
            this.comboBoxTeam.Name = "comboBoxTeam";
            this.comboBoxTeam.Size = new System.Drawing.Size(149, 24);
            this.comboBoxTeam.TabIndex = 26;
            this.comboBoxTeam.Tag = "Soldat";
            this.comboBoxTeam.ValueMember = "0x500";
            // 
            // manualSelLabel
            // 
            this.manualSelLabel.AutoSize = true;
            this.manualSelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualSelLabel.Location = new System.Drawing.Point(12, 394);
            this.manualSelLabel.Name = "manualSelLabel";
            this.manualSelLabel.Size = new System.Drawing.Size(110, 20);
            this.manualSelLabel.TabIndex = 28;
            this.manualSelLabel.Text = "Manuelle ID:";
            // 
            // gameModeLabel
            // 
            this.gameModeLabel.AutoSize = true;
            this.gameModeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameModeLabel.Location = new System.Drawing.Point(11, 40);
            this.gameModeLabel.Name = "gameModeLabel";
            this.gameModeLabel.Size = new System.Drawing.Size(280, 24);
            this.gameModeLabel.TabIndex = 29;
            this.gameModeLabel.Text = "Spielmodus: Singleplayer (Aktiv)";
            // 
            // selectedCharLabel
            // 
            this.selectedCharLabel.AutoSize = true;
            this.selectedCharLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedCharLabel.Location = new System.Drawing.Point(191, 351);
            this.selectedCharLabel.Name = "selectedCharLabel";
            this.selectedCharLabel.Size = new System.Drawing.Size(15, 20);
            this.selectedCharLabel.TabIndex = 30;
            this.selectedCharLabel.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 434);
            this.Controls.Add(this.selectedCharLabel);
            this.Controls.Add(this.gameModeLabel);
            this.Controls.Add(this.manualSelLabel);
            this.Controls.Add(this.teamLabel);
            this.Controls.Add(this.comboBoxTeam);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.groupBoxSelection);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.charDefLabel);
            this.Controls.Add(this.superSoldierBTN);
            this.Controls.Add(this.soldierIDLabel);
            this.Controls.Add(this.gameStateLabel);
            this.Controls.Add(this.ExplainLabel);
            this.Controls.Add(this.loseGameBTN);
            this.Controls.Add(this.winGameBTN);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.lvlLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.manaLabel);
            this.Controls.Add(this.manaBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Settlers 3 Ultimate Trainer by GeneralLee";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxSelection.ResumeLayout(false);
            this.groupBoxSelection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label manaLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label lvlLabel;
        private System.Windows.Forms.Timer UpdateMemoryTMR;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer GameAvailTMR;
        private System.Windows.Forms.Button manaBTN;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Button winGameBTN;
        private System.Windows.Forms.Button loseGameBTN;
        private System.Windows.Forms.Label ExplainLabel;
        private System.Windows.Forms.Label gameStateLabel;
        private System.Windows.Forms.Label soldierIDLabel;
        private System.Windows.Forms.Button superSoldierBTN;
        private System.Windows.Forms.Label charDefLabel;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.GroupBox groupBoxSelection;
        private System.Windows.Forms.RadioButton selAllAll;
        private System.Windows.Forms.RadioButton selAll;
        private System.Windows.Forms.RadioButton selOne;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label teamLabel;
        private System.Windows.Forms.ComboBox comboBoxTeam;
        private System.Windows.Forms.Label manualSelLabel;
        private System.Windows.Forms.Label gameModeLabel;
        private System.Windows.Forms.Label selectedCharLabel;
    }
}

