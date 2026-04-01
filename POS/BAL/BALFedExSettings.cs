using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALFedExSettings
    {
        public DataTable Select(BOLFedExSettings obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFedExSettings";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        //public void Insert(BOLFedExSettings obj)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPFedExSettings";
        //    cmd.Parameters.AddWithValue("@Spara", "Insert");
        //    cmd.Parameters.AddWithValue("@ID", obj.ID);
        //    cmd.Parameters.AddWithValue("@FedExLicenseKey", obj.FedExLicenseKey);
        //    cmd.Parameters.AddWithValue("@FedExUserName", obj.FedExUserName);
        //    cmd.Parameters.AddWithValue("@FedExPassword", obj.FedExPassword);
        //    DAL DAL = new DAL();
        //    DAL.Insert(cmd);
        //}

        //public void Update(BOLFedExSettings obj)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPFedExSettings";
        //    cmd.Parameters.AddWithValue("@Spara", "Update");
        //    cmd.Parameters.AddWithValue("@ID", obj.ID);
        //    cmd.Parameters.AddWithValue("@FedExLicenseKey", obj.FedExLicenseKey);
        //    cmd.Parameters.AddWithValue("@FedExUserName", obj.FedExUserName);
        //    cmd.Parameters.AddWithValue("@FedExPassword", obj.FedExPassword);
        //    DAL DAL = new DAL();
        //    DAL.Insert(cmd);
        //}


        public void Insert(BOLFedExSettings obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFedExSettings";
            cmd.Parameters.AddWithValue("@Spara", "InsertFedx");
            cmd.Parameters.AddWithValue("@client_id", obj.client_id);
            cmd.Parameters.AddWithValue("@client_secret", obj.client_secret);
            cmd.Parameters.AddWithValue("@FedExAccountNumber", obj.FedExAccountNumber);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void Update(BOLFedExSettings obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFedExSettings";
            cmd.Parameters.AddWithValue("@Spara", "UpdateFedx");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@client_id", obj.client_id);
            cmd.Parameters.AddWithValue("@client_secret", obj.client_secret);
            cmd.Parameters.AddWithValue("@FedExAccountNumber", obj.FedExAccountNumber);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
    }
}
