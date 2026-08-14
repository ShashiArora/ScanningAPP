using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Mail;
using SoftBrands.FourthShift.Transaction;
using Microsoft.Reporting.WinForms;

namespace ShopfloorScanning
{
    public partial class frmMORV : Form
    {
        private FSTIClient fstiClient;
        private string sFSUserID;
        private int iMOLineKey;
        private string sLotNumber;
        private string sInventoryCategory;
        private int iScrapRowIndex;
        private string sPreferredBin;
        private string sLotNumberMask;

        public frmMORV()
        {
            InitializeComponent();
        }

        //set up starting parameters
        private void frmMORV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopfloorDataSet.InventoryLocation' table. You can move, or remove it, as needed.
            this.scrapTableAdapter.Fill(this.shopfloorDataSet.InventoryLocation, "99");
            this.Text = Application.ProductName + " - MORV materials";
            CleanData();
        }

        //connect to FSTI
        private void FSTIConnect()
        {
            int status;
            string message = null;

            try
            {
                fstiClient = new FSTIClient();
                fstiClient.InitializeBySystemName(ConfigurationSettings.AppSettings["fstiSystem"], ConfigurationSettings.AppSettings["fstiServer"], true, true, "7361");
                status = fstiClient.Logon("FST", "fsti0001", ref message);

                if (status > 0)
                {
                    MessageBox.Show(this, "Cannot login to Fourth Shift. Please, check settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FSTIClose();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show(this, "Cannot connect to FSTI. Please, check settings." , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FSTIClose();
                this.Close();
            }
        }

        //close FSTI interface
        private void FSTIClose()
        {
            if (fstiClient != null)
            {
                fstiClient.Terminate();
            }
        }

        //ensure FSTI gets disconnected
        private void frmMORV_FormClosing(object sender, FormClosingEventArgs e)
        {
            FSTIClose();
        }

        //Validations

        private bool DecimalParser(string sValue)
        {
            decimal val;

            if (decimal.TryParse(sValue, out val))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //check user ID
        private void txtUserID_Validating(object sender, CancelEventArgs e)
        {
            ShopfloorDataSetTableAdapters.ShopfloorUsersTableAdapter mUsersTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.ShopfloorUsersTableAdapter();
            ShopfloorDataSet.ShopfloorUsersDataTable mUsersDataTable = new ShopfloorDataSet.ShopfloorUsersDataTable();
            ShopfloorDataSet.ShopfloorUsersRow mUsersRow;

            string sErrorMsg = "";

            //check if any data entered
            if (txtUserID.Text == "")
            {
                //no userID - error
                sErrorMsg = "Please scan or enter your UserID.";
            }
            else
            {
                mUsersTableAdapter.FillBy(mUsersDataTable, txtUserID.Text);

                if (mUsersDataTable.Rows.Count > 0)
                {
                    mUsersRow = (ShopfloorDataSet.ShopfloorUsersRow)mUsersDataTable.Rows[0];

                    lblUserName.Text = mUsersRow.UserName;
                    sFSUserID = mUsersRow.FSUserID;
                    lblDepartment.Text = mUsersRow.Department;

                    //security check
                    if (Convert.ToBoolean(mUsersRow["CanMORV"]) == false)
                    {
                        sErrorMsg = "This UserID is not allowed to do MORV operation. Please scan or enter valid UserID.";
                    }
                }
                else
                {
                    sErrorMsg = "This UserID don't exists. Please scan or enter valid UserID.";
                }
            }

            //check if any errors and display them if so
            if (sErrorMsg != "")
            {
                MessageBox.Show(this, sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserID.Select(0, 10);
                e.Cancel = true;
            }
        }

        //add enter handling to move to next field
        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMONumber.Focus();
            }	
        }

        //check MO entered
        private void txtMONumber_Validating(object sender, CancelEventArgs e)
        {
            ShopfloorDataSetTableAdapters.MOCheckTableAdapter mMOCheckTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.MOCheckTableAdapter();
            ShopfloorDataSet.MOCheckDataTable mMOCheckDataTable = new ShopfloorDataSet.MOCheckDataTable();
            ShopfloorDataSet.MOCheckRow mMOCheckRow;

            ShopfloorDataSetTableAdapters.QueriesTableAdapter query = new ShopfloorScanning.ShopfloorDataSetTableAdapters.QueriesTableAdapter();

            string sErrorMsg = "";
            string sMONumber = "";
            string sItemNumber = "";

            //check if any data entered
            if (txtMONumber.Text == "")
            {
                //no MO Number - error
                sErrorMsg = "Please scan or enter your MO Number and MO Line Number.";
            }
            else
            {
                try
                {
                    //check what have been entered
                    sMONumber = txtMONumber.Text;
                    if (sMONumber.IndexOf("$") != -1)
                    {
                        //MO No has been scanned - $ char detected
                        txtMONumber.Text = sMONumber.Substring(0, sMONumber.IndexOf("$"));
                        lblMOLineNumberData.Text = sMONumber.Substring(sMONumber.IndexOf("$") + 1);
                    }
                    else
                    {
                        //No $ char - maybe someone entered it manually
                        txtMONumber.Text = sMONumber.Substring(0, sMONumber.Length - 3);
                        lblMOLineNumberData.Text = sMONumber.Substring(sMONumber.Length - 3);
                    }
                }
                catch
                {
                    sErrorMsg = "Wrong MO Number and MO Line Number. Please scan or enter it again.";
                }

                if (sErrorMsg == "")
                {
                    mMOCheckTableAdapter.FillBy(mMOCheckDataTable, txtMONumber.Text, lblMOLineNumberData.Text);

                    if (mMOCheckDataTable.Rows.Count > 0)
                    {
                        mMOCheckRow = (ShopfloorDataSet.MOCheckRow)mMOCheckDataTable.Rows[0];

                        lblItemNumberData.Text = mMOCheckRow.ItemNumber;
                        iMOLineKey = mMOCheckRow.MOLineKey;
                        lblQtyOnOrderData.Text = mMOCheckRow.ItemOrderedQuantity.ToString();
                        lblQtyReceivedData.Text = mMOCheckRow.ReceiptQuantity.ToString();
                        lblQtyOpenData.Text = mMOCheckRow.OpenQuantity.ToString();

                        sPreferredBin = mMOCheckRow.PreferredBin;
                        txtStockroom.Text = mMOCheckRow.PreferredStockroom;
                        sLotNumberMask = (string)query.GetLotNumberMask(mMOCheckRow.ItemNumber);

                        if (sLotNumberMask.StartsWith("X"))
                        {
                            lblLotNo.Visible = true;
                            txtLotNo.Visible = true;

                            if (sLotNumberMask.Length > sLotNumberMask.IndexOf("$") + 1)
                            {
                                txtLotNo.Text = sLotNumberMask.Substring(sLotNumberMask.IndexOf("$") + 1);
                            }
                        }
                     }
                    else
                    {
                        //no read - MO don't exist
                        sErrorMsg = "Please check MO order status. Order possibly already closed.";
                    }

                    //check operations before
                    sItemNumber = Convert.ToString(query.CheckOperationsBefore(iMOLineKey, 999));

                    if (sItemNumber != "")
                    {
                        //there are earlier lines whithout scan	
                        sErrorMsg = "No issued quantity for Component =" + sItemNumber;
                    }
                }
            }

            //check if any errors and display them if so
            if (sErrorMsg != "")
            {
                MessageBox.Show(this, sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblMOLineNumberData.Text = "";
                txtMONumber.Text = sMONumber;
                txtMONumber.Select();
                e.Cancel = true;
            }
        }

        //add enter handling to move to next field
        private void txtMONumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtStockroom.Focus();
            }
        }

        //check data entered if valid
        private void txtStockroom_Validating(object sender, CancelEventArgs e)
        {
            string sErrorMsg = "";

            if (txtStockroom.Text == "")
            {
                sErrorMsg = "Stockroom name cannot be empty";
            }
            else
            {
                try
                {
                    ShopfloorDataSetTableAdapters.InventoryLocationTableAdapter binAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.InventoryLocationTableAdapter();
                    ShopfloorDataSet.InventoryLocationDataTable binTable = binAdapter.GetData(txtStockroom.Text);

                    if (binTable.Rows.Count > 0)
                    {
                        ddlBin.DataSource = binTable;
                        ddlBin.DisplayMember = binTable.BinColumn.ToString();
                        ddlBin.ValueMember = binTable.BinColumn.ToString();

                        foreach (DataRow row in binTable.Rows)
                        {
                            if (row["Bin"].ToString().Trim() == sPreferredBin)
                            {
                                ddlBin.SelectedValue = sPreferredBin;
                                break;
                            }
                        }

                        txtQuantity.Focus();
                    }
                    else
                    {

                        ddlBin.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    sErrorMsg = ex.Message;
                }
            }

            //check if any errors and display them if so
            if (sErrorMsg != "")
            {
                MessageBox.Show(this, sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStockroom.Select(0, 2);
                e.Cancel = true;
            }
        }

        private void txtStockroom_TextChanged(object sender, EventArgs e)
        {
            ShopfloorDataSetTableAdapters.InventoryLocationTableAdapter binAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.InventoryLocationTableAdapter();
            ShopfloorDataSet.InventoryLocationDataTable binTable = binAdapter.GetData(txtStockroom.Text);

            if (binTable.Rows.Count > 0)
            {
                ddlBin.DataSource = binTable;
                ddlBin.DisplayMember = binTable.BinColumn.ToString();
                ddlBin.ValueMember = binTable.BinColumn.ToString();

                foreach (DataRow row in binTable.Rows)
                {
                    if (row["Bin"].ToString().Trim() == sPreferredBin)
                    {
                        ddlBin.SelectedValue = sPreferredBin;
                        break;
                    }
                }

                txtQuantity.Focus();
            }
            else
            {

                ddlBin.DataSource = null;
            }
        }

        //add enter handling to move to next field
        private void txtStockroom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ddlBin.Focus();
            }
        }

        //check quantity entered
        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            string sErrorMsg = "";
            decimal dGoodQty;

            if (DecimalParser(txtQuantity.Text) == true)
            {
                dGoodQty = Convert.ToDecimal(txtQuantity.Text);

                if (dGoodQty > Convert.ToDecimal(lblQtyOpenData.Text))
                {
                    if (MessageBox.Show(this, "Quantity is greater than Open quantity. \n" +
                        "Do you want to continue? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        txtQuantity.Select(0, 20);
                        e.Cancel = true;
                    }
                }
            }
            else if (txtQuantity.Text != "")
            {
                sErrorMsg = "Quantity needs to be numeric or empty to process only scrap!";
            }

            //check if any errors and display them if so
            if (sErrorMsg != "")
            {
                MessageBox.Show(this, sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Select(0, 20);
                e.Cancel = true;
            }
        }

        //add enter handling to move to next field
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.Focus();
            }
        }

