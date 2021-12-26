namespace DopplerRadar
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.numTemperature = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chckBoxSpeed = new System.Windows.Forms.CheckBox();
            this.lbAmplitude = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.pbxSpectrum = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSpectrum)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.numTemperature);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.chckBoxSpeed);
            this.panel1.Controls.Add(this.lbAmplitude);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnSnapshot);
            this.panel1.Location = new System.Drawing.Point(10, 275);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 46);
            this.panel1.TabIndex = 2;
            // 
            // numTemperature
            // 
            this.numTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numTemperature.Location = new System.Drawing.Point(839, 7);
            this.numTemperature.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numTemperature.Name = "numTemperature";
            this.numTemperature.Size = new System.Drawing.Size(97, 29);
            this.numTemperature.TabIndex = 17;
            this.numTemperature.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numTemperature.ValueChanged += new System.EventHandler(this.numTemperature_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(623, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "AIR TEMPERATURE, C";
            // 
            // chckBoxSpeed
            // 
            this.chckBoxSpeed.AutoSize = true;
            this.chckBoxSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.chckBoxSpeed.Location = new System.Drawing.Point(530, 7);
            this.chckBoxSpeed.Name = "chckBoxSpeed";
            this.chckBoxSpeed.Size = new System.Drawing.Size(92, 28);
            this.chckBoxSpeed.TabIndex = 14;
            this.chckBoxSpeed.Text = "SPEED";
            this.chckBoxSpeed.UseVisualStyleBackColor = true;
            // 
            // lbAmplitude
            // 
            this.lbAmplitude.AutoSize = true;
            this.lbAmplitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAmplitude.Location = new System.Drawing.Point(407, 7);
            this.lbAmplitude.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAmplitude.Name = "lbAmplitude";
            this.lbAmplitude.Size = new System.Drawing.Size(48, 26);
            this.lbAmplitude.TabIndex = 5;
            this.lbAmplitude.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(239, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "MAX AMPLITUDE";
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStop.Location = new System.Drawing.Point(118, 2);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 40);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSnapshot.Location = new System.Drawing.Point(2, 2);
            this.btnSnapshot.Margin = new System.Windows.Forms.Padding(2);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(112, 40);
            this.btnSnapshot.TabIndex = 0;
            this.btnSnapshot.Text = "Start";
            this.btnSnapshot.UseVisualStyleBackColor = true;
            this.btnSnapshot.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pbxSpectrum
            // 
            this.pbxSpectrum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxSpectrum.BackColor = System.Drawing.Color.Black;
            this.pbxSpectrum.Location = new System.Drawing.Point(10, 11);
            this.pbxSpectrum.Margin = new System.Windows.Forms.Padding(2);
            this.pbxSpectrum.Name = "pbxSpectrum";
            this.pbxSpectrum.Size = new System.Drawing.Size(942, 260);
            this.pbxSpectrum.TabIndex = 1;
            this.pbxSpectrum.TabStop = false;
            this.pbxSpectrum.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxSpectrum_Paint);
            this.pbxSpectrum.Resize += new System.EventHandler(this.pbxSpectrum_Resize);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 332);
            this.Controls.Add(this.pbxSpectrum);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Signal graph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSpectrum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lbAmplitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbxSpectrum;
        private System.Windows.Forms.CheckBox chckBoxSpeed;
        private System.Windows.Forms.NumericUpDown numTemperature;
        private System.Windows.Forms.Label label5;
    }
}

