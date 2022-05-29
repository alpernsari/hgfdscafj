using Denklik.Models.dbModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denklik.DLL.Concrete
{
    public class adoDenklikDLL:propDLL
    {
        public DataTable GetAllTC()
        {
            dt = new DataTable();
            string sCom = "select TCNO from tblDenklik";
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sCom;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetOne(string sCom)
        {
            tblDenklik _denklik = new tblDenklik();
            dt = new DataTable();
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sCom;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        public void NewLine(string tblAdi, object[] Kolonlar)
        {
            string sCom = "insert into " + tblAdi + " values(";
            foreach (object item in Kolonlar)
            {
                sCom += "'" + item.ToString() + "',";
            }
            sCom = sCom.Substring(0, sCom.LastIndexOf(",") - 1);
            sCom += "')";
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sCom;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateOrDelete(string sCom)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sCom;
            cmd.ExecuteNonQuery();

        }

    }
}
