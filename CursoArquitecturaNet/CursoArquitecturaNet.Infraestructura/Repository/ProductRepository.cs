using CursoArquitecturaNet.Core.Entities;
using CursoArquitecturaNet.Core.Repositories;
using CursoArquitecturaNet.Infraestructura.Data;
using CursoArquitecturaNet.Infraestructura.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoArquitecturaNet.Infraestructura.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CursoArquitecturaNetContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Product>> GetProductByNameAsync(string productName) {
            return await dbContext.Products
                .Where(x => x.ProductName.Contains(productName))
                .ToListAsync();
        }
    }
}
