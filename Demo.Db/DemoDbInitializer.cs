using System.Collections.Generic;
using System.Data.Entity;
using Demo.Entities;

namespace Demo.Db
{
    public class DemoDbInitializer : DropCreateDatabaseAlways<DemoDbContext>
    {
        protected override void Seed(DemoDbContext context)
        {
            //var productList = new List<Product>
            //{
            //    new Product
            //    {
            //        ProductId = 1,
            //        ProductName = "Product 1",
            //        ProductDescription = "Description 1",
            //        ProductPrice = 111.00M
            //    },
            //    new Product
            //    {
            //        ProductId = 2,
            //        ProductName = "Product 2",
            //        ProductDescription = "Description 2",
            //        ProductPrice = 222.00M
            //    }
            //};

            //foreach (var p in productList)
            //{
            //    context.ProductSet.Add(p);
            //}

            base.Seed(context);
        }
    }
}