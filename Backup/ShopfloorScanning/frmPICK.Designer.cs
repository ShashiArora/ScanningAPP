namespace ShopfloorScanning
{
    partial class frmPICK
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPICK));
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
            this.grQuantity = new System.Windows.Forms.GroupBox();
            this.lblQtyIssuedData = new System.Windows.Forms.Label();
            this.lblQtyRemainingData = new System.Windows.Forms.Label();
            this.lblQtyRequiredData = new System.Windows.Forms.Label();
            this.lblQtyRemaining = new System.Windows.Forms.Label();
            this.lblQtyIssued = new System.Windows.Forms.Label();
            this.lblQtyRequired = new System.Windows.Forms.Label();
            this.grStock = new System.Windows.Forms.DataGridView();
            this.StockStockroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockBin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockLotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockLotDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shopfloorDataSet = new ShopfloorScanning.ShopfloorDataSet();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblMONumber = new System.Windows.Forms.Label();
            this.grUser = new System.Windows.Forms.GroupBox();
            this.grOrder = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.stockListTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.StockListTableAdapter();
            this.tableAdapterManager = new ShopfloorScanning.ShopfloorDataSetTableAdapters.TableAdapterManager();
            this.grQuantity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopfloorDataSet)).BeginInit();
            this.grUser.SuspendLayout();
            this.grOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(76, 27);
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
            this.txtUserID.Location = new System.Drawing.Point(143, 24);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserID.MaxLength = 10;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.PasswordChar = '*';
            this.txtUserID.Size = new System.Drawing.Size(113, 24);
            this.txtUserID.TabIndex = 1;
            this.txtUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserID_KeyDown);
            this.txtUserID.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserID_Validating);
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(270, 27);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(200, 18);
            this.lblUserName.TabIndex = 9;
            this.lblUserName.Text = "User Name";
            // 
            // lblMOLineNumberData
            // 
            this.lblMOLineNumberData.Location = new System.Drawing.Point(143, 76);
            this.lblMOLineNumberData.Name = "lblMOLineNumberData";
            this.lblMOLineNumberData.Size = new System.Drawing.Size(229, 18);
            this.lblMOLineNumberData.TabIndex = 12;
            this.lblMOLineNumberData.Text = "MO Line Number data";
            // 
            // lblItemNumber
            // 
            this.lblItemNumber.AutoSize = true;
            this.lblItemNumber.Location = new System.Drawing.Point(41, 107);
            this.lblItemNumber.Name = "lblItemNumber";
            this.lblItemNumber.Size = new System.Drawing.Size(93, 18);
            this.lblItemNumber.TabIndex = 13;
            this.lblItemNumber.Tag = "";
            this.lblItemNumber.Text = "Item Number";
            // 
            // lblItemNumberData
            // 
            this.lblItemNumberData.Location = new System.Drawing.Point(143, 107);
            this.lblItemNumberData.Name = "lblItemNumberData";
            this.lblItemNumberData.Size = new System.Drawing.Size(229, 18);
            this.lblItemNumberData.TabIndex = 14;
            this.lblItemNumberData.Text = "Item Number Data";
            // 
            // lblMOLineNumber
            // 
            this.lblMOLineNumber.AutoSize = true;
            this.lblMOLineNumber.Location = new System.Drawing.Point(13, 76);
            this.lblMOLineNumber.Name = "lblMOLineNumber";
            this.lblMOLineNumber.Size = new System.Drawing.Size(121, 18);
            this.lblMOLineNumber.TabIndex = 11;
            this.lblMOLineNumber.Tag = "";
            this.lblMOLineNumber.Text = "MO Line Number";
            // 
            // txtMONumber
            // 
            this.txtMONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMONumber.Location = new System.Drawing.Point(146, 42);
            this.txtMONumber.MaxLength = 20;
            this.txtMONumber.Name = "txtMONumber";
            this.txtMONumber.Size = new System.Drawing.Size(217, 24);
            this.txtMONumber.TabIndex = 2;
            this.txtMONumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMONumber_KeyDown);
            this.txtMONumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtMONumber_Validating);
            // 
            // lblPtUse
            // 
            this.lblPtUse.AutoSize = true;
            this.lblPtUse.Location = new System.Drawing.Point(44, 155);
            this.lblPtUse.Name = "lblPtUse";
            this.lblPtUse.Size = new System.Drawing.Size(90, 18);
            this.lblPtUse.TabIndex = 15;
            this.lblPtUse.Tag = "";
            this.lblPtUse.Text = "Point of Use";
            // 
            // lblPtUseData
            // 
            this.lblPtUseData.Location = new System.Drawing.Point(143, 155);
            this.lblPtUseData.Name = "lblPtUseData";
            this.lblPtUseData.Size = new System.Drawing.Size(229, 18);
            this.lblPtUseData.TabIndex = 16;
            this.lblPtUseData.Text = "PointOfUse Data";
            // 
            // lblWorkcenterData
            // 
            this.lblWorkcenterData.Location = new System.Drawing.Point(143, 223);
            this.lblWorkcenterData.Name = "lblWorkcenterData";
            this.lblWorkcenterData.Size = new System.Drawing.Size(229, 18);
            this.lblWorkcenterData.TabIndex = 19;
            this.lblWorkcenterData.Text = "Workcenter data";
            // 
            // lblWorkcenter
            // 
            this.lblWorkcenter.AutoSize = true;
            this.lblWorkcenter.Location = new System.Drawing.Point(48, 223);
            this.lblWorkcenter.Name = "lblWorkcenter";
            this.lblWorkcenter.Size = new System.Drawing.Size(86, 18);
            this.lblWorkcenter.TabIndex = 18;
            this.lblWorkcenter.Tag = "";
            this.lblWorkcenter.Text = "Workcenter";
            // 
            // lblSequenceNumber
            // 
            this.lblSequenceNumber.AutoSize = true;
            this.lblSequenceNumber.Location = new System.Drawing.Point(3, 188);
            this.lblSequenceNumber.Name = "lblSequenceNumber";
            this.lblSequenceNumber.Size = new System.Drawing.Size(131, 18);
            this.lblSequenceNumber.TabIndex = 17;
            this.lblSequenceNumber.Tag = "";
            this.lblSequenceNumber.Text = "Sequence Number";
            // 
            // txtSequenceNumber
            // 
            this.txtSequenceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSequenceNumber.Location = new System.Drawing.Point(146, 185);
            this.txtSequenceNumber.MaxLength = 50;
            this.txtSequenceNumber.Name = "txtSequenceNumber";
            this.txtSequenceNumber.Size = new System.Drawing.Size(217, 24);
            this.txtSequenceNumber.TabIndex = 3;
            this.txtSequenceNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSequenceNumber_KeyDown);
            this.txtSequenceNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtSequenceNumber_Validating);
            // 
            // grQuantity
            // 
            this.grQuantity.Controls.Add(this.lblQtyIssuedData);
            this.grQuantity.Controls.Add(this.lblQtyRemainingData);
            this.grQuantity.Controls.Add(this.lblQtyRequiredData);
            this.grQuantity.Controls.Add(this.lblQtyRemaining);
            this.grQuantity.Controls.Add(this.lblQtyIssued);
            this.grQuantity.Controls.Add(this.lblQtyRequired);
            this.grQuantity.Location = new System.Drawing.Point(412, 101);
            this.grQuantity.Name = "grQuantity";
            this.grQuantity.Size = new System.Drawing.Size(470, 141);
            this.grQuantity.TabIndex = 3;
            this.grQuantity.TabStop = false;
            this.grQuantity.Tag = "";
            this.grQuantity.Text = "Quantity";
            // 
            // lblQtyIssuedData
            // 
            this.lblQtyIssuedData.Location = new System.Drawing.Point(144, 67);
            this.lblQtyIssuedData.Name = "lblQtyIssuedData";
            this.lblQtyIssuedData.Size = new System.Drawing.Size(229, 18);
            this.lblQtyIssuedData.TabIndex = 4;
            this.lblQtyIssuedData.Text = "Quantity Issued Data";
            // 
            // lblQtyRemainingData
            // 
            this.lblQtyRemainingData.Location = new System.Drawing.Point(144, 95);
            this.lblQtyRemainingData.Name = "lblQtyRemainingData";
            this.lblQtyRemainingData.Size = new System.Drawing.Size(229, 18);
            this.lblQtyRemainingData.TabIndex = 6;
            this.lblQtyRemainingData.Text = "Quantity remaining data";
            // 
            // lblQtyRequiredData
            // 
            this.lblQtyRequiredData.Location = new System.Drawing.Point(144, 39);
            this.lblQtyRequiredData.Name = "lblQtyRequiredData";
            this.lblQtyRequiredData.Size = new System.Drawing.Size(229, 18);
            this.lblQtyRequiredData.TabIndex = 2;
            this.lblQtyRequiredData.Text = "Quantity required Data";
            // 
            // lblQtyRemaining
            // 
            this.lblQtyRemaining.AutoSize = true;
            this.lblQtyRemaining.Location = new System.Drawing.Point(57, 95);
            this.lblQtyRemaining.Name = "lblQtyRemaining";
            this.lblQtyRemaining.Size = new System.Drawing.Size(78, 18);
            this.lblQtyRemaining.TabIndex = 5;
            this.lblQtyRemaining.Tag = "";
            this.lblQtyRemaining.Text = "Remaining";
            // 
            // lblQtyIssued
            // 
            this.lblQtyIssued.AutoSize = true;
            this.lblQtyIssued.Location = new System.Drawing.Point(84, 67);
            this.lblQtyIssued.Name = "lblQtyIssued";
            this.lblQtyIssued.Size = new System.Drawing.Size(51, 18);
            this.lblQtyIssued.TabIndex = 3;
            this.lblQtyIssued.Tag = "";
            this.lblQtyIssued.Text = "Issued";
            // 
            // lblQtyRequired
            // 
            this.lblQtyRequired.AutoSize = true;
            this.lblQtyRequired.Location = new System.Drawing.Point(68, 39);
            this.lblQtyRequired.Name = "lblQtyRequired";
            this.lblQtyRequired.Size = new System.Drawing.Size(67, 18);
            this.lblQtyRequired.TabIndex = 1;
            this.lblQtyRequired.Tag = "";
            this.lblQtyRequired.Text = "Required";
            // 
            // grStock
            // 
            this.grStock.AllowUserToAddRows = false;
            this.grStock.AllowUserToDeleteRows = false;
            this.grStock.AllowUserToResizeColumns = false;
            this.grStock.AllowUserToResizeRows = false;
            this.grStock.AutoGenerateColumns = false;
            this.grStock.ColumnHeadersHeight = 27;
            this.grStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockStockroom,
            this.StockBin,
            this.StockQuantity,
            this.StockLotNumber,
            this.StockLotDate});
            this.grStock.DataSource = this.stockListBindingSource;
            this.grStock.Location = new System.Drawing.Point(412, 256);
            this.grStock.Name = "grStock";
            this.grStock.ReadOnly = true;
            this.grStock.RowHeadersVisible = false;
            this.grStock.RowHeadersWidth = 20;
            this.grStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grStock.ShowCellErrors = false;
            this.grStock.Size = new System.Drawing.Size(470, 171);
            this.grStock.TabIndex = 4;
            this.grStock.CurrentCellChanged += new System.EventHandler(this.grStock_CurrentCellChanged);
            this.grStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grStock_KeyDown);
            // 
            // StockStockroom
            // 
            this.StockStockroom.DataPropertyName = "Stockroom";
            this.StockStockroom.HeaderText = "Stock";
            this.StockStockroom.Name = "StockStockroom";
            this.StockStockroom.ReadOnly = true;
            this.StockStockroom.Width = 70;
            // 
            // StockBin
            // 
            this.StockBin.DataPropertyName = "Bin";
            this.StockBin.HeaderText = "Bin";
            this.StockBin.Name = "StockBin";
            this.StockBin.ReadOnly = true;
            this.StockBin.Width = 50;
            // 
            // StockQuantity
            // 
            this.StockQuantity.DataPropertyName = "InventoryQuantity";
            this.StockQuantity.HeaderText = "Quantity";
            this.StockQuantity.Name = "StockQuantity";
            this.StockQuantity.ReadOnly = true;
            this.StockQuantity.Width = 80;
            // 
            // StockLotNumber
            // 
            this.StockLotNumber.DataPropertyName = "LotNumber";
            this.StockLotNumber.HeaderText = "Lot No";
            this.StockLotNumber.Name = "StockLotNumber";
            this.StockLotNumber.ReadOnly = true;
            this.StockLotNumber.Width = 160;
            // 
            // StockLotDate
            // 
            this.StockLotDate.DataPropertyName = "LotReceiptDate";
            this.StockLotDate.HeaderText = "Date";
            this.StockLotDate.Name = "StockLotDate";
            this.StockLotDate.ReadOnly = true;
            // 
            // stockListBindingSource
            // 
            this.stockListBindingSource.DataMember = "StockList";
            this.stockListBindingSource.DataSource = this.shopfloorDataSet;
            // 
            // shopfloorDataSet
            // 
            this.shopfloorDataSet.DataSetName = "ShopfloorDataSet";
            this.shopfloorDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(72, 282);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(62, 18);
            this.lblQuantity.TabIndex = 21;
            this.lblQuantity.Tag = "";
            this.lblQuantity.Text = "Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuantity.Location = new System.Drawing.Point(143, 279);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(113, 24);
            this.txtQuantity.TabIndex = 4;
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            this.txtQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuantity_Validating);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(676, 448);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 26);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(782, 448);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Tag = "";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(543, 27);
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
            this.lblMONumber.Location = new System.Drawing.Point(44, 45);
            this.lblMONumber.Name = "lblMONumber";
            this.lblMONumber.Size = new System.Drawing.Size(90, 18);
            this.lblMONumber.TabIndex = 32;
            this.lblMONumber.Tag = "";
            this.lblMONumber.Text = "MO Number";
            // 
            // grUser
            // 
            this.grUser.Controls.Add(this.txtUserID);
            this.grUser.Controls.Add(this.lblUserID);
            this.grUser.Controls.Add(this.lblDepartment);
            this.grUser.Controls.Add(this.lblUserName);
            this.grUser.Location = new System.Drawing.Point(12, 12);
            this.grUser.Name = "grUser";
            this.grUser.Size = new System.Drawing.Size(754, 63);
            this.grUser.TabIndex = 1;
            this.grUser.TabStop = false;
            this.grUser.Text = "User details";
            // 
            // grOrder
            // 
            this.grOrder.Controls.Add(this.lblMONumber);
            this.grOrder.Controls.Add(this.lblMOLineNumberData);
            this.grOrder.Controls.Add(this.lblItemNumber);
            this.grOrder.Controls.Add(this.lblItemNumberData);
            this.grOrder.Controls.Add(this.lblMOLineNumber);
            this.grOrder.Controls.Add(this.txtQuantity);
            this.grOrder.Controls.Add(this.txtMONumber);
            this.grOrder.Controls.Add(this.lblQuantity);
            this.grOrder.Controls.Add(this.lblPtUse);
            this.grOrder.Controls.Add(this.lblPtUseData);
            this.grOrder.Controls.Add(this.lblWorkcenterData);
            this.grOrder.Controls.Add(this.txtSequenceNumber);
            this.grOrder.Controls.Add(this.lblWorkcenter);
            this.grOrder.Controls.Add(this.lblSequenceNumber);
            this.grOrder.Location = new System.Drawing.Point(12, 101);
            this.grOrder.Name = "grOrder";
            this.grOrder.Size = new System.Drawing.Size(384, 326);
            this.grOrder.TabIndex = 2;
            this.grOrder.TabStop = false;
            this.grOrder.Text = "Order details";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ShopfloorScanning.Properties.Resources.Trell_s;
            this.pictureBox1.Location = new System.Drawing.Point(782, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // stockListTableAdapter
            // 
            this.stockListTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.ShopfloorExtraJobEndTableAdapter = null;
            this.tableAdapterManager.ShopfloorExtraJobStartTableAdapter = null;
            this.tableAdapterManager.ShopfloorJobEndTableAdapter = null;
            this.tableAdapterManager.ShopfloorJobStartTableAdapter = null;
            this.tableAdapterManager.ShopfloorMaintenanceLogTableAdapter = null;
            this.tableAdapterManager.ShopfloorPicksTableAdapter = null;
            this.tableAdapterManager.ShopfloorScrapTableAdapter = null;
            this.tableAdapterManager.ShopfloorToolsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ShopfloorScanning.ShopfloorDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmPICK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 492);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grOrder);
            this.Controls.Add(this.grUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grStock);
            this.Controls.Add(this.grQuantity);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPICK";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPICK";
            this.Load += new System.EventHandler(this.frmPICK_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPICK_FormClosing);
            this.grQuantity.ResumeLayout(false);
            this.grQuantity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopfloorDataSet)).EndInit();
            this.grUser.ResumeLayout(false);
            this.grUser.PerformLayout();
            this.grOrder.ResumeLayout(false);
            this.grOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.GroupBox grQuantity;
        private System.Windows.Forms.Label lblQtyIssuedData;
        private System.Windows.Forms.Label lblQtyRemainingData;
        private System.Windows.Forms.Label lblQtyRequiredData;
        private System.Windows.Forms.Label lblQtyRemaining;
        private System.Windows.Forms.Label lblQtyIssued;
        private System.Windows.Forms.Label lblQtyRequired;
        private System.Windows.Forms.DataGridView grStock;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private ShopfloorDataSet shopfloorDataSet;
        private System.Windows.Forms.BindingSource stockListBindingSource;
        private ShopfloorScanning.ShopfloorDataSetTableAdapters.StockListTableAdapter stockListTableAdapter;
        private ShopfloorScanning.ShopfloorDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockStockroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockBin;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockLotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockLotDate;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblMONumber;
        private System.Windows.Forms.GroupBox grUser;
        private System.Windows.Forms.GroupBox grOrder;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}