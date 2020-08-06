using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslayer.Interfaces
{
    public interface IBEmployee
    {
        DataTable Employee_details(ClsEmployee ObjClsEmployee);
    }
}
