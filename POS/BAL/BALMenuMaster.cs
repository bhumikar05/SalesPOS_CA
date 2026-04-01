using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.BOL;
using POS.HelperClass;

namespace POS.BAL
{
    public class BALMenuMaster
    {
        public DataTable Select(BOLMenuMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPMenuMaster";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
