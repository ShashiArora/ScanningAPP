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
using System.Text.RegularExpressions;

namespace ShopfloorScanning
{
    public partial class frmEndJob : Form
    {
        private FSTIClient fstiClient;
        private string sFSUserID;
        private int iMOLineKey;
        private int iComponentItemKey;
        private string sComponentType;
        private decimal dQuantity;
        private int iMinutesWorked;
        private string[] sTools;
        private string[] sScrap;

        public frmEndJob()
        {
            InitializeComponent();
        }

        //starting options
        private void frmPICK_Load(object sender, EventArgs e)
        {
            CleanData();
            this.Text = Application.ProductName + " - Scan End of Job";
            FSTIConnect();
            txtUserID.Focus();

            JobType();
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
            txtQuantity.Enabled = true;
            txtQuantity.Text = "";
            sFSUserID = "";
            iMOLineKey = 0;
            iComponentItemKey = 0;
            sComponentType = "";
            dQuantity = 0;
            lblDepartment.Text = "";
            txtMinutesWorked.Text = "";
            lblSetup.Text = "";
            txtA.Text = "0";
            txtB.Text = "0";
            txtC.Text = "0";
            txtD.Text = "0";
            txtE.Text = "0";
            txtF.Text = "0";
            txtG.Text = "0";
            txtH.Text = "0";
            txtI.Text = "0";
            txtJ.Text = "0";
            txtK.Text = "0";
            txtL.Text = "0";
            txtM.Text = "0";
            txtN.Text = "0";
            txtO.Text = "0";
            txtP.Text = "0";
            txtQ.Text = "0";
            txtR.Text = "0";
            txtS.Text = "0";
            txtT.Text = "0";
            sTools = new string[] {"", "", "", "", "", ""};
            sScrap = new string[] {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"};
            btnTools.Enabled = false;
            btnScrap.Enabled = false;
            btnOK.Enabled = true;
            lblProcessType.Visible = false;
            cbJobType.Visible = false;
            lblJobIteration.Visible = false;
            txtJobIteration.Visible = false;
            txtJobIteration.Text = "";

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
                txtMinutesWorked.Focus();
            }
        }

