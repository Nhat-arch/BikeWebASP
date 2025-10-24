namespace App.Controllers.Areas.API.V1;

using App.DAO;
using App.Models;
using Microsoft.AspNetCore.Mvc;

[Area("API/V1")]
[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly ProductDAO _productDAO;
    public ProductController()
    {
        _productDAO = new ProductDAO();
    }
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _productDAO.LayDSProduct();
        return Ok(new
        {
            success = true,
            data = products,
            message = "Lấy danh sách sản phẩm thành công"
        });
    }
    [HttpGet("brands")]
    public IActionResult GetAllBrand()
    {
        var brands = _productDAO.LayDSBrand();
        return Ok(new
        {
            success = true,
            data = brands,
            message = "Lấy danh sách nhãn hiệu thành công"
        });
    }
    [HttpGet("types")]
    public IActionResult GetAllType()
    {
        var brands = _productDAO.LayDSType();
        return Ok(new
        {
            success = true,
            data = brands,
            message = "Lấy danh sách danh mục thành công"
        });
    }
    [HttpPost("store/brand")]
    public IActionResult AddBrand([FromBody] BrandModel b)
    {
        var result = _productDAO.ThemBrand(b);
        return Ok(new
        {
            success = true,
            data = result,
            message = "Tạo thành công brand mới"
        });
    }
    [HttpPost("store/type")]
    public IActionResult AddType([FromBody] TypeModel t)
    {
        var result = _productDAO.ThemType(t);
        return Ok(new
        {
            success = true,
            data = result,
            message = "Tạo type mới thành công"
        });
    }
}