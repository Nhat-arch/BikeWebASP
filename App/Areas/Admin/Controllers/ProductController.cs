// using App.DAO;
// using App.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Options;

// namespace App.Areas.Admin.Controllers;

// [Area("Admin")]
// public class ProductController : Controller
// {
//     private readonly ProductDAO _p;
//     private readonly IWebHostEnvironment _env;

//     public ProductController(IWebHostEnvironment env)
//     {
//         _p = new ProductDAO();
//         _env = env;
//     }
//     public IActionResult Index()
//     {
//         var ds = _p.LayDS();
//         return View(ds);
//     }
//     public IActionResult ProductAdd()
//     {
//         var ds = _p.LayDS();
//         return View(ds);
//     }
//     [HttpPost]
//     public IActionResult ProductAdd(ProductViewModel p)
//     {
//         if (p.Product.ProductName == _p.LayDSProduct().FirstOrDefault(x => x.ProductName == p.Product.ProductName)?.ProductName && p.Product.ProductName != null)
//         {
//             TempData["TonTai"] = "Tên sản phẩm đã tồn tại!";
//             var Error = _p.LayDS();
//             return View(Error);
//         }
//         if (!ModelState.IsValid)
//         {
//             var Error = _p.LayDS();
//             return View(Error);
//         }
//         var files = Request.Form.Files; //Lấy tất cả file được submit
//         if (files == null || files.Count == 0)
//         {
//             TempData["ImageError"] = "Phải có ít nhất một hình ảnh cho sản phẩm!";
//             var Error = _p.LayDS();
//             return View(Error);
//         }
//         var fileUploadSettings = HttpContext.RequestServices.GetService<IOptions<Poco.FileUploadSettings>>()?.Value;
//         //Xác minh từng file nhận được
//         foreach (var f in files)
//         {
//             //Kiểm tra kích thước file
//             if (f.Length > fileUploadSettings.MaxSize * 1024)
//             {
//                 TempData["ImageError"] = "Kích thước hình ảnh không được vượt quá " + (fileUploadSettings.MaxSize / 1024) + " MB!";
//                 var Error = _p.LayDS();
//                 return View(Error);
//             }
//             //Kiểm tra định dạng file
//             if (!string.Join(", ", fileUploadSettings.FileType).Contains(Path.GetExtension(f.FileName).ToLower()))
//             {
//                 TempData["ImageError"] = "Vui lòng chọn file hình ảnh hợp lệ! (" + string.Join(", ", fileUploadSettings.FileType) + ")";
//                 var Error = _p.LayDS();
//                 return View(Error);
//             }
//         }
//         if (p.Product != null && _p.Them(p.Product) > 0)
//         {
//             TempData["Success"] = "Thêm sản phẩm thành công!";
//         }
//         if (files != null && files.Count > 0) //Kiểm tra xem có file hay không
//         {
//             Console.WriteLine("Uploading " + files.Count + " files.");
//             var newProductId = _p.LayDSProduct().Max(x => x.ProductId); //Lấy Id sản phẩm mới thêm
//             //--Tạo thư mục lưu hình ảnh nếu chưa tồn tại
//             var webRoot = _env.WebRootPath;
//             var targetFolder = Path.Combine(webRoot, "images", "products");
//             if (!Directory.Exists(targetFolder)) Directory.CreateDirectory(targetFolder);
//             //--
//             foreach (var file in files)
//             {
//                 if (file != null && file.Length > 0)
//                 {
//                     var fileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName); //Tạo tên file
//                     var filePath = Path.Combine(targetFolder, fileName).Replace("\\", "/"); //Tạo đường dẫn
//                     //--Lưu file vào thư mục
//                     using (var stream = System.IO.File.Create(filePath))
//                     {
//                         file.CopyTo(stream);
//                     }
//                     //--
//                     //--Lưu đường dẫn file vào database
//                     var imgModel = new ImageModel()
//                     {
//                         ImagePath = Path.Combine("/images/products", fileName),
//                         ProductId = newProductId
//                     };
//                     _p.ThemImage(imgModel);
//                     //--
//                 }
//                 Console.WriteLine("Uploaded file: " + file.FileName);
//             }
//         }
//         return RedirectToAction("ProductAdd");
//     }
//     [HttpPost]
//     public IActionResult BrandAdd(ProductViewModel p)
//     {
//         if (!ModelState.IsValid)
//         {
//             var Error = _p.LayDS();
//             return View("ProductAdd", Error);
//         }
//         if (p.Brand != null && _p.ThemBrand(p.Brand) > 0)
//         {
//             TempData["BrandSuccess"] = "Thêm hãng mới thành công!";
//         }
//         return RedirectToAction("ProductAdd");
//     }
//     [HttpPost]
//     public IActionResult TypeAdd(ProductViewModel p)
//     {
//         if (!ModelState.IsValid)
//         {
//             var Error = _p.LayDS();
//             return View("ProductAdd", Error);
//         }
//         if (p.Type != null && _p.ThemType(p.Type) > 0)
//         {
//             TempData["TypeSuccess"] = "Thêm loại mới thành công!";
//         }
//         return RedirectToAction("ProductAdd");
//     }
// }