namespace FirstConcept
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
            this.components = new System.ComponentModel.Container();
            this.forwardClicked = new System.Windows.Forms.Button();
            this.moveRightClicked = new System.Windows.Forms.Button();
            this.moveLeftClicked = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.Button();
            this.kill = new System.Windows.Forms.Button();
            this.iPGetter = new System.Windows.Forms.TextBox();
            this.speach = new System.Windows.Forms.TextBox();
            this.textToSpeach = new System.Windows.Forms.Button();
            this.errorTicker = new System.Windows.Forms.TextBox();
            this.rest = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // forwardClicked
            // 
            this.forwardClicked.Location = new System.Drawing.Point(752, 216);
            this.forwardClicked.Name = "forwardClicked";
            this.forwardClicked.Size = new System.Drawing.Size(167, 35);
            this.forwardClicked.TabIndex = 0;
            this.forwardClicked.Text = "Move Forward";
            this.forwardClicked.UseVisualStyleBackColor = true;
            this.forwardClicked.Click += new System.EventHandler(this.forwardClicked_Click);
            // 
            // moveRightClicked
            // 
            this.moveRightClicked.Location = new System.Drawing.Point(918, 257);
            this.moveRightClicked.Name = "moveRightClicked";
            this.moveRightClicked.Size = new System.Drawing.Size(166, 35);
            this.moveRightClicked.TabIndex = 1;
            this.moveRightClicked.Text = "Move Right";
            this.moveRightClicked.UseVisualStyleBackColor = true;
            this.moveRightClicked.Click += new System.EventHandler(this.moveRightClicked_Click);
            // 
            // moveLeftClicked
            // 
            this.moveLeftClicked.Location = new System.Drawing.Point(587, 257);
            this.moveLeftClicked.Name = "moveLeftClicked";
            this.moveLeftClicked.Size = new System.Drawing.Size(166, 35);
            this.moveLeftClicked.TabIndex = 2;
            this.moveLeftClicked.Text = "Move Left";
            this.moveLeftClicked.UseVisualStyleBackColor = true;
            this.moveLeftClicked.Click += new System.EventHandler(this.moveLeftClicked_Click);
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(106, 42);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 3;
            this.Connect.Text = "connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // kill
            // 
            this.kill.Location = new System.Drawing.Point(794, 339);
            this.kill.Name = "kill";
            this.kill.Size = new System.Drawing.Size(75, 31);
            this.kill.TabIndex = 4;
            this.kill.Text = "Stop!";
            this.kill.UseVisualStyleBackColor = true;
            this.kill.Click += new System.EventHandler(this.kill_Click);
            // 
            // iPGetter
            // 
            this.iPGetter.Location = new System.Drawing.Point(0, 43);
            this.iPGetter.Name = "iPGetter";
            this.iPGetter.Size = new System.Drawing.Size(100, 22);
            this.iPGetter.TabIndex = 5;
            this.iPGetter.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // speach
            // 
            this.speach.Location = new System.Drawing.Point(473, 412);
            this.speach.Name = "speach";
            this.speach.Size = new System.Drawing.Size(494, 22);
            this.speach.TabIndex = 6;
            this.speach.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // textToSpeach
            // 
            this.textToSpeach.Location = new System.Drawing.Point(1009, 404);
            this.textToSpeach.Name = "textToSpeach";
            this.textToSpeach.Size = new System.Drawing.Size(75, 30);
            this.textToSpeach.TabIndex = 7;
            this.textToSpeach.Text = "Say";
            this.textToSpeach.UseVisualStyleBackColor = true;
            this.textToSpeach.Click += new System.EventHandler(this.textToSpeach_Click);
            // 
            // errorTicker
            // 
            this.errorTicker.Location = new System.Drawing.Point(12, 452);
            this.errorTicker.Name = "errorTicker";
            this.errorTicker.Size = new System.Drawing.Size(1072, 22);
            this.errorTicker.TabIndex = 8;
            this.errorTicker.TextChanged += new System.EventHandler(this.errorTicker_TextChanged);
            // 
            // rest
            // 
            this.rest.Location = new System.Drawing.Point(876, 43);
            this.rest.Name = "rest";
            this.rest.Size = new System.Drawing.Size(208, 104);
            this.rest.TabIndex = 9;
            this.rest.Text = "Go To Rest";
            this.rest.UseVisualStyleBackColor = true;
            this.rest.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(64, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(481, 335);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 536);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rest);
            this.Controls.Add(this.errorTicker);
            this.Controls.Add(this.textToSpeach);
            this.Controls.Add(this.speach);
            this.Controls.Add(this.iPGetter);
            this.Controls.Add(this.kill);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.moveLeftClicked);
            this.Controls.Add(this.moveRightClicked);
            this.Controls.Add(this.forwardClicked);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button forwardClicked;
        private System.Windows.Forms.Button moveRightClicked;
        private System.Windows.Forms.Button moveLeftClicked;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Button kill;
        private System.Windows.Forms.TextBox iPGetter;
        private System.Windows.Forms.TextBox speach;
        private System.Windows.Forms.Button textToSpeach;
        private System.Windows.Forms.TextBox errorTicker;
        private System.Windows.Forms.Button rest;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}

