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
    public partial class frmPICK : Form
    {
        private FSTIClient fstiClient;
        private string sFSUserID;
        private int iMOLineKey;
        private int iComponentItemKey;
        private string sComponentType;
        private string sStock;
        private string sBin;
        private string sLotNumber;
        private decimal dStockQuantity;
        private decimal dQuantity;
        private bool bCanOverPick;

        public frmPICK()
        {
            InitializeComponent();
        }

        //starting options
        private void frmPICK_Load(object sender, EventArgs e)
        {
            CleanData();
            this.Text = Application.ProductName + " - PICK materials";
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
                MessageBox.Show(this, "Cannot connect to FSTI. Please, check settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void frmPICK_FormClosing(object sender, FormClosingEventArgs e)
        {
            FSTIClose();
        }

        //check userID if it exists
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
                    bCanOverPick = mUsersRow.CanOverPICK;
                    
                    //security check
                    if (Convert.ToBoolean(mUsersRow["CanPICK"]) == false)
                    {
                        sErrorMsg = "This UserID is not allowed to do PICK operation. Please scan or enter valid UserID.";
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

        //clean all data
        private void CleanData()
        {
            lblUserName.Text = "";
            lblWorkcenterData.Text = "";
            lblQtyRequiredData.Text = "";
            lblQtyRemainingData.Text = "";
            lblQtyIssuedData.Text = "";
            lblPtUseData.Text = "";
            lblMOLineNumberData.Text = "";
            lblItemNumberData.Text = "";
            txtMONumber.Text = "";
            txtSequenceNumber.Text = "";
            txtUserID.Text = "";
            txtQuantity.Text = "";
            sFSUserID = "";
            iMOLineKey = 0;
            iComponentItemKey = 0;
            sComponentType = "";
            dQuantity = 0;
            sStock = "";
            sBin = "";
            sLotNumber = "";
            dStockQuantity = 0;
            lblDepartment.Text = "";
            ClearStockList();
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

            string sErrorMsg = "";
            string sMONumber = "";

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
                    }
                    else
                    {
                        //no read - MO don't exist
                        sErrorMsg = "Please check MO order status. Order possibly already closed.";
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
                txtSequenceNumber.Focus();
            }
        }

        //add enter handling to move to next field
        private void txtSequenceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grStock.Focus();
            }
        }

        //check Sequence number data
        private void txtSequenceNumber_Validating(object sender, CancelEventArgs e)
        {
            ShopfloorDataSetTableAdapters.WorkcenterCheckTableAdapter mWorkcenterCheck = new ShopfloorScanning.ShopfloorDataSetTableAdapters.WorkcenterCheckTableAdapter();
            ShopfloorDataSet.WorkcenterCheckDataTable mWorkcenterCheckDataTable = new ShopfloorDataSet.WorkcenterCheckDataTable();
            ShopfloorDataSet.WorkcenterCheckRow mWorkcenterCheckRow;

            ShopfloorDataSetTableAdapters.QueriesTableAdapter mQueriesTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.QueriesTableAdapter();

            string sErrorMsg = "";
            string sSeqNo = "";
            double dRemQty;
            string sItemNumber = "";

            //check if any data entered
            if (txtSequenceNumber.Text == "")
            {
                //no sequence barcode - error
                sErrorMsg = "Please scan or enter your Sequence barcode.";
            }
            else
            {
                try
                {
                    //check what have been entered - barcode
                    sSeqNo = txtSequenceNumber.Text;
                    
                    if (sSeqNo.IndexOf("$") != -1)
                    {
                        lblPtUseData.Text = sSeqNo.Substring(0, sSeqNo.IndexOf("$"));
                        txtSequenceNumber.Text = sSeqNo.Substring(sSeqNo.IndexOf("$") + 1, 3);
                        lblWorkcenterData.Text = sSeqNo.Substring(sSeqNo.LastIndexOf("$") + 1);

                        if (lblWorkcenterData.Text.Substring(0, 2) == "WC" || lblWorkcenterData.Text.Substring(0, 2) == "CM" || lblWorkcenterData.Text.Substring(0, 2) == "SM")
                        {
                            //Workcenter barcode scanned - $ char detected
                            sSeqNo = sSeqNo.Replace("/", "[");
                            sSeqNo = sSeqNo.Replace("%", "]");
                        }

                        //Sintering process
                        if (txtSequenceNumber.Text == "522")
                        {
                            MessageBox.Show(this, "SINTERING process will be automatically added with quantity updated from MOULDING process.", "Sintering Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        sErrorMsg = "Wrong data entered! Please scan or enter your Workcenter barcode again.";
                    }
                }
                catch
                {
                    sErrorMsg = "Wrong data entered! Please scan or enter your Workcenter barcode again.";
                }

                //check if user can do it

                if (sErrorMsg == "")
                {
                    mWorkcenterCheck.FillBy(mWorkcenterCheckDataTable, iMOLineKey, txtSequenceNumber.Text, lblPtUseData.Text, lblWorkcenterData.Text);

                    if (mWorkcenterCheckDataTable.Rows.Count > 0)
                    {
                        mWorkcenterCheckRow = (ShopfloorDataSet.WorkcenterCheckRow)mWorkcenterCheckDataTable.Rows[0];
                        
                        lblQtyRequiredData.Text = mWorkcenterCheckRow.RequiredQuantity.ToString();
                        lblQtyIssuedData.Text = mWorkcenterCheckRow.IssuedQuantity.ToString();
                        dRemQty = mWorkcenterCheckRow.RequiredQuantity - mWorkcenterCheckRow.IssuedQuantity;
                        
                        if (dRemQty < 0)
                        {
                            dRemQty = 0;
                        }

                        lblQtyRemainingData.Text = dRemQty.ToString();
                        sComponentType = mWorkcenterCheckRow.ComponentType;
                        iComponentItemKey = mWorkcenterCheckRow.ItemKey;

                        ClearStockList();
                        GetStockList();
                    }
                    else
                    {
                        //no read - workcenter / sequence don't exist
                        sErrorMsg = "Workcenter don't exist for selected MO. Please scan or enter Workcenter barcode again.";
                    } 

                    //check operations before
                    sItemNumber = Convert.ToString(mQueriesTableAdapter.CheckOperationsBefore(iMOLineKey, Convert.ToInt16(txtSequenceNumber.Text)));

                    if (sItemNumber != "")
                    {
                        //there are earlier lines whithout scan	
                        sErrorMsg = "No issued quantity for Component " + sItemNumber;
                    }
                }
            }

            //check if any errors and display them if so
            if (sErrorMsg != "")
            {
                MessageBox.Show(this, sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSequenceNumber.Text = sSeqNo;
                lblWorkcenterData.Text = "";
                lblPtUseData.Text = "";

                //ClearStockList();
                txtSequenceNumber.Select(0, 50);
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

        //start from begining
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanData();
            txtUserID.Focus();
        }

        //gets data that will be displayed as stock levels
        private void GetStockList()
        {
            this.stockListTableAdapter.FillBy(this.shopfloorDataSet.StockList, iComponentItemKey);
        }

        //clear list of stock
        private void ClearStockList()
        {
            shopfloorDataSet.StockList.Clear();
        }

        //selection done on stock
        private void grStock_CurrentCellChanged(object sender, EventArgs e)
        {
            if (grStock.CurrentCell != null)
            {
                sStock = grStock.CurrentRow.Cells["StockStockroom"].Value.ToString();
                sBin = grStock.CurrentRow.Cells["StockBin"].Value.ToString();
                dStockQuantity = Convert.ToDecimal(grStock.CurrentRow.Cells["StockQuantity"].Value.ToString());
                sLotNumber = grStock.CurrentRow.Cells["StockLotNumber"].Value.ToString();
            }
        }

        //move to quantity fields
        private void grStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtQuantity.Focus();
            }
        }

        //check entered quantity
        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            string sErrorMsg = "";

            if (txtQuantity.Text != "")
            {
                try
                {

                    dQuantity = Convert.ToDecimal(txtQuantity.Text);

                    txtQuantity.Text = dQuantity.ToString();

                    if ((dQuantity > dStockQuantity) & (sComponentType != "R"))
                    {
                        sErrorMsg = "Quantity has to be lower than available quantity in stock";
                    }

                    if (dQuantity <= 0)
                    {
                        sErrorMsg = "Quantity has to be higher that 0.";
                    }

                    if (Convert.ToDecimal(lblQtyRemainingData.Text) > 2)
                    {
                        if (dQuantity > Convert.ToDecimal(1.1) * Convert.ToDecimal(lblQtyRemainingData.Text))
                        {
                            if (bCanOverPick == true)
                            {
                                if (MessageBox.Show(this, "Quantity is greater than Remaining Quantity by more than 10%. \n" +
                                    "Do you want to continue? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    txtQuantity.Select(0, 20);
                                    e.Cancel = true;
                                }
                            }
                            else
                            {
                                frmPICKAcceptance dlgPICKAcceptance = new frmPICKAcceptance();

                                if (dlgPICKAcceptance.ShowDialog(this) == DialogResult.Cancel)
                                {
                                    txtQuantity.Select(0, 20);
                                    e.Cancel = true;
                                }

                                dlgPICKAcceptance.Dispose();
                            }
                        }
                    }
                    else
                    {
                        if (dQuantity > Convert.ToDecimal(2) * Convert.ToDecimal(lblQtyRemainingData.Text))
                        {
                            if (bCanOverPick == true)
                            {
                                if (MessageBox.Show(this, "Quantity is greater than Remaining Quantity by more than 100%. \n" +
                                    "Do you want to continue? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    txtQuantity.Select(0, 20);
                                    e.Cancel = true;
                                }
                            }
                            else
                            {
                                frmPICKAcceptance dlgPICKAcceptance = new frmPICKAcceptance();

                                if (dlgPICKAcceptance.ShowDialog(this) == DialogResult.Cancel)
                                {
                                    txtQuantity.Select(0, 20);
                                    e.Cancel = true;
                                }

                                dlgPICKAcceptance.Dispose();
                            }
                        }

                    }
                }
                catch
                {
                    sErrorMsg = "Quantity needs to be numeric!";
                }
            }

            //check if any errors and display them if so
            if (sErrorMsg != "")
            {
                MessageBox.Show(this, sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Select(0, 20);
                e.Cancel = true;
            }
        }

        //handle all picks that need to be done
        private void btnOK_Click(object sender, EventArgs e)
        {
            
            string sLine;

            if (txtQuantity.Text == "")
            {
                MessageBox.Show(this, "Please, enter quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return;
            }

            btnOK.Enabled = false;

            FSTIConnect();

            if (sComponentType == "R")
            {
                sLine = "\"PICK04\",\"\",\"\",\"\",\"0\",\"\",\"M\",\"I\",\"" + txtMONumber.Text + "\",\"" + lblMOLineNumberData.Text + "\",\"\",\"" + sComponentType + "\",\"" + lblPtUseData.Text + "\",\"" + txtSequenceNumber.Text + "\",\"" + lblWorkcenterData.Text + "\",\"\",\"" + sStock + "\",\"" + sBin + "\",\"\",\"" + sLotNumber + "\",\"\",\"" + dQuantity.ToString() + "\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"2\",\"\",\"I\",\"\"";
            }
            else
            {
                sLine = "\"PICK08\",\"\",\"\",\"\",\"0\",\"\",\"M\",\"I\",\"" + txtMONumber.Text + "\",\"" + lblMOLineNumberData.Text + "\",\"\",\"" + sComponentType + "\",\"" + lblPtUseData.Text + "\",\"" + txtSequenceNumber.Text + "\",\"" + lblWorkcenterData.Text + "\",\"\",\"" + sStock + "\",\"" + sBin + "\",\"\",\"" + sLotNumber + "\",\"\",\"" + dQuantity.ToString() + "\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"2\",\"\",\"I\",\"\"";
            }

            if (fstiClient.ProcessCDF(sLine, sFSUserID))
            {
                //all OK
                if (sComponentType == "R")
                {
                    MessageBox.Show(this, "PICK operation for PtUse " + lblPtUseData.Text + ", Sequence " + txtSequenceNumber.Text + ", Work Center " + lblWorkcenterData.Text + " with quantity " + dQuantity.ToString() + " has been successfully completed.  ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanData();
                    txtUserID.Focus();
                }
                else if (sComponentType == "N")
                {
                    if (MessageBox.Show(this, "PICK operation for Component " + lblWorkcenterData.Text + ", stock " + sStock + ", bin " + sBin + ", lot number " + sLotNumber + " with quantity " + dQuantity.ToString() + " has been successfully completed. PICK different lot for same Component?  ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        UpdatePickTable();
                        ClearStockList();
                        GetStockList();
                        txtQuantity.Text = "";
                        grStock.Focus();
                    }
                    else
                    {
                        UpdatePickTable();
                        CleanData();
                        txtUserID.Focus();
                    }
                }  
            }
            else
            {
                //check error
                FSTIError iError = fstiClient.TransactionError;
                MessageBox.Show(this, "Cannot make pick for this workcenter.\n" + iError.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnOK.Enabled = true;
            FSTIClose();
        }

        //saves data about PICK of Sintering process
        private void UpdatePickTable()
        {
            ShopfloorDataSetTableAdapters.ShopfloorPicksTableAdapter PicksTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.ShopfloorPicksTableAdapter();
            ShopfloorDataSet.ShopfloorPicksDataTable PicksDataTable = new ShopfloorDataSet.ShopfloorPicksDataTable();
            ShopfloorDataSet.ShopfloorPicksRow PicksRow;

            PicksRow = PicksDataTable.NewShopfloorPicksRow();

            PicksRow.BeginEdit();
            PicksRow.MONumber = txtMONumber.Text;
            PicksRow.MOLineNumber = lblMOLineNumberData.Text;
            PicksRow.ItemNumber = lblItemNumberData.Text;
            PicksRow.SequenceNumber = txtSequenceNumber.Text;
            PicksRow.ComponentItemNumber = lblWorkcenterData.Text;
            PicksRow.Quantity = Convert.ToDecimal(txtQuantity.Text);
            PicksRow.PTUse = lblPtUseData.Text;
            PicksRow.ComponentType = sComponentType;
            PicksRow.Stockroom = sStock;
            PicksRow.Bin = sBin;
            PicksRow.LotNumber = sLotNumber;
            PicksRow.EndEdit();

            PicksDataTable.Rows.Add(PicksRow);

            PicksTableAdapter.Update(PicksDataTable);    

        }

        //direct print
        private void DirectlyPrint(short iCopyNo)
        {
            DirectPrint mDirectPrint = new DirectPrint();
            
            mDirectPrint.ServerURL = new Uri("http://tssbrserp103/reportserver");
            mDirectPrint.ReportPath = "/Bridgwater Reports/Shopfloor/" + ConfigurationSettings.AppSettings["PICKLabel"].ToString();

            // Create the sales order number report parameter
            //ReportParameter[] reportParams = new ReportParameter[3];

            //reportParams[0] = new ReportParameter("MONumber", txtMONumber.Text);
            //reportParams[1] = new ReportParameter("ItemNumber", lblWorkcenterData.Text);
            //reportParams[2] = new ReportParameter("LotNumber", sLotNumber);

            //for service print version
            ReportRS.ParameterValue[] param = new ShopfloorScanning.ReportRS.ParameterValue[5];

            param[0] = new ShopfloorScanning.ReportRS.ParameterValue();
            param[0].Name = "MONumber";
            param[0].Value = txtMONumber.Text;
            param[1] = new ShopfloorScanning.ReportRS.ParameterValue();
            param[1].Name = "ItemNumber";
            param[1].Value = lblWorkcenterData.Text;
            param[2] = new ShopfloorScanning.ReportRS.ParameterValue();
            param[2].Name = "LotNumber";
            param[2].Value = sLotNumber;
            param[3] = new ShopfloorScanning.ReportRS.ParameterValue();
            param[3].Name = "Stockroom";
            param[3].Value = sStock;
            param[4] = new ShopfloorScanning.ReportRS.ParameterValue();
            param[4].Name = "Bin";
            param[4].Value = sBin;

            mDirectPrint.ParameterValue = param;

            mDirectPrint.PrinterName = ConfigurationSettings.AppSettings["PrinterName"];
            mDirectPrint.NumberOfCopies = iCopyNo;

            mDirectPrint.PrintReportViaService();
        }
    }
}