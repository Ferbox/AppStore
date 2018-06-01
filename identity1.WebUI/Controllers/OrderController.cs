using System.Collections.Generic;
using System.Web.Mvc;
using identity1.Domain.Entities;

namespace identity1.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult CreateOrder(IEnumerable<Product> products)
        {
            Order order = new Order();
           
            return View();
        }
    }
}