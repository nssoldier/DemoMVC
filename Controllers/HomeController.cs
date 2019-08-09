using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using demoMVC.Models;
using Microsoft.AspNetCore.Http;
using demoMVC.Model;

namespace demoMVC.Controllers
{
  public class HomeController : Controller
  {

    private MyDbContext dbContext;
    public HomeController(MyDbContext context)
    {
      this.dbContext = context;
    }
    public IActionResult Index([FromQuery]bool logged, int id)
    {
      if (logged == true)
      {
        var user = dbContext.Users.FirstOrDefault(acc => acc.Id == id);
        ViewBag.message = user.Username;
      }
      return View();
    }

    [HttpPost]
    public IActionResult Login(string name, string password)
    {
      var user = new Users(name, password);
      dbContext.Users.Add(user);
      dbContext.SaveChanges();
      user = dbContext.Users.FirstOrDefault(acc => acc.Username == name);
      HttpContext.Session.SetString("logged", "true");
      return Redirect("/?logged=" + true + "&id=" + user.Id);
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
