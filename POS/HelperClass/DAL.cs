using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POS.HelperClass
{
    class DAL
    {
        private string GetConnectionString()
        {
            string connstr = "";
            try
            {
                connstr = ConfigurationManager.AppSettings["Connection"].ToString();
                return connstr;
            }
            catch (Exception ex)
            {
                return connstr;
            }
        }

        internal DataTable Select(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                string connstr = GetConnectionString();
                SqlConnection conn = new SqlConnection(connstr);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr;
                conn.Open();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
            }
            catch (Exception ex)
            { return dt; }
            return dt;
        }

        internal void Insert(SqlCommand cmd)
        {
            try
            {
                string connstr = GetConnectionString();
                SqlConnection conn = new SqlConnection(connstr);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Class:DAL,Function :Insert. Message:" + ex.Message);
            }
        }

        internal void Update(SqlCommand cmd)
        {
            try
            {
                string connstr = GetConnectionString();
                SqlConnection conn = new SqlConnection(connstr);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Class:DAL,Function :Update. Message:" + ex.Message);
            }
        }

        internal void Delete(SqlCommand cmd)
        {
            string connstr = GetConnectionString();
            SqlConnection conn = new SqlConnection(connstr);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        internal int Insert_Update_Del(SqlCommand cmd)
        {
            int id = 0;
            try
            {
                string strConn = GetConnectionString();
                SqlConnection Con = new SqlConnection(strConn);
                cmd.Connection = Con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ids", 0).Direction = ParameterDirection.Output;
                Con.Open();
                cmd.ExecuteNonQuery();
                id = Convert.ToInt32(cmd.Parameters["@Ids"].Value.ToString());
                Con.Close();

            }
            catch (Exception ex) { ex.ToString(); }
            return id;
        }
    }
}
