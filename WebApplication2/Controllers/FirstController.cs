﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class FirstController : Controller
    {
        Player player = new Player();

        public ActionResult MultiGames()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Player p)
        {
            p = new Player();
            return View();
        }

        public ActionResult Signup()
        {
            return View(player);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Read()
        {
            return View();
        }

        public ActionResult facts()
        {
            return View();
        }

        // GET: First/Create
        public ActionResult Create()
        {
            return View();
        }
       
        public ActionResult Leaderboard()
        {
            return View();
        }
        public ActionResult Play()
        {
            return View();
        }
        // GET: First/Create
        public ActionResult Home()
        {
            return View();
        }
       
    }
}
