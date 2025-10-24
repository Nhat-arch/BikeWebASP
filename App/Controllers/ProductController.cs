// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using App.DAO;
// using App.Repositories.Interfaces;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;

// namespace App.Controllers
// {
//     public class ProductController : Controller
//     {
//         private readonly ILogger<ProductController> _logger;
//         private readonly IProductRepository _p;

//         public ProductController(ILogger<ProductController> logger, IProductRepository p)
//         {
//             _logger = logger;
//             _p = p;
//         }

//         public IActionResult Index()
//         {
//             var ds = _p.LayDS();
//             return View(ds);
//         }

//         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//         public IActionResult Error()
//         {
//             return View("Error!");
//         }
//     }
// }