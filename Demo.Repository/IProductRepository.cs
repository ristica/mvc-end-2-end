using Demo.Entities;
using Demo.ViewModels;
using System.Collections.Generic;


namespace Demo.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductViewModel> GetProducts();
        ProductViewModel GetProduct(int productId);
        ProductViewModel UpdateProduct(ProductViewModel product);
        void DeleteProduct(int productId);
    }
}