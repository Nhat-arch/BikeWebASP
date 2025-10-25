using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();
        UserModel? GetById(int id);
        void Add(UserModel user);
        void Delete(int id);
        bool Login(string username, string password);
    }
}