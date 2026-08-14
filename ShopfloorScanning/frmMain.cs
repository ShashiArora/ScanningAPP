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
        FSTransactionManager fstCon = new FSTransactionManager();

        public frmMain()
        {
            try
            {
                SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder(Settings.Default["FourthShift"].ToString());


                connection.UserID = "addonapp";
                connection.Password = "FS8.e$25";


                Settings.Default["FourthShift"] = connection.ToString();

                connection = new SqlConnectionStringBuilder(Settings.Default["FSPrograms"].ToString());

                connection.UserID = "addonapp";
                connection.Password = "FS8.e$25";

                Settings.Default["FSPrograms"] = connection.ToString();

                InitializeComponent();

            }
            catch (Exception ex)
            {
                fstCon.SendEMailError("Error initializing connection strings!" + ex.Message);
                MessageBox.Show("Error initializing connection strings: " + ex.Message, "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        //set up starting parameters
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                fstCon.SendEMailError("Can't Load form!" + ex.Message);
                MessageBox.Show("Error form Load: " + ex.Message, "frmLoad Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        //open next form depending on function
        private void btOK_Click(object sender, EventArgs e)
        {
            try
            {
                frmMORV dlgMORV = new frmMORV();
                frmPICK dlgPICK = new frmPICK();
                frmReversePICK dlgRevPICK = new frmReversePICK();
                frmStartJob dlgStartJob = new frmStartJob();
                frmEndJob dlgEndJob = new frmEndJob();
                frmMachine dlgMachine = new frmMachine();

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
            catch (Exception ex)
            {
                fstCon.SendEMailError("Error page Loading!" + ex.Message);
                MessageBox.Show("Error Load: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }


    }
}
