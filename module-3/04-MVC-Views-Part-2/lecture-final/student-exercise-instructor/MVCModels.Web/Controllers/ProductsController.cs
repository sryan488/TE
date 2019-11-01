using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCModels.Web.DAL;
using MVCModels.Web.Models;

namespace MVCModels.Web.Controllers
{
    public class ProductsController : Controller
    {
        private IProductDAO productDAO;
        public ProductsController(IProductDAO productDAO)
        {
            this.productDAO = productDAO;
        }

        // GET: products/
        // GET: products/index
        // GET: products/index?minPrice=25&sortOrder=PriceHighToLow
        public IActionResult Index(ProductFilter filter, ProductSortOrder sortOrder = ProductSortOrder.Default)
        {
            IList<Product> products = productDAO.GetAll(filter, sortOrder);
            return View(products);
        }

        // GET: products/tile?minPrice=50
        // GET: products/tile
        public IActionResult Tile(ProductFilter filter)
        {
            IList<Product> products = productDAO.GetAll(filter, ProductSortOrder.Default);
            string message = $"{products.Count} {(products.Count == 1 ? "product" : "products")} were found.";

            // TODO: Add the message to ViewData, then show it in the view
            return View(products);
        }

        // GET: products/detail/1
        // GET: products/detail?id=1
        public IActionResult Detail(int id)
        {
            Product product = productDAO.GetById(id);
            return View(product);
        }
    }
}