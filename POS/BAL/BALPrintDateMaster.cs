using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;


namespace POS.BAL
{
    class BALPrintDateMaster
    {
        public DataTable Select()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_PrintDateMaster";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void UpdatePrint(BOLPrintDateMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_PrintDateMaster";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            cmd.Parameters.AddWithValue("@Flag", obj.Flag);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public void UpdateFlag(BOLPrintDateMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_PrintDateMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateFlag");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Flag", obj.Flag);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
    }
}
