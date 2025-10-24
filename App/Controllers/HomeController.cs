// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using App.Models;
// using App.DAO;
// using App.Repositories.Interfaces;

// namespace App.Controllers;

// public class HomeController : Controller
// {
//     private readonly ILogger<HomeController> _logger;
//     private readonly IUserRepository _user;

//     public HomeController(ILogger<HomeController> logger, IUserRepository user)
//     {
//         _logger = logger;
//         _user = user;
//     }

//     public IActionResult Index()
//     {
//         return View();
//     }
//     public IActionResult Login()
//     {
//         return View();
//     }
//     [HttpPost]
//     public IActionResult Login(string username, string password)
//     {
//         if (!_user.Login(username, password))
//         {
//             TempData["login"] = "Sai tài khoản hoặc mật khẩu!";
//             return View();
//         }
//         else
//         {
//             HttpContext.Session.SetString("_user", username);
//             HttpContext.Session.SetInt32("_role", _user.getRole(username));
//         }
//         return RedirectToAction("Index");
//     }
//     public IActionResult Logout()
//     {
//         HttpContext.Session.Clear();
//         return RedirectToAction("Login");
//     }
//     public IActionResult Register()
//     {
//         return View();
//     }
//     [HttpPost]
//     public IActionResult Register(string ConfirmPassword, UserModel user)
//     {
//         var existingUser = _user.LayUser(user.Username);
//         if (!string.IsNullOrWhiteSpace(existingUser.Username))
//         {
//             TempData["username"] = "Tài khoản đã tồn tại!";
//             return View();
//         }
//         if (user.Password != ConfirmPassword)
//         {
//             TempData["confirm"] = "Mật khẩu không khớp!";
//             return View();
//         }
//         if (_user.Register(user) > 0)
//         {
//             return RedirectToAction("Login");
//         }
//         return View();
//     }
//     public IActionResult Privacy()
//     {
//         return View();
//     }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }
