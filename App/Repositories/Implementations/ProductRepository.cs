using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Repositories.Interfaces;

namespace App.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly BikeContext _context;

        public ProductRepository(BikeContext context)
        {
            _context = context;
        }
    }
}