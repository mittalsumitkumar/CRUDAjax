using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDAjax.Models;

namespace CRUDAjax.Controllers
{
    public class ManagerController : Controller
    {
        ActionDB mngrDB = new ActionDB();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(mngrDB.ListAllManager(),JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Manager manager)
        {
            return Json(mngrDB.AddManager(manager), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Manger = mngrDB.ListAllManager().Find(x => x.ID.Equals(ID));
            return Json(Manger, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Manager manager)
        {
            return Json(mngrDB.UpdateManager(manager), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(mngrDB.DeleteManager(ID), JsonRequestBehavior.AllowGet);
        }
    }
}