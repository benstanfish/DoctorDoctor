namespace DoctorDoctor
{
    partial class ColorSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonClosed = new System.Windows.Forms.Button();
            this.buttonConcur = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonNonconcur = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            this.colorDialog4 = new System.Windows.Forms.ColorDialog();
            this.colorDialog5 = new System.Windows.Forms.ColorDialog();
            this.colorDialog6 = new System.Windows.Forms.ColorDialog();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comment Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Comment Status";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(226, 246);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(147, 29);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(12, 32);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(147, 29);
            this.buttonOpen.TabIndex = 2;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonClosed
            // 
            this.buttonClosed.Location = new System.Drawing.Point(12, 67);
            this.buttonClosed.Name = "buttonClosed";
            this.buttonClosed.Size = new System.Drawing.Size(147, 29);
            this.buttonClosed.TabIndex = 3;
            this.buttonClosed.Text = "Closed";
            this.buttonClosed.UseVisualStyleBackColor = true;
            this.buttonClosed.Click += new System.EventHandler(this.buttonClosed_Click);
            // 
            // buttonConcur
            // 
            this.buttonConcur.Location = new System.Drawing.Point(226, 36);
            this.buttonConcur.Name = "buttonConcur";
            this.buttonConcur.Size = new System.Drawing.Size(147, 29);
            this.buttonConcur.TabIndex = 4;
            this.buttonConcur.Text = "Concur";
            this.buttonConcur.UseVisualStyleBackColor = true;
            this.buttonConcur.Click += new System.EventHandler(this.buttonConcur_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Location = new System.Drawing.Point(226, 71);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(147, 29);
            this.buttonInfo.TabIndex = 5;
            this.buttonInfo.Text = "For Info Only";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // buttonNonconcur
            // 
            this.buttonNonconcur.Location = new System.Drawing.Point(226, 106);
            this.buttonNonconcur.Name = "buttonNonconcur";
            this.buttonNonconcur.Size = new System.Drawing.Size(147, 29);
            this.buttonNonconcur.TabIndex = 6;
            this.buttonNonconcur.Text = "Nonconcur";
            this.buttonNonconcur.UseVisualStyleBackColor = true;
            this.buttonNonconcur.Click += new System.EventHandler(this.buttonNonconcur_Click);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(226, 141);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(147, 29);
            this.buttonCheck.TabIndex = 7;
            this.buttonCheck.Text = "Check / Resolve";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(12, 246);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(147, 29);
            this.buttonDefault.TabIndex = 10;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // ColorSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 287);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.buttonNonconcur);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.buttonConcur);
            this.Controls.Add(this.buttonClosed);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.label1);
            this.Name = "ColorSettingsForm";
            this.Text = "ColorSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ColorDialog colorDialog1;
        private Label label2;
        private Button buttonClose;
        private Button buttonOpen;
        private Button buttonClosed;
        private Button buttonConcur;
        private Button buttonInfo;
        private Button buttonNonconcur;
        private Button buttonCheck;
        private ColorDialog colorDialog2;
        private ColorDialog colorDialog3;
        private ColorDialog colorDialog4;
        private ColorDialog colorDialog5;
        private ColorDialog colorDialog6;
        private Button buttonDefault;
    }
}