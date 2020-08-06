using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EmployeeApplication.CommonFunctions
{
    public static class CommonFunction
    {
        public static String objWebApiUrl = ConfigurationManager.AppSettings["WEBAPIURL"].ToString();

        public static String GetTimestamp(this DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssfff");
        }
    }
}