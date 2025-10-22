using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Ocsp;
namespace App.Models;

public class UserModel
{
    [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
    public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    public string Password { get; set; } = string.Empty;
    public int RoleId { get; set; }
}
