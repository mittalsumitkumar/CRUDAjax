using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDAjax.Models;

namespace CRUDAjax.Controllers
{
    public class EmployeeController : Controller
    {
        ActionDB empDB = new ActionDB();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(empDB.ListAllEmp(),JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Employee emp)
        {
            return Json(empDB.AddEmployee(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = empDB.ListAllEmp().Find(x => x.ID.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Employee emp)
        {
            return Json(empDB.UpdateEmployee(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(empDB.DeleteEmployee(ID), JsonRequestBehavior.AllowGet);
        }
    }
}