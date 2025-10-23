using System.Diagnostics;
using App.Models;
using Microsoft.AspNetCore.Mvc;
namespace App.Areas.API.V1.Controllers;

[Area("API/V1")]
[Route("api/v1/[controller]")]
[ApiController]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Đây là một chuỗi từ API V1");
    }
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

