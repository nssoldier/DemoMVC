﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using demoMVC.Models;
using Microsoft.AspNetCore.Http;

namespace demoMVC.Controllers
{
  public class HomeController : Controller
  {

    public IActionResult Index([FromQuery]string name)
    {
      var username = HttpContext.Session.GetString("username");
      ViewBag.message = username;
      return View();
    }

    [HttpPost]
    public IActionResult Login(string name)
    {
      HttpContext.Session.SetString("username", name);
      return Redirect("/?name=" + name);
    }

    [HttpGet]
    public IActionResult Logout(string name)
    {
      HttpContext.Session.Clear();
      return Redirect("/");
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}