using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Accounts
{
    public class Global
    {
        public static int iCompanyId;
        public static int iFiscalYear;
        public static string ServerName = "Faizan-pc";
        public static string DatabaseName = "MtechwebxNajoom";
        public static string sCompanyName;
        public static string GetConnectString(string sServer, string sDBName)
        {
            return "SERVER=" + sServer + ";uid=sa;pwd=123456789;APP=Accounts;Database=" + sDBName + ";Persist Security Info=true; Trusted_Connection=True; TrustServerCertificate=True;Encrypt=False";
        }

        public static DataTable ExecuteQuery(string sConnectionString, string sql) 
        { 
            DataTable dt1 = new DataTable();
            SqlConnection conn = new SqlConnection(sConnectionString);

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            
            try
            {
                da.Fill(dt1);
            }
            catch (Exception ex)
            {
                
                return dt1;
            }
            return dt1;
        }
    }
}
