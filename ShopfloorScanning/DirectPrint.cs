using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Reporting.WinForms;
using System.Configuration;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;

namespace ShopfloorScanning
{
    class DirectPrint
    {
        private ReportParameter[] mReportParams;
        private Uri mServerURL;
        private string mReportPath;
        private string mPrinterName;
        int mCurrentPrintPage;
        private byte[][] mRenderedReport;
        private int NumberOfPages;
        private short mCopies;
        private ReportRS.ParameterValue[] mParameterValue;

        //constructor
        public DirectPrint()
        {
            mPrinterName = "";
            mReportPath = "";
            mReportParams = null;
            mCopies = 1;
            mServerURL = null;
        }

        //report params
        public ReportParameter[] ReportParameters
        {
            set
            {
                mReportParams = value;
            }
        }

        //report params value for via service print
        public ReportRS.ParameterValue[] ParameterValue
        {
            set
            {
                mParameterValue = value;
            }
        }

        //set server URL
        public Uri ServerURL
        {
            set
            {
                mServerURL = value;
            }
        }

        //patch to report
        public string ReportPath
        {
            set 
            {
                mReportPath = value;
            }
        }

        //printer name setup
        public string PrinterName
        {
            set 
            {
                mPrinterName = value;
            }
        }

        //number of copies
        public short NumberOfCopies
        { 
            set 
            {
                mCopies = value;
            }
        }

        //print report
        public bool PrintReport()
        {
            ReportViewer mReportViewer = new ReportViewer();

            mReportViewer.ProcessingMode = ProcessingMode.Remote;
            ServerReport serverReport = mReportViewer.ServerReport;

            // Get a reference to the default credentials
            System.Net.ICredentials credentials = System.Net.CredentialCache.DefaultCredentials;

            // Get a reference to the report server credentials
            ReportServerCredentials rsCredentials = serverReport.ReportServerCredentials;

            // Set the credentials for the server report
            rsCredentials.NetworkCredentials = credentials;

            // Set the report server URL and report path
            serverReport.ReportServerUrl = mServerURL;
            serverReport.ReportPath = mReportPath;

            mReportViewer.ServerReport.SetParameters(mReportParams);
            
            // render the report
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            Byte[] firstPage = null;
            Byte[][] pages = null;
            string deviceInfo = null;

            // Build device info based on the start page
            deviceInfo = String.Format(@"<DeviceInfo><OutputFormat>{0}</OutputFormat></DeviceInfo>", "EMF");

            firstPage = mReportViewer.ServerReport.Render("IMAGE", deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);

            NumberOfPages = streamids.Length + 1;
            pages = new Byte[NumberOfPages][];

            pages[0] = firstPage;

            //render other pages
            for (int pageIndex = 1; pageIndex < NumberOfPages; pageIndex++)
            {
                // Build device info based on start page
                deviceInfo = String.Format(@"<DeviceInfo><OutputFormat>{0}</OutputFormat><StartPage>{1}</StartPage></DeviceInfo>", "EMF", pageIndex + 1);
                pages[pageIndex] = mReportViewer.ServerReport.Render("IMAGE", deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
            }

            //keep report
            mRenderedReport = pages;

            if (NumberOfPages < 1)
                return false;

            //setup printer
            PrinterSettings printerSettings = new PrinterSettings();
            printerSettings.MaximumPage = NumberOfPages;
            printerSettings.MinimumPage = 1;
            printerSettings.PrintRange = PrintRange.SomePages;
            printerSettings.FromPage = 1;
            printerSettings.ToPage = NumberOfPages;
            printerSettings.PrinterName = mPrinterName;
            printerSettings.Copies = mCopies;
            
            //setup document for print
            PrintDocument pd = new PrintDocument();
            mCurrentPrintPage = 1;
            pd.PrinterSettings = printerSettings;
            
            // Print report
            pd.PrintPage += new PrintPageEventHandler(this.DocumentPrintPage);
            pd.Print();

            return true;
        }

        public bool PrintReportViaService()
        {
            ReportRS.ReportingService rs = new ShopfloorScanning.ReportRS.ReportingService();
            ReportRS.ParameterValue[] reportHistoryParameters = null;
            
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
                
            // render the report
            ReportRS.Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            Byte[] firstPage = null;
            Byte[][] pages = null;
            string deviceInfo = null;

            // Build device info based on the start page
            deviceInfo = String.Format(@"<DeviceInfo><OutputFormat>{0}</OutputFormat></DeviceInfo>", "EMF");

            //Exectute the report and get page count.
            // Renders the first page of the report and returns streamIDs for 
            // subsequent pages
            firstPage = rs.Render(mReportPath, "IMAGE", null, deviceInfo, mParameterValue, null, null, out encoding, out mimeType, out reportHistoryParameters, out warnings, out streamids);
            
            // The total number of pages of the report is 1 + the streamIDs         
            NumberOfPages = streamids.Length + 1;
            pages = new Byte[NumberOfPages][];

            // The first page was already rendered
            pages[0] = firstPage;

            for (int pageIndex = 1; pageIndex < NumberOfPages; pageIndex++)
            {
                // Build device info based on start page
                deviceInfo = String.Format(@"<DeviceInfo><OutputFormat>{0}</OutputFormat><StartPage>{1}</StartPage></DeviceInfo>", "EMF", pageIndex + 1);
                pages[pageIndex] = rs.Render(mReportPath, "IMAGE", null, deviceInfo, mParameterValue, null, null, out encoding, out mimeType, out reportHistoryParameters, out warnings, out streamids);
            }

            //keep report
            mRenderedReport = pages;

            if (NumberOfPages < 1)
                return false;

            //setup printer
            PrinterSettings printerSettings = new PrinterSettings();
            printerSettings.MaximumPage = NumberOfPages;
            printerSettings.MinimumPage = 1;
            printerSettings.PrintRange = PrintRange.SomePages;
            printerSettings.FromPage = 1;
            printerSettings.ToPage = NumberOfPages;
            printerSettings.PrinterName = mPrinterName;
            printerSettings.Copies = mCopies;
            
            //setup document for print
            PrintDocument pd = new PrintDocument();
            mCurrentPrintPage = 1;
            pd.PrinterSettings = printerSettings;
            
            // Print report
            pd.PrintPage += new PrintPageEventHandler(this.DocumentPrintPage);
            pd.Print();

            return true;
        }

        //even handler for page print
        private void DocumentPrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(new MemoryStream(mRenderedReport[mCurrentPrintPage - 1]));
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            mCurrentPrintPage++;
            ev.HasMorePages = (mCurrentPrintPage <= NumberOfPages);
        }
    }
}