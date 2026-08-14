namespace ShopfloorScanning
{
    partial class frmMORV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMORV));
            this.txtMONumber = new System.Windows.Forms.TextBox();
            this.lblMOLineNumber = new System.Windows.Forms.Label();
            this.lblItemNumberData = new System.Windows.Forms.Label();
            this.lblItemNumber = new System.Windows.Forms.Label();
            this.lblMONumber = new System.Windows.Forms.Label();
            this.lblMOLineNumberData = new System.Windows.Forms.Label();
            this.grQuantity = new System.Windows.Forms.GroupBox();
            this.lblQtyReceivedData = new System.Windows.Forms.Label();
            this.lblQtyOpenData = new System.Windows.Forms.Label();
            this.lblQtyOnOrderData = new System.Windows.Forms.Label();
            this.lblQtyOpen = new System.Windows.Forms.Label();
            this.lblQtyReceived = new System.Windows.Forms.Label();
            this.lblQtyOnOrder = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtStockroom = new System.Windows.Forms.TextBox();
            this.lblStockroom = new System.Windows.Forms.Label();
            this.lblBin = new System.Windows.Forms.Label();
            this.grUser = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.grOrder = new System.Windows.Forms.GroupBox();
            this.grOperation = new System.Windows.Forms.GroupBox();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.ddlBin = new System.Windows.Forms.ComboBox();
            this.shopfloorDataSet = new ShopfloorScanning.ShopfloorDataSet();
            this.scrapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grbScrap = new System.Windows.Forms.GroupBox();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.grScrap = new System.Windows.Forms.DataGridView();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblScrapReason = new System.Windows.Forms.Label();
            this.ddlScrapReason = new System.Windows.Forms.ComboBox();
            this.btnAddScrap = new System.Windows.Forms.Button();
            this.txtScrapQuantity = new System.Windows.Forms.TextBox();
            this.lblScrapQuantity = new System.Windows.Forms.Label();
            this.scrapTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.InventoryLocationTableAdapter();
            this.grQuantity.SuspendLayout();
            this.grUser.SuspendLayout();
            this.grOrder.SuspendLayout();
            this.grOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shopfloorDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrapBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grbScrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grScrap)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMONumber
            // 
            this.txtMONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMONumber.Location = new System.Drawing.Point(145, 38);
            this.txtMONumber.MaxLength = 20;
            this.txtMONumber.Name = "txtMONumber";
            this.txtMONumber.Size = new System.Drawing.Size(246, 24);
            this.txtMONumber.TabIndex = 2;
            this.txtMONumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMONumber_KeyDown);
            this.txtMONumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtMONumber_Validating);
            // 
            // lblMOLineNumber
            // 
            this.lblMOLineNumber.AutoSize = true;
            this.lblMOLineNumber.Location = new System.Drawing.Point(13, 74);
            this.lblMOLineNumber.Name = "lblMOLineNumber";
            this.lblMOLineNumber.Size = new System.Drawing.Size(121, 18);
            this.lblMOLineNumber.TabIndex = 17;
            this.lblMOLineNumber.Tag = "";
            this.lblMOLineNumber.Text = "MO Line Number";
            // 
            // lblItemNumberData
            // 
            this.lblItemNumberData.Location = new System.Drawing.Point(142, 106);
            this.lblItemNumberData.Name = "lblItemNumberData";
            this.lblItemNumberData.Size = new System.Drawing.Size(242, 18);
            this.lblItemNumberData.TabIndex = 20;
            this.lblItemNumberData.Text = "Item Number Data";
            // 
            // lblItemNumber
            // 
            this.lblItemNumber.AutoSize = true;
            this.lblItemNumber.Location = new System.Drawing.Point(41, 106);
            this.lblItemNumber.Name = "lblItemNumber";
            this.lblItemNumber.Size = new System.Drawing.Size(93, 18);
            this.lblItemNumber.TabIndex = 19;
            this.lblItemNumber.Tag = "";
            this.lblItemNumber.Text = "Item Number";
            // 
            // lblMONumber
            // 
            this.lblMONumber.AutoSize = true;
            this.lblMONumber.Location = new System.Drawing.Point(44, 41);
            this.lblMONumber.Name = "lblMONumber";
            this.lblMONumber.Size = new System.Drawing.Size(90, 18);
            this.lblMONumber.TabIndex = 16;
            this.lblMONumber.Tag = "";
            this.lblMONumber.Text = "MO Number";
            // 
            // lblMOLineNumberData
            // 
            this.lblMOLineNumberData.Location = new System.Drawing.Point(142, 74);
            this.lblMOLineNumberData.Name = "lblMOLineNumberData";
            this.lblMOLineNumberData.Size = new System.Drawing.Size(242, 18);
            this.lblMOLineNumberData.TabIndex = 18;
            this.lblMOLineNumberData.Text = "MO Line Number data";
            // 
            // grQuantity
            // 
            this.grQuantity.Controls.Add(this.lblQtyReceivedData);
            this.grQuantity.Controls.Add(this.lblQtyOpenData);
            this.grQuantity.Controls.Add(this.lblQtyOnOrderData);
            this.grQuantity.Controls.Add(this.lblQtyOpen);
            this.grQuantity.Controls.Add(this.lblQtyReceived);
            this.grQuantity.Controls.Add(this.lblQtyOnOrder);
            this.grQuantity.Location = new System.Drawing.Point(467, 93);
            this.grQuantity.Name = "grQuantity";
            this.grQuantity.Size = new System.Drawing.Size(412, 151);
            this.grQuantity.TabIndex = 21;
            this.grQuantity.TabStop = false;
            this.grQuantity.Tag = "";
            this.grQuantity.Text = "Quantity";
            // 
            // lblQtyReceivedData
            // 
            this.lblQtyReceivedData.Location = new System.Drawing.Point(142, 74);
            this.lblQtyReceivedData.Name = "lblQtyReceivedData";
            this.lblQtyReceivedData.Size = new System.Drawing.Size(188, 18);
            this.lblQtyReceivedData.TabIndex = 4;
            this.lblQtyReceivedData.Text = "Quantity Received Data";
            // 
            // lblQtyOpenData
            // 
            this.lblQtyOpenData.Location = new System.Drawing.Point(143, 106);
            this.lblQtyOpenData.Name = "lblQtyOpenData";
            this.lblQtyOpenData.Size = new System.Drawing.Size(188, 18);
            this.lblQtyOpenData.TabIndex = 6;
            this.lblQtyOpenData.Text = "Quantity Open data";
            // 
            // lblQtyOnOrderData
            // 
            this.lblQtyOnOrderData.Location = new System.Drawing.Point(143, 41);
            this.lblQtyOnOrderData.Name = "lblQtyOnOrderData";
            this.lblQtyOnOrderData.Size = new System.Drawing.Size(188, 18);
            this.lblQtyOnOrderData.TabIndex = 2;
            this.lblQtyOnOrderData.Text = "Quantity on order Data";
            // 
            // lblQtyOpen
            // 
            this.lblQtyOpen.AutoSize = true;
            this.lblQtyOpen.Location = new System.Drawing.Point(84, 106);
            this.lblQtyOpen.Name = "lblQtyOpen";
            this.lblQtyOpen.Size = new System.Drawing.Size(44, 18);
            this.lblQtyOpen.TabIndex = 5;
            this.lblQtyOpen.Tag = "";
            this.lblQtyOpen.Text = "Open";
            // 
            // lblQtyReceived
            // 
            this.lblQtyReceived.AutoSize = true;
            this.lblQtyReceived.Location = new System.Drawing.Point(58, 74);
            this.lblQtyReceived.Name = "lblQtyReceived";
            this.lblQtyReceived.Size = new System.Drawing.Size(69, 18);
            this.lblQtyReceived.TabIndex = 3;
            this.lblQtyReceived.Tag = "";
            this.lblQtyReceived.Text = "Received";
            // 
            // lblQtyOnOrder
            // 
            this.lblQtyOnOrder.AutoSize = true;
            this.lblQtyOnOrder.Location = new System.Drawing.Point(58, 41);
            this.lblQtyOnOrder.Name = "lblQtyOnOrder";
            this.lblQtyOnOrder.Size = new System.Drawing.Size(70, 18);
            this.lblQtyOnOrder.TabIndex = 1;
            this.lblQtyOnOrder.Tag = "";
            this.lblQtyOnOrder.Text = "On Order";
            // 
            // txtQuantity
            // 
            this.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuantity.Location = new System.Drawing.Point(145, 66);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(72, 24);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            this.txtQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuantity_Validating);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(23, 69);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(104, 18);
            this.lblQuantity.TabIndex = 23;
            this.lblQuantity.Tag = "";
            this.lblQuantity.Text = "Good Quantity";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(747, 546);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Tag = "";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(637, 546);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 26);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtStockroom
            // 
            this.txtStockroom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStockroom.Location = new System.Drawing.Point(145, 36);
            this.txtStockroom.MaxLength = 15;
            this.txtStockroom.Name = "txtStockroom";
            this.txtStockroom.Size = new System.Drawing.Size(73, 24);
            this.txtStockroom.TabIndex = 3;
            this.txtStockroom.TextChanged += new System.EventHandler(this.txtStockroom_TextChanged);
            this.txtStockroom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStockroom_KeyDown);
            this.txtStockroom.Validating += new System.ComponentModel.CancelEventHandler(this.txtStockroom_Validating);
            // 
            // lblStockroom
            // 
            this.lblStockroom.AutoSize = true;
            this.lblStockroom.Location = new System.Drawing.Point(44, 39);
            this.lblStockroom.Name = "lblStockroom";
            this.lblStockroom.Size = new System.Drawing.Size(83, 18);
            this.lblStockroom.TabIndex = 27;
            this.lblStockroom.Tag = "";
            this.lblStockroom.Text = "Stockroom";
            // 
            // lblBin
            // 
            this.lblBin.AutoSize = true;
            this.lblBin.Location = new System.Drawing.Point(262, 39);
            this.lblBin.Name = "lblBin";
            this.lblBin.Size = new System.Drawing.Size(29, 18);
            this.lblBin.TabIndex = 28;
            this.lblBin.Tag = "";
            this.lblBin.Text = "Bin";
            // 
            // grUser
            // 
            this.grUser.Controls.Add(this.txtPassword);
            this.grUser.Controls.Add(this.txtUserID);
            this.grUser.Controls.Add(this.lblUserID);
            this.grUser.Controls.Add(this.lblDepartment);
            this.grUser.Controls.Add(this.lblUserName);
            this.grUser.Location = new System.Drawing.Point(12, 12);
            this.grUser.Name = "grUser";
            this.grUser.Size = new System.Drawing.Size(752, 63);
            this.grUser.TabIndex = 1;
            this.grUser.TabStop = false;
            this.grUser.Text = "User details";
            // 
            // txtPassword
            // 
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.Location = new System.Drawing.Point(385, 21);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 10;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(88, 24);
            this.txtPassword.TabIndex = 38;
            this.txtPassword.Visible = false;
            // 
            // txtUserID
            // 
            this.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserID.Location = new System.Drawing.Point(145, 24);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserID.MaxLength = 10;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.PasswordChar = '*';
            this.txtUserID.Size = new System.Drawing.Size(113, 24);
            this.txtUserID.TabIndex = 1;
            this.txtUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserID_KeyDown);
            this.txtUserID.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserID_Validating);
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
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(477, 27);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(120, 18);
            this.lblDepartment.TabIndex = 31;
            this.lblDepartment.Tag = "";
            this.lblDepartment.Text = "Department Data";
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(270, 27);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(200, 18);
            this.lblUserName.TabIndex = 9;
            this.lblUserName.Text = "User Name";
            // 
            // grOrder
            // 
            this.grOrder.Controls.Add(this.lblMONumber);
            this.grOrder.Controls.Add(this.lblMOLineNumberData);
            this.grOrder.Controls.Add(this.lblItemNumber);
            this.grOrder.Controls.Add(this.lblItemNumberData);
            this.grOrder.Controls.Add(this.lblMOLineNumber);
            this.grOrder.Controls.Add(this.txtMONumber);
            this.grOrder.Location = new System.Drawing.Point(12, 93);
            this.grOrder.Name = "grOrder";
            this.grOrder.Size = new System.Drawing.Size(419, 151);
            this.grOrder.TabIndex = 2;
            this.grOrder.TabStop = false;
            this.grOrder.Text = "Order details";
            // 
            // grOperation
            // 
            this.grOperation.Controls.Add(this.txtLotNo);
            this.grOperation.Controls.Add(this.lblLotNo);
            this.grOperation.Controls.Add(this.ddlBin);
            this.grOperation.Controls.Add(this.txtStockroom);
            this.grOperation.Controls.Add(this.lblStockroom);
            this.grOperation.Controls.Add(this.lblBin);
            this.grOperation.Controls.Add(this.txtQuantity);
            this.grOperation.Controls.Add(this.lblQuantity);
            this.grOperation.Location = new System.Drawing.Point(12, 510);
            this.grOperation.Name = "grOperation";
            this.grOperation.Size = new System.Drawing.Size(609, 108);
            this.grOperation.TabIndex = 4;
            this.grOperation.TabStop = false;
            this.grOperation.Text = "Operation details";
            // 
            // txtLotNo
            // 
            this.txtLotNo.Location = new System.Drawing.Point(303, 66);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(170, 24);
            this.txtLotNo.TabIndex = 32;
            this.txtLotNo.Visible = false;
            this.txtLotNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtLotNo_Validating);
            // 
            // lblLotNo
            // 
            this.lblLotNo.AutoSize = true;
            this.lblLotNo.Location = new System.Drawing.Point(238, 69);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(53, 18);
            this.lblLotNo.TabIndex = 31;
            this.lblLotNo.Text = "Lot No";
            this.lblLotNo.Visible = false;
            // 
            // ddlBin
            // 
            this.ddlBin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBin.FormattingEnabled = true;
            this.ddlBin.Location = new System.Drawing.Point(303, 37);
            this.ddlBin.Name = "ddlBin";
            this.ddlBin.Size = new System.Drawing.Size(170, 26);
            this.ddlBin.TabIndex = 4;
            // 
            // shopfloorDataSet
            // 
            this.shopfloorDataSet.DataSetName = "ShopfloorDataSet";
            this.shopfloorDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // scrapBindingSource
            // 
            this.scrapBindingSource.DataMember = "InventoryLocation";
            this.scrapBindingSource.DataSource = this.shopfloorDataSet;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ShopfloorScanning.Properties.Resources.Trell_s;
            this.pictureBox1.Location = new System.Drawing.Point(782, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // grbScrap
            // 
            this.grbScrap.Controls.Add(this.btnDeleteRow);
            this.grbScrap.Controls.Add(this.grScrap);
            this.grbScrap.Controls.Add(this.lblScrapReason);
            this.grbScrap.Controls.Add(this.ddlScrapReason);
            this.grbScrap.Controls.Add(this.btnAddScrap);
            this.grbScrap.Controls.Add(this.txtScrapQuantity);
            this.grbScrap.Controls.Add(this.lblScrapQuantity);
            this.grbScrap.Location = new System.Drawing.Point(12, 261);
            this.grbScrap.Name = "grbScrap";
            this.grbScrap.Size = new System.Drawing.Size(867, 233);
            this.grbScrap.TabIndex = 3;
            this.grbScrap.TabStop = false;
            this.grbScrap.Text = "Scrap details";
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Enabled = false;
            this.btnDeleteRow.Location = new System.Drawing.Point(736, 41);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(100, 26);
            this.btnDeleteRow.TabIndex = 44;
            this.btnDeleteRow.Text = "Cancel";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // grScrap
            // 
            this.grScrap.AllowUserToAddRows = false;
            this.grScrap.AllowUserToResizeColumns = false;
            this.grScrap.AllowUserToResizeRows = false;
            this.grScrap.ColumnHeadersHeight = 27;
            this.grScrap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Line,
            this.Bin,
            this.ScrapReason,
            this.ScrapQuantity});
            this.grScrap.Location = new System.Drawing.Point(34, 83);
            this.grScrap.Name = "grScrap";
            this.grScrap.ReadOnly = true;
            this.grScrap.RowHeadersVisible = false;
            this.grScrap.RowHeadersWidth = 20;
            this.grScrap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grScrap.ShowCellErrors = false;
            this.grScrap.Size = new System.Drawing.Size(802, 130);
            this.grScrap.TabIndex = 42;
            this.grScrap.CurrentCellChanged += new System.EventHandler(this.grScrap_CurrentCellChanged);
            // 
            // Line
            // 
            this.Line.HeaderText = "Line No#";
            this.Line.Name = "Line";
            this.Line.ReadOnly = true;
            // 
            // Bin
            // 
            this.Bin.HeaderText = "Bin";
            this.Bin.Name = "Bin";
            this.Bin.ReadOnly = true;
            // 
            // ScrapReason
            // 
            this.ScrapReason.HeaderText = "Scrap Reason";
            this.ScrapReason.Name = "ScrapReason";
            this.ScrapReason.ReadOnly = true;
            this.ScrapReason.Width = 400;
            // 
            // ScrapQuantity
            // 
            this.ScrapQuantity.HeaderText = "Scrap Quantity";
            this.ScrapQuantity.Name = "ScrapQuantity";
            this.ScrapQuantity.ReadOnly = true;
            this.ScrapQuantity.Width = 150;
            // 
            // lblScrapReason
            // 
            this.lblScrapReason.AutoSize = true;
            this.lblScrapReason.Location = new System.Drawing.Point(31, 45);
            this.lblScrapReason.Name = "lblScrapReason";
            this.lblScrapReason.Size = new System.Drawing.Size(103, 18);
            this.lblScrapReason.TabIndex = 37;
            this.lblScrapReason.Tag = "";
            this.lblScrapReason.Text = "Scrap Reason";
            // 
            // ddlScrapReason
            // 
            this.ddlScrapReason.DataSource = this.scrapBindingSource;
            this.ddlScrapReason.DisplayMember = "InventoryLocationDescription";
            this.ddlScrapReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlScrapReason.FormattingEnabled = true;
            this.ddlScrapReason.Location = new System.Drawing.Point(145, 42);
            this.ddlScrapReason.Name = "ddlScrapReason";
            this.ddlScrapReason.Size = new System.Drawing.Size(246, 26);
            this.ddlScrapReason.TabIndex = 3;
            this.ddlScrapReason.ValueMember = "Bin";
            // 
            // btnAddScrap
            // 
            this.btnAddScrap.Location = new System.Drawing.Point(625, 41);
            this.btnAddScrap.Name = "btnAddScrap";
            this.btnAddScrap.Size = new System.Drawing.Size(100, 26);
            this.btnAddScrap.TabIndex = 43;
            this.btnAddScrap.TabStop = false;
            this.btnAddScrap.Text = "Add Scrap";
            this.btnAddScrap.UseVisualStyleBackColor = true;
            this.btnAddScrap.Click += new System.EventHandler(this.btnAddScrap_Click);
            // 
            // txtScrapQuantity
            // 
            this.txtScrapQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtScrapQuantity.Location = new System.Drawing.Point(508, 42);
            this.txtScrapQuantity.Name = "txtScrapQuantity";
            this.txtScrapQuantity.Size = new System.Drawing.Size(72, 24);
            this.txtScrapQuantity.TabIndex = 4;
            // 
            // lblScrapQuantity
            // 
            this.lblScrapQuantity.AutoSize = true;
            this.lblScrapQuantity.Location = new System.Drawing.Point(401, 45);
            this.lblScrapQuantity.Name = "lblScrapQuantity";
            this.lblScrapQuantity.Size = new System.Drawing.Size(105, 18);
            this.lblScrapQuantity.TabIndex = 36;
            this.lblScrapQuantity.Tag = "";
            this.lblScrapQuantity.Text = "Scrap Quantity";
            // 
            // scrapTableAdapter
            // 
            this.scrapTableAdapter.ClearBeforeFill = true;
            // 
            // frmMORV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 630);
            this.Controls.Add(this.grbScrap);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grOperation);
            this.Controls.Add(this.grOrder);
            this.Controls.Add(this.grUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grQuantity);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMORV";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMORV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMORV_FormClosing);
            this.Load += new System.EventHandler(this.frmMORV_Load);
            this.grQuantity.ResumeLayout(false);
            this.grQuantity.PerformLayout();
            this.grUser.ResumeLayout(false);
            this.grUser.PerformLayout();
            this.grOrder.ResumeLayout(false);
            this.grOrder.PerformLayout();
            this.grOperation.ResumeLayout(false);
            this.grOperation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shopfloorDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrapBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grbScrap.ResumeLayout(false);
            this.grbScrap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grScrap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMONumber;
        private System.Windows.Forms.Label lblMOLineNumber;
        private System.Windows.Forms.Label lblItemNumberData;
        private System.Windows.Forms.Label lblItemNumber;
        private System.Windows.Forms.Label lblMONumber;
        private System.Windows.Forms.Label lblMOLineNumberData;
        private System.Windows.Forms.GroupBox grQuantity;
        private System.Windows.Forms.Label lblQtyReceivedData;
        private System.Windows.Forms.Label lblQtyOpenData;
        private System.Windows.Forms.Label lblQtyOnOrderData;
        private System.Windows.Forms.Label lblQtyOpen;
        private System.Windows.Forms.Label lblQtyReceived;
        private System.Windows.Forms.Label lblQtyOnOrder;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtStockroom;
        private System.Windows.Forms.Label lblStockroom;
        private System.Windows.Forms.Label lblBin;
        private System.Windows.Forms.GroupBox grUser;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox grOrder;
        private System.Windows.Forms.GroupBox grOperation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grbScrap;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.DataGridView grScrap;
        private System.Windows.Forms.Label lblScrapReason;
        private System.Windows.Forms.ComboBox ddlScrapReason;
        private System.Windows.Forms.Button btnAddScrap;
        private System.Windows.Forms.TextBox txtScrapQuantity;
        private System.Windows.Forms.Label lblScrapQuantity;
        private ShopfloorDataSet shopfloorDataSet;
        private System.Windows.Forms.BindingSource scrapBindingSource;
        private ShopfloorScanning.ShopfloorDataSetTableAdapters.InventoryLocationTableAdapter scrapTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapQuantity;
        private System.Windows.Forms.ComboBox ddlBin;
        private System.Windows.Forms.TextBox txtLotNo;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.TextBox txtPassword;
    }
}