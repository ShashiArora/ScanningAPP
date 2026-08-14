namespace ShopfloorScanning
{
    partial class frmMORVByProduct
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
            this.grOperation = new System.Windows.Forms.GroupBox();
            this.lblItemNumberData = new System.Windows.Forms.Label();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.lblItemNumber = new System.Windows.Forms.Label();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.ddlBin = new System.Windows.Forms.ComboBox();
            this.txtStockroom = new System.Windows.Forms.TextBox();
            this.lblStockroom = new System.Windows.Forms.Label();
            this.lblBin = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // grOperation
            // 
            this.grOperation.Controls.Add(this.lblItemNumberData);
            this.grOperation.Controls.Add(this.txtLotNo);
            this.grOperation.Controls.Add(this.lblItemNumber);
            this.grOperation.Controls.Add(this.lblLotNo);
            this.grOperation.Controls.Add(this.ddlBin);
            this.grOperation.Controls.Add(this.txtStockroom);
            this.grOperation.Controls.Add(this.lblStockroom);
            this.grOperation.Controls.Add(this.lblBin);
            this.grOperation.Controls.Add(this.txtQuantity);
            this.grOperation.Controls.Add(this.lblQuantity);
            this.grOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grOperation.Location = new System.Drawing.Point(4, 11);
            this.grOperation.Margin = new System.Windows.Forms.Padding(4);
            this.grOperation.Name = "grOperation";
            this.grOperation.Padding = new System.Windows.Forms.Padding(4);
            this.grOperation.Size = new System.Drawing.Size(483, 134);
            this.grOperation.TabIndex = 8;
            this.grOperation.TabStop = false;
            this.grOperation.Text = "Operation details";
            // 
            // lblItemNumberData
            // 
            this.lblItemNumberData.Location = new System.Drawing.Point(114, 35);
            this.lblItemNumberData.Name = "lblItemNumberData";
            this.lblItemNumberData.Size = new System.Drawing.Size(319, 17);
            this.lblItemNumberData.TabIndex = 31;
            // 
            // txtLotNo
            // 
            this.txtLotNo.Location = new System.Drawing.Point(263, 97);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(170, 24);
            this.txtLotNo.TabIndex = 30;
            this.txtLotNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtLotNo_Validating);
            // 
            // lblItemNumber
            // 
            this.lblItemNumber.AutoSize = true;
            this.lblItemNumber.Location = new System.Drawing.Point(13, 35);
            this.lblItemNumber.Name = "lblItemNumber";
            this.lblItemNumber.Size = new System.Drawing.Size(93, 18);
            this.lblItemNumber.TabIndex = 10;
            this.lblItemNumber.Text = "Item Number";
            // 
            // lblLotNo
            // 
            this.lblLotNo.AutoSize = true;
            this.lblLotNo.Location = new System.Drawing.Point(198, 100);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(53, 18);
            this.lblLotNo.TabIndex = 29;
            this.lblLotNo.Text = "Lot No";
            this.lblLotNo.Visible = false;
            // 
            // ddlBin
            // 
            this.ddlBin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBin.FormattingEnabled = true;
            this.ddlBin.Location = new System.Drawing.Point(263, 65);
            this.ddlBin.Margin = new System.Windows.Forms.Padding(4);
            this.ddlBin.Name = "ddlBin";
            this.ddlBin.Size = new System.Drawing.Size(100, 26);
            this.ddlBin.TabIndex = 4;
            // 
            // txtStockroom
            // 
            this.txtStockroom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStockroom.Location = new System.Drawing.Point(114, 65);
            this.txtStockroom.Margin = new System.Windows.Forms.Padding(4);
            this.txtStockroom.MaxLength = 15;
            this.txtStockroom.Name = "txtStockroom";
            this.txtStockroom.Size = new System.Drawing.Size(76, 24);
            this.txtStockroom.TabIndex = 3;
            this.txtStockroom.Validating += new System.ComponentModel.CancelEventHandler(this.txtStockroom_Validating);
            // 
            // lblStockroom
            // 
            this.lblStockroom.AutoSize = true;
            this.lblStockroom.Location = new System.Drawing.Point(23, 68);
            this.lblStockroom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockroom.Name = "lblStockroom";
            this.lblStockroom.Size = new System.Drawing.Size(83, 18);
            this.lblStockroom.TabIndex = 27;
            this.lblStockroom.Tag = "";
            this.lblStockroom.Text = "Stockroom";
            // 
            // lblBin
            // 
            this.lblBin.AutoSize = true;
            this.lblBin.Location = new System.Drawing.Point(222, 68);
            this.lblBin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBin.Name = "lblBin";
            this.lblBin.Size = new System.Drawing.Size(29, 18);
            this.lblBin.TabIndex = 28;
            this.lblBin.Tag = "";
            this.lblBin.Text = "Bin";
            // 
            // txtQuantity
            // 
            this.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuantity.Location = new System.Drawing.Point(114, 97);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(76, 24);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuantity_Validating);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(44, 100);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(62, 18);
            this.lblQuantity.TabIndex = 23;
            this.lblQuantity.Tag = "";
            this.lblQuantity.Text = "Quantity";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(130, 153);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 26);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Continue";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(267, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmMORVByProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 188);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grOperation);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMORVByProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMORVByProduct";
            this.Load += new System.EventHandler(this.frmMORVByProduct_Load);
            this.grOperation.ResumeLayout(false);
            this.grOperation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grOperation;
        private System.Windows.Forms.ComboBox ddlBin;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtStockroom;
        private System.Windows.Forms.Label lblStockroom;
        private System.Windows.Forms.Label lblBin;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtLotNo;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.Label lblItemNumber;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblItemNumberData;
    }
}