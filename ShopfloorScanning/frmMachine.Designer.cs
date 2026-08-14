namespace ShopfloorScanning
{
    partial class frmMachine 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMachine));
            this.lblUserID = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtMachineID = new System.Windows.Forms.TextBox();
            this.lblMachineID = new System.Windows.Forms.Label();
            this.lblMachineIDDesc = new System.Windows.Forms.Label();
            this.grstatus = new System.Windows.Forms.GroupBox();
            this.rbMaintenance = new System.Windows.Forms.RadioButton();
            this.rbUnavailable = new System.Windows.Forms.RadioButton();
            this.rbAvailable = new System.Windows.Forms.RadioButton();
            this.lblTimeWorked = new System.Windows.Forms.Label();
            this.txtTimeWorked = new System.Windows.Forms.TextBox();
            this.btnMaintain = new System.Windows.Forms.Button();
            this.grUser = new System.Windows.Forms.GroupBox();
            this.grMachine = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grstatus.SuspendLayout();
            this.grUser.SuspendLayout();
            this.grMachine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(38, 28);
            this.lblUserID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(58, 18);
            this.lblUserID.TabIndex = 8;
            this.lblUserID.Tag = "";
            this.lblUserID.Text = "User ID";
            // 
            // txtUserID
            // 
            this.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserID.Location = new System.Drawing.Point(105, 25);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserID.MaxLength = 10;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.PasswordChar = '*';
            this.txtUserID.Size = new System.Drawing.Size(122, 24);
            this.txtUserID.TabIndex = 1;
            this.txtUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserID_KeyDown);
            this.txtUserID.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserID_Validating);
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(233, 28);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(169, 18);
            this.lblUserName.TabIndex = 9;
            this.lblUserName.Text = "User Name";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(555, 349);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 26);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(670, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Tag = "";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(441, 28);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(120, 18);
            this.lblDepartment.TabIndex = 31;
            this.lblDepartment.Tag = "";
            this.lblDepartment.Text = "Department Data";
            // 
            // txtMachineID
            // 
            this.txtMachineID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMachineID.Location = new System.Drawing.Point(105, 34);
            this.txtMachineID.Margin = new System.Windows.Forms.Padding(2);
            this.txtMachineID.MaxLength = 10;
            this.txtMachineID.Name = "txtMachineID";
            this.txtMachineID.Size = new System.Drawing.Size(122, 24);
            this.txtMachineID.TabIndex = 2;
            this.txtMachineID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMachineID_KeyDown);
            this.txtMachineID.Validating += new System.ComponentModel.CancelEventHandler(this.txtMachineID_Validating);
            // 
            // lblMachineID
            // 
            this.lblMachineID.AutoSize = true;
            this.lblMachineID.Location = new System.Drawing.Point(14, 37);
            this.lblMachineID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMachineID.Name = "lblMachineID";
            this.lblMachineID.Size = new System.Drawing.Size(82, 18);
            this.lblMachineID.TabIndex = 34;
            this.lblMachineID.Tag = "";
            this.lblMachineID.Text = "Machine ID";
            // 
            // lblMachineIDDesc
            // 
            this.lblMachineIDDesc.AutoSize = true;
            this.lblMachineIDDesc.Location = new System.Drawing.Point(233, 37);
            this.lblMachineIDDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMachineIDDesc.Name = "lblMachineIDDesc";
            this.lblMachineIDDesc.Size = new System.Drawing.Size(178, 18);
            this.lblMachineIDDesc.TabIndex = 35;
            this.lblMachineIDDesc.Tag = "";
            this.lblMachineIDDesc.Text = "Machine Description Data";
            // 
            // grstatus
            // 
            this.grstatus.Controls.Add(this.rbMaintenance);
            this.grstatus.Controls.Add(this.rbUnavailable);
            this.grstatus.Controls.Add(this.rbAvailable);
            this.grstatus.Location = new System.Drawing.Point(22, 196);
            this.grstatus.Name = "grstatus";
            this.grstatus.Size = new System.Drawing.Size(748, 132);
            this.grstatus.TabIndex = 3;
            this.grstatus.TabStop = false;
            this.grstatus.Text = "Machine status";
            // 
            // rbMaintenance
            // 
            this.rbMaintenance.AutoSize = true;
            this.rbMaintenance.Location = new System.Drawing.Point(105, 94);
            this.rbMaintenance.Name = "rbMaintenance";
            this.rbMaintenance.Size = new System.Drawing.Size(167, 22);
            this.rbMaintenance.TabIndex = 2;
            this.rbMaintenance.TabStop = true;
            this.rbMaintenance.Text = "Planned Maintenance";
            this.rbMaintenance.UseVisualStyleBackColor = true;
            // 
            // rbUnavailable
            // 
            this.rbUnavailable.AutoSize = true;
            this.rbUnavailable.Location = new System.Drawing.Point(105, 66);
            this.rbUnavailable.Name = "rbUnavailable";
            this.rbUnavailable.Size = new System.Drawing.Size(208, 22);
            this.rbUnavailable.TabIndex = 1;
            this.rbUnavailable.TabStop = true;
            this.rbUnavailable.Text = "Unavailable - awaiting repair";
            this.rbUnavailable.UseVisualStyleBackColor = true;
            // 
            // rbAvailable
            // 
            this.rbAvailable.AutoSize = true;
            this.rbAvailable.Location = new System.Drawing.Point(105, 38);
            this.rbAvailable.Name = "rbAvailable";
            this.rbAvailable.Size = new System.Drawing.Size(83, 22);
            this.rbAvailable.TabIndex = 0;
            this.rbAvailable.TabStop = true;
            this.rbAvailable.Text = "Available";
            this.rbAvailable.UseVisualStyleBackColor = true;
            // 
            // lblTimeWorked
            // 
            this.lblTimeWorked.AutoSize = true;
            this.lblTimeWorked.Location = new System.Drawing.Point(24, 354);
            this.lblTimeWorked.Name = "lblTimeWorked";
            this.lblTimeWorked.Size = new System.Drawing.Size(94, 18);
            this.lblTimeWorked.TabIndex = 37;
            this.lblTimeWorked.Text = "Time worked";
            this.lblTimeWorked.Visible = false;
            // 
            // txtTimeWorked
            // 
            this.txtTimeWorked.Location = new System.Drawing.Point(127, 351);
            this.txtTimeWorked.MaxLength = 5;
            this.txtTimeWorked.Name = "txtTimeWorked";
            this.txtTimeWorked.Size = new System.Drawing.Size(122, 24);
            this.txtTimeWorked.TabIndex = 4;
            this.txtTimeWorked.Visible = false;
            this.txtTimeWorked.Validating += new System.ComponentModel.CancelEventHandler(this.CheckNumber);
            // 
            // btnMaintain
            // 
            this.btnMaintain.Location = new System.Drawing.Point(268, 349);
            this.btnMaintain.Name = "btnMaintain";
            this.btnMaintain.Size = new System.Drawing.Size(100, 26);
            this.btnMaintain.TabIndex = 5;
            this.btnMaintain.Tag = "";
            this.btnMaintain.Text = "Start";
            this.btnMaintain.UseVisualStyleBackColor = true;
            this.btnMaintain.Visible = false;
            this.btnMaintain.Click += new System.EventHandler(this.btnMaintain_Click);
            // 
            // grUser
            // 
            this.grUser.Controls.Add(this.txtUserID);
            this.grUser.Controls.Add(this.lblUserID);
            this.grUser.Controls.Add(this.lblUserName);
            this.grUser.Controls.Add(this.lblDepartment);
            this.grUser.Location = new System.Drawing.Point(22, 12);
            this.grUser.Name = "grUser";
            this.grUser.Size = new System.Drawing.Size(632, 62);
            this.grUser.TabIndex = 1;
            this.grUser.TabStop = false;
            this.grUser.Text = "User details";
            // 
            // grMachine
            // 
            this.grMachine.Controls.Add(this.txtPassword);
            this.grMachine.Controls.Add(this.lblMachineID);
            this.grMachine.Controls.Add(this.txtMachineID);
            this.grMachine.Controls.Add(this.lblMachineIDDesc);
            this.grMachine.Location = new System.Drawing.Point(22, 90);
            this.grMachine.Name = "grMachine";
            this.grMachine.Size = new System.Drawing.Size(748, 81);
            this.grMachine.TabIndex = 2;
            this.grMachine.TabStop = false;
            this.grMachine.Text = "Machine details";
            // 
            // txtPassword
            // 
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.Location = new System.Drawing.Point(648, 31);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 10;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(88, 24);
            this.txtPassword.TabIndex = 36;
            this.txtPassword.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ShopfloorScanning.Properties.Resources.Trell_s;
            this.pictureBox1.Location = new System.Drawing.Point(670, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // frmMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 401);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grMachine);
            this.Controls.Add(this.grUser);
            this.Controls.Add(this.btnMaintain);
            this.Controls.Add(this.txtTimeWorked);
            this.Controls.Add(this.lblTimeWorked);
            this.Controls.Add(this.grstatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMachine";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmStartJob";
            this.Load += new System.EventHandler(this.frmStartJob_Load);
            this.grstatus.ResumeLayout(false);
            this.grstatus.PerformLayout();
            this.grUser.ResumeLayout(false);
            this.grUser.PerformLayout();
            this.grMachine.ResumeLayout(false);
            this.grMachine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtMachineID;
        private System.Windows.Forms.Label lblMachineID;
        private System.Windows.Forms.Label lblMachineIDDesc;
        private System.Windows.Forms.GroupBox grstatus;
        private System.Windows.Forms.RadioButton rbMaintenance;
        private System.Windows.Forms.RadioButton rbUnavailable;
        private System.Windows.Forms.RadioButton rbAvailable;
        private System.Windows.Forms.Label lblTimeWorked;
        private System.Windows.Forms.TextBox txtTimeWorked;
        private System.Windows.Forms.Button btnMaintain;
        private System.Windows.Forms.GroupBox grUser;
        private System.Windows.Forms.GroupBox grMachine;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPassword;
    }
}