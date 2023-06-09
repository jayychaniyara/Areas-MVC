﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC.Filters;
using UdemyMVC.Identity;
using Company.DomainModels;
using Company.DataLayer;

namespace UdemyMVC.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<ApplicationUser> existingUsers = db.Users.ToList();
            return View(existingUsers);
        }
    }
}