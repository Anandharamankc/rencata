using Businesslayer.Classes;
using Businesslayer.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        IBEmployee objBEmployee;
        DataTable objDataTable;
        HttpResponseMessage response;

        [HttpPost]
        [ActionName("Employee_details")]
        public HttpResponseMessage Employee_details([FromBody]ClsEmployee ObjClsEmployee)
        {
            try
            {
                objBEmployee = new BEmployee();
                objDataTable = new DataTable();
                objDataTable = objBEmployee.Employee_details(ObjClsEmployee);

                return response = Request.CreateResponse(HttpStatusCode.OK, objDataTable);
            }
            catch (Exception objException)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, objException.Message);
            }
        }
    }
}
