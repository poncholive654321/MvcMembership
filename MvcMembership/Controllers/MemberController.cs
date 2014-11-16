using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMembership.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/

        public ActionResult Index()
        {
            var x = Services.FtpReaderService.GetInstance().GetFiles(User.Identity.Name);
            return View();
        }

        public ActionResult Admin()
        {   
            return View();
        }


    }
}
