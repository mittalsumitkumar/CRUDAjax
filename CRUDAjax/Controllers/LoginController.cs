using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDAjax.Models;

namespace CRUDAjax.Controllers
{
    public class LoginController : Controller
    {
        ActionDB loginDB = new ActionDB();
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }
        public JsonResult LoginUser(Login lg )
        {
            var isvalid = loginDB.isLoginUserValid(lg);
            if (isvalid)
                return Json("Sucess", JsonRequestBehavior.AllowGet);
            //RedirectToAction("Employee", "index", new { area = "" });
            else
                return Json("Invalid", JsonRequestBehavior.AllowGet);

        }
    }
}