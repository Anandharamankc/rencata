using Businesslayer.Interfaces;
using DataAccessLayer.Classes;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer.Classes
{
    public class BEmployee: IBEmployee
    {
        IDEmployee objDEmployee = new DEmployee();

        public DataTable Employee_details(ClsEmployee ObjClsEmployee)
        {
            return objDEmployee.Employee_details(ObjClsEmployee);
        }
    }
}
