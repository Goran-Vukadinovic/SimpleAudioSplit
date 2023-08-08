namespace AudioCorpusTools
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
            this.btnSrcFolder = new System.Windows.Forms.Button();
            this.tbDst = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSrc = new System.Windows.Forms.TextBox();
            this.btnDstFolder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbSkip2Sentence = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbStartNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSrcFolder
            // 
            this.btnSrcFolder.Location = new System.Drawing.Point(527, 28);
            this.btnSrcFolder.Name = "btnSrcFolder";
            this.btnSrcFolder.Size = new System.Drawing.Size(29, 23);
            this.btnSrcFolder.TabIndex = 0;
            this.btnSrcFolder.Text = "...";
            this.btnSrcFolder.UseVisualStyleBackColor = true;
            this.btnSrcFolder.Click += new System.EventHandler(this.btnSrcFolder_Click);
            // 
            // tbDst
            // 
            this.tbDst.Location = new System.Drawing.Point(87, 70);
            this.tbDst.Name = "tbDst";
            this.tbDst.Size = new System.Drawing.Size(433, 23);
            this.tbDst.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sorce Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Target Path";
            // 
            // tbSrc
            // 
            this.tbSrc.Location = new System.Drawing.Point(88, 30);
            this.tbSrc.Name = "tbSrc";
            this.tbSrc.Size = new System.Drawing.Size(433, 23);
            this.tbSrc.TabIndex = 1;
            // 
            // btnDstFolder
            // 
            this.btnDstFolder.Location = new System.Drawing.Point(527, 70);
            this.btnDstFolder.Name = "btnDstFolder";
            this.btnDstFolder.Size = new System.Drawing.Size(29, 23);
            this.btnDstFolder.TabIndex = 0;
            this.btnDstFolder.Text = "...";
            this.btnDstFolder.UseVisualStyleBackColor = true;
            this.btnDstFolder.Click += new System.EventHandler(this.btnDstFolder_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(446, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Process";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbSkip2Sentence
            // 
            this.cmbSkip2Sentence.AutoSize = true;
            this.cmbSkip2Sentence.Location = new System.Drawing.Point(87, 156);
            this.cmbSkip2Sentence.Name = "cmbSkip2Sentence";
            this.cmbSkip2Sentence.Size = new System.Drawing.Size(108, 19);
            this.cmbSkip2Sentence.TabIndex = 4;
            this.cmbSkip2Sentence.Text = "Skip 2 Sentence";
            this.cmbSkip2Sentence.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "File Name Start";
            // 
            // tbStartNumber
            // 
            this.tbStartNumber.Location = new System.Drawing.Point(183, 113);
            this.tbStartNumber.Name = "tbStartNumber";
            this.tbStartNumber.Size = new System.Drawing.Size(156, 23);
            this.tbStartNumber.TabIndex = 1;
            this.tbStartNumber.Text = "4000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 203);
            this.Controls.Add(this.cmbSkip2Sentence);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSrc);
            this.Controls.Add(this.tbStartNumber);
            this.Controls.Add(this.tbDst);
            this.Controls.Add(this.btnDstFolder);
            this.Controls.Add(this.btnSrcFolder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSrcFolder;
        private TextBox tbDst;
        private Label label1;
        private Label label2;
        private TextBox tbSrc;
        private Button btnDstFolder;
        private Button button1;
        private CheckBox cmbSkip2Sentence;
        private Label label3;
        private TextBox tbStartNumber;
    }
}