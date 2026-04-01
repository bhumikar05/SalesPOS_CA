using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALFromShipping
    {
        public DataTable Select(BOLFromShipping obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFromShippingAddress";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectUPS(BOLFromShipping obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFromShippingAddress";
            cmd.Parameters.AddWithValue("@Spara", "SelectUPS");
            cmd.Parameters.AddWithValue("@FromAddress", obj.FromAddress);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectByID(BOLFromShipping obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFromShippingAddress";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void Insert(BOLFromShipping obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFromShippingAddress";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@FromAddress", obj.FromAddress);
            cmd.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Address1", obj.Address1);
            cmd.Parameters.AddWithValue("@Address2", obj.Address2);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@Zip", obj.Zip);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@Country", obj.Country);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Update(BOLFromShipping obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFromShippingAddress";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@FromAddress", obj.FromAddress);
            cmd.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Address1", obj.Address1);
            cmd.Parameters.AddWithValue("@Address2", obj.Address2);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@Zip", obj.Zip);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@Country", obj.Country);
            cmd.Parameters.AddWithValue("@ModifiedID", obj.ModifiedID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Delete(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFromShippingAddress";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
