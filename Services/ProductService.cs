using Repositories;
using System.Data;
using System.Diagnostics;
using Zxcvbn;
namespace Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _IProductRepository;

        public ProductService(IProductRepository IProductRepository)
        {
            _IProductRepository = IProductRepository;
        }


        public async Task<List<Product>> getAllProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _IProductRepository.getAllProducts(position,skip,desc, minPrice,maxPrice ,categoryIds);
        }

        public async Task<Product> getProductById(int id)
        {
            return await _IProductRepository.getProductById(id);
        }
    }
}
