using POS.BOL;
using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BALPaypalConfig
{
    public DataTable Select(BOLPaypalConfig obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SPPaypalConfig";
        cmd.Parameters.AddWithValue("@Spara", "Select");
        DAL DAL = new DAL();
        DataTable dt = DAL.Select(cmd);
        return dt;
    }

    public void Insert(BOLPaypalConfig obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SPPaypalConfig";
        cmd.Parameters.AddWithValue("@Spara", "Insert");        
        cmd.Parameters.AddWithValue("@PaypalAuthToken", obj.PaypalAuthToken);
        cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
        DAL DAL = new DAL();
        DAL.Insert(cmd);
    }

    public void Update(BOLPaypalConfig obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SPPaypalConfig";
        cmd.Parameters.AddWithValue("@Spara", "Update");
        cmd.Parameters.AddWithValue("@ID", obj.ID);
        cmd.Parameters.AddWithValue("@PaypalAuthToken", obj.PaypalAuthToken);
        cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
        DAL DAL = new DAL();
        DAL.Insert(cmd);
    }

}
