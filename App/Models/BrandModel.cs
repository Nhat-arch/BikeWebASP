using System.ComponentModel.DataAnnotations;
namespace App.Models;

public class BrandModel
{
    [Key]
    public int BrandId { get; set; }

    [Required(ErrorMessage = "Tên thương hiệu không được để trống")]
    [StringLength(100, ErrorMessage = "Tên thương hiệu tối đa 100 ký tự")]
    [Display(Name = "Tên thương hiệu")]
    public string BrandName { get; set; } = string.Empty;
}