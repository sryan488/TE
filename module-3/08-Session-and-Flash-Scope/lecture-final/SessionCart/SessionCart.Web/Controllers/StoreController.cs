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
        private const string cartSessionKey = "Cart";
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

            ShoppingCart cart = GetShoppingCart();

            // At this point, I have the cart, with the items as they were last saved into session

            // For demo purposes, randomly select a product to add to the cart
            IList<Product> products = productDAO.GetProducts();
            Random random = new Random();
            int index = random.Next(products.Count);
            Product selectedProduct = products[index];

            cart.AddToCart(selectedProduct, 1);

            SaveShoppingCart(cart);

            // Update Session with the *new* last time accessed
            HttpContext.Session.SetString("Access", DateTime.Now.ToString());

            ViewData["Message"] = $"Congratulations, you just bought a {selectedProduct.Name} for {selectedProduct.Cost:C}";

            return View();
        }

        private void SaveShoppingCart(ShoppingCart cart)
        {
            // Jam that baby back into session
            string cartJson = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString(cartSessionKey, cartJson);
        }

        private ShoppingCart GetShoppingCart()
        {
            // Get the cart from session
            string s = HttpContext.Session.GetString(cartSessionKey);
            ShoppingCart cart;

            if (s == null || s.Length == 0)
            {
                cart = new ShoppingCart();
            }
            else
            {
                // Deserialize to change from a string to an object (DSO)
                cart = JsonConvert.DeserializeObject<ShoppingCart>(s);
            }

            return cart;
        }
    }
}