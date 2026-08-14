using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ShopfloorScanning
{
    public partial class frmScrap : Form
    {
        private string[] sScrap = new string[27];

        //constructor
        public frmScrap()
        {
            InitializeComponent();
        }

        //set and get scrap values
        public string[] Scrap
        {
            set
            {
                sScrap = value;
            }
            get 
            {
                return sScrap;
            }
        }

        //check if field is number
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
        }

        //setupd fields values
        private void frmScrap_Load(object sender, EventArgs e)
        {
            txtScrap10.Text = sScrap[0];
            txtScrap11.Text = sScrap[1];
            txtScrap12.Text = sScrap[2];
            txtScrap13.Text = sScrap[3];
            txtScrap14.Text = sScrap[4];
            txtScrap15.Text = sScrap[5];
            txtScrap16.Text = sScrap[6];
            txtScrap17.Text = sScrap[7];
            txtScrap18.Text = sScrap[8];
            txtScrap19.Text = sScrap[9];
            txtScrap20.Text = sScrap[10];
            txtScrap21.Text = sScrap[11];
            txtScrap22.Text = sScrap[12];
            txtScrap23.Text = sScrap[13];
            txtScrap31.Text = sScrap[14];
            txtScrap32.Text = sScrap[15];
            txtScrap33.Text = sScrap[16];
            txtScrap34.Text = sScrap[17];
            txtScrap35.Text = sScrap[18];
            txtScrap36.Text = sScrap[19];
            txtScrap37.Text = sScrap[20];
            txtScrap38.Text = sScrap[21];
            txtScrap39.Text = sScrap[22];
            txtScrap40.Text = sScrap[23];
            txtScrap41.Text = sScrap[24];
            txtScrap42.Text = sScrap[25];
            txtScrap43.Text = sScrap[26];
        }

        //confirm data in form
        private void btnOK_Click(object sender, EventArgs e)
        {
            sScrap[0] = txtScrap10.Text;
            sScrap[1] = txtScrap11.Text;
            sScrap[2] = txtScrap12.Text;
            sScrap[3] = txtScrap13.Text;
            sScrap[4] = txtScrap14.Text;
            sScrap[5] = txtScrap15.Text;
            sScrap[6] = txtScrap16.Text;
            sScrap[7] = txtScrap17.Text;
            sScrap[8] = txtScrap18.Text;
            sScrap[9] = txtScrap19.Text;
            sScrap[10] = txtScrap20.Text;
            sScrap[11] = txtScrap21.Text;
            sScrap[12] = txtScrap22.Text; 
            sScrap[13] = txtScrap23.Text;
            sScrap[14] = txtScrap31.Text;
            sScrap[15] = txtScrap32.Text;
            sScrap[16] = txtScrap33.Text;
            sScrap[17] = txtScrap34.Text;
            sScrap[18] = txtScrap35.Text;
            sScrap[19] = txtScrap36.Text;
            sScrap[20] = txtScrap37.Text;
            sScrap[21] = txtScrap38.Text;
            sScrap[22] = txtScrap39.Text;
            sScrap[23] = txtScrap40.Text;
            sScrap[24] = txtScrap41.Text;
            sScrap[25] = txtScrap42.Text;
            sScrap[26] = txtScrap43.Text;
        }
    }
}
