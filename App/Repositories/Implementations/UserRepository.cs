
using App.Data;
using App.Models;
using App.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<UserModel> GetAll()
        {
            return _context.Users
                .Include(u => u.Role)
                .Where(u => u.TrangThai == 1)
                .ToList();
        }
        public UserModel? GetById(int id)
        {
            return _context.Users.Find(id);
        }
        public void Add(UserModel user)
        {
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            user.Role.Id = 3;
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null) user.TrangThai = 0;
            _context.SaveChanges();
        }
        public bool Login(string username, string password)
        {
            var user = GetAll().FirstOrDefault(u => u.Username == username);
            if (user?.Password == null) return false;

            return VerifyPassword(user, password);
        }
        private bool VerifyPassword(UserModel user, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}