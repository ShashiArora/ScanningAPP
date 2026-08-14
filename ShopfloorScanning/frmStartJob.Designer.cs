namespace ShopfloorScanning
{
    partial class frmStartJob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStartJob));
            this.lblUserID = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblMOLineNumberData = new System.Windows.Forms.Label();
            this.lblItemNumber = new System.Windows.Forms.Label();
            this.lblItemNumberData = new System.Windows.Forms.Label();
            this.lblMOLineNumber = new System.Windows.Forms.Label();
            this.txtMONumber = new System.Windows.Forms.TextBox();
            this.lblPtUse = new System.Windows.Forms.Label();
            this.lblPtUseData = new System.Windows.Forms.Label();
            this.lblWorkcenterData = new System.Windows.Forms.Label();
            this.lblWorkcenter = new System.Windows.Forms.Label();
            this.lblSequenceNumber = new System.Windows.Forms.Label();
            this.txtSequenceNumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRuntimeIssuedData = new System.Windows.Forms.Label();
            this.lblRuntimeRemainingData = new System.Windows.Forms.Label();
            this.lblRuntimeRequiredData = new System.Windows.Forms.Label();
            this.lblQtyRemaining = new System.Windows.Forms.Label();
            this.lblQtyIssued = new System.Windows.Forms.Label();
            this.lblQtyRequired = new System.Windows.Forms.Label();
            this.lblQtyIssuedData = new System.Windows.Forms.Label();
            this.lblQtyRemainingData = new System.Windows.Forms.Label();
            this.lblQtyRequiredData = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblMONumber = new System.Windows.Forms.Label();
            this.txtMachineID = new System.Windows.Forms.TextBox();
            this.lblMachineID = new System.Windows.Forms.Label();
            this.lblMachineIDDesc = new System.Windows.Forms.Label();
            this.grUser = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.grMachine = new System.Windows.Forms.GroupBox();
            this.grOrder = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grUser.SuspendLayout();
            this.grMachine.SuspendLayout();
            this.grOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(86, 30);
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
            this.txtUserID.Location = new System.Drawing.Point(155, 27);
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
            this.lblUserName.Location = new System.Drawing.Point(304, 30);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(216, 18);
            this.lblUserName.TabIndex = 9;
            this.lblUserName.Text = "User Name";
            // 
            // lblMOLineNumberData
            // 
            this.lblMOLineNumberData.Location = new System.Drawing.Point(153, 67);
            this.lblMOLineNumberData.Name = "lblMOLineNumberData";
            this.lblMOLineNumberData.Size = new System.Drawing.Size(229, 18);
            this.lblMOLineNumberData.TabIndex = 12;
            this.lblMOLineNumberData.Text = "MO Line Number data";
            // 
            // lblItemNumber
            // 
            this.lblItemNumber.AutoSize = true;
            this.lblItemNumber.Location = new System.Drawing.Point(51, 98);
            this.lblItemNumber.Name = "lblItemNumber";
            this.lblItemNumber.Size = new System.Drawing.Size(93, 18);
            this.lblItemNumber.TabIndex = 13;
            this.lblItemNumber.Tag = "";
            this.lblItemNumber.Text = "Item Number";
            // 
            // lblItemNumberData
            // 
            this.lblItemNumberData.Location = new System.Drawing.Point(150, 98);
            this.lblItemNumberData.Name = "lblItemNumberData";
            this.lblItemNumberData.Size = new System.Drawing.Size(229, 18);
            this.lblItemNumberData.TabIndex = 14;
            this.lblItemNumberData.Text = "Item Number Data";
            // 
            // lblMOLineNumber
            // 
            this.lblMOLineNumber.AutoSize = true;
            this.lblMOLineNumber.Location = new System.Drawing.Point(23, 67);
            this.lblMOLineNumber.Name = "lblMOLineNumber";
            this.lblMOLineNumber.Size = new System.Drawing.Size(121, 18);
            this.lblMOLineNumber.TabIndex = 11;
            this.lblMOLineNumber.Tag = "";
            this.lblMOLineNumber.Text = "MO Line Number";
            // 
            // txtMONumber
            // 
            this.txtMONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMONumber.Location = new System.Drawing.Point(153, 33);
            this.txtMONumber.MaxLength = 20;
            this.txtMONumber.Name = "txtMONumber";
            this.txtMONumber.Size = new System.Drawing.Size(208, 24);
            this.txtMONumber.TabIndex = 7;
            this.txtMONumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMONumber_KeyDown);
            this.txtMONumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtMONumber_Validating);
            // 
            // lblPtUse
            // 
            this.lblPtUse.AutoSize = true;
            this.lblPtUse.Location = new System.Drawing.Point(54, 163);
            this.lblPtUse.Name = "lblPtUse";
            this.lblPtUse.Size = new System.Drawing.Size(90, 18);
            this.lblPtUse.TabIndex = 15;
            this.lblPtUse.Tag = "";
            this.lblPtUse.Text = "Point of Use";
            // 
            // lblPtUseData
            // 
            this.lblPtUseData.Location = new System.Drawing.Point(153, 163);
            this.lblPtUseData.Name = "lblPtUseData";
            this.lblPtUseData.Size = new System.Drawing.Size(229, 18);
            this.lblPtUseData.TabIndex = 16;
            this.lblPtUseData.Text = "PointOfUse Data";
            // 
            // lblWorkcenterData
            // 
            this.lblWorkcenterData.Location = new System.Drawing.Point(153, 230);
            this.lblWorkcenterData.Name = "lblWorkcenterData";
            this.lblWorkcenterData.Size = new System.Drawing.Size(229, 18);
            this.lblWorkcenterData.TabIndex = 19;
            this.lblWorkcenterData.Text = "Workcenter data";
            // 
            // lblWorkcenter
            // 
            this.lblWorkcenter.AutoSize = true;
            this.lblWorkcenter.Location = new System.Drawing.Point(58, 230);
            this.lblWorkcenter.Name = "lblWorkcenter";
            this.lblWorkcenter.Size = new System.Drawing.Size(86, 18);
            this.lblWorkcenter.TabIndex = 18;
            this.lblWorkcenter.Tag = "";
            this.lblWorkcenter.Text = "Workcenter";
            // 
            // lblSequenceNumber
            // 
            this.lblSequenceNumber.AutoSize = true;
            this.lblSequenceNumber.Location = new System.Drawing.Point(13, 196);
            this.lblSequenceNumber.Name = "lblSequenceNumber";
            this.lblSequenceNumber.Size = new System.Drawing.Size(131, 18);
            this.lblSequenceNumber.TabIndex = 17;
            this.lblSequenceNumber.Tag = "";
            this.lblSequenceNumber.Text = "Sequence Number";
            // 
            // txtSequenceNumber
            // 
            this.txtSequenceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSequenceNumber.Location = new System.Drawing.Point(153, 193);
            this.txtSequenceNumber.MaxLength = 50;
            this.txtSequenceNumber.Name = "txtSequenceNumber";
            this.txtSequenceNumber.Size = new System.Drawing.Size(208, 24);
            this.txtSequenceNumber.TabIndex = 8;
            this.txtSequenceNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSequenceNumber_KeyDown);
            this.txtSequenceNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtSequenceNumber_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRuntimeIssuedData);
            this.groupBox1.Controls.Add(this.lblRuntimeRemainingData);
            this.groupBox1.Controls.Add(this.lblRuntimeRequiredData);
            this.groupBox1.Controls.Add(this.lblQtyRemaining);
            this.groupBox1.Controls.Add(this.lblQtyIssued);
            this.groupBox1.Controls.Add(this.lblQtyRequired);
            this.groupBox1.Location = new System.Drawing.Point(464, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 138);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            this.groupBox1.Text = "Runtimes in minutes";
            // 
            // lblRuntimeIssuedData
            // 
            this.lblRuntimeIssuedData.Location = new System.Drawing.Point(121, 67);
            this.lblRuntimeIssuedData.Name = "lblRuntimeIssuedData";
            this.lblRuntimeIssuedData.Size = new System.Drawing.Size(223, 18);
            this.lblRuntimeIssuedData.TabIndex = 4;
            this.lblRuntimeIssuedData.Text = "Quantity Issued Data";
            // 
            // lblRuntimeRemainingData
            // 
            this.lblRuntimeRemainingData.Location = new System.Drawing.Point(121, 95);
            this.lblRuntimeRemainingData.Name = "lblRuntimeRemainingData";
            this.lblRuntimeRemainingData.Size = new System.Drawing.Size(223, 18);
            this.lblRuntimeRemainingData.TabIndex = 6;
            this.lblRuntimeRemainingData.Text = "Quantity remaining data";
            // 
            // lblRuntimeRequiredData
            // 
            this.lblRuntimeRequiredData.Location = new System.Drawing.Point(121, 36);
            this.lblRuntimeRequiredData.Name = "lblRuntimeRequiredData";
            this.lblRuntimeRequiredData.Size = new System.Drawing.Size(223, 18);
            this.lblRuntimeRequiredData.TabIndex = 2;
            this.lblRuntimeRequiredData.Text = "Quantity required Data";
            // 
            // lblQtyRemaining
            // 
            this.lblQtyRemaining.AutoSize = true;
            this.lblQtyRemaining.Location = new System.Drawing.Point(37, 95);
            this.lblQtyRemaining.Name = "lblQtyRemaining";
            this.lblQtyRemaining.Size = new System.Drawing.Size(78, 18);
            this.lblQtyRemaining.TabIndex = 5;
            this.lblQtyRemaining.Tag = "";
            this.lblQtyRemaining.Text = "Remaining";
            // 
            // lblQtyIssued
            // 
            this.lblQtyIssued.AutoSize = true;
            this.lblQtyIssued.Location = new System.Drawing.Point(64, 67);
            this.lblQtyIssued.Name = "lblQtyIssued";
            this.lblQtyIssued.Size = new System.Drawing.Size(51, 18);
            this.lblQtyIssued.TabIndex = 3;
            this.lblQtyIssued.Tag = "";
            this.lblQtyIssued.Text = "Issued";
            // 
            // lblQtyRequired
            // 
            this.lblQtyRequired.AutoSize = true;
            this.lblQtyRequired.Location = new System.Drawing.Point(48, 36);
            this.lblQtyRequired.Name = "lblQtyRequired";
            this.lblQtyRequired.Size = new System.Drawing.Size(67, 18);
            this.lblQtyRequired.TabIndex = 1;
            this.lblQtyRequired.Tag = "";
            this.lblQtyRequired.Text = "Required";
            // 
            // lblQtyIssuedData
            // 
            this.lblQtyIssuedData.Location = new System.Drawing.Point(121, 57);
            this.lblQtyIssuedData.Name = "lblQtyIssuedData";
            this.lblQtyIssuedData.Size = new System.Drawing.Size(229, 18);
            this.lblQtyIssuedData.TabIndex = 4;
            this.lblQtyIssuedData.Text = "Quantity Issued Data";
            // 
            // lblQtyRemainingData
            // 
            this.lblQtyRemainingData.Location = new System.Drawing.Point(121, 85);
            this.lblQtyRemainingData.Name = "lblQtyRemainingData";
            this.lblQtyRemainingData.Size = new System.Drawing.Size(229, 18);
            this.lblQtyRemainingData.TabIndex = 6;
            this.lblQtyRemainingData.Text = "Quantity remaining data";
            // 
            // lblQtyRequiredData
            // 
            this.lblQtyRequiredData.Location = new System.Drawing.Point(121, 29);
            this.lblQtyRequiredData.Name = "lblQtyRequiredData";
            this.lblQtyRequiredData.Size = new System.Drawing.Size(229, 18);
            this.lblQtyRequiredData.TabIndex = 2;
            this.lblQtyRequiredData.Text = "Quantity required Data";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(644, 491);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 26);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(760, 491);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Tag = "";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(573, 30);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(120, 18);
            this.lblDepartment.TabIndex = 31;
            this.lblDepartment.Tag = "";
            this.lblDepartment.Text = "Department Data";
            // 
            // lblMONumber
            // 
            this.lblMONumber.AutoSize = true;
            this.lblMONumber.Location = new System.Drawing.Point(54, 36);
            this.lblMONumber.Name = "lblMONumber";
            this.lblMONumber.Size = new System.Drawing.Size(90, 18);
            this.lblMONumber.TabIndex = 32;
            this.lblMONumber.Tag = "";
            this.lblMONumber.Text = "MO Number";
            // 
            // txtMachineID
            // 
            this.txtMachineID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMachineID.Location = new System.Drawing.Point(155, 35);
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
            this.lblMachineID.Location = new System.Drawing.Point(62, 38);
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
            this.lblMachineIDDesc.Location = new System.Drawing.Point(304, 38);
            this.lblMachineIDDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMachineIDDesc.Name = "lblMachineIDDesc";
            this.lblMachineIDDesc.Size = new System.Drawing.Size(178, 18);
            this.lblMachineIDDesc.TabIndex = 35;
            this.lblMachineIDDesc.Tag = "";
            this.lblMachineIDDesc.Text = "Machine Description Data";
            // 
            // grUser
            // 
            this.grUser.Controls.Add(this.txtPassword);
            this.grUser.Controls.Add(this.txtUserID);
            this.grUser.Controls.Add(this.lblUserID);
            this.grUser.Controls.Add(this.lblUserName);
            this.grUser.Controls.Add(this.lblDepartment);
            this.grUser.Location = new System.Drawing.Point(12, 12);
            this.grUser.Name = "grUser";
            this.grUser.Size = new System.Drawing.Size(753, 62);
            this.grUser.TabIndex = 1;
            this.grUser.TabStop = false;
            this.grUser.Text = "User details";
            // 
            // txtPassword
            // 
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.Location = new System.Drawing.Point(479, 22);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 10;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(88, 24);
            this.txtPassword.TabIndex = 45;
            this.txtPassword.Visible = false;
            // 
            // grMachine
            // 
            this.grMachine.Controls.Add(this.txtMachineID);
            this.grMachine.Controls.Add(this.lblMachineID);
            this.grMachine.Controls.Add(this.lblMachineIDDesc);
            this.grMachine.Location = new System.Drawing.Point(12, 89);
            this.grMachine.Name = "grMachine";
            this.grMachine.Size = new System.Drawing.Size(870, 82);
            this.grMachine.TabIndex = 2;
            this.grMachine.TabStop = false;
            this.grMachine.Text = "Machine details";
            // 
            // grOrder
            // 
            this.grOrder.Controls.Add(this.lblMONumber);
            this.grOrder.Controls.Add(this.lblMOLineNumberData);
            this.grOrder.Controls.Add(this.lblItemNumber);
            this.grOrder.Controls.Add(this.lblItemNumberData);
            this.grOrder.Controls.Add(this.lblMOLineNumber);
            this.grOrder.Controls.Add(this.txtMONumber);
            this.grOrder.Controls.Add(this.txtSequenceNumber);
            this.grOrder.Controls.Add(this.lblPtUse);
            this.grOrder.Controls.Add(this.lblSequenceNumber);
            this.grOrder.Controls.Add(this.lblPtUseData);
            this.grOrder.Controls.Add(this.lblWorkcenter);
            this.grOrder.Controls.Add(this.lblWorkcenterData);
            this.grOrder.Location = new System.Drawing.Point(12, 191);
            this.grOrder.Name = "grOrder";
            this.grOrder.Size = new System.Drawing.Size(432, 283);
            this.grOrder.TabIndex = 3;
            this.grOrder.TabStop = false;
            this.grOrder.Text = "Order details";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ShopfloorScanning.Properties.Resources.Trell_s;
            this.pictureBox1.Location = new System.Drawing.Point(782, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblQtyIssuedData);
            this.groupBox2.Controls.Add(this.lblQtyRemainingData);
            this.groupBox2.Controls.Add(this.lblQtyRequiredData);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(464, 345);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 129);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "";
            this.groupBox2.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 18);
            this.label4.TabIndex = 5;
            this.label4.Tag = "";
            this.label4.Text = "Remaining";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 18);
            this.label5.TabIndex = 3;
            this.label5.Tag = "";
            this.label5.Text = "Issued";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 18);
            this.label6.TabIndex = 1;
            this.label6.Tag = "";
            this.label6.Text = "Required";
            // 
            // frmStartJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 534);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grOrder);
            this.Controls.Add(this.grMachine);
            this.Controls.Add(this.grUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStartJob";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmStartJob";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStartJob_FormClosing);
            this.Load += new System.EventHandler(this.frmStartJob_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grUser.ResumeLayout(false);
            this.grUser.PerformLayout();
            this.grMachine.ResumeLayout(false);
            this.grMachine.PerformLayout();
            this.grOrder.ResumeLayout(false);
            this.grOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblMOLineNumberData;
        private System.Windows.Forms.Label lblItemNumber;
        private System.Windows.Forms.Label lblItemNumberData;
        private System.Windows.Forms.Label lblMOLineNumber;
        private System.Windows.Forms.TextBox txtMONumber;
        private System.Windows.Forms.Label lblPtUse;
        private System.Windows.Forms.Label lblPtUseData;
        private System.Windows.Forms.Label lblWorkcenterData;
        private System.Windows.Forms.Label lblWorkcenter;
        private System.Windows.Forms.Label lblSequenceNumber;
        private System.Windows.Forms.TextBox txtSequenceNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblQtyIssuedData;
        private System.Windows.Forms.Label lblQtyRemainingData;
        private System.Windows.Forms.Label lblQtyRequiredData;
        private System.Windows.Forms.Label lblQtyRemaining;
        private System.Windows.Forms.Label lblQtyIssued;
        private System.Windows.Forms.Label lblQtyRequired;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblMONumber;
        private System.Windows.Forms.TextBox txtMachineID;
        private System.Windows.Forms.Label lblMachineID;
        private System.Windows.Forms.Label lblMachineIDDesc;
        private System.Windows.Forms.GroupBox grUser;
        private System.Windows.Forms.GroupBox grMachine;
        private System.Windows.Forms.GroupBox grOrder;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblRuntimeIssuedData;
        private System.Windows.Forms.Label lblRuntimeRemainingData;
        private System.Windows.Forms.Label lblRuntimeRequiredData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
    }
}