        //clean all data
        private void CleanData()
        {
            lblQtyOpenData.Text = "";
            lblQtyOnOrderData.Text = "";
            lblQtyReceivedData.Text = "";
            lblMOLineNumberData.Text = "";
            lblItemNumberData.Text = "";
            lblUserName.Text = "";
            txtStockroom.Text = "";
            ddlBin.DataSource = null;
            lblLotNo.Visible = false;
            txtLotNo.Visible = false;
            txtLotNo.Text = "";
            txtUserID.Text = "";
            txtMONumber.Text = "";
            txtQuantity.Text = "";
            lblDepartment.Text = "";
            iMOLineKey = 0;
            
            txtScrapQuantity.Text = "";
            grScrap.Rows.Clear();

            txtUserID.Focus();
        }

        //start from top
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanData();
            txtUserID.Focus();
        }

        //move parts
        private void btnOK_Click(object sender, EventArgs e)
        {
            string sOKMsg = "";
            string sErrorMsg = "";
            string sLotPolicy;
            string sLine;
            string sByProductItem;

            decimal dScrapQty = 0;
            decimal dGoodQty = 0;
            decimal dTotalQty = 0;

            //Pre processing

            ShopfloorDataSetTableAdapters.QueriesTableAdapter query = new ShopfloorScanning.ShopfloorDataSetTableAdapters.QueriesTableAdapter();

            if (DecimalParser(txtQuantity.Text) == true)
            {
                if (txtStockroom.Text == "")
                {
                    sErrorMsg = "Stockroom name cannot be empty!";
                }
                else if (ddlBin.SelectedValue == "" || ddlBin.SelectedValue == null)
                {
                    sErrorMsg = "Bin name cannot be empty!";
                }
                else
                {
                    sInventoryCategory = query.GetInventoryCategory(txtStockroom.Text, ddlBin.SelectedValue.ToString());

                    if (sInventoryCategory == null)
                    {
                       sErrorMsg =  "Stockroom " + txtStockroom.Text + " and Bin " + ddlBin.SelectedValue.ToString() + " don't exist. Please correct";
                    }

                    if (sInventoryCategory == "A")
                        sInventoryCategory = "O";
                }
            }

            if (sLotNumberMask.StartsWith("X") && txtLotNo.Text == "")
            {
                sErrorMsg = "Lot number cannot be empty!";
            }

            //check if any errors and display them if so
            if (sErrorMsg != "")
            {
                MessageBox.Show(this, sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //FS processing

            FSTIConnect();

            MORV00 tMorv00;
            tMorv00 = new MORV00();

            MOMT07 tMomt07;
            tMomt07 = new MOMT07();

            string[] Temp;

            sLotPolicy = (string)query.GetLotPolicy(lblItemNumberData.Text);

            //By Product processing

            sByProductItem = (string)query.GetByProductItem(txtMONumber.Text, Convert.ToInt16(lblMOLineNumberData.Text));

            if (sByProductItem != null && sByProductItem.StartsWith("3"))
            {
                tMomt07.MONumber.Value = txtMONumber.Text;
                tMomt07.MOLineNumber.Value = lblMOLineNumberData.Text;
                tMomt07.MOLineType.Value = "B";
                tMomt07.ItemNumber.Value = sByProductItem.Substring(2);
                tMomt07.MOLineStatus.Value = "4";

                if (fstiClient.ProcessId(tMomt07, sFSUserID))
                {
                    //all ok
                    sOKMsg += "Order line type B for order " + txtMONumber.Text + " line " + lblMOLineNumberData.Text + " and item " + sByProductItem.Substring(2) + " has been released! \n";
                }
                else
                {
                    //check error
                    FSTIError iError = fstiClient.TransactionError;
                    sErrorMsg += "It is not possible to released B type order " + txtMONumber.Text + " line " + lblMOLineNumberData.Text + " and item " + sByProductItem.Substring(2) + " - " + iError.Description + "\n";
                }
            }

            //Scrap processing

            if (grScrap.Rows.Count > 0)
            {
                foreach (DataGridViewRow rowScrap in grScrap.Rows)
                {
                    tMorv00.MONumber.Value = txtMONumber.Text;
                    tMorv00.MOLineNumber.Value = lblMOLineNumberData.Text;
                    tMorv00.ReceivingType.Value = "R";
                    tMorv00.ReceiptQuantity.Value = rowScrap.Cells["ScrapQuantity"].Value.ToString().Replace(".", ",");
                    tMorv00.MoveQuantity1.Value = rowScrap.Cells["ScrapQuantity"].Value.ToString().Replace(".", ",");
                    tMorv00.Stockroom1.Value = "99";
                    tMorv00.Bin1.Value = rowScrap.Cells["Bin"].Value.ToString();
                    tMorv00.InventoryCategory1.Value = "H";
                    tMorv00.InspectionCode1.Value = "R";
                    tMorv00.MOLineType.Value = "M";
                    //tMorv00.CurrentPotencyPercent.Value = "100";
                    tMorv00.ItemNumber.Value = lblItemNumberData.Text;

                    if (sLotNumberMask.StartsWith("X"))
                    {
                        tMorv00.LotNumber.Value = txtLotNo.Text;
                        tMorv00.LotNumberDefault.Value = txtLotNo.Text;
                    }

                    tMorv00.IsNewLot.Value = "Y";
                    tMorv00.LotNumberAssignmentPolicy.Value = sLotPolicy;

                    if (fstiClient.ProcessId(tMorv00, sFSUserID))
                    {
                        //all ok
                        sOKMsg += "Scrap item " + lblItemNumberData.Text + " with qty " + rowScrap.Cells["ScrapQuantity"].Value.ToString() + " and reason " + rowScrap.Cells["Bin"].Value.ToString() + "\n";

                        dScrapQty += Convert.ToDecimal(rowScrap.Cells["ScrapQuantity"].Value);
                    }
                    else
                    {
                        //check error
                        FSTIError iError = fstiClient.TransactionError;
                        sErrorMsg += "It is not possible to scrap " + lblItemNumberData.Text + " and reason " + rowScrap.Cells["Bin"].Value.ToString() + " with quantity " + rowScrap.Cells["ScrapQuantity"].Value.ToString() + " - " + iError.Description + "\n";
                    }
                }
            }

            //MORV & Components processing

            if (DecimalParser(txtQuantity.Text) == true)
            {
                dGoodQty = Convert.ToDecimal(txtQuantity.Text);
                
                //MORV processing

                if (dGoodQty > 0)
                {
                    tMorv00.MONumber.Value = txtMONumber.Text;
                    tMorv00.MOLineNumber.Value = lblMOLineNumberData.Text;
                    tMorv00.ReceivingType.Value = "R"; //changed from E
                    tMorv00.ReceiptQuantity.Value = txtQuantity.Text;
                    tMorv00.MoveQuantity1.Value = txtQuantity.Text;
                    tMorv00.Stockroom1.Value = txtStockroom.Text;
                    tMorv00.Bin1.Value = ddlBin.SelectedValue.ToString();
                    tMorv00.InventoryCategory1.Value = sInventoryCategory;

                    switch (sInventoryCategory)
                    {
                        case "O": tMorv00.InspectionCode1.Value = "G";
                            break;
                        case "I": tMorv00.InspectionCode1.Value = "N";
                            break;
                        case "H": tMorv00.InspectionCode1.Value = "R";
                            break;
                        default: tMorv00.InspectionCode1.Value = "O";
                            break;
                    }

                    tMorv00.MOLineType.Value = "M";
                    //tMorv00.CurrentPotencyPercent.Value = "100";
                    tMorv00.ItemNumber.Value = lblItemNumberData.Text;

                    if (sLotNumberMask.StartsWith("X"))
                    {
                        tMorv00.LotNumber.Value = txtLotNo.Text;
                        tMorv00.LotNumberDefault.Value = txtLotNo.Text;
                    }

                    tMorv00.IsNewLot.Value = "Y";
                    tMorv00.LotNumberAssignmentPolicy.Value = sLotPolicy; //changed from A

                    if (fstiClient.ProcessId(tMorv00, sFSUserID))
                    {
                        //get lot number
                        Temp = fstiClient.CDFResponse.Split('\"');
                        sLotNumber = Temp[69];

                        sOKMsg += "MORV item " + lblItemNumberData.Text + " with lot number " + sLotNumber + " and qty " + dGoodQty.ToString() + "\n";
                    }
                    else
                    {
                        //check error
                        FSTIError iError = fstiClient.TransactionError;
                        sErrorMsg += "It is not possible to receive " + lblItemNumberData.Text + " into location " + txtStockroom.Text + " and bin " + ddlBin.SelectedValue.ToString() + " with quantity " + dGoodQty.ToString() + " - " + iError.Description + "\n";
                    }
                }
            }

            //Calculating total quantity 

            dTotalQty = dGoodQty + dScrapQty;

            //Components processing

            if (dTotalQty > 0)
            {
                ShopfloorDataSetTableAdapters.ComponentListTableAdapter ComponentListAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.ComponentListTableAdapter();
                ShopfloorDataSet.ComponentListDataTable ComponentListTable = new ShopfloorDataSet.ComponentListDataTable();

                ComponentListAdapter.Fill(ComponentListTable, txtMONumber.Text, Convert.ToInt16(lblMOLineNumberData.Text), dTotalQty);

                if (ComponentListTable.Rows.Count > 0)
                {
                    foreach (DataRow rowComponent in ComponentListTable.Rows)
                    {
                        //Runtime processing

                        if (rowComponent["ComponentType"].ToString() == "R")
                        {

                            sLine = "\"PICK04\",\"\",\"\",\"\",\"0\",\"\",\"M\",\"I\",\"" + txtMONumber.Text + "\",\"" + lblMOLineNumberData.Text + "\",\"\",\"" + rowComponent["ComponentType"].ToString() + "\",\"" + rowComponent["PointOfUseID"].ToString() + "\",\"" + rowComponent["OperationSequenceNumberString"].ToString() + "\",\"" + rowComponent["ComponentItemNumber"].ToString() + "\",\"\",\"\",\"\",\"\",\"\",\"\",\"" + rowComponent["RequiredQuantity"].ToString() + "\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"2\",\"\",\"I\",\"\"";

                            if (fstiClient.ProcessCDF(sLine, sFSUserID))
                            {
                                //all OK

                                sOKMsg += "PICK operation for PtUse " + rowComponent["PointOfUseID"].ToString() + ", Sequence " + rowComponent["OperationSequenceNumberString"].ToString() + ", Work Center " + rowComponent["ComponentItemNumber"].ToString() + " with quantity " + rowComponent["RequiredQuantity"].ToString() + " has been successfully completed.";
                            }
                            else
                            {
                                //check error
                                FSTIError iError = fstiClient.TransactionError;
                                sErrorMsg += "It is not possible to make pick for PtUse " + rowComponent["PointOfUseID"].ToString() + ", Sequence " + rowComponent["OperationSequenceNumberString"].ToString() + ", Work Center " + rowComponent["ComponentItemNumber"].ToString() + " with quantity " + rowComponent["RequiredQuantity"].ToString() + " - " + iError.Description + "\n";
                            }
                        }

                        //By Product processing

                        else if (rowComponent["ComponentType"].ToString() == "B")
                        {
                            frmMORVByProduct dlgByProduct = new frmMORVByProduct();

                            dlgByProduct.sBPItemNumber = rowComponent["ComponentItemNumber"].ToString();
                            dlgByProduct.sBPQuantity = rowComponent["RequiredQuantity"].ToString();

                            if (dlgByProduct.ShowDialog(this) == DialogResult.OK)
                            {
                                tMorv00.MONumber.Value = txtMONumber.Text;
                                tMorv00.MOLineNumber.Value = lblMOLineNumberData.Text;
                                tMorv00.ReceivingType.Value = "R"; //changed from E
                                tMorv00.ReceiptQuantity.Value = dlgByProduct.sBPQuantity;
                                tMorv00.MoveQuantity1.Value = dlgByProduct.sBPQuantity;
                                tMorv00.Stockroom1.Value = dlgByProduct.sBPStockroom;
                                tMorv00.Bin1.Value = dlgByProduct.sBPBin;
                                tMorv00.InventoryCategory1.Value = sInventoryCategory;

                                switch (sInventoryCategory)
                                {
                                    case "O": tMorv00.InspectionCode1.Value = "G";
                                        break;
                                    case "I": tMorv00.InspectionCode1.Value = "N";
                                        break;
                                    case "H": tMorv00.InspectionCode1.Value = "R";
                                        break;
                                    default: tMorv00.InspectionCode1.Value = "O";
                                        break;
                                }

                                tMorv00.MOLineType.Value = "B";
                                //tMorv00.CurrentPotencyPercent.Value = "100";
                                tMorv00.ItemNumber.Value = rowComponent["ComponentItemNumber"].ToString();

                                if (dlgByProduct.sBPLotNumber != null)
                                {
                                    tMorv00.LotNumber.Value = dlgByProduct.sBPLotNumber;
                                    tMorv00.LotNumberDefault.Value = dlgByProduct.sBPLotNumber;
                                }

                                tMorv00.IsNewLot.Value = "Y";
                                tMorv00.LotNumberAssignmentPolicy.Value = sLotPolicy;

                                if (fstiClient.ProcessId(tMorv00, sFSUserID))
                                {
                                    //get lot number
                                    Temp = fstiClient.CDFResponse.Split('\"');
                                    sLotNumber = Temp[69];

                                    sOKMsg += "MORV by product item " + rowComponent["ComponentItemNumber"].ToString() + " with lot number " + sLotNumber + " and qty " + dlgByProduct.sBPQuantity + "\n";
                                }
                                else
                                {
                                    //check error
                                    FSTIError iError = fstiClient.TransactionError;
                                    sErrorMsg += "It is not possible to receive by product " + rowComponent["ComponentItemNumber"].ToString() + " into location " + dlgByProduct.sBPStockroom + " and bin " + dlgByProduct.sBPBin + " with quantity " + dlgByProduct.sBPQuantity + " - " + iError.Description + "\n";
                                }
                            }
                        }
                    }
                }

                //Close lines
                if (MessageBox.Show(this, "Do You want to close order " + txtMONumber.Text + " line " + lblMOLineNumberData.Text + " ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Close by product line

                    if (sByProductItem != null)
                    {
                        tMomt07.MONumber.Value = txtMONumber.Text;
                        tMomt07.MOLineNumber.Value = lblMOLineNumberData.Text;
                        tMomt07.MOLineType.Value = "B";
                        tMomt07.ItemNumber.Value = sByProductItem.Substring(2);
                        tMomt07.MOLineStatus.Value = "5";

                        if (fstiClient.ProcessId(tMomt07, sFSUserID))
                        {
                            //all ok
                            sOKMsg += "Order line type B for order " + txtMONumber.Text + " line " + lblMOLineNumberData.Text + " and item " + sByProductItem.Substring(2) + " has been closed! \n";
                        }
                        else
                        {
                            //check error
                            FSTIError iError = fstiClient.TransactionError;
                            sErrorMsg += "It is not possible to close B type order " + txtMONumber.Text + " line " + lblMOLineNumberData.Text + " and item " + sByProductItem.Substring(2) + " - " + iError.Description + "\n";
                        }
                    }

                    //Close m type line

                    tMomt07.MONumber.Value = txtMONumber.Text;
                    tMomt07.MOLineNumber.Value = lblMOLineNumberData.Text;
                    tMomt07.MOLineType.Value = "M";
                    tMomt07.ItemNumber.Value = lblItemNumberData.Text;
                    tMomt07.MOLineStatus.Value = "5";

                    if (fstiClient.ProcessId(tMomt07, sFSUserID))
                    {
                        //all ok
                        sOKMsg += "Order line type M for order " + txtMONumber.Text + " line " + lblMOLineNumberData.Text + " has been closed! \n";
                    }
                    else
                    {
                        //check error
                        FSTIError iError = fstiClient.TransactionError;
                        sErrorMsg += "It is not possible to close M type order " + txtMONumber.Text + " line " + lblMOLineNumberData.Text + " - " + iError.Description + "\n";
                    }
                }
            }

            // Final messages

            if (sErrorMsg != "")
            {
                if (sOKMsg != "")
                {
                    MessageBox.Show(this, "Process has been finished with following issues:\n" + sErrorMsg + "\n" + "but following part has been successful:\n" + sOKMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(this, "Process has been finished with following issues:\n" + sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "Process has been successfully completed!\n" + sOKMsg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Cleaning form
            CleanData();
            FSTIClose();
        }

        //direct print
        private void DirectlyPrint(short iCopyNo)
        {
            DirectPrint mDirectPrint = new DirectPrint();

            mDirectPrint.ServerURL = new Uri("http://tssstrfsh001/reportserver");
            mDirectPrint.ReportPath = "/Bridgwater Reports/Shopfloor/" + ConfigurationSettings.AppSettings["MORVLabel"].ToString();

            // Create the sales order number report parameter
            //for service print version
            ReportRS.ParameterValue[] param = new ShopfloorScanning.ReportRS.ParameterValue[5];

            param[0] = new ShopfloorScanning.ReportRS.ParameterValue();
            param[0].Name = "ItemNumber";
            param[0].Value = lblItemNumberData.Text;
            param[1] = new ShopfloorScanning.ReportRS.ParameterValue();
            param[1].Name = "Quantity";
            param[1].Value = txtQuantity.Text;
            param[2] = new ShopfloorScanning.ReportRS.ParameterValue();
            param[2].Name = "Stockroom";
            param[2].Value = txtStockroom.Text;
            param[3] = new ShopfloorScanning.ReportRS.ParameterValue();
            param[3].Name = "Bin";
            param[3].Value = ddlBin.SelectedValue.ToString();
            param[4] = new ShopfloorScanning.ReportRS.ParameterValue();
            param[4].Name = "LotNumber";
            param[4].Value = sLotNumber;

            mDirectPrint.ParameterValue = param;
            mDirectPrint.NumberOfCopies = (short) iCopyNo;

            mDirectPrint.PrinterName = ConfigurationSettings.AppSettings["PrinterName"];

            mDirectPrint.PrintReportViaService();
        }

        //Scrap transaction

        //Add scrap reason
        private void btnAddScrap_Click(object sender, EventArgs e)
        {
            if (DecimalParser(txtScrapQuantity.Text) == false)
            {
                MessageBox.Show(this, "Scrap quantity has to be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtScrapQuantity.Focus();
            }
            else if (ddlScrapReason.SelectedValue == null)
            {
                MessageBox.Show(this, "Scrap reason can not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtScrapQuantity.Focus();
            }
            else
            {
                grScrap.Rows.Add();

                int iScrapRowIndex = grScrap.RowCount - 1;
                DataGridViewRow rowScrap = grScrap.Rows[iScrapRowIndex];

                rowScrap.Cells["Line"].Value = grScrap.RowCount;
                rowScrap.Cells["Bin"].Value = ddlScrapReason.SelectedValue;
                rowScrap.Cells["ScrapReason"].Value = ddlScrapReason.Text;
                rowScrap.Cells["ScrapQuantity"].Value = txtScrapQuantity.Text;
            }
        }

        //Process scrap grid
        private void grScrap_CurrentCellChanged(object sender, EventArgs e)
        {
            if (grScrap.CurrentCell != null)
            {
                btnDeleteRow.Enabled = true;
                iScrapRowIndex = Convert.ToInt16(grScrap.CurrentRow.Index);
            }
        }

        //Delete scrap line
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (grScrap.RowCount > 0 & iScrapRowIndex != null)
            {
                DataGridViewRow rowScrap = grScrap.Rows[iScrapRowIndex];

                grScrap.Rows.Remove(grScrap.Rows[iScrapRowIndex]);
            }
        }

        private void txtLotNo_Validating(object sender, CancelEventArgs e)
        {
            if (sLotNumberMask.StartsWith("X") && txtLotNo.Text == "")
            {
                MessageBox.Show(this, "Lot number can not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLotNo.Select(0, 20);
                e.Cancel = true;

            }
        }
    }
}