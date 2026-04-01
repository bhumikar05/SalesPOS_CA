using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALCustomerMaster
    {
        public DataTable SelectUnAssignedCustomerList(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectUnAssignedCustomerList");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void UpdateCustomer(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateCustomer");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public DataTable SelectAssignedCustomerList(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectAssignedCustomerList");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByTerms(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByTerms");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable Search(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "Search");
            cmd.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@IsCustomerNumber", obj.IsCustomerNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByAll(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByAll");
            cmd.Parameters.AddWithValue("@SalesRepID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable Select(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@IsCustomerNumber", obj.IsCustomerNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByUpdateName(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByUpdateName");
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectAllCustomer(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectAllCustomer");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectCustomer(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectCustomer");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public DataTable SelectAll(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectCustByDate");
            cmd.Parameters.AddWithValue("@StartD", obj.StartD);
            cmd.Parameters.AddWithValue("@EndD", obj.EndD);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectActiveCustomer(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectActiveCustomer");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@IsCustomerNumber", obj.IsCustomerNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectPriceTier()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectPriceTier");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable UpdatePriceTier(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdatePriceTier");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@PriceTier", obj.PriceTier);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByCustomerPriceTier(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByCustomerPriceTier");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectBySalesRep(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectAll");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public DataTable SelectCus(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectAll");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public DataTable SelectOpenBalanceCustomer(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectOpenBalanceCustomer");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@IsCustomerNumber", obj.IsCustomerNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public DataTable SelectCustomerWithOverDueInvoices(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectCustomerWithOverDueInvoices");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@IsCustomerNumber", obj.IsCustomerNumber);

            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public DataTable SelectByID(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectBySalesRap(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectBySalesRap");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByAddressID(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByAddressID");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public DataTable SelectByFullName(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByFullName");
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public int Insert(BOLCustomerMaster obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@ParentID", obj.ParentID);
            cmd.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
            cmd.Parameters.AddWithValue("@CustomerDate", obj.CustomerDate);
            cmd.Parameters.AddWithValue("@Salutation", obj.Salutation);
            cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", obj.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", obj.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", obj.JobTitle);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
            cmd.Parameters.AddWithValue("@Fax", obj.Fax);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@CcEmail", obj.CcEmail);
            cmd.Parameters.AddWithValue("@Other", obj.Other);
            cmd.Parameters.AddWithValue("@WorkPhone", obj.WorkPhone);
            cmd.Parameters.AddWithValue("@WebSite", obj.WebSite);
            cmd.Parameters.AddWithValue("@TermsID", obj.TermsID);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@Balance", obj.Balance);
            cmd.Parameters.AddWithValue("@TotalBalance", obj.TotalBalance);
            cmd.Parameters.AddWithValue("@AccountNumber", obj.AccountNumber);
            cmd.Parameters.AddWithValue("@PaymentMethodID", obj.PaymentMethodID);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@IsSync", obj.IsSync);
            cmd.Parameters.AddWithValue("@PayPalName", obj.PayPalName);
            cmd.Parameters.AddWithValue("@PayPalEmail", obj.PayPalEmail);
            cmd.Parameters.AddWithValue("@AllowLowestPrice", obj.AllowLowestPrice);
            //Hiren
            cmd.Parameters.AddWithValue("@SalesTaxID", obj.SalesTaxID);
            //princy
            cmd.Parameters.AddWithValue("@SalesRepCode", obj.SalesRepCode);
            DAL DAL = new DAL();
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }
        public int NewInsert(BOLCustomerMaster obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNewCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            //cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@PosID", obj.PosID);
            cmd.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            //cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            //cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            DAL DAL = new DAL();
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }
        public int NewUpdate(BOLCustomerMaster obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNewCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            //cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@PosID", obj.PosID);
            cmd.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            //cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            DAL DAL = new DAL();
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }
        public int Update(BOLCustomerMaster obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@ParentID", obj.ParentID);
            cmd.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
            cmd.Parameters.AddWithValue("@CustomerDate", obj.CustomerDate);
            cmd.Parameters.AddWithValue("@Salutation", obj.Salutation);
            cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", obj.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", obj.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", obj.JobTitle);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
            cmd.Parameters.AddWithValue("@Fax", obj.Fax);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@CcEmail", obj.CcEmail);
            cmd.Parameters.AddWithValue("@Other", obj.Other);
            cmd.Parameters.AddWithValue("@WorkPhone", obj.WorkPhone);
            cmd.Parameters.AddWithValue("@WebSite", obj.WebSite);
            cmd.Parameters.AddWithValue("@TermsID", obj.TermsID);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@AccountNumber", obj.AccountNumber);
            cmd.Parameters.AddWithValue("@PaymentMethodID", obj.PaymentMethodID);
            cmd.Parameters.AddWithValue("@ModifiedID", obj.ModifiedID);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@IsSync", obj.IsSync);
            cmd.Parameters.AddWithValue("@Remainderday", obj.Remainderday);
            cmd.Parameters.AddWithValue("@PayPalName", obj.PayPalName);
            cmd.Parameters.AddWithValue("@PayPalEmail", obj.PayPalEmail);
            //Hiren
            cmd.Parameters.AddWithValue("@SalesTaxID", obj.SalesTaxID);
            //princy
            cmd.Parameters.AddWithValue("@SalesRepCode", obj.SalesRepCode);

            DAL DAL = new DAL();
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }
        public void UpdateSalesRepID(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateSalesRepID");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@SalesRepAll", obj.SalesRepAll);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void UpdateCustomerBalance(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateCustomerBalance");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@TotalBalance", obj.TotalBalance);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void Delete(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public DataTable SelectByParentID(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByParentID");
            cmd.Parameters.AddWithValue("@ParentID", obj.ParentID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectParentAndChildCustomer(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectParentAndChildCustomer");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void UpdateFullName(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateFullName");
            cmd.Parameters.AddWithValue("@ParentID", obj.ParentID);
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public DataTable CustomerInvoiceList(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "CustomerInvoiceList");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable CustomerSummaryList(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "CustomerSummaryList");
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectInActiveCustomer(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectInActiveCustomer");
            cmd.Parameters.AddWithValue("@FromDate", obj.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void UpdateInactiveTransferActive(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateInactiveTransferActive");
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public void UpdateAllowLowest(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateAllowLowest");
            cmd.Parameters.AddWithValue("@AllowLowestPrice", obj.AllowLowestPrice);
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public DataTable SelectInActiveCustomerSalesRep(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectInActiveCustomerSalesRep");
            cmd.Parameters.AddWithValue("@FromDate", obj.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByIdForEmail(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByIdForEmail");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectTransferCustomerList()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectTransferCustomerList");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectAllList()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectActive");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectAssignCustomer()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectAssignCustomer");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectTransferCustomerListByDays(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectTransferCustomerListByDays");
            cmd.Parameters.AddWithValue("@FromDate", obj.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectAllCustomerListByDays(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectAllCustomerListByDays");
            cmd.Parameters.AddWithValue("@FromDate", obj.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectAssignCustomerByDays(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectAssignCustomerByDays");
            cmd.Parameters.AddWithValue("@FromDate", obj.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectActiveCustomerByDays(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectActiveCustomerByDays");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@FromDate", obj.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public DataTable SelectForNewCustomer(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();                                                                                
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectForNewCustomer");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@IsCustomerNumber", obj.IsCustomerNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public DataTable SelectPayPalName(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectPayPalName");
            cmd.Parameters.AddWithValue("@PayPalName", obj.PayPalName);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        //Export
        public DataTable SelectActiveCustomerExport(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectActiveCustomerExport");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@IsCustomerNumber", obj.IsCustomerNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectExport(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectExport");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@IsCustomerNumber", obj.IsCustomerNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectOpenBalanceCustomerExport(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectOpenBalanceCustomerExport");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@IsCustomerNumber", obj.IsCustomerNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectCustomerWithOverDueInvoicesExport(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectCustomerWithOverDueInvoicesExport");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@IsCustomerNumber", obj.IsCustomerNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectForNewCustomerExport(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectForNewCustomerExport");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        //Nidhi ADD
        public DataTable SelectAllCustomerName(BOLCustomerMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "ReceivePaymentCustomer");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectAgingReport()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster";
            cmd.Parameters.AddWithValue("@Spara", "CustomerAgingReport");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}

