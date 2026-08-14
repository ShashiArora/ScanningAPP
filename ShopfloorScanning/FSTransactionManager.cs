using SoftBrands.FourthShift.Transaction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopfloorScanning
{
    public class FSTransactionManager
    {
        public FSTIClient fstiClient;

        private bool UnifiedLogon = Convert.ToBoolean(ConfigurationManager.AppSettings["UnifiedLogon"].ToString());
        private bool Impersonation = Convert.ToBoolean(ConfigurationManager.AppSettings["Impersonation"].ToString());
      
        private string fstiSystem = ConfigurationManager.AppSettings["fstiSystem"].ToString();
        private string fstiServer = ConfigurationManager.AppSettings["fstiServer"].ToString();

        public void FSTIConnect(string username, string password)
        {
            int status;
            string message = null;
            
            try
            {
                fstiClient = new FSTIClient();
                fstiClient.InitializeBySystemName(fstiSystem, fstiServer, UnifiedLogon, Impersonation, "7361");
                if (fstiClient.IsLogonRequired)
                {
                    status = fstiClient.Logon(username, password, ref message);
                    if (status > 0)
                    {
                        SendEMailError("Cannot login to Fourth Shift. Please check settings." + message);
                        FSTIClose();
                    }
                }
            }
            catch (Exception ex)
            {
                SendEMailError("Can't Connect to FSTI!" + ex.Message);
                FSTIClose();
            }
        }

        //close FSTI interface
        public void FSTIClose()
        {
            if (fstiClient != null)
            {
                fstiClient.Terminate();
                fstiClient = null;
            }
        }
        public void SendEMailError(string sErrorMsg)
        {
            try
            {
                string username = Environment.UserName;
                string machineName = Environment.MachineName;
                string domain = Environment.UserDomainName;
                string userSid = WindowsIdentity.GetCurrent().User?.Value;

                // Append system info to the error message
                string systemInfo = $"User: {domain}\\{username}\n" +
                                    $"Machine: {machineName}\n" +
                                    $"SID: {userSid}\n\n";

                string fullErrorMsg = systemInfo + sErrorMsg;

                // Read from App.config
                string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
                int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);

                string mailFrom = ConfigurationManager.AppSettings["MailFrom"];
                string mailBccList = ConfigurationManager.AppSettings["MailBcc"];
                string subjectPrefix = ConfigurationManager.AppSettings["MailSubjectPrefix"];

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(mailFrom);
                    mail.Subject = subjectPrefix + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    mail.Body = fullErrorMsg;
                    mail.Priority = MailPriority.Normal;

                    // Add BCC recipients from config
                    foreach (var address in mailBccList.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        mail.Bcc.Add(address.Trim());
                    }

                    using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                    {
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
