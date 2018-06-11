using System.Collections.Generic;
using System.Web.Mvc;
using identity1.Domain.Abstract;
using identity1.Domain.Entities;
using identity1.Domain.ViewModels;
using Microsoft.AspNet.Identity;

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
            int[] orderlist = new int[Session.Count];
            for (int i = 0;i < Session.Count;i++)
            {
                orderlist[i] = int.Parse(Session[i].ToString());
            }
            ViewBag.Products = repository.GetOrderList(orderlist);

            return View();
        }
        [HttpPost]
        public ActionResult OrderPage(Order order, int[] qty)
        {
            string id = User.Identity.GetUserId();
            int[] orderlist = new int[Session.Count];
            for (int i = 0;i < Session.Count;i++)
            {
                orderlist[i] = int.Parse(Session[i].ToString());
            }
            repository.CreateOrder(order , id , orderlist, qty);
            return RedirectToAction("Index","Products");
        }

        //Partial view for products list
        public ActionResult OrderList(IEnumerable<OrderList> prod)
        {
            return View(prod);
        }
    }
}