        //check Sequence number data
        private void txtSequenceNumber_Validating(object sender, CancelEventArgs e)
        {
            ShopfloorDataSetTableAdapters.WorkcenterCheckTableAdapter mWorkcenterCheck = new ShopfloorScanning.ShopfloorDataSetTableAdapters.WorkcenterCheckTableAdapter();
            ShopfloorDataSet.WorkcenterCheckDataTable mWorkcenterCheckDataTable = new ShopfloorDataSet.WorkcenterCheckDataTable();
            ShopfloorDataSet.WorkcenterCheckRow mWorkcenterCheckRow;

            ShopfloorDataSetTableAdapters.QueriesTableAdapter queryTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.QueriesTableAdapter();
            int? iKey;
            //int iScrap;

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


                        if (lblWorkcenterData.Text.Contains("WC[S]") == true)
                        {
                            txtQuantity.Enabled = false;
                            txtQuantity.Text = "0";

                            lblSetup.Text = "YES";

                            btnTools.Enabled = false;
                            btnScrap.Enabled = false;

                        }
                        else
                        {
                            txtQuantity.Enabled = true;
                            txtQuantity.Text = "";
                            
                            lblSetup.Text = "NO";

                            btnTools.Enabled = true;
                            btnScrap.Enabled = true;
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
                        
                        lblRuntimeRequiredData.Text = (mWorkcenterCheckRow.RequiredQuantity * 60).ToString();
                        lblRuntimeIssuedData.Text = (mWorkcenterCheckRow.IssuedQuantity * 60).ToString();

                        dRemQty = mWorkcenterCheckRow.RequiredQuantity - mWorkcenterCheckRow.IssuedQuantity;
                        //iScrap = Convert.ToInt32(queryTableAdapter.GetScrapQuantity(txtMONumber.Text, lblMOLineNumberData.Text, lblItemNumberData.Text, lblWorkcenterData.Text));
                        //dRemQty += iScrap;

                        if (dRemQty < 0)
                        {
                            dRemQty = 0;
                        }

                        lblRuntimeRemainingData.Text = (dRemQty * 60).ToString();
                        sComponentType = mWorkcenterCheckRow.ComponentType;
                        iComponentItemKey = mWorkcenterCheckRow.ItemKey;
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
            else
            { 
                //check if it was started
                iKey = Convert.ToInt32(queryTableAdapter.CheckIfJobStarted(txtMONumber.Text, lblMOLineNumberData.Text, lblPtUseData.Text, txtSequenceNumber.Text, lblWorkcenterData.Text));

                if (iKey == 0)
                {
                    MessageBox.Show(this, "Job for selected MO, workcenter and sequence number has been not yet started", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CleanData();
                    txtUserID.Focus();
                }

                //check if it is Moulding/Sintering process
                if (lblWorkcenterData.Text == "SM[T]" || lblWorkcenterData.Text == "CM[T]")
                {
                    lblProcessType.Visible = true;
                    cbJobType.Visible = true;
                }
            }
        }

        //check Job Iteration number data
        private void txtJobIteration_Validating(object sender, CancelEventArgs e)
        {
            ShopfloorDataSetTableAdapters.QueriesTableAdapter queryTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.QueriesTableAdapter();
            int? iJob;

            string sErrorMsg = "";
            string sSeqNo = "";

            if (lblWorkcenterData.Text == "SM[T]" || lblWorkcenterData.Text == "CM[T]")
            {
                //check if any data entered
                try
                {
                    iJob = Convert.ToInt16(txtJobIteration.Text);
                }
                catch
                    
                {
                    sErrorMsg = "Please scan or enter correct Iteration No.";
                }
            }

            //check if any errors and display them if so
            if (sErrorMsg != "")
            {
                MessageBox.Show(this, sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                //check if it was started
                iJob = Convert.ToInt32(queryTableAdapter.CheckIfExtraJobStarted(txtMONumber.Text, lblMOLineNumberData.Text, lblPtUseData.Text, txtSequenceNumber.Text, lblWorkcenterData.Text, Convert.ToInt16(txtJobIteration.Text)));

                if (iJob == 0)
                {
                    MessageBox.Show(this, "Iteration for selected MO, workcenter and sequence number has been not yet started", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CleanData();
                    txtUserID.Focus();
                }
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

        //check entered quantity
        private void txtMinutesWorked_Validating(object sender, CancelEventArgs e)
        {
            string sErrorMsg = "";

            try
            {
                iMinutesWorked = Convert.ToInt32(txtMinutesWorked.Text);

                txtMinutesWorked.Text = iMinutesWorked.ToString();

                if (sComponentType != "R")
                {
                    sErrorMsg = "Only workcenters should be booked not materials.";
                }

                if (iMinutesWorked > Convert.ToDecimal(1.1) * Convert.ToDecimal(lblRuntimeRemainingData.Text))
                {
                    if (MessageBox.Show(this, "Minutes worked are greater than Remaining work time by more than 10%. \n" +
                        "Do you want to continue? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        txtMinutesWorked.Select(0, 20);
                        btnTools.Enabled = false;
                        btnScrap.Enabled = false;
                        e.Cancel = true;
                    }
                }
            }
            catch
            {
                sErrorMsg = "Minutes worked needs to be numeric!";
            }

            //check if any errors and display them if so
            if (sErrorMsg != "")
            {
                MessageBox.Show(this, sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Select(0, 20);
                btnTools.Enabled = false;
                btnScrap.Enabled = false;
                e.Cancel = true;
            }
        }

        //check entered quantity
        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            string sErrorMsg = "";

            try
            {
                dQuantity = Convert.ToDecimal(txtQuantity.Text);
                
                txtQuantity.Text = dQuantity.ToString();
                
                if (sComponentType != "R")
                {
                    sErrorMsg = "Only workcenters should be booked not materials.";
                }
           
                if (dQuantity > Convert.ToDecimal(1.1) * Convert.ToDecimal(lblQtyRemainingData.Text))
                {
                    if (MessageBox.Show(this, "Quantity is greater than Remaining Quantity by more than 10%. \n" +
                        "Do you want to continue? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        txtQuantity.Select(0, 20);
                        btnTools.Enabled = false;
                        btnScrap.Enabled = false;
                        e.Cancel = true;
                    }
                }
            }
            catch
            {
                sErrorMsg = "Quantity needs to be numeric!";
            }

            //check if any errors and display them if so
            if (sErrorMsg != "")
            {
                MessageBox.Show(this, sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Select(0, 20);
                btnTools.Enabled = false;
                btnScrap.Enabled = false;
                e.Cancel = true;
            }
        }

        //handle all picks that need to be done
        private void btnOK_Click(object sender, EventArgs e)
        {
            string sLine;
            decimal dTimeWorked;
            int iDownTime;
            int iScrap = 0;
            bool bTool = false;
            decimal dQtyRemaining;

            frmEntryAcceptance dlgAccept = new frmEntryAcceptance();

            dTimeWorked = Math.Round(Convert.ToDecimal(txtMinutesWorked.Text) / 60 , 2);

            iDownTime = Convert.ToInt32(txtA.Text) + Convert.ToInt32(txtB.Text) + Convert.ToInt32(txtC.Text) + Convert.ToInt32(txtD.Text) +
                        Convert.ToInt32(txtE.Text) + Convert.ToInt32(txtF.Text) + Convert.ToInt32(txtG.Text) + Convert.ToInt32(txtH.Text) +
                        Convert.ToInt32(txtI.Text) + Convert.ToInt32(txtJ.Text) + Convert.ToInt32(txtK.Text) + Convert.ToInt32(txtL.Text) +
                        Convert.ToInt32(txtM.Text) + Convert.ToInt32(txtN.Text) + Convert.ToInt32(txtO.Text) + Convert.ToInt32(txtP.Text) +
                        Convert.ToInt32(txtQ.Text) + Convert.ToInt32(txtR.Text) + Convert.ToInt32(txtS.Text) + Convert.ToInt32(txtT.Text);

            for (int i = 0; i < sScrap.Length; i++)
            {
                iScrap += Convert.ToInt32(sScrap[i]);
            }

            for (int i=0; i < sTools.Length; i++)
            {
                if (sTools[i] != "")
                    bTool = true;
            }

            dQtyRemaining = Convert.ToDecimal(lblRuntimeRemainingData.Text) - Convert.ToDecimal(txtMinutesWorked.Text);
            
            if (dQtyRemaining < 0)
                dQtyRemaining = 0;

            dlgAccept.QtyManufactured = txtQuantity.Text;
            dlgAccept.QtyRejected = iScrap.ToString();
            dlgAccept.QtyRemaining = dQtyRemaining.ToString();
            dlgAccept.QtyRequired = lblRuntimeRequiredData.Text;
            dlgAccept.MONumber = txtMONumber.Text;
            dlgAccept.ItemNumber = lblItemNumberData.Text;
            dlgAccept.DownTime = iDownTime.ToString();
            dlgAccept.Sequence = txtSequenceNumber.Text;
            dlgAccept.TotalTime = txtMinutesWorked.Text;
            dlgAccept.UserID = txtUserID.Text;

            if (dlgAccept.ShowDialog() == DialogResult.OK)
            {
                if (cbJobType.SelectedValue.ToString() == "S")
                {
                    UpdateEndExtraJobTable();
                    CleanData();
                    txtUserID.Focus();
                }
                else
                {
                    if (iScrap > 0)
                        BookScrap();

                    if (bTool)
                        BookTools();

                    if (dTimeWorked > 0)
                    {
                        btnOK.Enabled = false;

                        sLine = "\"PICK08\",\"" + sFSUserID + "\",\"\",\"\",\"0\",\"\",\"M\",\"I\",\"" + txtMONumber.Text + "\",\"" + lblMOLineNumberData.Text + "\",\"\",\"" + sComponentType + "\",\"" + lblPtUseData.Text + "\",\"" + txtSequenceNumber.Text + "\",\"" + lblWorkcenterData.Text + "\",\"\",\"\",\"\",\"\",\"\",\"\",\"" + dTimeWorked.ToString() + "\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"2\",\"\",\"I\",\"\"";

                        if (fstiClient.ProcessCDF(sLine, sFSUserID) == false)
                        {
                            //check error
                            FSTIError iError = fstiClient.TransactionError;
                            MessageBox.Show(this, "Cannot make pick for this workcenter.\n" + iError.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    UpdateEndJobTable();
                    CleanData();
                    txtUserID.Focus();
                }
            }
        }

        //save tools information
        private void BookTools()
        {
            ShopfloorDataSetTableAdapters.ShopfloorToolsTableAdapter ToolsTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.ShopfloorToolsTableAdapter();
            ShopfloorDataSet.ShopfloorToolsDataTable ToolsDataTable = new ShopfloorDataSet.ShopfloorToolsDataTable();
            ShopfloorDataSet.ShopfloorToolsRow ToolsRow;

            ToolsRow = ToolsDataTable.NewShopfloorToolsRow();

            ToolsRow.BeginEdit();
            ToolsRow.TransactionDate = DateTime.Now;
            ToolsRow.UserID = sFSUserID;
            ToolsRow.MONumber = txtMONumber.Text;
            ToolsRow.MOLineNumber = lblMOLineNumberData.Text;
            ToolsRow.ItemNumber = lblItemNumberData.Text;
            ToolsRow.Workcenter = lblWorkcenterData.Text;
            ToolsRow.Setup = lblSetup.Text;
            ToolsRow.Quantity = Convert.ToDecimal(txtQuantity.Text);
            ToolsRow.Tool1 = sTools[0];
            ToolsRow.Tool2 = sTools[1];
            ToolsRow.Tool3 = sTools[2];
            ToolsRow.Tool4 = sTools[3];
            ToolsRow.Tool5 = sTools[4];
            ToolsRow.Tool6 = sTools[5];
            ToolsRow.EndEdit();

            ToolsDataTable.Rows.Add(ToolsRow);
            ToolsTableAdapter.Update(ToolsDataTable);
        }

        //save scrap information
        private void BookScrap()
        {
            ShopfloorDataSetTableAdapters.ShopfloorScrapTableAdapter ScrapTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.ShopfloorScrapTableAdapter();
            ShopfloorDataSet.ShopfloorScrapDataTable ScrapDataTable = new ShopfloorDataSet.ShopfloorScrapDataTable();
            ShopfloorDataSet.ShopfloorScrapRow ScrapRow;
            ScrapRow = ScrapDataTable.NewShopfloorScrapRow();

            ScrapRow.BeginEdit();
            ScrapRow.TransactionDate = DateTime.Now;
            ScrapRow.UserID = sFSUserID;
            ScrapRow.MONumber = txtMONumber.Text;
            ScrapRow.MOLineNumber = lblMOLineNumberData.Text;
            ScrapRow.ItemNumber = lblItemNumberData.Text;
            ScrapRow.Workcenter = lblWorkcenterData.Text;
            ScrapRow.Setup = lblSetup.Text;
            ScrapRow.Quantity = 0; //Convert.ToDecimal(txtQuantity.Text);
            ScrapRow.Scrap10 = Convert.ToInt32(sScrap[0]);
            ScrapRow.Scrap11 = Convert.ToInt32(sScrap[1]);
            ScrapRow.Scrap12 = Convert.ToInt32(sScrap[2]);
            ScrapRow.Scrap13 = Convert.ToInt32(sScrap[3]);
            ScrapRow.Scrap14 = Convert.ToInt32(sScrap[4]);
            ScrapRow.Scrap15 = Convert.ToInt32(sScrap[5]);
            ScrapRow.Scrap16 = Convert.ToInt32(sScrap[6]);
            ScrapRow.Scrap17 = Convert.ToInt32(sScrap[7]);
            ScrapRow.Scrap18 = Convert.ToInt32(sScrap[8]);
            ScrapRow.Scrap19 = Convert.ToInt32(sScrap[9]);
            ScrapRow.Scrap20 = Convert.ToInt32(sScrap[10]);
            ScrapRow.Scrap21 = Convert.ToInt32(sScrap[11]);
            ScrapRow.Scrap22 = Convert.ToInt32(sScrap[12]);
            ScrapRow.Scrap23 = Convert.ToInt32(sScrap[13]);
            ScrapRow.Scrap31 = Convert.ToInt32(sScrap[14]);
            ScrapRow.Scrap32 = Convert.ToInt32(sScrap[15]);
            ScrapRow.Scrap33 = Convert.ToInt32(sScrap[16]);
            ScrapRow.Scrap34 = Convert.ToInt32(sScrap[17]);
            ScrapRow.Scrap35 = Convert.ToInt32(sScrap[18]);
            ScrapRow.Scrap36 = Convert.ToInt32(sScrap[19]);
            ScrapRow.Scrap37 = Convert.ToInt32(sScrap[20]);
            ScrapRow.Scrap38 = Convert.ToInt32(sScrap[21]);
            ScrapRow.Scrap39 = Convert.ToInt32(sScrap[22]);
            ScrapRow.Scrap40 = Convert.ToInt32(sScrap[23]);
            ScrapRow.Scrap41 = Convert.ToInt32(sScrap[24]);
            ScrapRow.Scrap42 = Convert.ToInt32(sScrap[25]);
            ScrapRow.Scrap43 = Convert.ToInt32(sScrap[26]);

            ScrapRow.EndEdit();

            ScrapDataTable.Rows.Add(ScrapRow);
            ScrapTableAdapter.Update(ScrapDataTable);
        }

        //saves data to table
        private void UpdateEndJobTable()
        {
            ShopfloorDataSetTableAdapters.ShopfloorJobEndTableAdapter JobEndTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.ShopfloorJobEndTableAdapter();
            ShopfloorDataSet.ShopfloorJobEndDataTable JobEndDataTable = new ShopfloorDataSet.ShopfloorJobEndDataTable();
            ShopfloorDataSet.ShopfloorJobEndRow JobEndRow;

            JobEndRow = JobEndDataTable.NewShopfloorJobEndRow();

            JobEndRow.BeginEdit();
            JobEndRow.TransactionDate = DateTime.Now;
            JobEndRow.UserID = sFSUserID;
            JobEndRow.Workcenter = lblWorkcenterData.Text;
            JobEndRow.MONumber = txtMONumber.Text;
            JobEndRow.MOLineNumber = lblMOLineNumberData.Text;
            JobEndRow.PTUse = lblPtUseData.Text;
            JobEndRow.Sequence = txtSequenceNumber.Text;
            JobEndRow.MinutesWorked = Convert.ToInt32(txtMinutesWorked.Text);
            JobEndRow.QuantityMade = Convert.ToDecimal(txtQuantity.Text);
            JobEndRow.ItemNumber = lblItemNumberData.Text;
            JobEndRow.LostTimeA = Convert.ToInt32(txtA.Text);
            JobEndRow.LostTimeB = Convert.ToInt32(txtB.Text);
            JobEndRow.LostTimeC = Convert.ToInt32(txtC.Text);
            JobEndRow.LostTimeD = Convert.ToInt32(txtD.Text);
            JobEndRow.LostTimeE = Convert.ToInt32(txtE.Text);
            JobEndRow.LostTimeF = Convert.ToInt32(txtF.Text);
            JobEndRow.LostTimeG = Convert.ToInt32(txtG.Text);
            JobEndRow.LostTimeH = Convert.ToInt32(txtH.Text);
            JobEndRow.LostTimeI = Convert.ToInt32(txtI.Text);
            JobEndRow.LostTimeJ = Convert.ToInt32(txtJ.Text);
            JobEndRow.LostTimeK = Convert.ToInt32(txtK.Text);
            JobEndRow.LostTimeL = Convert.ToInt32(txtL.Text);
            JobEndRow.LostTimeM = Convert.ToInt32(txtM.Text);
            JobEndRow.LostTimeN = Convert.ToInt32(txtN.Text);
            JobEndRow.LostTimeO = Convert.ToInt32(txtO.Text);
            JobEndRow.LostTimeQ = Convert.ToInt32(txtP.Text);
            JobEndRow.LostTimeP = Convert.ToInt32(txtQ.Text);
            JobEndRow.LostTimeR = Convert.ToInt32(txtR.Text);
            JobEndRow.LostTimeS = Convert.ToInt32(txtS.Text);
            JobEndRow.LostTimeT = Convert.ToInt32(txtT.Text);
            JobEndRow.Setup = lblSetup.Text;
            JobEndRow.EndEdit();

            JobEndDataTable.Rows.Add(JobEndRow);

            JobEndTableAdapter.Update(JobEndDataTable);  
        }

        private void UpdateEndExtraJobTable()
        {
            ShopfloorDataSetTableAdapters.ShopfloorExtraJobEndTableAdapter ExtraJobEndTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.ShopfloorExtraJobEndTableAdapter();
            ShopfloorDataSet.ShopfloorExtraJobEndDataTable ExtraJobEndDataTable = new ShopfloorDataSet.ShopfloorExtraJobEndDataTable();
            ShopfloorDataSet.ShopfloorExtraJobEndRow ExtraJobEndRow;

            ExtraJobEndRow = ExtraJobEndDataTable.NewShopfloorExtraJobEndRow();

            ExtraJobEndRow.BeginEdit();
            ExtraJobEndRow.TransactionDate = DateTime.Now;
            ExtraJobEndRow.UserID = sFSUserID;
            ExtraJobEndRow.Workcenter = lblWorkcenterData.Text;
            ExtraJobEndRow.MONumber = txtMONumber.Text;
            ExtraJobEndRow.MOLineNumber = lblMOLineNumberData.Text;
            ExtraJobEndRow.PTUse = lblPtUseData.Text;
            ExtraJobEndRow.Sequence = txtSequenceNumber.Text;
            ExtraJobEndRow.MinutesWorked = Convert.ToInt32(txtMinutesWorked.Text);
            ExtraJobEndRow.QuantityMade = Convert.ToDecimal(txtQuantity.Text);
            ExtraJobEndRow.JobIteration = Convert.ToInt16(txtJobIteration.Text);
            ExtraJobEndRow.JobDesc = "SINTERING";
            ExtraJobEndRow.ItemNumber = lblItemNumberData.Text;
            ExtraJobEndRow.LostTimeA = Convert.ToInt32(txtA.Text);
            ExtraJobEndRow.LostTimeB = Convert.ToInt32(txtB.Text);
            ExtraJobEndRow.LostTimeC = Convert.ToInt32(txtC.Text);
            ExtraJobEndRow.LostTimeD = Convert.ToInt32(txtD.Text);
            ExtraJobEndRow.LostTimeE = Convert.ToInt32(txtE.Text);
            ExtraJobEndRow.LostTimeF = Convert.ToInt32(txtF.Text);
            ExtraJobEndRow.LostTimeG = Convert.ToInt32(txtG.Text);
            ExtraJobEndRow.LostTimeH = Convert.ToInt32(txtH.Text);
            ExtraJobEndRow.LostTimeI = Convert.ToInt32(txtI.Text);
            ExtraJobEndRow.LostTimeJ = Convert.ToInt32(txtJ.Text);
            ExtraJobEndRow.LostTimeK = Convert.ToInt32(txtK.Text);
            ExtraJobEndRow.LostTimeL = Convert.ToInt32(txtL.Text);
            ExtraJobEndRow.LostTimeM = Convert.ToInt32(txtM.Text);
            ExtraJobEndRow.LostTimeN = Convert.ToInt32(txtN.Text);
            ExtraJobEndRow.LostTimeO = Convert.ToInt32(txtO.Text);
            ExtraJobEndRow.LostTimeQ = Convert.ToInt32(txtP.Text);
            ExtraJobEndRow.LostTimeP = Convert.ToInt32(txtQ.Text);
            ExtraJobEndRow.LostTimeR = Convert.ToInt32(txtR.Text);
            ExtraJobEndRow.LostTimeS = Convert.ToInt32(txtS.Text);
            ExtraJobEndRow.LostTimeT = Convert.ToInt32(txtT.Text);
            ExtraJobEndRow.Setup = lblSetup.Text;
            ExtraJobEndRow.EndEdit();

            ExtraJobEndDataTable.Rows.Add(ExtraJobEndRow);

            ExtraJobEndTableAdapter.Update(ExtraJobEndDataTable);
        }

        //check if number and not more than 600
        private void CheckNumber(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txtBox;

            txtBox = (TextBox)sender;
            if (!Regex.IsMatch(txtBox.Text, "^([0-9]|[1-9][0-9]|[1-9][0-9][0-9])$"))
            {
                MessageBox.Show(this, "Only numeric values please!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBox.Text = "0";
                e.Cancel = true;
                return;
            }
            else if (Convert.ToInt32(txtBox.Text) > 600)
            {
                MessageBox.Show(this, "600 is maximum allowed value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBox.Text = "600";
                e.Cancel = true;
                return;
            }
        }

        //handles scrap screen display
        private void btnScrap_Click(object sender, EventArgs e)
        {

        }
        
        //handles tools screen display
        private void btnTools_Click(object sender, EventArgs e)
        {
            frmTools dlgTools = new frmTools();

            dlgTools.Tools = sTools;

            if (dlgTools.ShowDialog(this) == DialogResult.OK)
            {
                sTools = dlgTools.Tools;
            }

            dlgTools.Dispose();
        }

        private void JobType()
        {
            DataTable JobType = new DataTable();
            JobType.Columns.Add("ID");
            JobType.Columns.Add("Desc");
            JobType.Rows.Add("M", "Moulding");
            JobType.Rows.Add("S", "Sintering");

            cbJobType.DataSource = JobType;
            cbJobType.DisplayMember = "Desc";
            cbJobType.ValueMember = "ID";
            cbJobType.SelectedIndex = 0;
            cbJobType.Refresh();

            lblProcessType.Visible = false;
            cbJobType.Visible = false;
        }

        private void cbJobType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbJobType.SelectedValue.ToString() == "S")
            {
                lblJobIteration.Visible = true;
                txtJobIteration.Visible = true;
                btnScrap.Visible = false;
                btnTools.Visible = false;
            }
            else
            {
                lblJobIteration.Visible = false;
                txtJobIteration.Visible = false;
                btnScrap.Visible = true;
                btnTools.Visible = true;
            }
        }

   }
}