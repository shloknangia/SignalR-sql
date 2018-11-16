﻿using SignalRsql3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRsql3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Updates()
        {
            return View();
        }

        public ActionResult GetUsers()
        {
            UsersRepository _userRepository = new UsersRepository();
            return PartialView("_UsersList", _userRepository.GetAllUsers());
        }
    }
}