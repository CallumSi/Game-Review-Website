﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class DeveloperController : Controller
    {

        private List<Developer> _developers = new List<Developer>()
        {
            new Developer
            {   DeveloperId = 1,
                Name = "John",
                Description = "Upcoming developer!",
                Platform = "PC",
                Rating = 8.1m},
            new Developer
            {   DeveloperId = 2,
                Name = "Steve",
                Description = "Good developer!",
                Platform = "PC",
                Rating = 0.1m},
            new Developer
            {   DeveloperId = 3,
                Name = "Jake",
                Description = "Great developer!",
                Platform = "PC",
                Rating = 0.1m}

        };
        // GET: Developer
        public ActionResult Index()
        {
            return View(_developers);
        }

        // GET: Details/id
        public ActionResult Details(int? id)
        {

            if (id == null) return new HttpNotFoundResult();
            Developer selectedDeveloper = _developers.First(p => p.DeveloperId == id);
            if (selectedDeveloper == null) return new HttpNotFoundResult();
            return View(selectedDeveloper);

        }

        // GET: Edit/id
        public ActionResult Edit(int? id)
        {

        }
    }
}