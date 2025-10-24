
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using App.Data;
using App.Models;
using App.Repositories.Interfaces;

namespace App.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly BikeContext _context;
        private readonly IPasswordHasher<UserModel> _passwordHasher;

        public UserRepository(BikeContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<UserModel>();
        }

        // 🔹 Lấy thông tin user theo username
        public UserModel? GetUser(string username)
        {
            return _context.Users
                .Include(u => u.Role) // load cả role
                .FirstOrDefault(u => u.TrangThai == 1 && u.Username == username);
        }

        // 🔹 Đăng ký user mới
        public int Register(UserModel user)
        {
            // Hash mật khẩu trước khi lưu
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            user.TrangThai = 1;

            // Nếu chưa chọn role, mặc định là Customer (id = 3)
            if (user.Role.Id == 0)
                user.Role.Id = 3;

            _context.Users.Add(user);
            return _context.SaveChanges();
        }

        // 🔹 Kiểm tra đăng nhập
        public bool Login(string username, string password)
        {
            var user = GetUser(username);
            if (user == null) return false;

            return VerifyPassword(user, password);
        }

        // 🔹 Xác thực mật khẩu
        private bool VerifyPassword(UserModel user, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            return result == PasswordVerificationResult.Success;
        }

        // 🔹 Lấy RoleId của user
        public int GetRole(string username)
        {
            var user = GetUser(username);
            return user?.Role.Id ?? 0;
        }

        // 🔹 (Tùy chọn) Lấy tất cả user
        public IEnumerable<UserModel> GetAllUsers()
        {
            return _context.Users
                .Include(u => u.Role)
                .Where(u => u.TrangThai == 1)
                .ToList();
        }

        // 🔹 (Tùy chọn) Vô hiệu hóa user
        public bool DisableUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null) return false;

            user.TrangThai = 0;
            _context.SaveChanges();
            return true;
        }
    }
}