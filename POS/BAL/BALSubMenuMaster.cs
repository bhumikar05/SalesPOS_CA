using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.BOL;
using POS.HelperClass;

namespace POS.BAL
{
    public class BALSubMenuMaster
    {
        public DataTable SelectByMenuID(BOLSubMenuMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPSubMenuMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByMenuID");
            cmd.Parameters.AddWithValue("@MenuID", obj.MenuID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
