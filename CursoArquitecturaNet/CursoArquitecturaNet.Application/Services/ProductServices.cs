using CursoArquitecturaNet.Application.Interfaces;
using CursoArquitecturaNet.Core.Entities;
using CursoArquitecturaNet.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoArquitecturaNet.Application.Services
{
    public class ProductServices : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductServices(IProductRepository productRepository) {
            this.productRepository = productRepository;
        }
        public async Task<Product> Create(Product product) {
            await ValidateProductIfExist(product);
            var newEntity = await productRepository.AddAsync(product);
            return newEntity;
        }

        public async Task Delete(Product product) {
            ValidateProductIfNotExist(product);
            var deletedProduct = await productRepository.GetByIdAsync(product.Id);
            if (deletedProduct == null)
                throw new ApplicationException($"Entity could not be loaded.");
            await productRepository.DeleteAsync(deletedProduct);
        }
        public async Task<Product> GetProductById(int productId) {
            var product = await productRepository.GetByIdAsync(productId);
            return product;
        }
        public async Task<IEnumerable<Product>> GetProductByName(string productName) {
            var productList = await productRepository.GetProductByNameAsync(productName);
            return productList;
        }

        public async Task<IEnumerable<Product>> GetProductList() { 
            var prudctList = await productRepository.GetAllAsync();
            return prudctList;
        }
        public async Task Update(Product product) {
            ValidateProductIfNotExist(product);
            var editProduct = await productRepository.GetByIdAsync(product.Id);
            if (editProduct == null)
                throw new ApplicationException($"Entity could not be loaded.");
            editProduct.Id = product.Id;
            editProduct.ProductName = product.ProductName;
            editProduct.UnitPrice = product.UnitPrice;
            editProduct.UnitsInStock = product.UnitsInStock;
            editProduct.UnitsOnOrder = product.UnitsOnOrder;
        }

        private async Task ValidateProductIfExist(Product product)
        {
            var existingEntity = await productRepository.GetByIdAsync(product.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{product.ToString()} with this id already exist");
        }

        private void ValidateProductIfNotExist(Product product)
        {
            var existingEntity = productRepository.GetByIdAsync(product.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{product.ToString()} with this id is not exist");
        }
    }
}
