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
    public class adoDenklikSabitlerDLL:propDLL
    {

        public DataTable GetOne()
        {
            string sCom = "SELECT TOP (1) [DenklikTarihi],[KomisyonBaskani]" +
                " FROM[DENKLİK].[dbo].[tblDenklikSabitler]";
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sCom;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

    }
}
