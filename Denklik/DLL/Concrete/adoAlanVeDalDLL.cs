using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Denklik.DLL.Concrete
{
    public class adoAlanVeDalDLL:propDLL
    {

        public int Count(string sCom)
        {
            
            dt = new DataTable();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sCom;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            
            return dt.Rows.Count;
        }

        public DataTable GetAll(string colomn)
        {
            dt = new DataTable();
            string sCom = colomn;
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sCom;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
