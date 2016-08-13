using Demo.Repository;
using Demo.ViewModels;
using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demo.Controllers.Mvc
{
    public class ProductController : Controller
    {
        #region Fields

        private readonly IProductRepository _repository;

        #endregion

        #region C-Tor

        /// <summary>
        /// this is the default constructor
        /// </summary>
        public ProductController() : this(new ProductRepository()) { }

        /// <summary>
        /// this on eis for test purposes
        /// </summary>
        /// <param name="repository"></param>
        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
        }

        #endregion

        #region HttpGet

        [HttpGet]
        public ActionResult List()
        {
            var model = this._repository.GetProducts();
            return View("List", model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = this._repository.GetProduct(id);
            if (model == null)
            {
                return HttpNotFound("Product with id '{0}' was not found.");
            }
            return View("Details", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = this._repository.GetProduct(id);
            if (model == null)
            {
                return HttpNotFound("Product with id '{0}' was not found.");
            }
            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create", new ProductViewModel());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = this._repository.GetProduct(id);
            if (model == null)
            {
                return HttpNotFound("Product with id '{0}' was not found.");
            }

            ViewBag.Question = "Are you sure you want to delete this?";
            return View("Delete", model);
        }

        [HttpGet]
        public ActionResult Confirmation(int productId)
        {
            ViewBag.ProductId = productId;
            return View("Confirmation");
        }

        #endregion

        #region HttpPost

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", product);
            }

            var result = this._repository.UpdateProduct(product);

            return RedirectToAction(
                "Confirmation",
                new RouteValueDictionary(
                    new
                    {
                        controller = "Product",
                        action = "Confirmation",
                        productId = result.ProductId
                    }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", product);
                }

                var result = this._repository.UpdateProduct(product);

                return RedirectToAction(
                    "Confirmation",
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Product",
                            action = "Confirmation",
                            productId = result.ProductId
                        }));
            }
            catch(Exception ex)
            {
                Debugger.Break();
            }

            return null;
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            this._repository.DeleteProduct(id);

            return RedirectToAction(
                "Confirmation",
                new RouteValueDictionary(
                    new
                    {
                        controller = "Product",
                        action = "Confirmation",
                        productId = id
                    }));
        }

        #endregion
    }
}
