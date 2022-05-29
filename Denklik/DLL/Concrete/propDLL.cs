using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Denklik.DLL.Concrete
{
    public class propDLL
    {
        protected SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DENKLİK;Integrated Security=True");
        protected SqlCommand cmd;
        protected SqlDataAdapter da;

        protected DataTable dt;

        /*protected void ConOpen()
        {
            con.Open();
        }

        protected void ConClose()
        {
            con.Close();
        }*/
    }
}
