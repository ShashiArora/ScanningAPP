namespace ShopfloorScanning
{
    partial class frmReversePICK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReversePICK));
            this.lblMONumber = new System.Windows.Forms.Label();
            this.lblItemNumber = new System.Windows.Forms.Label();
            this.lblItemNumberData = new System.Windows.Forms.Label();
            this.txtMONumber = new System.Windows.Forms.TextBox();
            this.grStock = new System.Windows.Forms.DataGridView();
            this.MONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SequenceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComponentItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComponentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stockroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PICKKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shopfloorDataSet = new ShopfloorScanning.ShopfloorDataSet();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grUser = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.grDetails = new System.Windows.Forms.GroupBox();
            this.pickDetailsTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.PickDetailsTableAdapter();
            this.tableAdapterManager = new ShopfloorScanning.ShopfloorDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.grStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopfloorDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grUser.SuspendLayout();
            this.grDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMONumber
            // 
            this.lblMONumber.AutoSize = true;
            this.lblMONumber.Location = new System.Drawing.Point(32, 35);
            this.lblMONumber.Name = "lblMONumber";
            this.lblMONumber.Size = new System.Drawing.Size(90, 18);
            this.lblMONumber.TabIndex = 10;
            this.lblMONumber.Tag = "";
            this.lblMONumber.Text = "MO Number";
            // 
            // lblItemNumber
            // 
            this.lblItemNumber.AutoSize = true;
            this.lblItemNumber.Location = new System.Drawing.Point(25, 68);
            this.lblItemNumber.Name = "lblItemNumber";
            this.lblItemNumber.Size = new System.Drawing.Size(93, 18);
            this.lblItemNumber.TabIndex = 13;
            this.lblItemNumber.Tag = "";
            this.lblItemNumber.Text = "Item Number";
            // 
            // lblItemNumberData
            // 
            this.lblItemNumberData.Location = new System.Drawing.Point(127, 68);
            this.lblItemNumberData.Name = "lblItemNumberData";
            this.lblItemNumberData.Size = new System.Drawing.Size(372, 18);
            this.lblItemNumberData.TabIndex = 14;
            this.lblItemNumberData.Text = "Item Number Data";
            // 
            // txtMONumber
            // 
            this.txtMONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMONumber.Location = new System.Drawing.Point(127, 32);
            this.txtMONumber.MaxLength = 20;
            this.txtMONumber.Name = "txtMONumber";
            this.txtMONumber.Size = new System.Drawing.Size(175, 24);
            this.txtMONumber.TabIndex = 2;
            this.txtMONumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMONumber_KeyDown);
            this.txtMONumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtMONumber_Validating);
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
            this.MONumber,
            this.MOLineNumber,
            this.ItemNumber,
            this.LotNumber,
            this.Quantity,
            this.PTUse,
            this.SequenceNumber,
            this.ComponentItemNumber,
            this.ComponentType,
            this.Stockroom,
            this.Bin,
            this.PICKKey});
            this.grStock.DataSource = this.pickDetailsBindingSource;
            this.grStock.Location = new System.Drawing.Point(15, 224);
            this.grStock.Name = "grStock";
            this.grStock.ReadOnly = true;
            this.grStock.RowHeadersVisible = false;
            this.grStock.RowHeadersWidth = 20;
            this.grStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grStock.ShowCellErrors = false;
            this.grStock.Size = new System.Drawing.Size(828, 150);
            this.grStock.TabIndex = 30;
            this.grStock.CurrentCellChanged += new System.EventHandler(this.grStock_CurrentCellChanged);
            this.grStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grStock_KeyDown);
            // 
            // MONumber
            // 
            this.MONumber.DataPropertyName = "MONumber";
            this.MONumber.HeaderText = "MONumber";
            this.MONumber.Name = "MONumber";
            this.MONumber.ReadOnly = true;
            this.MONumber.Visible = false;
            // 
            // MOLineNumber
            // 
            this.MOLineNumber.DataPropertyName = "MOLineNumber";
            this.MOLineNumber.HeaderText = "MO Ln";
            this.MOLineNumber.Name = "MOLineNumber";
            this.MOLineNumber.ReadOnly = true;
            this.MOLineNumber.Width = 60;
            // 
            // ItemNumber
            // 
            this.ItemNumber.DataPropertyName = "ItemNumber";
            this.ItemNumber.HeaderText = "ItemNumber";
            this.ItemNumber.Name = "ItemNumber";
            this.ItemNumber.ReadOnly = true;
            this.ItemNumber.Width = 150;
            // 
            // LotNumber
            // 
            this.LotNumber.DataPropertyName = "LotNumber";
            this.LotNumber.HeaderText = "LotNumber";
            this.LotNumber.Name = "LotNumber";
            this.LotNumber.ReadOnly = true;
            this.LotNumber.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 80;
            // 
            // PTUse
            // 
            this.PTUse.DataPropertyName = "PTUse";
            this.PTUse.HeaderText = "PTUse";
            this.PTUse.Name = "PTUse";
            this.PTUse.ReadOnly = true;
            this.PTUse.Width = 60;
            // 
            // SequenceNumber
            // 
            this.SequenceNumber.DataPropertyName = "SequenceNumber";
            this.SequenceNumber.HeaderText = "Seq";
            this.SequenceNumber.Name = "SequenceNumber";
            this.SequenceNumber.ReadOnly = true;
            this.SequenceNumber.Width = 60;
            // 
            // ComponentItemNumber
            // 
            this.ComponentItemNumber.DataPropertyName = "ComponentItemNumber";
            this.ComponentItemNumber.HeaderText = "Component";
            this.ComponentItemNumber.Name = "ComponentItemNumber";
            this.ComponentItemNumber.ReadOnly = true;
            // 
            // ComponentType
            // 
            this.ComponentType.DataPropertyName = "ComponentType";
            this.ComponentType.HeaderText = "CT";
            this.ComponentType.Name = "ComponentType";
            this.ComponentType.ReadOnly = true;
            this.ComponentType.Width = 30;
            // 
            // Stockroom
            // 
            this.Stockroom.DataPropertyName = "Stockroom";
            this.Stockroom.HeaderText = "Stk";
            this.Stockroom.Name = "Stockroom";
            this.Stockroom.ReadOnly = true;
            this.Stockroom.Width = 50;
            // 
            // Bin
            // 
            this.Bin.DataPropertyName = "Bin";
            this.Bin.HeaderText = "Bin";
            this.Bin.Name = "Bin";
            this.Bin.ReadOnly = true;
            this.Bin.Width = 70;
            // 
            // PICKKey
            // 
            this.PICKKey.DataPropertyName = "PICKKey";
            this.PICKKey.HeaderText = "PICKKey";
            this.PICKKey.Name = "PICKKey";
            this.PICKKey.ReadOnly = true;
            this.PICKKey.Visible = false;
            // 
            // pickDetailsBindingSource
            // 
            this.pickDetailsBindingSource.DataMember = "PickDetails";
            this.pickDetailsBindingSource.DataSource = this.shopfloorDataSet;
            // 
            // shopfloorDataSet
            // 
            this.shopfloorDataSet.DataSetName = "ShopfloorDataSet";
            this.shopfloorDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 404);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(121, 18);
            this.lblQuantity.TabIndex = 21;
            this.lblQuantity.Tag = "";
            this.lblQuantity.Text = "Reverse Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuantity.Location = new System.Drawing.Point(142, 401);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(175, 24);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            this.txtQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuantity_Validating);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(626, 400);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 26);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(743, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Tag = "";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ShopfloorScanning.Properties.Resources.Trell_s;
            this.pictureBox1.Location = new System.Drawing.Point(743, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // grUser
            // 
            this.grUser.Controls.Add(this.txtPassword);
            this.grUser.Controls.Add(this.txtUserID);
            this.grUser.Controls.Add(this.lblUserID);
            this.grUser.Controls.Add(this.lblUserName);
            this.grUser.Location = new System.Drawing.Point(15, 12);
            this.grUser.Name = "grUser";
            this.grUser.Size = new System.Drawing.Size(711, 62);
            this.grUser.TabIndex = 1;
            this.grUser.TabStop = false;
            this.grUser.Text = "User details";
            // 
            // txtPassword
            // 
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.Location = new System.Drawing.Point(618, 25);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 10;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(88, 24);
            this.txtPassword.TabIndex = 39;
            this.txtPassword.Visible = false;
            // 
            // txtUserID
            // 
            this.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserID.Location = new System.Drawing.Point(127, 22);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserID.MaxLength = 10;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.PasswordChar = '*';
            this.txtUserID.Size = new System.Drawing.Size(175, 24);
            this.txtUserID.TabIndex = 1;
            this.txtUserID.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserID_Validating);
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(60, 25);
            this.lblUserID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(58, 18);
            this.lblUserID.TabIndex = 8;
            this.lblUserID.Tag = "";
            this.lblUserID.Text = "User ID";
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(389, 25);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(216, 18);
            this.lblUserName.TabIndex = 9;
            this.lblUserName.Text = "User Name";
            // 
            // grDetails
            // 
            this.grDetails.Controls.Add(this.lblMONumber);
            this.grDetails.Controls.Add(this.lblItemNumber);
            this.grDetails.Controls.Add(this.lblItemNumberData);
            this.grDetails.Controls.Add(this.txtMONumber);
            this.grDetails.Location = new System.Drawing.Point(15, 94);
            this.grDetails.Name = "grDetails";
            this.grDetails.Size = new System.Drawing.Size(828, 112);
            this.grDetails.TabIndex = 2;
            this.grDetails.TabStop = false;
            this.grDetails.Text = "Details";
            // 
            // pickDetailsTableAdapter
            // 
            this.pickDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.ShopfloorExtraJobEndTableAdapter = null;
            this.tableAdapterManager.ShopfloorExtraJobStartTableAdapter = null;
            this.tableAdapterManager.ShopfloorJobBreakTableAdapter = null;
            this.tableAdapterManager.ShopfloorJobEndTableAdapter = null;
            this.tableAdapterManager.ShopfloorJobStartTableAdapter = null;
            this.tableAdapterManager.ShopfloorMaintenanceLogTableAdapter = null;
            this.tableAdapterManager.ShopfloorPicksTableAdapter = null;
            this.tableAdapterManager.ShopfloorScrapTableAdapter = null;
            this.tableAdapterManager.ShopfloorToolsTableAdapter = null;
            this.tableAdapterManager.ShopfloorUsersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ShopfloorScanning.ShopfloorDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmReversePICK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 448);
            this.Controls.Add(this.grDetails);
            this.Controls.Add(this.grUser);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.grStock);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReversePICK";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmReversePICK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReversePICK_FormClosing);
            this.Load += new System.EventHandler(this.frmReversePICK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopfloorDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grUser.ResumeLayout(false);
            this.grUser.PerformLayout();
            this.grDetails.ResumeLayout(false);
            this.grDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMONumber;
        private System.Windows.Forms.Label lblItemNumber;
        private System.Windows.Forms.Label lblItemNumberData;
        private System.Windows.Forms.TextBox txtMONumber;
        private System.Windows.Forms.DataGridView grStock;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private ShopfloorDataSet shopfloorDataSet;
        private System.Windows.Forms.BindingSource pickDetailsBindingSource;
        private ShopfloorScanning.ShopfloorDataSetTableAdapters.PickDetailsTableAdapter pickDetailsTableAdapter;
        private ShopfloorScanning.ShopfloorDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grUser;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox grDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn SequenceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComponentItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComponentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stockroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bin;
        private System.Windows.Forms.DataGridViewTextBoxColumn PICKKey;
        private System.Windows.Forms.TextBox txtPassword;
    }
}