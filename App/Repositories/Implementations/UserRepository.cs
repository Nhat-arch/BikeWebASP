using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Repositories.Interfaces;

namespace App.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly BikeContext _context;

        public UserRepository(BikeContext context)
        {
            _context = context;
        }
    }
}