using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace ShopfloorScanning
{
    public partial class frmMachine : Form
    {
        private string sFSUserID;
        private bool bHasRights;
        private int iMachineID;

        public frmMachine()
        {
            InitializeComponent();
        }

        //starting options
        private void frmStartJob_Load(object sender, EventArgs e)
        {
            CleanData();
            this.Text = Application.ProductName + " - Machine maintenence";
        }

        //clean all data
        private void CleanData()
        {
            lblUserName.Text = "";
            txtUserID.Text = "";
            lblDepartment.Text = "";
            lblMachineIDDesc.Text = "";
            txtMachineID.Text = "";
            sFSUserID = "";
            lblTimeWorked.Visible = false;
            txtTimeWorked.Visible = false;
            btnMaintain.Visible = false;
            btnMaintain.Enabled = false;
            txtTimeWorked.Enabled = false;
            rbAvailable.Checked = false;
            rbMaintenance.Checked = false;
            rbUnavailable.Checked = false;
            rbAvailable.Enabled = false;
            rbMaintenance.Enabled = false;
            rbUnavailable.Enabled = false;
            btnOK.Enabled = true;

            txtUserID.Focus();
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
                    bHasRights = mUsersRow.CanMaintain;
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
                txtMachineID.Focus();
            }	
        }

        //move to next field with enter
        private void txtMachineID_Validating(object sender, CancelEventArgs e)
        {
            string sErrorMsg = "";
            string sMachineDesc;
            string sStatus = "";
            string sServiceLevel = "";

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
                iMachineID = Convert.ToInt32(queryTableAdapter.GetMachineID(txtMachineID.Text));

                if (sMachineDesc == null)
                {
                    sErrorMsg = "This Machine doesn't exist. Please scan or enter it again.";
                }
                else
                {
                    lblMachineIDDesc.Text = sMachineDesc;
                    sStatus = Convert.ToString(queryTableAdapter.GetMachineStatus(iMachineID));

                    switch (sStatus)
                    {
                        case "U":
                            {
                                //unavailable
                                rbUnavailable.Checked = true;
                                rbAvailable.Checked = false;
                                rbMaintenance.Checked = false;
                                rbUnavailable.Enabled = false;
                                rbAvailable.Enabled = false;
                                rbMaintenance.Enabled = false;
                                break;
                            }
                        case "P":
                            {
                                //unavailable
                                rbUnavailable.Checked = false;
                                rbAvailable.Checked = false;
                                rbMaintenance.Checked = true;
                                rbUnavailable.Enabled = false;
                                rbAvailable.Enabled = false;
                                rbMaintenance.Enabled = false;
                                break;
                            }
                        default:
                            {
                                //Available
                                rbUnavailable.Checked = false;
                                rbAvailable.Checked = true;
                                rbMaintenance.Checked = false;
                                rbUnavailable.Enabled = true;
                                rbAvailable.Enabled = false;
                                rbMaintenance.Enabled = true;
                                break;
                            }
                    }
                    if (bHasRights)
                    {
                        sServiceLevel = queryTableAdapter.GetMachineServiceLevel(iMachineID).ToString();

                        switch (sServiceLevel.ToUpper())
                        {
                            case "RAISED":
                            {
                                btnMaintain.Visible = true;
                                btnMaintain.Enabled = true;
                                btnMaintain.Text = "Start";
                                btnOK.Enabled = false;
                                break;
                            }

                            case "STARTED":
                            {
                                btnMaintain.Visible = true;
                                btnMaintain.Enabled = true;
                                btnMaintain.Text = "Stop";
                                lblTimeWorked.Visible = true;
                                txtTimeWorked.Visible = true;
                                txtTimeWorked.Enabled = true;
                                btnOK.Enabled = false;
                                break;
                            }
                        }
                    }
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
                if (txtTimeWorked.Visible)
                    txtTimeWorked.Focus();
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
            ShopfloorDataSetTableAdapters.ShopfloorMaintenanceLogTableAdapter maintenanceTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.ShopfloorMaintenanceLogTableAdapter();
            ShopfloorDataSet.ShopfloorMaintenanceLogDataTable maintenanceDataTable = new ShopfloorDataSet.ShopfloorMaintenanceLogDataTable();
            ShopfloorDataSet.ShopfloorMaintenanceLogRow maintenanceRow;

            if (rbMaintenance.Enabled)
            {
                //options are enabled so we raise request for maintenance
                maintenanceRow = maintenanceDataTable.NewShopfloorMaintenanceLogRow();

                maintenanceRow.BeginEdit();

                maintenanceRow.MachineID = iMachineID;
                maintenanceRow.RaisedBy = sFSUserID;
                maintenanceRow.RaisedOn = DateTime.Now;
                if (rbMaintenance.Checked)
                    maintenanceRow.Status = "P";
                else
                    maintenanceRow.Status = "U";
                maintenanceRow.EndEdit();

                maintenanceDataTable.Rows.Add(maintenanceRow);
                maintenanceTableAdapter.Update(maintenanceDataTable);
            }
            MessageBox.Show(this, "Status change for machine " + txtMachineID.Text + " has been recorded.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CleanData();
            txtUserID.Focus();
        }

        //check if field is number
        private void CheckNumber(object sender, CancelEventArgs e)
        {
            TextBox txtBox;
            int iValue;

            txtBox = (TextBox)sender;

            try
            {
                if (txtBox.Text == "")
                    txtBox.Text = "0";

                iValue = Convert.ToInt32(txtBox.Text);
            }
            catch
            {
                MessageBox.Show(this, "Only numeric values please!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBox.SelectAll();
                e.Cancel = true;
                return;
            }
        }

        //process changes to log entry
        private void btnMaintain_Click(object sender, EventArgs e)
        {
            ShopfloorDataSetTableAdapters.ShopfloorMaintenanceLogTableAdapter maintenanceTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.ShopfloorMaintenanceLogTableAdapter();
            ShopfloorDataSet.ShopfloorMaintenanceLogDataTable maintenanceDataTable = new ShopfloorDataSet.ShopfloorMaintenanceLogDataTable();
            ShopfloorDataSet.ShopfloorMaintenanceLogRow maintenaceRow;

            maintenanceTableAdapter.FillBy(maintenanceDataTable, iMachineID);

            maintenaceRow = (ShopfloorDataSet.ShopfloorMaintenanceLogRow)maintenanceDataTable.Rows[0];

            if (maintenaceRow != null)
            {
                if (btnMaintain.Text == "Stop")
                {
                    maintenaceRow.BeginEdit();
                    maintenaceRow.MaintenanceStopBy = sFSUserID;
                    maintenaceRow.MaintenanceStopOn = DateTime.Now;
                    maintenaceRow.MaintenanceTime = Convert.ToInt32(txtTimeWorked.Text);
                    maintenaceRow.EndEdit();

                    maintenanceTableAdapter.Update(maintenaceRow);

                    MessageBox.Show(this, "Maintenace of machine " + txtMachineID.Text + " has been finished.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    maintenaceRow.BeginEdit();
                    maintenaceRow.MaintenanceStartBy = sFSUserID;
                    maintenaceRow.MaintenanceStartOn = DateTime.Now;
                    maintenaceRow.EndEdit();

                    maintenanceTableAdapter.Update(maintenaceRow);

                    MessageBox.Show(this, "Maintenace of machine " + txtMachineID.Text + " has been started.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            CleanData();
            txtUserID.Focus();
        }
    }
}