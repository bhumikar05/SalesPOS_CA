using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALSalesRepMaster
    {
        public DataTable Select(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByPassword(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByPassword");
            cmd.Parameters.AddWithValue("@UserName", obj.UserName);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public int SelectByInitial(string Initial)
        {
            int IsDuplicate = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByInitial");
            cmd.Parameters.AddWithValue("@Initial", Initial);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            if(dt.Rows.Count > 0)
            {
                IsDuplicate = 1;
            }
            return IsDuplicate;
        }
        public DataTable SelectUser(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectUser");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectActiveUser(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectActiveUser");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectLoginUser(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectLoginUser");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectInActiveUser(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectInActiveUser");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectForLogin(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectForLogin")                                                                                                                                                                                                                                                                                                                                              ;
            cmd.Parameters.AddWithValue("@UserName", obj.UserName);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByID(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

       

        public DataTable SelectByName(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByName");
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByUserTypeID(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByUserTypeID");
            cmd.Parameters.AddWithValue("@UserTypeID", obj.UserTypeID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByUser(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByUser");
            cmd.Parameters.AddWithValue("@UserName", obj.UserName);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByUpdateUser(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByUpdateUser");
            cmd.Parameters.AddWithValue("@UserName", obj.UserName);
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByAdminUser(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByAdminUser");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByUpdateName(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByUpdateName");
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByUserName(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByUserName");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByTransferAccess(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByTransferAccess");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SalesRepSummaryList(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SalesRepSummaryList");
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectBySalesRepID(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectBySalesRep");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SalesRepSummaryListCM(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SalesRepSummaryListCM");
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectBySalesRepCM(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectBySalesRepCM");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public int Insert(BOLSalesRepMaster obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
            cmd.Parameters.AddWithValue("@Saluation", obj.Saluation);
            cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", obj.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", obj.LastName);
            cmd.Parameters.AddWithValue("@UserName", obj.UserName);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            cmd.Parameters.AddWithValue("@Contact", obj.Contact);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@Fax", obj.Fax);
            cmd.Parameters.AddWithValue("@AltPhone", obj.AltPhone);
            cmd.Parameters.AddWithValue("@AltContact", obj.AltContact);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@AccountNo", obj.AccountNo);
            cmd.Parameters.AddWithValue("@UserTypeID", obj.UserTypeID);
            cmd.Parameters.AddWithValue("@SalesRepType", obj.SalesRepType);
            cmd.Parameters.AddWithValue("@Initial", obj.Initial);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            cmd.Parameters.AddWithValue("@IsSync", obj.IsSync);
            cmd.Parameters.AddWithValue("@IsLogin", obj.IsLogin);
            cmd.Parameters.AddWithValue("@LowestPriceAllow", obj.LowestPriceAllow);
            cmd.Parameters.AddWithValue("@AssistantAdminID", obj.AssistantAdminID);
            DAL DAL = new DAL();
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }
        public int UpdatePassword(BOLSalesRepMaster obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdatePassword");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            DAL DAL = new DAL();
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }
        public int Update(BOLSalesRepMaster obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
            cmd.Parameters.AddWithValue("@Saluation", obj.Saluation);
            cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", obj.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", obj.LastName);
            cmd.Parameters.AddWithValue("@UserName", obj.UserName);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            cmd.Parameters.AddWithValue("@Contact", obj.Contact);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@Fax", obj.Fax);
            cmd.Parameters.AddWithValue("@AltPhone", obj.AltPhone);
            cmd.Parameters.AddWithValue("@AltContact", obj.AltContact);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@AccountNo", obj.AccountNo);
            cmd.Parameters.AddWithValue("@UserTypeID", obj.UserTypeID);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@ModifiedID", obj.ModifiedID);
            cmd.Parameters.AddWithValue("@IsSync", obj.IsSync);
            cmd.Parameters.AddWithValue("@IsLogin", obj.IsLogin);
            cmd.Parameters.AddWithValue("@LowestPriceAllow", obj.LowestPriceAllow);
            cmd.Parameters.AddWithValue("@AssistantAdminID", obj.AssistantAdminID);
            DAL DAL = new DAL();
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }

        public void UpdateIsLogin(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateIsLogin");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@IsLogin", obj.IsLogin);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Delete(BOLSalesRepMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMaster";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
