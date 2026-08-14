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
    public partial class frmReversePICK : Form
    {
        private FSTIClient fstiClient;
        private string sFSUserID;
        private decimal dQuantity;

        public frmReversePICK()
        {
            InitializeComponent();
        }

        //starting options
        private void frmReversePICK_Load(object sender, EventArgs e)
        {
            CleanData();
            this.Text = Application.ProductName + " - Reverse PICK materials back to stores";

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
        private void frmReversePICK_FormClosing(object sender, FormClosingEventArgs e)
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
            lblItemNumberData.Text = "";
            txtMONumber.Text = "";
            txtUserID.Text = "";
            txtQuantity.Text = "";
            sFSUserID = "";
            dQuantity = 0;
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
            string sErrorMsg = "";

            //check if any data entered
            if (txtMONumber.Text == "")
            {
                //no MO Number - error
                sErrorMsg = "Please scan or enter MO Number.";
            }
            else
            {
                if (txtMONumber.Text.IndexOf("$") != -1)
                {
                    //MO No has been scanned - $ char detected
                    txtMONumber.Text = txtMONumber.Text.Substring(0, txtMONumber.Text.IndexOf("$"));
                }

                ClearStockList();
                GetStockList();

                if (grStock.RowCount > 0)
                {
                    lblItemNumberData.Text = grStock.CurrentRow.Cells["ItemNumber"].Value.ToString();
                    txtQuantity.Text = grStock.CurrentRow.Cells["Quantity"].Value.ToString();
                }
                else
                {
                    //no read - MO don't exist
                    sErrorMsg = "This MO number doesn't exist. Please scan or enter it again.";
                }
            }

            //check if any errors and display them if so
            if (sErrorMsg != "")
            {
                MessageBox.Show(this, sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMONumber.Select();
                e.Cancel = true;
            }
        }

        //add enter handling to move to next field
        private void txtMONumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grStock.Focus();
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
            this.pickDetailsTableAdapter.FillBy(this.shopfloorDataSet.PickDetails, txtMONumber.Text);
        }

        //clear list of stock
        private void ClearStockList()
        {
            shopfloorDataSet.PickDetails.Clear();
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

                    if ((dQuantity > Convert.ToDecimal(grStock.CurrentRow.Cells["Quantity"].Value)) & (grStock.CurrentRow.Cells["ComponentType"].Value.ToString() != "R"))
                    {
                        sErrorMsg = "Quantity has to be lower than available quantity in stock";
                    }

                    if (dQuantity <= 0)
                    {
                        sErrorMsg = "Quantity has to be higher that 0.";
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
            if (txtQuantity.Text == "")
            {
                MessageBox.Show(this, "Please, enter quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return;
            }

            if (grStock.CurrentCell != null)
            {
                FSTIConnect();

                PICK13 tPICK13 = new PICK13();

                tPICK13.IssueType.Value = "X";
                tPICK13.OrderType.Value = "M";
                tPICK13.OrderNumber.Value = grStock.CurrentRow.Cells["MONumber"].Value.ToString();
                tPICK13.LineNumber.Value = grStock.CurrentRow.Cells["MOLineNumber"].Value.ToString();
                tPICK13.ItemNumber.Value = grStock.CurrentRow.Cells["ComponentItemNumber"].Value.ToString();
                tPICK13.PointOfUseID.Value = grStock.CurrentRow.Cells["PTUse"].Value.ToString();
                tPICK13.OperationSequenceNumber.Value = grStock.CurrentRow.Cells["SequenceNumber"].Value.ToString();
                tPICK13.ComponentLineType.Value = grStock.CurrentRow.Cells["ComponentType"].Value.ToString();
                tPICK13.Stockroom.Value = grStock.CurrentRow.Cells["Stockroom"].Value.ToString();
                tPICK13.Bin.Value = grStock.CurrentRow.Cells["Bin"].Value.ToString();
                tPICK13.ReverseQuantity.Value = txtQuantity.Text;
                tPICK13.LotNumber.Value = grStock.CurrentRow.Cells["LotNumber"].Value.ToString();
                tPICK13.InventoryCategory.Value = "O";
                tPICK13.ResourceComponentPolicy.Value = "2";

                if (fstiClient.ProcessId(tPICK13, sFSUserID))
                {
                    UpdatePickTable();
                    MessageBox.Show(this, "Reverse pick for component " + grStock.CurrentRow.Cells["ComponentItemNumber"].Value.ToString() + " quantity " + txtQuantity.Text + " Lot No " + grStock.CurrentRow.Cells["LotNumber"].Value.ToString() + " and location " + grStock.CurrentRow.Cells["Stockroom"].Value.ToString() + "-" + grStock.CurrentRow.Cells["Bin"].Value.ToString() + " has been finished successfully!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanData();
                    ClearStockList();
                    txtUserID.Focus();
                }
                else
                {
                    //check error
                    FSTIError iError = fstiClient.TransactionError;
                    MessageBox.Show(this, "Cannot make reverse pick for this workcenter.\n" + iError.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                FSTIClose();
            }
        }

        //saves data about PICK of N type component
        private void UpdatePickTable()
        {
            decimal Quantity;

            ShopfloorDataSetTableAdapters.ShopfloorPicksTableAdapter PicksTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.ShopfloorPicksTableAdapter();
            ShopfloorDataSet.ShopfloorPicksDataTable PicksDataTable = new ShopfloorDataSet.ShopfloorPicksDataTable();
            ShopfloorDataSet.ShopfloorPicksRow PicksRow;

            if (grStock.CurrentCell != null)
            {
                PicksTableAdapter.FillBy(PicksDataTable, Convert.ToInt32(grStock.CurrentRow.Cells["PICKKey"].Value));

                PicksRow = (ShopfloorDataSet.ShopfloorPicksRow)PicksDataTable.Rows[0];

                Quantity = PicksRow.Quantity - dQuantity;

                PicksRow.BeginEdit();
                PicksRow.Quantity = Quantity;
                PicksRow.EndEdit();

                PicksTableAdapter.Update(PicksDataTable);
            }
        }

        //when tab press move to next field
        private void grStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtQuantity.Focus();
            }
        }

        private void grStock_CurrentCellChanged(object sender, EventArgs e)
        {
            txtQuantity.Text = grStock.CurrentRow.Cells["Quantity"].Value.ToString();
            lblItemNumberData.Text = grStock.CurrentRow.Cells["ItemNumber"].Value.ToString();
        }

    }
}