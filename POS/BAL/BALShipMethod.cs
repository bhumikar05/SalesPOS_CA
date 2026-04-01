using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALShipMethod
    {
        public DataTable SelectShipMethod(BOLShipMethod obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPShipMethod";
            cmd.Parameters.AddWithValue("@Spara", "SelectShipMethod");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectShipMethodAll(BOLShipMethod obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPShipMethod";
            cmd.Parameters.AddWithValue("@Spara", "SelectShipMethodAll");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

    }
}
