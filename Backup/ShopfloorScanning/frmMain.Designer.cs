namespace ShopfloorScanning
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbMachine = new System.Windows.Forms.RadioButton();
            this.rbEndJob = new System.Windows.Forms.RadioButton();
            this.rbStartJob = new System.Windows.Forms.RadioButton();
            this.rbReversePICK = new System.Windows.Forms.RadioButton();
            this.btOK = new System.Windows.Forms.Button();
            this.rbMorv = new System.Windows.Forms.RadioButton();
            this.rbPick = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbLogo.Image = global::ShopfloorScanning.Properties.Resources.Trell_b;
            this.pbLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.InitialImage")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(794, 251);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbMachine);
            this.groupBox1.Controls.Add(this.rbEndJob);
            this.groupBox1.Controls.Add(this.rbStartJob);
            this.groupBox1.Controls.Add(this.rbReversePICK);
            this.groupBox1.Controls.Add(this.btOK);
            this.groupBox1.Controls.Add(this.rbMorv);
            this.groupBox1.Controls.Add(this.rbPick);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(12, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(770, 291);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            this.groupBox1.Text = "What do you want to do?";
            // 
            // rbMachine
            // 
            this.rbMachine.AutoSize = true;
            this.rbMachine.Location = new System.Drawing.Point(27, 219);
            this.rbMachine.Name = "rbMachine";
            this.rbMachine.Size = new System.Drawing.Size(153, 28);
            this.rbMachine.TabIndex = 8;
            this.rbMachine.TabStop = true;
            this.rbMachine.Tag = "";
            this.rbMachine.Text = "Machine status";
            this.rbMachine.UseVisualStyleBackColor = true;
            // 
            // rbEndJob
            // 
            this.rbEndJob.AutoSize = true;
            this.rbEndJob.Location = new System.Drawing.Point(27, 117);
            this.rbEndJob.Name = "rbEndJob";
            this.rbEndJob.Size = new System.Drawing.Size(99, 28);
            this.rbEndJob.TabIndex = 5;
            this.rbEndJob.TabStop = true;
            this.rbEndJob.Tag = "";
            this.rbEndJob.Text = "End Job";
            this.rbEndJob.UseVisualStyleBackColor = true;
            // 
            // rbStartJob
            // 
            this.rbStartJob.AutoSize = true;
            this.rbStartJob.Location = new System.Drawing.Point(27, 83);
            this.rbStartJob.Name = "rbStartJob";
            this.rbStartJob.Size = new System.Drawing.Size(100, 28);
            this.rbStartJob.TabIndex = 4;
            this.rbStartJob.TabStop = true;
            this.rbStartJob.Tag = "";
            this.rbStartJob.Text = "Start Job";
            this.rbStartJob.UseVisualStyleBackColor = true;
            // 
            // rbReversePICK
            // 
            this.rbReversePICK.AutoSize = true;
            this.rbReversePICK.Location = new System.Drawing.Point(27, 151);
            this.rbReversePICK.Name = "rbReversePICK";
            this.rbReversePICK.Size = new System.Drawing.Size(259, 28);
            this.rbReversePICK.TabIndex = 3;
            this.rbReversePICK.TabStop = true;
            this.rbReversePICK.Tag = "";
            this.rbReversePICK.Text = "PICK material back to stores";
            this.rbReversePICK.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(618, 237);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(133, 33);
            this.btOK.TabIndex = 7;
            this.btOK.Tag = "";
            this.btOK.Text = "Accept";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // rbMorv
            // 
            this.rbMorv.AutoSize = true;
            this.rbMorv.Location = new System.Drawing.Point(27, 185);
            this.rbMorv.Name = "rbMorv";
            this.rbMorv.Size = new System.Drawing.Size(447, 28);
            this.rbMorv.TabIndex = 2;
            this.rbMorv.TabStop = true;
            this.rbMorv.Tag = "";
            this.rbMorv.Text = "MORV or Scrap material from manufacturing order";
            this.rbMorv.UseVisualStyleBackColor = true;
            // 
            // rbPick
            // 
            this.rbPick.AutoSize = true;
            this.rbPick.Location = new System.Drawing.Point(27, 49);
            this.rbPick.Name = "rbPick";
            this.rbPick.Size = new System.Drawing.Size(377, 28);
            this.rbPick.TabIndex = 1;
            this.rbPick.TabStop = true;
            this.rbPick.Tag = "";
            this.rbPick.Text = "PICK material against manufacturing order";
            this.rbPick.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 559);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.RadioButton rbMorv;
        private System.Windows.Forms.RadioButton rbPick;
        private System.Windows.Forms.RadioButton rbEndJob;
        private System.Windows.Forms.RadioButton rbStartJob;
        private System.Windows.Forms.RadioButton rbReversePICK;
        private System.Windows.Forms.RadioButton rbMachine;
    }
}

