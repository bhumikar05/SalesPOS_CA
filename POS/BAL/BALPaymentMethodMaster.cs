using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.HelperClass;
using POS.BOL;
using System.Data;
using System.Data.SqlClient;

namespace POS.BAL
{
    class BALPaymentMethodMaster
    {
        public DataTable Select()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_PaymentMethodMaster";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
