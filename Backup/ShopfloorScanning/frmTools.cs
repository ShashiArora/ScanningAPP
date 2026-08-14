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
    public partial class frmTools : Form
    {
        private string[] sToolValues = new string[6];

        //constructor
        public frmTools()
        {
            InitializeComponent();
        }

        //set or get Tool Values
        public string[] Tools
        {
            set
            {
                sToolValues = value;
            }
            get
            {
                return sToolValues;
            }
        }

        //load values
        private void frmTools_Load(object sender, EventArgs e)
        {
            txtTools1.Text = sToolValues[0];
            txtTools2.Text = sToolValues[1];
            txtTools3.Text = sToolValues[2];
            txtTools4.Text = sToolValues[3];
            txtTools5.Text = sToolValues[4];
            txtTools6.Text = sToolValues[5];
        }

        //Tools Validating
        private void txtTools_Validating(object sender, CancelEventArgs e)
        {
            sToolValues[0] = txtTools1.Text;
            sToolValues[1] = txtTools2.Text;
            sToolValues[2] = txtTools3.Text;
            sToolValues[3] = txtTools4.Text;
            sToolValues[4] = txtTools5.Text;
            sToolValues[5] = txtTools6.Text;

            ShopfloorDataSetTableAdapters.QueriesTableAdapter queryTableAdapter = new ShopfloorScanning.ShopfloorDataSetTableAdapters.QueriesTableAdapter();

            string sItemNumber;
            string sErrorMsg = "";
            string sToolNo = "";
            int i;

            for (i = 0; i < 6; i++)
            {
                if (sToolValues[i] == "")
                    continue;
                else
                {
                    sItemNumber = queryTableAdapter.CheckIfToolExist(sToolValues[i]);

                    if (sItemNumber == null)
                    {
                        sToolNo += i + 1 + " (" + sToolValues[i] + ")";
                    }
                }
            }

            if (sToolNo != "")
            {
                sErrorMsg = "Tool no. " + sToolNo + " does not exist in FS";
                MessageBox.Show(this, sErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        //close form and save data entered
        private void btnOK_Click(object sender, EventArgs e)
        {
            sToolValues[0] = txtTools1.Text;
            sToolValues[1] = txtTools2.Text;
            sToolValues[2] = txtTools3.Text;
            sToolValues[3] = txtTools4.Text;
            sToolValues[4] = txtTools5.Text;
            sToolValues[5] = txtTools6.Text;
        }

    }
}
