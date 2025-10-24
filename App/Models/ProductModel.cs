using System.ComponentModel.DataAnnotations;
namespace App.Models;

public class ProductModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
    [StringLength(100, ErrorMessage = "Tên sản phẩm tối đa 100 ký tự")]
    [Display(Name = "Tên sản phẩm")]
    public string? Name { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Hãy chọn thương hiệu")]
    [Display(Name = "Thương hiệu")]
    public BrandModel Brand { get; set; } = new BrandModel();

    [Range(0.01, double.MaxValue, ErrorMessage = "Hãy chọn loại sản phẩm")]
    [Display(Name = "Loại sản phẩm")]
    public TypeModel Type { get; set; } = new TypeModel();

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn 0")]
    [Display(Name = "Giá sản phẩm")]
    public decimal Price { get; set; }

    [Display(Name = "Mô tả sản phẩm")]
    public string? Description { get; set; }

    [Display(Name = "Lượt xem")]
    public int LuotXem { get; set; }
    public int TrangThai { get; set; }
    public ICollection<ImageModel> Images { get; } = new List<ImageModel>();
}