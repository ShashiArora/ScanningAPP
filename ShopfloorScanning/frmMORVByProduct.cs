using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShopfloorScanning
{
    public partial class frmMORVByProduct : Form
    {
        public string sBPItemNumber;
        public string sBPQuantity;
        public string sBPStockroom;
        public string sBPBin;
        public string sBPLotNumber;

        private string sPreferredLocation;
        private string sPreferredStockroom;
        private string sPreferredBin;
        private string sLotNumberMask;

        public frmMORVByProduct()
        {
            InitializeComponent();
        }
        
        private void frmMORVByProduct_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " - MORV by product materials";
            CheckIfJobBreak();

            lblItemNumberData.Text = sBPItemNumber;
            txtQuantity.Text = sBPQuantity;

            ShopfloorDataSetTableAdapters.QueriesTableAdapter query = new ShopfloorScanning.ShopfloorDataSetTableAdapters.QueriesTableAdapter();

            sPreferredLocation = (string)query.GetPreferredLocation(sBPItemNumber);
            sLotNumberMask = (string)query.GetLotNumberMask(sBPItemNumber);

            if (sPreferredLocation != null)
            {
                sPreferredStockroom = sPreferredLocation.Substring(0, sPreferredLocation.IndexOf("$"));
                sPreferredBin = sPreferredLocation.Substring(sPreferredLocation.IndexOf("$") + 1);

                txtStockroom.Text = sPreferredStockroom;
            }

            if (sLotNumberMask.StartsWith("X"))
            {
                lblLotNo.Visible = true;
                txtLotNo.Visible = true;

                if (sLotNumberMask.Length > sLotNumberMask.IndexOf("$") + 1)
                {
                    txtLotNo.Text = sLotNumberMask.Substring(sLotNumberMask.IndexOf("$") + 1);
                }
            }

            txtStockroom.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CheckIfJobBreak();

            sBPQuantity = txtQuantity.Text;
            sBPStockroom = txtStockroom.Text;
            sBPBin = ddlBin.SelectedValue.ToString();

            if (sLotNumberMask.StartsWith("X"))
            {
                sBPLotNumber = txtLotNo.Text;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

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

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Convert.ToDecimal(txtQuantity.Text);
            }
            catch 
            {
                MessageBox.Show(this, "Quantity needs to be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Select(0, 20);
                e.Cancel = true;
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

        private void CheckIfJobBreak()
        {
            TimeSpan tBreakStart = DateTime.Now.TimeOfDay;
            TimeSpan tBreakPreStart = DateTime.Now.TimeOfDay;
            TimeSpan tBreakStop = DateTime.Now.TimeOfDay;
            TimeSpan tNow = DateTime.Now.TimeOfDay;

            try
            {
                ShopfloorDataSetTableAdapters.ShopfloorJobBreakTableAdapter JobBreakAdapter = new ShopfloorDataSetTableAdapters.ShopfloorJobBreakTableAdapter();
                ShopfloorDataSet.ShopfloorJobBreakDataTable JobBreakTable = JobBreakAdapter.GetData();

                if (JobBreakTable.Rows.Count > 0)
                {
                    tBreakStart = (TimeSpan)JobBreakTable.Rows[0]["BreakStart"];
                    tBreakPreStart = tBreakStart - TimeSpan.FromMinutes(15);
                    tBreakStop = (TimeSpan)JobBreakTable.Rows[0]["BreakStop"];

                    if (tNow >= tBreakStart || tNow <= tBreakStop)
                    {
                        MessageBox.Show(this, "Application is unavailable since " + tBreakStart.ToString() + " till " + tBreakStop.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Form.ActiveForm.Close();
                    }
                    else if (tNow >= tBreakPreStart)
                    {
                        MessageBox.Show(this, "Application will be unavailable since " + tBreakStart.ToString() + " till " + tBreakStop.ToString() + ". Please finish your tasks in application before " + tBreakStart.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No possible to retrive job break settings. Please contact administrator. Error - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
