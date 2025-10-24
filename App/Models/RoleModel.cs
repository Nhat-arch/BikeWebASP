using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class RoleModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Tên role không được để trống")]
    [StringLength(50, ErrorMessage = "Độ dài tối đa 20 ký tự")]
    [Display(Name = "Tên chức vụ")]
    public string? Name { get; set; }
    public int TrangThai { get; set; }
    public ICollection<UserModel> Users { get; } = new List<UserModel>();
}

