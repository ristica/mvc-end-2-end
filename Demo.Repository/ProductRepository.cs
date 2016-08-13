using Demo.Db;
using Demo.Entities;
using Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repository
{
    public class ProductRepository : IProductRepository
    {
        public ProductViewModel UpdateProduct(ProductViewModel vm)
        {
            using (var ctx = new DemoDbContext())
            {
                if (vm.ProductId == 0)
                {
                    // add 
                    var e = ctx.ProductSet.Add(ObjectMapper.MapViewModelToEntity<Product, ProductViewModel>(vm));
                    ctx.SaveChanges();

                    return ObjectMapper.MapEntityToViewModel<ProductViewModel, Product>(e);
                }
                else
                {
                    // update
                    var e = ctx.ProductSet.SingleOrDefault(p => p.ProductId == vm.ProductId);
                    if (e == null)
                    {
                        throw new ApplicationException($"No product with id '{vm.ProductId}'.");
                    }

                    e.ProductId = vm.ProductId;
                    e.ProductName = vm.ProductName;
                    e.ProductDescription = vm.ProductDescription;
                    e.ProductPrice = vm.ProductPrice;

                    ctx.SaveChanges();

                    return ObjectMapper.MapEntityToViewModel<ProductViewModel, Product>(e);
                }                
            }
        }

        public ProductViewModel GetProduct(int productId)
        {
            using (var ctx = new DemoDbContext())
            {
                var entity = ctx.ProductSet.SingleOrDefault(p => p.ProductId == productId);
                return entity == null ? null : ObjectMapper.MapEntityToViewModel<ProductViewModel, Product>(entity);
            }
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            using (var ctx = new DemoDbContext())
            {
                var list = new List<ProductViewModel>();
                var entities = ctx.ProductSet;

                foreach (var e in entities)
                {
                    list.Add(ObjectMapper.MapEntityToViewModel<ProductViewModel, Product>(e));
                }

                return list;
            }
        }

        public void DeleteProduct(int productId)
        {
            using (var ctx = new DemoDbContext())
            {
                var entity = ctx.ProductSet.SingleOrDefault(p => p.ProductId == productId);
                if (entity == null)
                {
                    throw new ApplicationException($"No product with id '{productId}'.");
                }

                ctx.ProductSet.Remove(entity);
                ctx.SaveChanges();
            }
        }
    }
}
