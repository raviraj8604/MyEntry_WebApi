﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyEntry_WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
          
            return View();
        }
    }
}
