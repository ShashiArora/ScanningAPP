using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using SoftBrands.FourthShift.Transaction;
using Microsoft.Reporting.WinForms;

namespace ShopfloorScanning
{
    public partial class frmStartJob : Form
    {
        private FSTIClient fstiClient;
        private string sFSUserID;
        private int iMOLineKey;
        private bool? bIsCoolantRequired = false;

        public frmStartJob()
        {
            InitializeComponent();
        }

        //starting options
        private void frmStartJob_Load(object sender, EventArgs e)
        {
            CleanData();
            this.Text = Application.ProductName + " - Scan Start of Job";
            FSTIConnect();
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
            catch (Exception ex)
            {
                MessageBox.Show(this, "Cannot connect to FSTI. Please, check settings. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void frmStartJob_FormClosing(object sender, FormClosingEventArgs e)
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
                    
                    //security check
                    if (Convert.ToBoolean(mUsersRow["CanPICK"]) == false)
                    {
                        sErrorMsg = "This UserID is not allowed to do Start Job operation. Please scan or enter valid UserID.";
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
            lblRuntimeRequiredData.Text = "";
            lblRuntimeRemainingData.Text = "";
            lblRuntimeIssuedData.Text = "";
            lblQtyRequiredData.Text = "";
            lblQtyRemainingData.Text = "";
            lblQtyIssuedData.Text = "";
            lblPtUseData.Text = "";
            lblMOLineNumberData.Text = "";
            lblItemNumberData.Text = "";
            txtMONumber.Text = "";
            txtSequenceNumber.Text = "";
            txtUserID.Text = "";
            sFSUserID = "";
            lblDepartment.Text = "";
            lblMachineIDDesc.Text = "";
            txtMachineID.Text = "";
        }

        //add enter handling to move to next field
        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMachineID.Focus();
            }	
        }

        //move to next field with enter
        private void txtMachineID_Validating(object sender, CancelEventArgs e)
        {
            string sErrorMsg = "";
            string sMachineDesc;

            ShopfloorDataSetTableAdapters.QueriesTableAdapter queryTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.QueriesTableAdapter();
            
            //check if any data entered
            if (txtUserID.Text == "")
            {
                //no userID - error
                sErrorMsg = "Please scan or enter your UserID.";
            }
            else
            {
                sMachineDesc = queryTableAdapter.GetMachineDesc(txtMachineID.Text);

                if (sMachineDesc == null)
                {
                    sErrorMsg = "This Machine doesn't exist. Please scan or enter it again.";
                }
                else
                {
                    lblMachineIDDesc.Text = sMachineDesc;
                    bIsCoolantRequired = queryTableAdapter.IsCoolantRequired(txtMachineID.Text);
                }
            }

            //check if any errors and display them if so
            if (sErrorMsg != "")
            {
                MessageBox.Show(this, sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMachineID.Select(0, 10);
                e.Cancel = true;
            }
        }

        //chekc machine ID
        private void txtMachineID_KeyDown(object sender, KeyEventArgs e)
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
                        lblQtyRequiredData.Text = mMOCheckRow.ItemOrderedQuantity.ToString();
                        lblQtyIssuedData.Text = mMOCheckRow.ReceiptQuantity.ToString();
                        lblQtyRemainingData.Text = mMOCheckRow.OpenQuantity.ToString();
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
                btnOK.Focus();
            }
        }

