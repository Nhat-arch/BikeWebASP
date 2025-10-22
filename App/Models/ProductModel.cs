using System.ComponentModel.DataAnnotations;
namespace App.Models;

public class ProductModel
{
    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
    [StringLength(100, ErrorMessage = "Tên sản phẩm tối đa 100 ký tự")]
    [Display(Name = "Tên sản phẩm")]
    public string ProductName { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Hãy chọn thương hiệu")]
    [Display(Name = "Thương hiệu")]
    public int BrandId { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Hãy chọn loại sản phẩm")]
    [Display(Name = "Loại sản phẩm")]
    public int TypeId { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn 0")]
    [Display(Name = "Giá sản phẩm")]
    public decimal ProductPrice { get; set; }

    [Display(Name = "Mô tả sản phẩm")]
    public string? ProductDescription { get; set; } = string.Empty;

    [Display(Name = "Lượt xem")]
    public int LuotXem { get; set; } = 0;
}