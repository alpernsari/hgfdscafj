using Denklik.Models.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Denklik.DLL.Concrete
{
    public class adoOkullarDLL:propDLL
    {
        public DataTable GetOne(string E_Posta,string Sifre)
        {
            dt = new DataTable();
            string sCom = "select * from tblOKullar where OkulE_Posta= '"
                +E_Posta +"' and OkulSifre='"+Sifre +"'";
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sCom;
            da = new SqlDataAdapter(cmd.CommandText, con);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetAll()
        {
            dt = new DataTable();
            string sCom = "select * from tblOKullar";
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
