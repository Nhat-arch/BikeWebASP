using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class TypeModel
{
    [Key]
    public int TypeId { get; set; }

    [Required(ErrorMessage = "Tên loại sản phẩm không được để trống")]
    [StringLength(50, ErrorMessage = "Tên loại tối đa 50 ký tự")]
    [Display(Name = "Loại sản phẩm")]
    public string TypeName { get; set; } = string.Empty;
}