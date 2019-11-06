using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionCart.Web.DAL;
using SessionCart.Web.Models;
using Newtonsoft.Json;

namespace SessionCart.Web.Controllers
{
    public class StoreController : Controller
    {
        /* Steps
           TODO 02. (StoreController)    Create Index Action for store/index
           TODO 03. (Index View)         Create Index View for store/index
           TODO 04. (StoreController)    Add a call to Session to store the last access time
                                         On next access, get the last access time and compare it to current time.
                                         Display "It has been NN seconds since you have been here" (use ViewData for now)
                                         Toy around with the session timeout.
           TEST
           TODO 05. (StoreController)    Update Index Action to read (from DAO) and pass products
           TODO 06. (Index View)         Display Products
           TEST

           TODO 07. (Index View)         Add Form Tag w/ AddToCart button > POST to store/index
                                         Pass Product Id in Form
           TODO 08. (StoreController)    Create POST Index Action for store/index, accept product id
           
           TODO 09. (StoreController)    Create GetShoppingCart
                                            Reads cart from session and de-serializes
                                            Guarantee ShoppingCart is in session, create if not
                                         Create SaveShoppingCart 
                                            Serializes the cart and sets it in Session.

           TODO 10. (StoreController)    In POST Index: Retrieve Product, Add it to the shopping cart, 
                                         Save shoppingCart and redirect to store/viewcart     
                                         
           TODO 11. (StoreController)    Create ViewCart action for store/viewcart
                                         Retrieve the shoopping cart and pass to the view
           TODO 12. (ViewCart View)      Display shopping cart
           TEST
       */
        private IProductDAO productDAO;
        public StoreController(IProductDAO productDAO)
        {
            this.productDAO = productDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Get from session, the last time accessed
            string timeString = HttpContext.Session.GetString("Access");

            string message;
            if (timeString == null || timeString.Length == 0)
            {
                message = "Welcome!";
            }
            else
            {
                DateTime time = Convert.ToDateTime(timeString);
                message = $"Welcome back! You were here {(DateTime.Now - time).TotalSeconds:N2} seconds ago.";
            }

            ViewData["Message"] = message;


            // For demo purposes, create and populate a shopping cart.
            IList<Product> products = productDAO.GetProducts();
            ShoppingCart cart = new ShoppingCart();

            for (int i = 0; i < products.Count; i++)
            {
                cart.AddToCart(products[i], i + 1);
            }

            // Serialize the cart object into a string for saving into Session
            string cartJson = JsonConvert.SerializeObject(cart);

            // Save teh cart string into session
            HttpContext.Session.SetString("Cart", cartJson);

            /////////////////////////////////////////////////////////////////

            // Now Get the Cart string back from Session
            string s = HttpContext.Session.GetString("Cart");

            // Now de-serialize it into a new cart object
            ShoppingCart anotherCart = JsonConvert.DeserializeObject<ShoppingCart>(s);

            // Update Session with the *new* last time accessed
            HttpContext.Session.SetString("Access", DateTime.Now.ToString());

            return View();
        }
    }
}