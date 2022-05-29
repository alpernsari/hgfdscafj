using Denklik.DLL.Concrete;
using Denklik.Models.dbModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denklik.BLL.Concrete
{
    public static class adoDenklikSabitlerBLL
    {

        public static tblDenklikSabitler GetOne()
        {
            adoDenklikSabitlerDLL DSabitler = new adoDenklikSabitlerDLL();
            tblDenklikSabitler sabit = new tblDenklikSabitler();

            DataTable dt;
            dt = DSabitler.GetOne();

            sabit.DenklikTarihi = dt.Rows[0][0].ToString();
            sabit.KomisyonBaskani = dt.Rows[0][1].ToString();

            return sabit;
        }

    }
}
