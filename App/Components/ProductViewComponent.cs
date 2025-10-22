using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents;

[ViewComponent(Name = "Product")]
public class ProductViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("Default");
    }
}