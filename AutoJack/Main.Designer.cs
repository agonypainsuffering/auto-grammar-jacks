namespace AutoJack
{
    partial class AutoJack
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
            this.sanoinaCheckBox = new System.Windows.Forms.CheckBox();
            this.hellCheckBox = new System.Windows.Forms.CheckBox();
            this.tila = new System.Windows.Forms.Label();
            this.startFromUpDown = new System.Windows.Forms.NumericUpDown();
            this.countToUpDown = new System.Windows.Forms.NumericUpDown();
            this.jumpBetween = new System.Windows.Forms.CheckBox();
            this.openchatTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.hellCapsCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.hyphenCheckBox = new System.Windows.Forms.CheckBox();
            this.fullstopCheckBox = new System.Windows.Forms.CheckBox();
            this.begincapitalCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.deathCheckBox = new System.Windows.Forms.CheckBox();
            this.numbermodeCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.currentNumber = new System.Windows.Forms.Label();
            this.currentWait = new System.Windows.Forms.Label();
            this.upButton = new System.Windows.Forms.Button();
            this.processBox = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.refreshProcesses = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.keybindBox = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.speedLabel = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.startFromUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countToUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.speedLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sanoinaCheckBox
            // 
            this.sanoinaCheckBox.AutoSize = true;
            this.sanoinaCheckBox.Location = new System.Drawing.Point(78, 21);
            this.sanoinaCheckBox.Name = "sanoinaCheckBox";
            this.sanoinaCheckBox.Size = new System.Drawing.Size(57, 17);
            this.sanoinaCheckBox.TabIndex = 1;
            this.sanoinaCheckBox.Text = "Words";
            this.sanoinaCheckBox.UseVisualStyleBackColor = true;
            this.sanoinaCheckBox.CheckedChanged += new System.EventHandler(this.sanoinaCheckBox_CheckedChanged);
            // 
            // hellCheckBox
            // 
            this.hellCheckBox.AutoSize = true;
            this.hellCheckBox.Location = new System.Drawing.Point(135, 21);
            this.hellCheckBox.Name = "hellCheckBox";
            this.hellCheckBox.Size = new System.Drawing.Size(44, 17);
            this.hellCheckBox.TabIndex = 2;
            this.hellCheckBox.Text = "Hell";
            this.hellCheckBox.UseVisualStyleBackColor = true;
            this.hellCheckBox.CheckedChanged += new System.EventHandler(this.hellCheckBox_CheckedChanged);
            // 
            // tila
            // 
            this.tila.AutoSize = true;
            this.tila.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tila.Location = new System.Drawing.Point(10, 21);
            this.tila.Name = "tila";
            this.tila.Size = new System.Drawing.Size(116, 16);
            this.tila.TabIndex = 3;
            this.tila.Text = "Ready to start (F8)";
            // 
            // startFromUpDown
            // 
            this.startFromUpDown.Location = new System.Drawing.Point(6, 19);
            this.startFromUpDown.Maximum = new decimal(new int[] {
            -469762049,
            -590869294,
            5421010,
            0});
            this.startFromUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startFromUpDown.Name = "startFromUpDown";
            this.startFromUpDown.Size = new System.Drawing.Size(73, 20);
            this.startFromUpDown.TabIndex = 5;
            this.startFromUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startFromUpDown.ValueChanged += new System.EventHandler(this.startFromUpDown_ValueChanged);
            // 
            // countToUpDown
            // 
            this.countToUpDown.Location = new System.Drawing.Point(6, 19);
            this.countToUpDown.Maximum = new decimal(new int[] {
            -469762049,
            -590869294,
            5421010,
            0});
            this.countToUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.countToUpDown.Name = "countToUpDown";
            this.countToUpDown.Size = new System.Drawing.Size(73, 20);
            this.countToUpDown.TabIndex = 6;
            this.countToUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.countToUpDown.ValueChanged += new System.EventHandler(this.countToUpDown_ValueChanged);
            // 
            // jumpBetween
            // 
            this.jumpBetween.AutoSize = true;
            this.jumpBetween.Checked = true;
            this.jumpBetween.CheckState = System.Windows.Forms.CheckState.Checked;
            this.jumpBetween.Location = new System.Drawing.Point(12, 21);
            this.jumpBetween.Name = "jumpBetween";
            this.jumpBetween.Size = new System.Drawing.Size(138, 17);
            this.jumpBetween.TabIndex = 8;
            this.jumpBetween.Text = "Jump between numbers";
            this.jumpBetween.UseVisualStyleBackColor = true;
            this.jumpBetween.CheckedChanged += new System.EventHandler(this.jumpBetween_CheckedChanged);
            // 
            // openchatTextBox
            // 
            this.openchatTextBox.Location = new System.Drawing.Point(157, 18);
            this.openchatTextBox.Name = "openchatTextBox";
            this.openchatTextBox.Size = new System.Drawing.Size(22, 20);
            this.openchatTextBox.TabIndex = 9;
            this.openchatTextBox.Text = "/";
            this.openchatTextBox.TextChanged += new System.EventHandler(this.openchatTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Open chat key";
            // 
            // speedBar
            // 
            this.speedBar.LargeChange = 1;
            this.speedBar.Location = new System.Drawing.Point(6, 13);
            this.speedBar.Maximum = 100;
            this.speedBar.Minimum = 1;
            this.speedBar.Name = "speedBar";
            this.speedBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.speedBar.RightToLeftLayout = true;
            this.speedBar.Size = new System.Drawing.Size(331, 45);
            this.speedBar.TabIndex = 1;
            this.speedBar.TickFrequency = 0;
            this.speedBar.Value = 50;
            this.speedBar.ValueChanged += new System.EventHandler(this.speedBar_ValueChanged);
            // 
            // hellCapsCheckBox
            // 
            this.hellCapsCheckBox.AutoSize = true;
            this.hellCapsCheckBox.Location = new System.Drawing.Point(101, 21);
            this.hellCapsCheckBox.Name = "hellCapsCheckBox";
            this.hellCapsCheckBox.Size = new System.Drawing.Size(50, 17);
            this.hellCapsCheckBox.TabIndex = 13;
            this.hellCapsCheckBox.Text = "Caps";
            this.hellCapsCheckBox.UseVisualStyleBackColor = true;
            this.hellCapsCheckBox.CheckedChanged += new System.EventHandler(this.capsCheckBox_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.openchatTextBox);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.jumpBetween);
            this.groupBox5.Location = new System.Drawing.Point(12, 373);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(346, 48);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Other";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.hyphenCheckBox);
            this.groupBox4.Controls.Add(this.fullstopCheckBox);
            this.groupBox4.Controls.Add(this.hellCapsCheckBox);
            this.groupBox4.Controls.Add(this.begincapitalCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 320);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(345, 47);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Grammar";
            // 
            // hyphenCheckBox
            // 
            this.hyphenCheckBox.AutoSize = true;
            this.hyphenCheckBox.Location = new System.Drawing.Point(153, 21);
            this.hyphenCheckBox.Name = "hyphenCheckBox";
            this.hyphenCheckBox.Size = new System.Drawing.Size(63, 17);
            this.hyphenCheckBox.TabIndex = 14;
            this.hyphenCheckBox.Text = "Hyphen";
            this.hyphenCheckBox.UseVisualStyleBackColor = true;
            this.hyphenCheckBox.CheckedChanged += new System.EventHandler(this.hyphenCheckBox_CheckedChanged);
            // 
            // fullstopCheckBox
            // 
            this.fullstopCheckBox.AutoSize = true;
            this.fullstopCheckBox.Location = new System.Drawing.Point(221, 21);
            this.fullstopCheckBox.Name = "fullstopCheckBox";
            this.fullstopCheckBox.Size = new System.Drawing.Size(65, 17);
            this.fullstopCheckBox.TabIndex = 15;
            this.fullstopCheckBox.Text = "Full stop";
            this.fullstopCheckBox.UseVisualStyleBackColor = true;
            this.fullstopCheckBox.CheckedChanged += new System.EventHandler(this.fullstopCheckBox_CheckedChanged);
            // 
            // begincapitalCheckBox
            // 
            this.begincapitalCheckBox.AutoSize = true;
            this.begincapitalCheckBox.Location = new System.Drawing.Point(9, 21);
            this.begincapitalCheckBox.Name = "begincapitalCheckBox";
            this.begincapitalCheckBox.Size = new System.Drawing.Size(87, 17);
            this.begincapitalCheckBox.TabIndex = 16;
            this.begincapitalCheckBox.Text = "Begin capital";
            this.begincapitalCheckBox.UseVisualStyleBackColor = true;
            this.begincapitalCheckBox.CheckedChanged += new System.EventHandler(this.begincapitalCheckBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.deathCheckBox);
            this.groupBox3.Controls.Add(this.numbermodeCheckBox);
            this.groupBox3.Controls.Add(this.hellCheckBox);
            this.groupBox3.Controls.Add(this.sanoinaCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 266);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(345, 48);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modes";
            // 
            // deathCheckBox
            // 
            this.deathCheckBox.AutoSize = true;
            this.deathCheckBox.Location = new System.Drawing.Point(182, 21);
            this.deathCheckBox.Name = "deathCheckBox";
            this.deathCheckBox.Size = new System.Drawing.Size(55, 17);
            this.deathCheckBox.TabIndex = 4;
            this.deathCheckBox.Text = "Death";
            this.deathCheckBox.UseVisualStyleBackColor = true;
            this.deathCheckBox.CheckedChanged += new System.EventHandler(this.deathCheckBox_CheckedChanged);
            // 
            // numbermodeCheckBox
            // 
            this.numbermodeCheckBox.AutoSize = true;
            this.numbermodeCheckBox.Checked = true;
            this.numbermodeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.numbermodeCheckBox.Location = new System.Drawing.Point(9, 21);
            this.numbermodeCheckBox.Name = "numbermodeCheckBox";
            this.numbermodeCheckBox.Size = new System.Drawing.Size(68, 17);
            this.numbermodeCheckBox.TabIndex = 3;
            this.numbermodeCheckBox.Text = "Numbers";
            this.numbermodeCheckBox.UseVisualStyleBackColor = true;
            this.numbermodeCheckBox.CheckedChanged += new System.EventHandler(this.numbermodeCheckBox_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.currentNumber);
            this.groupBox6.Controls.Add(this.currentWait);
            this.groupBox6.Location = new System.Drawing.Point(12, 45);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(346, 66);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // currentNumber
            // 
            this.currentNumber.AutoSize = true;
            this.currentNumber.Location = new System.Drawing.Point(11, 41);
            this.currentNumber.Name = "currentNumber";
            this.currentNumber.Size = new System.Drawing.Size(111, 13);
            this.currentNumber.TabIndex = 1;
            this.currentNumber.Text = "Currently typing: None";
            // 
            // currentWait
            // 
            this.currentWait.AutoSize = true;
            this.currentWait.Location = new System.Drawing.Point(11, 21);
            this.currentWait.Name = "currentWait";
            this.currentWait.Size = new System.Drawing.Size(126, 13);
            this.currentWait.TabIndex = 0;
            this.currentWait.Text = "Current typing wait: None";
            // 
            // upButton
            // 
            this.upButton.FlatAppearance.BorderSize = 0;
            this.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upButton.Location = new System.Drawing.Point(12, 117);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(345, 23);
            this.upButton.TabIndex = 19;
            this.upButton.Text = "🡱";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // processBox
            // 
            this.processBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.processBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.processBox.FormattingEnabled = true;
            this.processBox.Location = new System.Drawing.Point(12, 18);
            this.processBox.Name = "processBox";
            this.processBox.Size = new System.Drawing.Size(119, 21);
            this.processBox.TabIndex = 13;
            this.processBox.SelectedIndexChanged += new System.EventHandler(this.processBox_SelectedIndexChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.refreshProcesses);
            this.groupBox7.Controls.Add(this.processBox);
            this.groupBox7.Location = new System.Drawing.Point(12, 146);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(164, 48);
            this.groupBox7.TabIndex = 20;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Process";
            // 
            // refreshProcesses
            // 
            this.refreshProcesses.FlatAppearance.BorderSize = 0;
            this.refreshProcesses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshProcesses.Location = new System.Drawing.Point(134, 19);
            this.refreshProcesses.Name = "refreshProcesses";
            this.refreshProcesses.Size = new System.Drawing.Size(23, 20);
            this.refreshProcesses.TabIndex = 24;
            this.refreshProcesses.Text = "↺";
            this.refreshProcesses.UseVisualStyleBackColor = true;
            this.refreshProcesses.Click += new System.EventHandler(this.refreshProcesses_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startFromUpDown);
            this.groupBox1.Location = new System.Drawing.Point(182, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(85, 48);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "From";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.keybindBox);
            this.groupBox2.Controls.Add(this.tila);
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 52);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // keybindBox
            // 
            this.keybindBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keybindBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keybindBox.FormattingEnabled = true;
            this.keybindBox.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.keybindBox.Location = new System.Drawing.Point(300, 18);
            this.keybindBox.Name = "keybindBox";
            this.keybindBox.Size = new System.Drawing.Size(37, 21);
            this.keybindBox.TabIndex = 14;
            this.keybindBox.SelectedIndexChanged += new System.EventHandler(this.keybindBox_SelectedIndexChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.countToUpDown);
            this.groupBox8.Location = new System.Drawing.Point(273, 146);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(85, 48);
            this.groupBox8.TabIndex = 22;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "To";
            // 
            // speedLabel
            // 
            this.speedLabel.Controls.Add(this.speedBar);
            this.speedLabel.Location = new System.Drawing.Point(12, 200);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(346, 60);
            this.speedLabel.TabIndex = 23;
            this.speedLabel.TabStop = false;
            this.speedLabel.Text = "Delay (50)";
            // 
            // AutoJack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(371, 430);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.groupBox6);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AutoJack";
            this.ShowIcon = false;
            this.Text = "AutoJack";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.startFromUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countToUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.speedLabel.ResumeLayout(false);
            this.speedLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox sanoinaCheckBox;
        private System.Windows.Forms.CheckBox hellCheckBox;
        private System.Windows.Forms.Label tila;
        private System.Windows.Forms.NumericUpDown startFromUpDown;
        private System.Windows.Forms.NumericUpDown countToUpDown;
        private System.Windows.Forms.CheckBox jumpBetween;
        private System.Windows.Forms.TextBox openchatTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.CheckBox hellCapsCheckBox;
        private System.Windows.Forms.CheckBox hyphenCheckBox;
        private System.Windows.Forms.CheckBox begincapitalCheckBox;
        private System.Windows.Forms.CheckBox fullstopCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label currentWait;
        private System.Windows.Forms.Label currentNumber;
        private System.Windows.Forms.CheckBox numbermodeCheckBox;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.ComboBox processBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox speedLabel;
        private System.Windows.Forms.ComboBox keybindBox;
        private System.Windows.Forms.Button refreshProcesses;
        private System.Windows.Forms.CheckBox deathCheckBox;
    }
}

