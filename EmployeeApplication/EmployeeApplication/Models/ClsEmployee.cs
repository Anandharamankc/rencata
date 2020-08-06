using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.Models
{
    public class ClsEmployee
    {
        public Int32 employee_id { get; set; }
        public String employee_name { get; set; }
        public String father_name { get; set; }
        public String mother_name { get; set; }
        public DateTime DOB { get; set; }
        public String gender { get; set; }
        public String marital_status { get; set; }
        public String Address { get; set; }
        public String Dml_Indicator { get; set; }
    }
}