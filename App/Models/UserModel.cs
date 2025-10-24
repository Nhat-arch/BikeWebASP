using System.ComponentModel.DataAnnotations;
namespace App.Models;

public class UserModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
    public string? Username { get; set; }
    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    public string? Password { get; set; }
    public RoleModel Role { get; set; } = new RoleModel();
    public int TrangThai { get; set; }
}
