﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Web.UI;

namespace WebApplication2.Controllers
{
    public class FirstController : Controller
    {
        string FileName = @"SavedPlayers.bin";
        static Player player = new Player();
        static List<Player> playersList = new List<Player>();

        public FirstController()
        {
            string dirPath = Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().Location);
            FileName = dirPath + FileName;
            if (!System.IO.File.Exists(FileName))
            {            
                Stream SaveFileStream = System.IO.File.Create(FileName);
                BinaryFormatter serializer = new BinaryFormatter();
                SaveFileStream.Close();
            }
        }


        public ActionResult MultiGames()
        {
            return View();
        }

        public ActionResult localGames()
        {
            return View();
        }

        public ActionResult singleGames()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            //save player to file
            Stream SaveFileStream = System.IO.File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(SaveFileStream, playersList);
            SaveFileStream.Close();

            player.UserName = null;
            return RedirectToAction("Menu");

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Player p)
        {
            if (System.IO.File.Exists(FileName))
            {
                Stream openFileStream = System.IO.File.OpenRead(FileName);
                if (openFileStream.Length != 0)
                {
                    BinaryFormatter deserializer = new BinaryFormatter();
                    playersList = (List<Player>)deserializer.Deserialize(openFileStream);
                }
                openFileStream.Close();
            }

            if (playersList.Count == 0)
            {
                ModelState.AddModelError("username", "username not found or matched");
                return View();
            }
            bool user_exists = false;
            //bool pass_right = false;
            int i = 0; 
            foreach (Player pl in playersList)
            {
                if(p.UserName == pl.UserName && p.Password == pl.Password) {
                    user_exists = true;
                    break;
                }
                i++;
            }

            if (!user_exists)
            {
                ModelState.AddModelError("username", "username not found or matched");
                return View();
            }
            player = playersList[i];
            return RedirectToAction("Menu");
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Player p)
        {
            Player newPlayer = new Player();
            newPlayer.UserName = p.UserName;
            newPlayer.Password = p.Password;
            newPlayer.Email = p.Email;
            newPlayer.FirstName = p.FirstName;
            newPlayer.LastName = p.LastName;
            newPlayer.Date = p.Date;
            playersList.Add(newPlayer);
            player = newPlayer;
            player.players = playersList;

            return RedirectToAction("Menu");
        }

        public ActionResult Contact()
        {
            try {
                return View(player);
            }
            catch
            {
                return RedirectToAction("Menu");
            }
        }

        public ActionResult Read()
        {
            return View();
        }

        public ActionResult facts(Player p)
        {
            return View(p);
        }

        public ActionResult Menu()
        {
            return View(player);
        }
       

        public ActionResult Leaderboard()
        {
            if (player.UserName != null)
            {
                return View(player);
            }
            return RedirectToAction("Error");
        }


        public ActionResult Play()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Error(Player p)
        {
            return View(p);
        }

        public ActionResult Settings(Player p)
        {
            return View(p);
        }
        public ActionResult close()
        {
            return RedirectToAction("Menu");
        }

        public ActionResult quizMenu()
        {
            return View();
        }
        public ActionResult startQuiz()
        {
            return RedirectToAction("quiz1");
        }

        public ActionResult quiz1()
        {
            return View();
        }


        [HttpGet]
        public ActionResult quiz1_result(int id)
        {
            player.Score += id * 10;
            return RedirectToAction("quiz2");
        }


        [HttpGet]
        public ActionResult quiz2_result(int id)
        {
            player.Score += id * 20;
            return RedirectToAction("Menu");

        }

        public ActionResult quiz2()
        {
            return View();
        }

        public ActionResult quiz3()
        {
            return View();
        }

        public ActionResult Matching1()
        {
            if (player.Score < 100) {
                return View();
            }
            if (player.Score > 100 && player.Score < 200)
            {
                return RedirectToAction("Matching2");
            }

            return RedirectToAction("Matching3");

        }

        [HttpGet]
        public void matching1_result(int id)
        {
            player.Score += id;
        }

        public ActionResult Matching2()
        {
            return View();
        }

        public ActionResult middle()
        {
            return RedirectToAction("Matching2");

        }
        [HttpGet]
        public void matching2_result(int id)
        {
            player.Score += id;
        }

        public ActionResult Matching3()
        {
            return View();
        }

        [HttpGet]
        public void matching3_result(int id)
        {
            player.Score += id;
        }
        public ActionResult Snake()
        {
            return View(player);
        }
        public ActionResult Snake2()
        {
            return View(player);
        }



        [HttpGet]
        public ActionResult Snake_level(int level)
        {
            if (level == 0)
            {
                return RedirectToAction("Snake");
            }
            else
            {
                return RedirectToAction("Snake2");
            }
        }


        public ActionResult SnakesAndLadders()
        {
            return View(player);
        }

        [HttpGet]
        public ActionResult SnkLds(int id)
        {
            switch (id) {
                case 1:
                    Matching1();
                    break;
                case 2:
                    return RedirectToAction("Matching2");
                case 3:
                    return RedirectToAction("Matching3");

            }
            return RedirectToAction("Matching3");
        }

        public ActionResult TetrisCode()
        {
            if (player.Score < 10)
            {
                return View();
            }
            else
            {
                return RedirectToAction("TetrisCode2");
            }
        }

        public ActionResult TetrisCode2()
        {
            return View();
        }
        [HttpGet]
        public void tetris_result(int id)
        {
            player.Score += id;
        }

        public ActionResult Parameters()
        {
            return View();
        }

        public ActionResult Functions()
        {
            return View();
        }

        public ActionResult Langs()
        {
            return View();
        }

        public ActionResult People()
        {
            return View();
        }

    }
}
