using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class TypeModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Tên loại sản phẩm không được để trống")]
    [StringLength(50, ErrorMessage = "Tên loại tối đa 50 ký tự")]
    [Display(Name = "Tên Loại sản phẩm")]
    public string? Name { get; set; }
    public int TrangThai { get; set; }
    public ICollection<ProductModel> Products { get; } = new List<ProductModel>();
}