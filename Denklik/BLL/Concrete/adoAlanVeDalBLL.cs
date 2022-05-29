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
    public static class adoAlanVeDalBLL
    {
        public static DataTable GetAll(string colomn)
        {
            adoAlanVeDalDLL _alandal = new adoAlanVeDalDLL();
            DataTable dt;
            dt = _alandal.GetAll(colomn);

            return dt; 
        }
        
        public static int Count(string sCom)
        {
            adoAlanVeDalDLL _alandal = new adoAlanVeDalDLL();

            return _alandal.Count(sCom);
        }

        public static DataTable GetDal(string colomn)
        {
            adoAlanVeDalDLL _alandal = new adoAlanVeDalDLL();
            DataTable dt= _alandal.GetAll(colomn);
            return dt;
        }
    }
}
