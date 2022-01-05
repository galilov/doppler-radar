
namespace PulseRadar
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
            this.btnStart = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.PictureBox();
            this.numTemperature = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.chckZeroLevel = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemperature)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnStart.Location = new System.Drawing.Point(12, 225);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(103, 42);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pb
            // 
            this.pb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb.BackColor = System.Drawing.Color.Black;
            this.pb.Location = new System.Drawing.Point(12, 12);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(1425, 207);
            this.pb.TabIndex = 1;
            this.pb.TabStop = false;
            this.pb.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_Paint);
            this.pb.Resize += new System.EventHandler(this.pb_Resize);
            // 
            // numTemperature
            // 
            this.numTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numTemperature.Location = new System.Drawing.Point(511, 232);
            this.numTemperature.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numTemperature.Name = "numTemperature";
            this.numTemperature.Size = new System.Drawing.Size(97, 29);
            this.numTemperature.TabIndex = 19;
            this.numTemperature.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numTemperature.ValueChanged += new System.EventHandler(this.numTemperature_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(295, 234);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 24);
            this.label5.TabIndex = 18;
            this.label5.Text = "AIR TEMPERATURE, C";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnStop.Location = new System.Drawing.Point(121, 225);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(103, 42);
            this.btnStop.TabIndex = 20;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chckZeroLevel
            // 
            this.chckZeroLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chckZeroLevel.AutoSize = true;
            this.chckZeroLevel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chckZeroLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.chckZeroLevel.Location = new System.Drawing.Point(638, 230);
            this.chckZeroLevel.Name = "chckZeroLevel";
            this.chckZeroLevel.Size = new System.Drawing.Size(146, 28);
            this.chckZeroLevel.TabIndex = 22;
            this.chckZeroLevel.Text = "ZERO LEVEL";
            this.chckZeroLevel.UseVisualStyleBackColor = true;
            this.chckZeroLevel.CheckedChanged += new System.EventHandler(this.chckZeroLevel_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 279);
            this.Controls.Add(this.chckZeroLevel);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.numTemperature);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.Text = "Pulse Radar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemperature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.NumericUpDown numTemperature;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chckZeroLevel;
    }
}

