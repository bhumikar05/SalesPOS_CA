using POS.HelperClass;
using SalesPOS.BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPOS.BAL
{
    class BALManuallyEmail:DAL
    {
        public DataTable Select()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_ManuallyEmail";
            cmd.Parameters.AddWithValue("@MODE", "SELECT");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void Insert(BOLManuallyEmail obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_ManuallyEmail";
            cmd.Parameters.AddWithValue("@MODE", "Insert");
            cmd.Parameters.AddWithValue("@ConsolePath", obj.ConsolePath);
            cmd.Parameters.AddWithValue("@FromDate", obj.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);
            cmd.Parameters.AddWithValue("@DailyShipTo", obj.DailyShipTo);
            cmd.Parameters.AddWithValue("@DailyShipCC", obj.DailyShipCC);
            cmd.Parameters.AddWithValue("@DailyShipMail", obj.DailyShipMail);
            cmd.Parameters.AddWithValue("@ItemCodesTo", obj.ItemCodesTo);
            cmd.Parameters.AddWithValue("@ItemCodesCC", obj.ItemCodesCC);
            cmd.Parameters.AddWithValue("@ItemCodesMail", obj.ItemCodesMail);
            cmd.Parameters.AddWithValue("@ProfitReportTo", obj.ProfitReportTo);
            cmd.Parameters.AddWithValue("@ProfitReportCC", obj.ProfitReportCC);
            cmd.Parameters.AddWithValue("@ProfitReportMail", obj.ProfitReportMail);
            cmd.Parameters.AddWithValue("@PaymentsAndCreditMemoTo", obj.PaymentsAndCreditMemoTo);
            cmd.Parameters.AddWithValue("@PaymentsAndCreditMemoCC", obj.PaymentsAndCreditMemoCC);
            cmd.Parameters.AddWithValue("@PaymentsAndCreditMemoMail", obj.PaymentsAndCreditMemoMail);
            cmd.Parameters.AddWithValue("@SummaryReportTo", obj.SummaryReportTo);
            cmd.Parameters.AddWithValue("@SummaryReportCC", obj.SummaryReportCC);
            cmd.Parameters.AddWithValue("@SummaryReportMail", obj.SummaryReportMail);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Update(BOLManuallyEmail obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_ManuallyEmail";
            cmd.Parameters.AddWithValue("@MODE", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@ConsolePath", obj.ConsolePath);
            cmd.Parameters.AddWithValue("@FromDate", obj.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);
            cmd.Parameters.AddWithValue("@DailyShipTo", obj.DailyShipTo);
            cmd.Parameters.AddWithValue("@DailyShipCC", obj.DailyShipCC);
            cmd.Parameters.AddWithValue("@DailyShipMail", obj.DailyShipMail);
            cmd.Parameters.AddWithValue("@ItemCodesTo", obj.ItemCodesTo);
            cmd.Parameters.AddWithValue("@ItemCodesCC", obj.ItemCodesCC);
            cmd.Parameters.AddWithValue("@ItemCodesMail", obj.ItemCodesMail);
            cmd.Parameters.AddWithValue("@ProfitReportTo", obj.ProfitReportTo);
            cmd.Parameters.AddWithValue("@ProfitReportCC", obj.ProfitReportCC);
            cmd.Parameters.AddWithValue("@ProfitReportMail", obj.ProfitReportMail);
            cmd.Parameters.AddWithValue("@PaymentsAndCreditMemoTo", obj.PaymentsAndCreditMemoTo);
            cmd.Parameters.AddWithValue("@PaymentsAndCreditMemoCC", obj.PaymentsAndCreditMemoCC);
            cmd.Parameters.AddWithValue("@PaymentsAndCreditMemoMail", obj.PaymentsAndCreditMemoMail);
            cmd.Parameters.AddWithValue("@SummaryReportTo", obj.SummaryReportTo);
            cmd.Parameters.AddWithValue("@SummaryReportCC", obj.SummaryReportCC);
            cmd.Parameters.AddWithValue("@SummaryReportMail", obj.SummaryReportMail);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
    }
}
