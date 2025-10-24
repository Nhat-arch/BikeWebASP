using System.ComponentModel.DataAnnotations;
namespace App.Models;

public class BrandModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Tên thương hiệu không được để trống")]
    [StringLength(100, ErrorMessage = "Tên thương hiệu tối đa 100 ký tự")]
    [Display(Name = "Tên thương hiệu")]
    public string? Name { get; set; }
    public int TrangThai { get; set; }
    public ICollection<ProductModel> Products { get; } = new List<ProductModel>();
}