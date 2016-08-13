using Demo.Db;
using Demo.Repository;
using Demo.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Integration.Tests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        [TestMethod]
        public void TestCreateNewProducts()
        {
            var repository = new ProductRepository();

            var vm = new ProductViewModel
            {
                ProductId = 0,
                ProductName = "TestProduct",
                ProductDescription = "TestDescription",
                ProductPrice = new decimal(111)
            };

            var product = repository.UpdateProduct(vm);

            Assert.IsNotNull(product);
            Assert.IsTrue(product.ProductName == "TestProduct");
            Assert.IsTrue(product.ProductDescription == "TestDescription");
            Assert.IsTrue(product.ProductPrice == new decimal(111));
        }

        [TestMethod]
        public void TestUpdateProduct()
        {
            var repository = new ProductRepository();

            var vm = new ProductViewModel
            {
                ProductId = 0,
                ProductName = "TestProduct",
                ProductDescription = "TestDescription",
                ProductPrice = new decimal(111)
            };

            // add new product
            var product = repository.UpdateProduct(vm);

            Assert.IsTrue(product.ProductName == "TestProduct");
            Assert.IsTrue(product.ProductDescription == "TestDescription");
            Assert.IsTrue(product.ProductPrice == new decimal(111));

            // update product
            vm.ProductId = product.ProductId;
            vm.ProductName = "Updated Test Product";
            vm.ProductDescription = "Updated Test Description";
            vm.ProductPrice = new decimal(222);

            product = repository.UpdateProduct(vm);

            Assert.IsTrue(product.ProductName == "Updated Test Product");
            Assert.IsTrue(product.ProductDescription == "Updated Test Description");
            Assert.IsTrue(product.ProductPrice == new decimal(222));
        }

        [TestMethod]
        public void TestDeleteProduct()
        {
            var repository = new ProductRepository();

            var vm = new ProductViewModel
            {
                ProductId = 0,
                ProductName = "TestProduct",
                ProductDescription = "TestDescription",
                ProductPrice = new decimal(111)
            };

            // add product
            var product = repository.UpdateProduct(vm);

            repository.DeleteProduct(product.ProductId);

            var result = repository.GetProduct(product.ProductId);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetProduct()
        {
            var repository = new ProductRepository();

            var vm = new ProductViewModel
            {
                ProductId = 0,
                ProductName = "TestProduct",
                ProductDescription = "TestDescription",
                ProductPrice = new decimal(111)
            };

            // add product
            var product = repository.UpdateProduct(vm);
            var result = repository.GetProduct(product.ProductId);

            Assert.IsNotNull(product);
            Assert.IsTrue(result.ProductName == "TestProduct");
            Assert.IsTrue(result.ProductDescription == "TestDescription");
            Assert.IsTrue(result.ProductPrice == new decimal(111));
        }

        [TestMethod]
        public void TestGetProducts()
        {
            var repository = new ProductRepository();

            var vm1 = new ProductViewModel
            {
                ProductId = 0,
                ProductName = "TestProduct 1",
                ProductDescription = "TestDescription 1",
                ProductPrice = new decimal(111)
            };
            var vm2 = new ProductViewModel
            {
                ProductId = 0,
                ProductName = "TestProduct 2",
                ProductDescription = "TestDescription 2",
                ProductPrice = new decimal(112)
            };

            var p1 = repository.UpdateProduct(vm1);
            var p2 = repository.UpdateProduct(vm2);

            IEnumerable<ProductViewModel> products = repository.GetProducts();

            Assert.IsNotNull(products.SingleOrDefault(p => p.ProductId == p1.ProductId));
            Assert.IsNotNull(products.SingleOrDefault(p => p.ProductId == p2.ProductId));
        }
    }
}
