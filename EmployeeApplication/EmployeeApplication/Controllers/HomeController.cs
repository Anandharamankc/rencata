using EmployeeApplication.CommonFunctions;
using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApplication.Controllers
{
    public class HomeController : Controller
    {

        #region Declaration

        HttpClient objHttpClient;
        HttpResponseMessage objresponseMessage;

        #endregion

        #region constructor

        public HomeController()
        {
            objHttpClient = new HttpClient();
            objHttpClient.BaseAddress = new Uri(CommonFunction.objWebApiUrl);
            objHttpClient.DefaultRequestHeaders.Accept.Clear();
            objHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public JsonResult Employee_details(ClsEmployee objClsEmployee)
        {
            try
            {
                objresponseMessage = objHttpClient.PostAsJsonAsync(CommonFunction.objWebApiUrl + "Employee/Employee_details", objClsEmployee).Result;
                var DoctorSchedule = objresponseMessage.Content.ReadAsStringAsync().Result;
                if (objresponseMessage.IsSuccessStatusCode)
                {
                    return Json(DoctorSchedule, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception)
            {


            }

            return Json(new EmptyResult(), JsonRequestBehavior.AllowGet);
        }
    }
}