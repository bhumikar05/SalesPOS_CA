using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALCustomerRequest
    {
        public DataTable Select(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByRefnumber()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectByRefnumber");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByInvoice(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectByInvoice");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByID(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectBySalesRepID(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectBySalesRepID");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByCusID(string ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectByInvID");
            cmd.Parameters.AddWithValue("@CustomerID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void DeleteRequest(string ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "DeleteRequest");
            cmd.Parameters.AddWithValue("@CustomerID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public DataTable SelectByApproveCount(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectByApproveCount");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectAdminPendingRequest(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectAdminPendingRequest");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectAdminPendingRequestCount(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectAdminPendingRequestCount");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectPendingStatus(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectPendingStatus");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectApprovedStatus(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectApprovedStatus");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }


        public DataTable SelectApprovedStatusCustomerRequest(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectApprovedStatusCustomerRequest");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            cmd.Parameters.AddWithValue("@InvoiceNumber", obj.InvoiceNumber);
            cmd.Parameters.AddWithValue("@LowestPrice", obj.LowestPrice);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void Insert(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@InvoiceNumber", obj.InvoiceNumber);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            cmd.Parameters.AddWithValue("@LowestPrice", obj.LowestPrice);
            cmd.Parameters.AddWithValue("@Status", obj.Status);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            cmd.Parameters.AddWithValue("@IsRead", obj.IsRead);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void UpdateStatus(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "UpdateStatus");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@AllowesNo", obj.AllowesNo);
            cmd.Parameters.AddWithValue("@NoOFDays", obj.NoOFDays);
            cmd.Parameters.AddWithValue("@CurrentInvoice", obj.CurrentInvoice);
            cmd.Parameters.AddWithValue("@UseAllowesNo", obj.UseAllowesNo);
            cmd.Parameters.AddWithValue("@UseNoOFDays", obj.UseNoOFDays);
            cmd.Parameters.AddWithValue("@UseCurrentInvoice", obj.UseCurrentInvoice);
            cmd.Parameters.AddWithValue("@Status", obj.Status);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@ModifiedID", obj.ModifiedID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void UpdateRejectStatus(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "UpdateRejectStatus");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Status", obj.Status);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@ModifiedID", obj.ModifiedID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void UpdateUseData(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "UpdateUseData");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@UseAllowesNo", obj.UseAllowesNo);
            cmd.Parameters.AddWithValue("@UseNoOFDays", obj.UseNoOFDays);
            cmd.Parameters.AddWithValue("@UseCurrentInvoice", obj.UseCurrentInvoice);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void Delete(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "DeleteByNo");
            cmd.Parameters.AddWithValue("@InvoiceNumber", obj.InvoiceNumber);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public DataTable SelectForReject(string InvoiceNo, string ItemID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectForReject");
            cmd.Parameters.AddWithValue("@InvoiceNumber", InvoiceNo);
            cmd.Parameters.AddWithValue("@ItemID", ItemID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByDate(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectByDate");
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectForRejectCheck(string InvoiceNo, string ItemID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectForRejectCheck");
            cmd.Parameters.AddWithValue("@InvoiceNumber", InvoiceNo);
            cmd.Parameters.AddWithValue("@ItemID", ItemID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }


        //Hiren
        public DataTable SelectByFilter(BOLCustomerRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectByFilter");
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }



    }
}
