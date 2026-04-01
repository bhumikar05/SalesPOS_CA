using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALUPSSettings
    {
        //public DataTable Select(BOLUPSSettings obj)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPUPSSettings";
        //    cmd.Parameters.AddWithValue("@Spara", "Select");
        //    DAL DAL = new DAL();
        //    DataTable dt = DAL.Select(cmd);
        //    return dt;
        //}

        public DataTable Select()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFedExSettings";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Insert_Update(BOLUPSSettings obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFedExSettings";
            cmd.Parameters.AddWithValue("@Spara", "Insert_Update");
            cmd.Parameters.AddWithValue("@AccountNo", obj.AccountNo);
            cmd.Parameters.AddWithValue("@ClientID", obj.ClientID);
            cmd.Parameters.AddWithValue("@ClientSecret", obj.ClientSecret);
            cmd.Parameters.AddWithValue("@AccessToken", obj.AccessToken);
            cmd.Parameters.AddWithValue("@RefreshToken", obj.RefreshToken);
            cmd.Parameters.AddWithValue("@Type", obj.Type);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void UPDATEToken(string Token, string Type)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFedExSettings";
            cmd.Parameters.AddWithValue("@Spara", "UPDATEToken");
            cmd.Parameters.AddWithValue("@AccessToken", Token);
            cmd.Parameters.AddWithValue("@Type", Type);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }


        public DataTable SelectByType(string Type)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFedExSettings";
            cmd.Parameters.AddWithValue("@Spara", "SelectByType");
            cmd.Parameters.AddWithValue("@Type", Type);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }


        //public void Insert(BOLUPSSettings obj)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPUPSSettings";
        //    cmd.Parameters.AddWithValue("@Spara", "Insert");
        //    cmd.Parameters.AddWithValue("@ID", obj.ID);
        //    cmd.Parameters.AddWithValue("@UPSAccessLicenseKey", obj.UPSAccessLicenseKey);
        //    cmd.Parameters.AddWithValue("@UPSUserName", obj.UPSUserName);
        //    cmd.Parameters.AddWithValue("@UPSPassword", obj.UPSPassword);
        //    DAL DAL = new DAL();
        //    DAL.Insert(cmd);
        //}

        //public void Update(BOLUPSSettings obj)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPUPSSettings";
        //    cmd.Parameters.AddWithValue("@Spara", "Update");
        //    cmd.Parameters.AddWithValue("@ID", obj.ID);
        //    cmd.Parameters.AddWithValue("@UPSAccessLicenseKey", obj.UPSAccessLicenseKey);
        //    cmd.Parameters.AddWithValue("@UPSUserName", obj.UPSUserName);
        //    cmd.Parameters.AddWithValue("@UPSPassword", obj.UPSPassword);
        //    DAL DAL = new DAL();
        //    DAL.Insert(cmd);
        //}
        //public DataTable SelectByType(string Type)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPFedExSettings";
        //    cmd.Parameters.AddWithValue("@Spara", "SelectByType");
        //    cmd.Parameters.AddWithValue("@Type", Type);
        //    DAL DAL = new DAL();
        //    DataTable dt = DAL.Select(cmd);
        //    return dt;
        //}

        //public void UPDATEToken(string Token, string Type)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPFedExSettings";
        //    cmd.Parameters.AddWithValue("@Spara", "UPDATEToken");
        //    cmd.Parameters.AddWithValue("@AccessToken", Token);
        //    cmd.Parameters.AddWithValue("@Type", Type);
        //    DAL DAL = new DAL();
        //    DAL.Update(cmd);
        //}

    }
}
