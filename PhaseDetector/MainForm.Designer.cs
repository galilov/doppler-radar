
namespace PhaseDetector
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.chckReflected = new System.Windows.Forms.CheckBox();
            this.numTemperature = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lbAmplitude = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.chckZeroLevel = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numTemperature)).BeginInit();
            this.SuspendLayout();
            // 
            // chckReflected
            // 
            this.chckReflected.AutoSize = true;
            this.chckReflected.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chckReflected.Checked = true;
            this.chckReflected.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckReflected.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.chckReflected.Location = new System.Drawing.Point(12, 12);
            this.chckReflected.Name = "chckReflected";
            this.chckReflected.Size = new System.Drawing.Size(203, 28);
            this.chckReflected.TabIndex = 20;
            this.chckReflected.Text = "REFLECTED MODE";
            this.chckReflected.UseVisualStyleBackColor = true;
            this.chckReflected.CheckedChanged += new System.EventHandler(this.chckReflected_CheckedChanged);
            // 
            // numTemperature
            // 
            this.numTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numTemperature.Location = new System.Drawing.Point(227, 75);
            this.numTemperature.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numTemperature.Name = "numTemperature";
            this.numTemperature.Size = new System.Drawing.Size(97, 29);
            this.numTemperature.TabIndex = 19;
            this.numTemperature.ValueChanged += new System.EventHandler(this.numTemperature_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(11, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 24);
            this.label5.TabIndex = 18;
            this.label5.Text = "AIR TEMPERATURE, C";
            // 
            // lbAmplitude
            // 
            this.lbAmplitude.AutoSize = true;
            this.lbAmplitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAmplitude.Location = new System.Drawing.Point(383, 33);
            this.lbAmplitude.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAmplitude.Name = "lbAmplitude";
            this.lbAmplitude.Size = new System.Drawing.Size(105, 55);
            this.lbAmplitude.TabIndex = 5;
            this.lbAmplitude.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(389, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "DISTANCE, MM:";
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStop.Location = new System.Drawing.Point(127, 118);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 40);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.Location = new System.Drawing.Point(11, 118);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 40);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chckZeroLevel
            // 
            this.chckZeroLevel.AutoSize = true;
            this.chckZeroLevel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chckZeroLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.chckZeroLevel.Location = new System.Drawing.Point(12, 46);
            this.chckZeroLevel.Name = "chckZeroLevel";
            this.chckZeroLevel.Size = new System.Drawing.Size(146, 28);
            this.chckZeroLevel.TabIndex = 21;
            this.chckZeroLevel.Text = "ZERO LEVEL";
            this.chckZeroLevel.UseVisualStyleBackColor = true;
            this.chckZeroLevel.CheckedChanged += new System.EventHandler(this.chckZeroLevel_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 164);
            this.Controls.Add(this.lbAmplitude);
            this.Controls.Add(this.numTemperature);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chckZeroLevel);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chckReflected);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Phase Detector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTemperature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbAmplitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown numTemperature;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chckReflected;
        private System.Windows.Forms.CheckBox chckZeroLevel;
    }
}

