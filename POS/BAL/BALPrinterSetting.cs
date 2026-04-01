using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.BOL;
using POS.HelperClass;

namespace POS.BAL
{
    class BALPrinterSetting
    {
        public void Insert(BOLPrinterSetting obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPrinterSetting";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public DataTable Select()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPrinterSetting";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
