using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALPaymentMethod
    {
        public DataTable Select(BOLPaymentMethod obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentMethod";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectPaymentMethodType(BOLPaymentMethod obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentMethod";
            cmd.Parameters.AddWithValue("@Spara", "SelectPaymentMethodType");
            cmd.Parameters.AddWithValue("@PaymentMethodType", obj.PaymentMethodType);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentMethod";
            cmd.Parameters.AddWithValue("@Spara", "SelectAll");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Insert(BOLPaymentMethod obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentMethod";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            //Nidhi Change
            cmd.Parameters.AddWithValue("@PaymentMethodType", obj.PaymentMethodType);
            cmd.Parameters.AddWithValue("@IsActive", 1);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public DataTable SelectByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentMethod";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", id);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Update(BOLPaymentMethod obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentMethod";
            cmd.Parameters.AddWithValue("@Spara", "UpdateAll");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            //Nidhi Change
            cmd.Parameters.AddWithValue("@PaymentMethodType", obj.PaymentMethodType);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public void DeleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentMethod";
            cmd.Parameters.AddWithValue("@Spara", "DeleteByID");
            cmd.Parameters.AddWithValue("@ID", id);
            //Nidhi Change
            cmd.Parameters.AddWithValue("@IsActive", 0);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
