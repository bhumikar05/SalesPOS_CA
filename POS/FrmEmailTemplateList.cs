using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace POS
{
    public partial class FrmEmailTemplateList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public string Type = ""; string FullName = ""; string FirstName = ""; string LastName = ""; string InvoiceNumber = ""; string CusEmail = "";
        decimal TransactionTotal = 0; string CompanyName = ""; string TxnDate = ""; string ShipDate = ""; string DueDate = "";
        string Subject = ""; string Body = ""; string URL = ""; string TrackingNumber = ""; string ShipCompany = ""; string TransactionID = ""; decimal PaymentAmount = 0; decimal BalanceDue = 0;
        string FilePathPDF = ""; Boolean Path = false;
        DataTable dtFrom = new DataTable(); DataTable dtTo = new DataTable();
        //Hiren
        DataTable dtCC = new DataTable();
        public string CusID = "";

        public FrmEmailTemplateList()
        {
            InitializeComponent();
        }

        private void FrmEmailTemplateList_Load(object sender, EventArgs e)
        {
            GetTemplateName();
            GetFromEmail();
            GetToEmail();
            //Hiren
            GetToCC();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void GetTemplateName()
        {
            try
            {
                DataTable dtTemplateName = new BALEmailTemplate().SelectByTemplateType(new BOLEmailTemplate() { TemplateType = Type });
                DataRow dr = dtTemplateName.NewRow();
                dr["TemplateName"] = "--Select--";
                dr["ID"] = "0";
                dtTemplateName.Rows.InsertAt(dr, 0);
                cmbTemplateName.DataSource = dtTemplateName;
                cmbTemplateName.DisplayMember = "TemplateName";
                cmbTemplateName.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailTemplateList,Function :GetTemplateName. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetFromEmail()
        {
            try
            {
                dtFrom = new DataTable();
                dtFrom.Columns.Add("Email", typeof(string));

                Outlook.Application Application = new Outlook.Application();
                Outlook.Accounts accounts = Application.Session.Accounts;
                foreach (Outlook.Account account in accounts)
                {
                    dtFrom.Rows.Add(account.DisplayName);
                }


                DataRow dr = dtFrom.NewRow();
                dr["Email"] = "--Select--";
                dtFrom.Rows.InsertAt(dr, 0);
                cmbFrom.DataSource = dtFrom;
                cmbFrom.DisplayMember = "Email";
                cmbFrom.ValueMember = "Email";
                cmbFrom.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailTemplateList,Function :GetFromEmail. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetToEmail()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("ID", typeof(string));

                dtTo = new BALCustomerMaster().SelectByIdForEmail(new BOLCustomerMaster() { ID = Convert.ToInt32(CusID) });
                if (dtTo.Rows.Count > 0)
                {
                    if (dtTo.Rows[0]["Email"].ToString() != "")
                        dt.Rows.Add(dtTo.Rows[0]["Email"].ToString(), dtTo.Rows[0]["ID"].ToString());
                    //if (dtTo.Rows[0]["CcEmail"].ToString() != "")
                    //    dt.Rows.Add(dtTo.Rows[0]["CcEmail"].ToString(), dtTo.Rows[0]["ID"].ToString());

                    DataRow dr = dt.NewRow();
                    dr["Email"] = "--Select--";
                    dr["ID"] = "0";
                    dt.Rows.InsertAt(dr, 0);
                    cmbTo.DataSource = dt;
                    cmbTo.DisplayMember = "Email";
                    cmbTo.ValueMember = "ID";
                    cmbTo.SelectedIndex = 0;
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["Email"] = "--Select--";
                    dr["ID"] = "0";
                    dt.Rows.InsertAt(dr, 0);
                    cmbTo.DataSource = dt;
                    cmbTo.DisplayMember = "Email";
                    cmbTo.ValueMember = "ID";
                    cmbTo.SelectedIndex = 0;
                }


            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailTemplateList,Function :GetFromEmail. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void EmialCustomerStatement(string TemplateType, string Email, string FilePath, string CustomerID)
        {
            try
            {
                chkAttach.Visible = true;
                chkAttach.Checked = true;
                Type = TemplateType;
                CusEmail = Email;
                FilePathPDF = FilePath;
                CusID = CustomerID;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:EmialCustomerStatement,Function :LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void EmialLoadData(string TemplateType, string FullNm, string FN, string LN, string InvNo, decimal TraTotal, string CName, string TDate, string SDate, string DDate, string Email, string FilePath, string CustomerID)
        {
            try
            {
                chkAttach.Visible = true;
                Type = TemplateType;
                FullName = FullNm;
                FirstName = FN;
                LastName = LN;
                InvoiceNumber = InvNo;
                TransactionTotal = TraTotal;
                CompanyName = CName;
                if (TDate != "")
                {
                    TxnDate = Convert.ToDateTime(TDate).ToString("MM-dd-yyyy");
                }
                if (SDate != "")
                {
                    ShipDate = Convert.ToDateTime(SDate).ToString("MM-dd-yyyy");
                }
                if (DDate != "")
                {
                    DueDate = Convert.ToDateTime(DDate).ToString("MM-dd-yyyy");
                }
                CusEmail = Email;
                FilePathPDF = FilePath;
                CusID = CustomerID;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailTemplateList,Function :LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void EmialLoadDataPayment(string TemplateType, string FullNm, string FN, string LN, string InvNo, decimal TraTotal, string CName, string TDate, string SDate, string DDate, string Email, string TranID, decimal PaymentAmt, decimal BalDue, string CustomerID)
        {
            try
            {
                Type = TemplateType;
                FullName = FullNm;
                FirstName = FN;
                LastName = LN;
                InvoiceNumber = InvNo;
                TransactionTotal = TraTotal;
                CompanyName = CName;
                TxnDate = Convert.ToDateTime(TDate).ToString("MM-dd-yyyy");
                ShipDate = Convert.ToDateTime(SDate).ToString("MM-dd-yyyy");
                DueDate = Convert.ToDateTime(DDate).ToString("MM-dd-yyyy");
                CusEmail = Email;
                TransactionID = TranID;
                PaymentAmount = PaymentAmt;
                BalanceDue = BalDue;
                CusID = CustomerID;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailTemplateList,Function :EmialLoadDataPayment. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void EmialLoadDataTracking(string TemplateType, string FullNm, string FN, string LN, string InvNo, string CName, string Email, string url, string trackingnumber, string shipcompany, string CustomerID)
        {
            try
            {
                Type = TemplateType;
                FullName = FullNm;
                FirstName = FN;
                LastName = LN;
                InvoiceNumber = InvNo;
                CompanyName = CName;
                CusEmail = Email;
                URL = url;
                TrackingNumber = trackingnumber;
                ShipCompany = shipcompany;
                CusID = CustomerID;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailTemplateList,Function :EmialLoadDataTracking. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean checkEmail()
        {
            Boolean x = true;
            string email = txtToEmail.Text;
            string CC = txtCC.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            Match match1 = regex.Match(CC);

            if (radioButton2.Checked == true)
            {
                if (match.Success)
                {

                }
                else
                {
                    MessageBox.Show("Enter ValidEmail");

                    txtToEmail.Clear();
                    x = false;
                    txtToEmail.Focus();
                }
            }
            if (txtCC.Text != "")
            {
                if (match1.Success)
                {

                }
                else
                {
                    MessageBox.Show("Enter ValidEmail");

                    txtCC.Clear();
                    x = false;
                    txtCC.Focus();
                }
            }
            return x;
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTemplateName.SelectedIndex > 0)
                {
                    if (checkEmail())
                    {
                        Subject = ""; Body = ""; string CC = "";
                        DataTable dt = new BALEmailTemplate().SelectByID(new BOLEmailTemplate() { ID = Convert.ToInt32(cmbTemplateName.SelectedValue) });
                        if (dt.Rows.Count > 0)
                        {
                            if (cmbFrom.SelectedIndex > 0)
                            {
                                if (cmbTo.SelectedIndex == 0 && txtToEmail.Text == "")
                                {
                                    MessageBox.Show("Please select To Email..!!");
                                    goto Final;
                                }
                                string ToEmail = "";
                                if (radioButton1.Checked == true && cmbTo.SelectedIndex == 0)
                                {
                                    MessageBox.Show("Please select To Email..!!");
                                    goto Final;
                                }
                                if (radioButton1.Checked == true)
                                {
                                    ToEmail = cmbTo.Text;
                                    //Hiren
                                    CC = cmbCC.Text;
                                }
                                else
                                {
                                    ToEmail = txtToEmail.Text;
                                    //Hiren
                                    CC = txtCC.Text;
                                }
                                //CC = txtCC.Text;

                                Subject = dt.Rows[0]["Subject"].ToString().Replace("{InvoiceNumber}", InvoiceNumber);
                                Body = dt.Rows[0]["Body"].ToString().Replace("{CustomerFullName}", FullName).Replace("{FirstName}", FirstName).Replace("{LastName}", LastName).Replace("{InvoiceNumber}", InvoiceNumber).Replace("{TransactionTotal}", TransactionTotal.ToString()).Replace("{CompanyName}", CompanyName).Replace("{TxnDate}", TxnDate.ToString()).Replace("{ShipDate}", ShipDate.ToString()).Replace("{DueDate}", DueDate.ToString()).Replace("{TransactionID}", TransactionID.ToString()).Replace("{PaymentAmount}", PaymentAmount.ToString()).Replace("{BalanceDue}", BalanceDue.ToString()).Replace("{URL}", URL.ToString()).Replace("{TRACKINGNUMBER}", TrackingNumber.ToString()).Replace("{SHIPCOMPANY}", ShipCompany.ToString());
                                //SendEmail(CusEmail, Subject, Body, FilePathPDF);
                                try
                                {
                                    SendEmail(ToEmail, CC, Subject, Body, FilePathPDF);
                                    MessageBox.Show("Email Send Successfully");
                                }
                                catch (Exception ex)
                                {
                                    ClsCommon.WriteErrorLogs("Form:FrmEmailTemplateList,Function :btnEmail_Click. Message:" + ex.Message);
                                    MessageBox.Show("Error:" + ex.Message);
                                }
                            Final:;
                            }
                            else
                            {
                                MessageBox.Show("Please select From Email..!!");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Plese Select TemplateName");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailTemplateList,Function :btnEmail_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }


        public void EmailSend()
        {
            Path = true;
            Subject = ""; Body = ""; string ToEmail = "";
            dtTo = new DataTable();
            DataTable dt = new BALEmailTemplate().SelectByTemplateType(new BOLEmailTemplate() { TemplateType = Type });
            if (dt.Rows.Count > 0)
            {
                Subject = dt.Rows[0]["Subject"].ToString().Replace("{InvoiceNumber}", InvoiceNumber);
                Body = dt.Rows[0]["Body"].ToString().Replace("{CustomerFullName}", FullName).Replace("{FirstName}", FirstName).Replace("{LastName}", LastName).Replace("{InvoiceNumber}", InvoiceNumber).Replace("{TransactionTotal}", TransactionTotal.ToString()).Replace("{CompanyName}", CompanyName).Replace("{TxnDate}", TxnDate.ToString()).Replace("{ShipDate}", ShipDate.ToString()).Replace("{DueDate}", DueDate.ToString()).Replace("{TransactionID}", TransactionID.ToString()).Replace("{PaymentAmount}", PaymentAmount.ToString()).Replace("{BalanceDue}", BalanceDue.ToString()).Replace("{URL}", URL.ToString()).Replace("{TRACKINGNUMBER}", TrackingNumber.ToString()).Replace("{SHIPCOMPANY}", ShipCompany.ToString());

                dtTo = new BALCustomerMaster().SelectByIdForEmail(new BOLCustomerMaster() { ID = Convert.ToInt32(CusID) });
                if (dtTo.Rows.Count > 0)
                {
                    if (dtTo.Rows[0]["Email"].ToString() != "")
                    {
                        ToEmail = dtTo.Rows[0]["Email"].ToString();
                        try
                        {
                            SendEmail(ToEmail, "", Subject, Body, FilePathPDF);
                            MessageBox.Show("Email Send Successfully");
                            Path = false;
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:FrmEmailTemplateList,Function :btnEmail_Click. Message:" + ex.Message);
                            MessageBox.Show("Error:" + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter Email for this Customer");
                    }
                }


            }
        }

        public void SendEmail(string ToEmail, string CC, string Subject, string BodyText, string FileName)
        {
            try
            {

                string Email = ConfigurationManager.AppSettings["Email"].ToString();
                string Password = ConfigurationManager.AppSettings["Password"].ToString();
                string Port = ConfigurationManager.AppSettings["Port"].ToString();
                string Smtp = ConfigurationManager.AppSettings["Smtp"].ToString();
                string IsEnable = ConfigurationManager.AppSettings["IsEnable"].ToString();
                // string BCC = txtToEmail.Text;

                //MailMessage mail = new MailMessage();
                //SmtpClient SmtpServer = new SmtpClient(Smtp.ToString());
                //mail.Sender = new MailAddress(Email);
                //mail.From = new MailAddress(Email);
                //mail.To.Add(ToEmail);
                //mail.Subject = Subject;
                //mail.Body = BodyText;
                //mail.IsBodyHtml = true;
                //MailAddress bcc = new MailAddress(BCC);
                //mail.Bcc.Add(bcc);

                //if (chkAttach.Checked == true && FileName!="")
                //{
                //    mail.Attachments.Add(new Attachment(FileName));
                //}

                //SmtpServer.UseDefaultCredentials = true;
                //SmtpServer.Port = Convert.ToInt32(Port.ToString());
                //SmtpServer.Credentials = new System.Net.NetworkCredential(Email.ToString(), Password.ToString()); //you have to provide you gamil username and password
                //SmtpServer.EnableSsl = Convert.ToBoolean(IsEnable.ToString());
                //SmtpServer.Send(mail);
                //mail.Dispose();



                Outlook._Application _app = new Outlook.Application();
                Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);

                if (cmbFrom.Text != "")
                {
                    Outlook.Account account = GetAccountForEmailAddress(_app, cmbFrom.Text);
                    mail.SendUsingAccount = account;
                }
                else
                {
                    string From = mail.UserProperties.Session.CurrentUser.Address;
                    Outlook.Account account = GetAccountForEmailAddress(_app, From);
                    mail.SendUsingAccount = account;
                }


                if (ToEmail.Contains(","))
                {
                    mail.To = ToEmail.Replace(",", ";");

                    //string[] email = ToEmail.Split(',');
                    //for (int j = 0; j < email.Length; j++)
                    //{
                    //    mail.To.Insert(j,email[j].ToString());
                    //}
                }
                else
                {
                    mail.To = ToEmail;
                }

                mail.CC = CC;
                mail.Subject = Subject;
                mail.HTMLBody = BodyText;


                mail.Importance = Outlook.OlImportance.olImportanceNormal;
                if (chkAttach.Checked == true && FileName != "")
                {
                    mail.Attachments.Add(FileName, Outlook.OlAttachmentType.olByValue);
                }
                else if (Path == true)
                {
                    mail.Attachments.Add(FileName, Outlook.OlAttachmentType.olByValue);
                }
                ((Outlook._MailItem)mail).Send();

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :CustomerEmailSend. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public static Outlook.Account GetAccountForEmailAddress(Outlook._Application application, string smtpAddress)
        {

            try
            {
                // Loop over the Accounts collection of the current Outlook session.
                Outlook.Accounts accounts = application.Session.Accounts;
                //Outlook.Account account;
                foreach (Outlook.Account account1 in accounts)
                {
                    // When the email address matches, return the account.
                    if (account1.SmtpAddress == smtpAddress)
                        return account1;
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :GetAccountForEmailAddress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
            throw new System.Exception(string.Format("No Account with SmtpAddress: {0} exists!", smtpAddress));
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cmbTo.Enabled = true;
                txtToEmail.Enabled = false;
                //Hiren
                cmbCC.Enabled = true;
                txtCC.Enabled = false;
            }
            else
            {
                cmbTo.Enabled = false;
                txtToEmail.Enabled = true;
                //Hiren
                cmbCC.Enabled = false;
                txtCC.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                cmbTo.Enabled = false;
                txtToEmail.Enabled = true;
                //Hiren
                cmbCC.Enabled = false;
                txtCC.Enabled = true;
            }
            else
            {
                cmbTo.Enabled = true;
                txtToEmail.Enabled = false;
                //Hiren
                cmbCC.Enabled = true;
                txtCC.Enabled = false;
            }
        }

        //Hiren
        private void GetToCC()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CcEmail", typeof(string));
                dt.Columns.Add("ID", typeof(string));

                dtCC = new BALCustomerMaster().SelectByIdForEmail(new BOLCustomerMaster() { ID = Convert.ToInt32(CusID) });
                if (dtCC.Rows.Count > 0)
                {
                    //if (dtCC.Rows[0]["Email"].ToString() != "")
                    //    dt.Rows.Add(dtCC.Rows[0]["Email"].ToString(), dtCC.Rows[0]["ID"].ToString());
                    if (dtCC.Rows[0]["CcEmail"].ToString() != "")
                        dt.Rows.Add(dtCC.Rows[0]["CcEmail"].ToString(), dtCC.Rows[0]["ID"].ToString());

                    DataRow dr = dt.NewRow();
                    dr["CcEmail"] = "--Select--";
                    dr["ID"] = "0";
                    dt.Rows.InsertAt(dr, 0);
                    cmbCC.DataSource = dt;
                    cmbCC.DisplayMember = "CcEmail";
                    cmbCC.ValueMember = "ID";
                    cmbCC.SelectedIndex = 0;
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["CcEmail"] = "--Select--";
                    dr["ID"] = "0";
                    dt.Rows.InsertAt(dr, 0);
                    cmbCC.DataSource = dt;
                    cmbCC.DisplayMember = "CcEmail";
                    cmbCC.ValueMember = "ID";
                    cmbCC.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailTemplateList,Function :GetToCC. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}