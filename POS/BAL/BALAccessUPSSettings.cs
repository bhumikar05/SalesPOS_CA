using POS.BOL;
using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BAL
{
    class BALAccessUPSSettings
    {
        public DataTable Select(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAccessUPSSettings";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            cmd.Parameters.AddWithValue("@UserID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Insert(BOLAccessUPSSettings obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAccessUPSSettings";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@UserID", obj.ID);
            cmd.Parameters.AddWithValue("@NegotiatedRate", obj.NegotiatedRate);
            cmd.Parameters.AddWithValue("@DeliveryConfirmation", obj.DeliveryConfirmation);
            cmd.Parameters.AddWithValue("@COD", obj.COD);
            cmd.Parameters.AddWithValue("@OtherService", obj.OtherService);
            cmd.Parameters.AddWithValue("@PrinterName", obj.PrinterName);
            cmd.Parameters.AddWithValue("@Copies", obj.Copies);
            cmd.Parameters.AddWithValue("@Landscape", obj.Landscape);
            cmd.Parameters.AddWithValue("@Margins", obj.Margins);
            cmd.Parameters.AddWithValue("@PaperSize", obj.PaperSize);
            cmd.Parameters.AddWithValue("@PaperSource", obj.PaperSource);
            cmd.Parameters.AddWithValue("@PrinterResolution", obj.PrinterResolution);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Update(BOLAccessUPSSettings obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAccessUPSSettings";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@UserID", obj.ID);
            cmd.Parameters.AddWithValue("@NegotiatedRate", obj.NegotiatedRate);
            cmd.Parameters.AddWithValue("@DeliveryConfirmation", obj.DeliveryConfirmation);
            cmd.Parameters.AddWithValue("@COD", obj.COD);
            cmd.Parameters.AddWithValue("@OtherService", obj.OtherService);
            cmd.Parameters.AddWithValue("@PrinterName", obj.PrinterName);
            cmd.Parameters.AddWithValue("@Copies", obj.Copies);
            cmd.Parameters.AddWithValue("@Landscape", obj.Landscape);
            cmd.Parameters.AddWithValue("@Margins", obj.Margins);
            cmd.Parameters.AddWithValue("@PaperSize", obj.PaperSize);
            cmd.Parameters.AddWithValue("@PaperSource", obj.PaperSource);
            cmd.Parameters.AddWithValue("@PrinterResolution", obj.PrinterResolution);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
    }
}