        //check Sequence number data
        private void txtSequenceNumber_Validating(object sender, CancelEventArgs e)
        {
            ShopfloorDataSetTableAdapters.WorkcenterCheckTableAdapter mWorkcenterCheck = new ShopfloorScanning.ShopfloorDataSetTableAdapters.WorkcenterCheckTableAdapter();
            ShopfloorDataSet.WorkcenterCheckDataTable mWorkcenterCheckDataTable = new ShopfloorDataSet.WorkcenterCheckDataTable();
            ShopfloorDataSet.WorkcenterCheckRow mWorkcenterCheckRow;

            ShopfloorDataSetTableAdapters.QueriesTableAdapter queryTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.QueriesTableAdapter();

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
                        //Workcenter barcode scanned - $ char detected
                        sSeqNo = sSeqNo.Replace("/", "[");
                        sSeqNo = sSeqNo.Replace("%", "]");

                        lblPtUseData.Text = sSeqNo.Substring(0, sSeqNo.IndexOf("$"));
                        txtSequenceNumber.Text = sSeqNo.Substring(sSeqNo.IndexOf("$") + 1, 3);
                        lblWorkcenterData.Text = sSeqNo.Substring(sSeqNo.LastIndexOf("$") + 1);
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
                        
                        lblRuntimeRequiredData.Text = (mWorkcenterCheckRow.RequiredQuantity * 60).ToString();
                        lblRuntimeIssuedData.Text = (mWorkcenterCheckRow.IssuedQuantity * 60).ToString();
                        dRemQty = mWorkcenterCheckRow.RequiredQuantity - mWorkcenterCheckRow.IssuedQuantity;
                        
                        if (dRemQty < 0)
                        {
                            dRemQty = 0;
                        }

                        lblRuntimeRemainingData.Text = (dRemQty * 60).ToString();
                    }
                    else
                    {
                        //no read - workcenter / sequence don't exist
                        sErrorMsg = "Workcenter don't exist for selected MO. Please scan or enter Workcenter barcode again.";
                    } 
                }

                //check operations before
                sItemNumber = Convert.ToString(queryTableAdapter.CheckOperationsBefore(iMOLineKey, Convert.ToInt16(txtSequenceNumber.Text)));

                if (sItemNumber != "")
                {
                    //there are earlier lines whithout scan	
                    sErrorMsg = "No issued quantity for Component " + sItemNumber;
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

        //start from begining
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanData();
            txtUserID.Focus();
        }

