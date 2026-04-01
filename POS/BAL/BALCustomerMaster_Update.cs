using POS.BOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.HelperClass;
using System.Data;

namespace POS.BAL
{
    class BALCustomerMaster_Update
    {
        public int Insert(BOLCustomerMaster_Update obj)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SPCustomerMaster_UpdateLog";
                cmd.Parameters.AddWithValue("@Spara", "NewInsertUpdate");
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
                cmd.Parameters.AddWithValue("@NewCustomerName", obj.NewCustomerName);
                cmd.Parameters.AddWithValue("@OldCustomerName", obj.OldCustomerName);
                //cmd.Parameters.AddWithValue("@NewFullName", obj.NewFullName);
                //cmd.Parameters.AddWithValue("@OldFullName", obj.OldFullName);
                cmd.Parameters.AddWithValue("@NewSalutation", obj.NewSalutation);
                cmd.Parameters.AddWithValue("@OldSalutation", obj.OldSalutation);
                cmd.Parameters.AddWithValue("@NewFirstName", obj.NewFirstName);
                cmd.Parameters.AddWithValue("@OldFirstName", obj.OldFirstName);
                cmd.Parameters.AddWithValue("@NewMiddleName", obj.NewMiddleName);
                cmd.Parameters.AddWithValue("@OldMiddleName", obj.OldMiddleName);
                cmd.Parameters.AddWithValue("@OldLastName", obj.OldLastName);
                cmd.Parameters.AddWithValue("@NewLastName", obj.NewLastName);

                SqlParameter outputParam = new SqlParameter("@Ids", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                result = Convert.ToInt32(cmd.Parameters["@Ids"].Value);

                DAL DAL = new DAL();
                DAL.Insert(cmd);

            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating customer", ex);
            }

            return result;
        }
        public DataTable SelectByDate(BOLCustomerMaster_Update obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster_UpdateLog";
            cmd.Parameters.AddWithValue("@Spara", "SelectByDate");
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Delete(BOLCustomerMaster_Update obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerMaster_UpdateLog";
            cmd.Parameters.AddWithValue("@Spara", "DeleteCustomerLog");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
