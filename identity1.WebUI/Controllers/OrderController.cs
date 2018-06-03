using System.Web.Mvc;
using identity1.Domain.Abstract;
using identity1.Domain.Entities;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;

namespace identity1.Controllers
{
    public class OrderController:Controller
    {
        IOrderRepository repository;
        public OrderController(IOrderRepository _repository)
        { 
            repository = _repository;
        }
        // GET: Order
        public ActionResult OrderPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrderPage(Order order)
        {
            repository.CreateOrder(order);
            return RedirectToAction("Index","Products");
        }

        //Partial view for products list
        
    }
}