using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShopfloorScanning.Properties;
using System.Configuration;

namespace ShopfloorScanning
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder(Settings.Default["FourthShift"].ToString());

            connection.UserID = "fsadmin";
            connection.Password = "Trelleborg123";

            Settings.Default["FourthShift"] = connection.ToString();

            connection = new SqlConnectionStringBuilder(Settings.Default["FSPrograms"].ToString());

            connection.UserID = "fsadmin";
            connection.Password = "Trelleborg123";

            Settings.Default["FSPrograms"] = connection.ToString();

            InitializeComponent();
        }

        //set up starting parameters
        private void frmMain_Load(object sender, EventArgs e)
        {
            string sMenuOption;

            this.Text = Application.ProductName + " " + Application.ProductVersion;
            sMenuOption = ConfigurationSettings.AppSettings["MenuOption"];
            sMenuOption = sMenuOption.ToUpper();

            if (sMenuOption == "MORV")
            {
                //Morv only
                rbPick.Enabled = false;
                rbPick.Hide();
                rbReversePICK.Enabled = false;
                rbReversePICK.Hide();
                rbMorv.Checked = true;

                rbMorv.Location = new Point(27, 49);
                rbStartJob.Location = new Point(27, 83);
                rbEndJob.Location = new Point(27, 117);

            }
            else if (sMenuOption == "BOTH")
            {
                //both
                rbPick.Checked = true;
            }
            else
            {
                //pick and default
                rbMorv.Enabled = false;
                rbMorv.Hide();

                rbPick.Checked = true;
                rbReversePICK.Location = new Point(27, 83);
                rbStartJob.Location = new Point(27, 117);
                rbEndJob.Location = new Point(27, 151);
            }	
        }

        //open next form depending on function
        private void btOK_Click(object sender, EventArgs e)
        {
            frmMORV dlgMORV = new frmMORV();
            frmPICK dlgPICK = new frmPICK ();
            frmReversePICK dlgRevPICK = new frmReversePICK();
            frmStartJob dlgStartJob = new frmStartJob();
            frmEndJob dlgEndJob = new frmEndJob();
            //frmSubstitutePICK dlgSubst = new frmSubstitutePICK();
            frmMachine dlgMachine = new frmMachine();
            //frmAddPICK dlgAdd = new frmAddPICK();

            if (rbPick.Checked)
            {
                dlgPICK.ShowDialog(this);
                dlgPICK.Dispose();
            }
            else if (rbMorv.Checked)
            {
                dlgMORV.ShowDialog(this);
                dlgMORV.Dispose();
            }
            else if (rbReversePICK.Checked)
            {
                dlgRevPICK.ShowDialog(this);
                dlgRevPICK.Dispose();
            }
            else if (rbStartJob.Checked)
            {
                dlgStartJob.ShowDialog(this);
                dlgStartJob.Dispose();
            }
            else if (rbEndJob.Checked)
            {
                dlgEndJob.ShowDialog(this);
                dlgEndJob.Dispose();
            }
            else if (rbMachine.Checked)
            {
                dlgMachine.ShowDialog(this);
                dlgMachine.Dispose();
            }

            this.Show();
        }


    }
}
