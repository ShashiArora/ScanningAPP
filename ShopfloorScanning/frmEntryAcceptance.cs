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
    public partial class frmEntryAcceptance : Form
    {
        private string mUserID = "";
        private string mMONumber = "";
        private string mItemNumber = "";
        private string mSequence = "";
        private string mQtyManufactured = "";
        private string mQtyRequired = "";
        private string mQtyRejected = "";
        private string mQtyRemaining = "";
        private string mTotalTime = "";
        private string mDownTime = "";

        public frmEntryAcceptance()
        {
            InitializeComponent();
        }

        //get / set user ID
        public string UserID
        {
            get
            {
                return mUserID;
            }
            set
            {
                mUserID = value;
            }
        }

        //get / set MoNumber
        public string MONumber
        {
            get
            {
                return mMONumber;
            }
            set
            {
                mMONumber = value;
            }
        }

        //get / set ItemNumber
        public string ItemNumber
        {
            get
            {
                return mItemNumber;
            }
            set
            {
                mItemNumber = value;
            }
        }

        //get / set Sequence
        public string Sequence
        {
            get
            {
                return mSequence;
            }
            set
            {
                mSequence = value;
            }
        }

        //get / set QtyManufactured
        public string QtyManufactured
        {
            get
            {
                return mQtyManufactured;
            }
            set
            {
                mQtyManufactured = value;
            }
        }

        //get / set QtyRequired
        public string QtyRequired
        {
            get
            {
                return mQtyRequired;
            }
            set
            {
                mQtyRequired = value;
            }
        }

        //get / set QtyRejected
        public string QtyRejected
        {
            get
            {
                return mQtyRejected;
            }
            set
            {
                mQtyRejected = value;
            }
        }

        //get / set QtyRemaining
        public string QtyRemaining
        {
            get
            {
                return mQtyRemaining;
            }
            set
            {
                mQtyRemaining = value;
            }
        }

        //get / set TotalTime
        public string TotalTime
        {
            get
            {
                return mTotalTime;
            }
            set
            {
                mTotalTime = value;
            }
        }

        //get / set DownTime
        public string DownTime
        {
            get
            {
                return mDownTime;
            }
            set
            {
                mDownTime = value;
            }
        }

        //set up texts
        private void frmEntryAcceptance_Load(object sender, EventArgs e)
        {
            lblTotalTimeData.Text = mTotalTime + " minutes";
            lblQtyRejectedData.Text = mQtyRejected;
            lblDownTimeData.Text = mDownTime + " minutes";
            lblQtyRemainingData.Text = mQtyRemaining;
            lblItemNumberData.Text = mItemNumber;
            lblUserIDData.Text = mUserID;
            lblSequenceData.Text = mSequence;
            lblQtyRequiredData.Text = mQtyRequired;
            lblQtyManufacturedData.Text = mQtyManufactured;
            lblMONumberData.Text = mMONumber;
        }
    }
}
