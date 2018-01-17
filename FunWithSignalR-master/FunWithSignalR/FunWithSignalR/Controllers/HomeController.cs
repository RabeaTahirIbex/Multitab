using FunWithSignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunWithSignalR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }
        
        public static class ListofUsers
        {
            public static List<listID> opentabs = new List<listID>();

        }
        [Route("home/request/{id}")]
        public ActionResult Request(string id)
        {
            if (ListofUsers.opentabs.Find((listID i) => i.consistentUserID == id) != null)
            {
                var obj = ListofUsers.opentabs.Find((listID i) => i.consistentUserID == id);
                //return RedirectToAction("reconnect", obj);
                obj.isAlready = true;
                return View(obj);
            }
            else if (!String.IsNullOrEmpty(id))
            {
                string ran = Guid.NewGuid().ToString();

                ListofUsers.opentabs.Add(new listID()
                {
                    random = ran,
                    consistentUserID = id
                });
                listID c = new listID();
                c.random = ran;
                c.consistentUserID = id;
                c.isAlready = false;
                return View(c);
            }
            return Content("None");


        }

        //[Route("home/request/{random}{consistentUserID}{ConnectionID}")]
        //public ActionResult Reconnect(string random, string consistentUserID, string ConnectionID)
        //{
        //    listID c = new listID();
        //    c.random = random;
        //    c.consistentUserID = consistentUserID;
        //    return View(c);
        //    // return Content("None");


        //}
        public JsonResult VerifyUserNameInUse(string userName)
        {
            try
            {
                using (var db = new ZigChatContext())
                {
                    return Json(new { Success = true, InUse = db.Connections.Where(x => x.UserName.ToLower() == userName.ToLower() && x.IsOnline).SingleOrDefault() != null }, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new { Success = false, ErrorMessage = "Something wrong happened." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}