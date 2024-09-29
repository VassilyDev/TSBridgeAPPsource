
namespace TrainSimulatorBridge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "debug (NON VISIBILE)\r\n";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(300, 76);
            this.listBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(314, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 72);
            this.button2.TabIndex = 3;
            this.button2.Text = "CONNECT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(480, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 72);
            this.button3.TabIndex = 4;
            this.button3.Text = "REFRESH";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 318);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(427, 60);
            this.button4.TabIndex = 5;
            this.button4.Text = "GENERATE LOCO REPORT";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Loco: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(536, 100);
            this.label3.TabIndex = 7;
            this.label3.Text = "If controls are not accurate or not working for the current loco,\r\nplease click t" +
    "he button below.\r\nA report will be generated in the program folder (loco.txt),\r\n" +
    "please send it to the dev team.";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(581, 50);
            this.label7.TabIndex = 11;
            this.label7.Text = "Please connect to your Arduino serial port. The connect button will\r\nbecome green" +
    " once the connection is successful.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 542);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(356, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "TSBridge v1.1 (04/04/23)  Train icon by";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 580);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "®Alessandro Felicetti";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(369, 542);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(70, 25);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Icons8";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(210, 580);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(166, 25);
            this.linkLabel2.TabIndex = 15;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "http://felicetti-a.eu";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(426, 60);
            this.button1.TabIndex = 16;
            this.button1.Text = "CHECK FOR UPDATE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 636);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(680, 700);
            this.MinimumSize = new System.Drawing.Size(680, 700);
            this.Name = "Form1";
            this.Text = "TSBridge";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button button1;
    }
}

