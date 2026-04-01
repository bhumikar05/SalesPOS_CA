using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALEmailTemplate
    {
        public DataTable Select(BOLEmailTemplate obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPEmailTemplate";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByID(BOLEmailTemplate obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPEmailTemplate";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByTemplateName(BOLEmailTemplate obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPEmailTemplate";
            cmd.Parameters.AddWithValue("@Spara", "SelectByTemplateName");
            cmd.Parameters.AddWithValue("@TemplateName", obj.TemplateName);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByTemplateNameUpdate(BOLEmailTemplate obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPEmailTemplate";
            cmd.Parameters.AddWithValue("@Spara", "SelectByTemplateNameUpdate");
            cmd.Parameters.AddWithValue("@TemplateName", obj.TemplateName);
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByTemplateType(BOLEmailTemplate obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPEmailTemplate";
            cmd.Parameters.AddWithValue("@Spara", "SelectByTemplateType");
            cmd.Parameters.AddWithValue("@TemplateType", obj.TemplateType);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void Insert(BOLEmailTemplate obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPEmailTemplate";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@TemplateType", obj.TemplateType);
            cmd.Parameters.AddWithValue("@TemplateName", obj.TemplateName);
            cmd.Parameters.AddWithValue("@Body", obj.Body);
            cmd.Parameters.AddWithValue("@Subject", obj.Subject);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Update(BOLEmailTemplate obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPEmailTemplate";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@TemplateType", obj.TemplateType);
            cmd.Parameters.AddWithValue("@TemplateName", obj.TemplateName);
            cmd.Parameters.AddWithValue("@Body", obj.Body);
            cmd.Parameters.AddWithValue("@Subject", obj.Subject);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Delete(BOLEmailTemplate obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPEmailTemplate";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