        //handle all picks that need to be done
        private void btnOK_Click(object sender, EventArgs e)
        {
            MOMT04 tMOMT04 = new MOMT04();

            tMOMT04.MONumber.Value = txtMONumber.Text;
            tMOMT04.WorkCenter.Value = txtMachineID.Text;

            if (fstiClient.ProcessId(tMOMT04, sFSUserID))
            {
                UpdateStartJobTable();
                CleanData();
                txtUserID.Focus();
            }
            else
            {
                //check error
                FSTIError iError = fstiClient.TransactionError;
                MessageBox.Show(this, "Cannot make pick for this workcenter.\n" + iError.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //saves data about PICK of N type component
        private void UpdateStartJobTable()
        {
            ShopfloorDataSetTableAdapters.ShopfloorJobStartTableAdapter StartJobTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.ShopfloorJobStartTableAdapter();
            ShopfloorDataSet.ShopfloorJobStartDataTable StartJobDataTable = new ShopfloorDataSet.ShopfloorJobStartDataTable();
            ShopfloorDataSet.ShopfloorJobStartRow StartJobRow;
            ShopfloorDataSetTableAdapters.QueriesTableAdapter queryTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.QueriesTableAdapter();
            int? iKey;

            iKey = Convert.ToInt32(queryTableAdapter.CheckIfJobStarted(txtMONumber.Text, lblMOLineNumberData.Text, lblPtUseData.Text, txtSequenceNumber.Text, lblWorkcenterData.Text));

            if (iKey == 0)
            {
                StartJobRow = StartJobDataTable.NewShopfloorJobStartRow();

                StartJobRow.BeginEdit();
                StartJobRow.TransactionDate = DateTime.Now;
                StartJobRow.UserID = sFSUserID;
                StartJobRow.Workcenter = lblWorkcenterData.Text;
                StartJobRow.MONumber = txtMONumber.Text;
                StartJobRow.MOLineNumber = lblMOLineNumberData.Text;
                StartJobRow.Machine = txtMachineID.Text;
                StartJobRow.PTUse = lblPtUseData.Text;
                StartJobRow.Sequence = txtSequenceNumber.Text;
                StartJobRow.EndEdit();

                StartJobDataTable.Rows.Add(StartJobRow);

                StartJobTableAdapter.Update(StartJobDataTable);
            }
            else 
            {
                if (lblWorkcenterData.Text == "SM[T]" || lblWorkcenterData.Text == "CM[T]")
                {
                    if (MessageBox.Show(this, "Moulding process for selected MO, workcenter and machine has been already started.\nDo You want to start Sintering process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        UpdateStartExtraJobTable();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Job for selected MO, workcenter and machine has been already started", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void UpdateStartExtraJobTable()
        {
            ShopfloorDataSetTableAdapters.ShopfloorExtraJobStartTableAdapter StartExtraJobTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.ShopfloorExtraJobStartTableAdapter();
            ShopfloorDataSet.ShopfloorExtraJobStartDataTable StartExtraJobDataTable = new ShopfloorDataSet.ShopfloorExtraJobStartDataTable();
            ShopfloorDataSet.ShopfloorExtraJobStartRow StartExtraJobRow;
            ShopfloorDataSetTableAdapters.QueriesTableAdapter queryTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.QueriesTableAdapter();

            //int? iKey;
            int? iJob;

            //iKey = Convert.ToInt32(queryTableAdapter.CheckIfExtraJobStarted(txtMONumber.Text, lblMOLineNumberData.Text, lblPtUseData.Text, txtSequenceNumber.Text, lblWorkcenterData.Text));
            iJob = (int)queryTableAdapter.GetExtraJobIteration(txtMONumber.Text, lblMOLineNumberData.Text, lblPtUseData.Text, txtSequenceNumber.Text, lblWorkcenterData.Text);

            if ( iJob == 0 )
            {
                    StartExtraJobRow = StartExtraJobDataTable.NewShopfloorExtraJobStartRow();

                    StartExtraJobRow.BeginEdit();
                    StartExtraJobRow.TransactionDate = DateTime.Now;
                    StartExtraJobRow.UserID = sFSUserID;
                    StartExtraJobRow.Workcenter = lblWorkcenterData.Text;
                    StartExtraJobRow.MONumber = txtMONumber.Text;
                    StartExtraJobRow.MOLineNumber = lblMOLineNumberData.Text;
                    StartExtraJobRow.Machine = txtMachineID.Text;
                    StartExtraJobRow.PTUse = lblPtUseData.Text;
                    StartExtraJobRow.Sequence = txtSequenceNumber.Text;
                    StartExtraJobRow.JobIteration = 1;
                    StartExtraJobRow.JobDesc = "SINTERING";
                    StartExtraJobRow.EndEdit();

                    StartExtraJobDataTable.Rows.Add(StartExtraJobRow);

                    StartExtraJobTableAdapter.Update(StartExtraJobDataTable);

                    MessageBox.Show(this, "Iteration No. 1 for Sintering process for selected MO, workcenter and machine has been started.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show(this, "Iteration No. " + iJob + " for Sintering process for selected MO, workcenter and machine has been already started!\nDo You want to start new iteration?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    StartExtraJobRow = StartExtraJobDataTable.NewShopfloorExtraJobStartRow();

                    StartExtraJobRow.BeginEdit();
                    StartExtraJobRow.TransactionDate = DateTime.Now;
                    StartExtraJobRow.UserID = sFSUserID;
                    StartExtraJobRow.Workcenter = lblWorkcenterData.Text;
                    StartExtraJobRow.MONumber = txtMONumber.Text;
                    StartExtraJobRow.MOLineNumber = lblMOLineNumberData.Text;
                    StartExtraJobRow.Machine = txtMachineID.Text;
                    StartExtraJobRow.PTUse = lblPtUseData.Text;
                    StartExtraJobRow.Sequence = txtSequenceNumber.Text;
                    StartExtraJobRow.JobIteration = Convert.ToInt16((iJob + 1));
                    StartExtraJobRow.JobDesc = "SINTERING";
                    StartExtraJobRow.EndEdit();

                    StartExtraJobDataTable.Rows.Add(StartExtraJobRow);

                    StartExtraJobTableAdapter.Update(StartExtraJobDataTable);

                    MessageBox.Show(this, "Iteration No. " + Convert.ToInt16((iJob + 1)).ToString() + " for Sintering process for selected MO, workcenter and machine has been started.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //check if field is number
        private void CheckNumber(object sender, CancelEventArgs e)
        {
            TextBox txtBox;
            decimal dValue;

            txtBox = (TextBox)sender;

            try
            {
                if (txtBox.Text == "")
                    txtBox.Text = "0";

                dValue = Convert.ToDecimal(txtBox.Text);
            }
            catch
            {
                MessageBox.Show(this, "Only numeric values please!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBox.SelectAll();
                e.Cancel = true;
                return;
            }
        }

    }
}