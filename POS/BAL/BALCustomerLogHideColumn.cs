using POS.BOL;
using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POS.BAL
{
    public class BALCustomerLogHideColumn
    {
        public DataTable Select(BOLCustomerLogHideColumn obj)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_CustomerLogHideColumn";
            cmd.Parameters.AddWithValue("@Mode", "Select");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public void Insert(BOLCustomerLogHideColumn obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_CustomerLogHideColumn";
                cmd.Parameters.AddWithValue("@Mode", "Insert");
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);

                cmd.Parameters.AddWithValue("@NewCustomerName", obj.NewCustomerName);
                cmd.Parameters.AddWithValue("@OldCustomerName", obj.OldCustomerName);
                cmd.Parameters.AddWithValue("@NewSalutation", obj.NewSalutation);
                cmd.Parameters.AddWithValue("@OldSalutation", obj.OldSalutation);
                cmd.Parameters.AddWithValue("@NewFirstName", obj.NewFirstName);
                cmd.Parameters.AddWithValue("@OldFirstName", obj.OldFirstName);
                cmd.Parameters.AddWithValue("@NewMiddleName", obj.NewMiddleName);
                cmd.Parameters.AddWithValue("@OldMiddleName", obj.OldMiddleName);
                cmd.Parameters.AddWithValue("@NewLastName", obj.NewLastName);
                cmd.Parameters.AddWithValue("@OldLastName", obj.OldLastName);
                cmd.Parameters.AddWithValue("@EditCount", obj.EditCount);
                cmd.Parameters.AddWithValue("@UpdateDate", obj.UpdateDate);
                DAL DAL = new DAL();
                DAL.Insert(cmd);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Class:BALCustomerLogHideColumn,Function :Insert. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void Update(BOLCustomerLogHideColumn obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_CustomerLogHideColumn";
                cmd.Parameters.AddWithValue("@Mode", "Update");
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);
                cmd.Parameters.AddWithValue("@NewCustomerName", obj.NewCustomerName);
                cmd.Parameters.AddWithValue("@OldCustomerName", obj.OldCustomerName);
                cmd.Parameters.AddWithValue("@NewSalutation", obj.NewSalutation);
                cmd.Parameters.AddWithValue("@OldSalutation", obj.OldSalutation);
                cmd.Parameters.AddWithValue("@NewFirstName", obj.NewFirstName);
                cmd.Parameters.AddWithValue("@OldFirstName", obj.OldFirstName);
                cmd.Parameters.AddWithValue("@NewMiddleName", obj.NewMiddleName);
                cmd.Parameters.AddWithValue("@OldMiddleName", obj.OldMiddleName);
                cmd.Parameters.AddWithValue("@NewLastName", obj.NewLastName);
                cmd.Parameters.AddWithValue("@OldLastName", obj.OldLastName);
                cmd.Parameters.AddWithValue("@EditCount", obj.EditCount);
                cmd.Parameters.AddWithValue("@UpdateDate", obj.UpdateDate);
                DAL DAL = new DAL();
                DAL.Update(cmd);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Class:BALCustomerLogHideColumn,Function :Update. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

    }
}
