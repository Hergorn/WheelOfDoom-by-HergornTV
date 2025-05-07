namespace WheelOfDoom
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            H1 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            saveBtn = new Button();
            countdownNum = new NumericUpDown();
            label4 = new Label();
            PrizesTxt = new TextBox();
            label5 = new Label();
            exportBtn = new Button();
            importBtn = new Button();
            WheelUrlCopyBtn = new Button();
            systemLbl = new Label();
            ((System.ComponentModel.ISupportInitialize)countdownNum).BeginInit();
            SuspendLayout();
            // 
            // H1
            // 
            H1.AutoSize = true;
            H1.Font = new Font("Agency FB", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            H1.Location = new Point(12, 12);
            H1.Name = "H1";
            H1.Size = new Size(169, 39);
            H1.TabIndex = 0;
            H1.Text = "Wheel of Doom";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Agency FB", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(93, 51);
            label1.Name = "label1";
            label1.Size = new Size(77, 23);
            label1.TabIndex = 1;
            label1.Text = "by HergornTV";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Agency FB", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 119);
            label2.Name = "label2";
            label2.Size = new Size(95, 28);
            label2.TabIndex = 3;
            label2.Text = "Countdown:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 74);
            label3.Name = "label3";
            label3.Size = new Size(80, 33);
            label3.TabIndex = 4;
            label3.Text = "Settings";
            // 
            // saveBtn
            // 
            saveBtn.Font = new Font("Agency FB", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveBtn.Location = new Point(12, 286);
            saveBtn.Margin = new Padding(3, 4, 3, 4);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(116, 39);
            saveBtn.TabIndex = 5;
            saveBtn.Text = "SAVE";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // countdownNum
            // 
            countdownNum.Font = new Font("Agency FB", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            countdownNum.Location = new Point(113, 117);
            countdownNum.Maximum = new decimal(new int[] { 268435455, 1042612833, 542101086, 0 });
            countdownNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            countdownNum.Name = "countdownNum";
            countdownNum.Size = new Size(180, 36);
            countdownNum.TabIndex = 6;
            countdownNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Agency FB", 12F);
            label4.Location = new Point(12, 169);
            label4.Name = "label4";
            label4.Size = new Size(64, 28);
            label4.TabIndex = 7;
            label4.Text = "Prizes:";
            // 
            // PrizesTxt
            // 
            PrizesTxt.Font = new Font("Agency FB", 12F);
            PrizesTxt.Location = new Point(113, 165);
            PrizesTxt.Margin = new Padding(3, 4, 3, 4);
            PrizesTxt.Multiline = true;
            PrizesTxt.Name = "PrizesTxt";
            PrizesTxt.PlaceholderText = "separate with \",\" (comma)";
            PrizesTxt.Size = new Size(380, 97);
            PrizesTxt.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Agency FB", 12F);
            label5.Location = new Point(299, 119);
            label5.Name = "label5";
            label5.Size = new Size(93, 28);
            label5.TabIndex = 9;
            label5.Text = "in seconds";
            // 
            // exportBtn
            // 
            exportBtn.Font = new Font("Agency FB", 12F);
            exportBtn.Location = new Point(133, 286);
            exportBtn.Margin = new Padding(3, 4, 3, 4);
            exportBtn.Name = "exportBtn";
            exportBtn.Size = new Size(116, 39);
            exportBtn.TabIndex = 10;
            exportBtn.Text = "EXPORT";
            exportBtn.UseVisualStyleBackColor = true;
            exportBtn.Click += exportBtn_Click;
            // 
            // importBtn
            // 
            importBtn.Font = new Font("Agency FB", 12F);
            importBtn.Location = new Point(255, 286);
            importBtn.Margin = new Padding(3, 4, 3, 4);
            importBtn.Name = "importBtn";
            importBtn.Size = new Size(116, 39);
            importBtn.TabIndex = 11;
            importBtn.Text = "IMPORT";
            importBtn.UseVisualStyleBackColor = true;
            importBtn.Click += importBtn_Click;
            // 
            // WheelUrlCopyBtn
            // 
            WheelUrlCopyBtn.Font = new Font("Agency FB", 12F);
            WheelUrlCopyBtn.Location = new Point(377, 286);
            WheelUrlCopyBtn.Name = "WheelUrlCopyBtn";
            WheelUrlCopyBtn.Size = new Size(116, 39);
            WheelUrlCopyBtn.TabIndex = 12;
            WheelUrlCopyBtn.Text = "WHEEL URL";
            WheelUrlCopyBtn.UseVisualStyleBackColor = true;
            WheelUrlCopyBtn.Click += WheelUrlCopyBtn_Click;
            // 
            // systemLbl
            // 
            systemLbl.AutoSize = true;
            systemLbl.Font = new Font("Agency FB", 12F);
            systemLbl.ForeColor = Color.Orange;
            systemLbl.Location = new Point(12, 340);
            systemLbl.Name = "systemLbl";
            systemLbl.Size = new Size(97, 28);
            systemLbl.TabIndex = 13;
            systemLbl.Text = "Initializing...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 33F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 404);
            Controls.Add(systemLbl);
            Controls.Add(WheelUrlCopyBtn);
            Controls.Add(importBtn);
            Controls.Add(exportBtn);
            Controls.Add(label5);
            Controls.Add(PrizesTxt);
            Controls.Add(label4);
            Controls.Add(countdownNum);
            Controls.Add(saveBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(H1);
            Font = new Font("Agency FB", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Wheel of Doom by HergornTV";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)countdownNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label H1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button saveBtn;
        private NumericUpDown countdownNum;
        private Label label4;
        private TextBox PrizesTxt;
        private Label label5;
        private Button exportBtn;
        private Button importBtn;
        private Button WheelUrlCopyBtn;
        private Label systemLbl;
    }
}
