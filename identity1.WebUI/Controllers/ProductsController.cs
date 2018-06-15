using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using identity1.Common.Entities;
using identity1.Common.Models.Enums;
using identity1.LogicContracts;
using Microsoft.AspNet.Identity;

namespace identity1.WebUI.Controllers
{
    public class ProductsController:Controller
    {
        IProductLogic logic;
        public ProductsController(IProductLogic _logic)
        {
            logic = _logic;
        }
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Index(int type = 1)
        {
            try
            {
                var products = logic.GetProducts(type);
                return View(products);
            }
            catch (NullReferenceException)
            {
                return HttpNotFound();
            }
        }
        public async Task<ActionResult> PageOfProduct(int id)
        {
            try
            {
                var product = logic.GetProduct(id);
                return View(await product);
            }
            catch (NullReferenceException)
            {
                return HttpNotFound();
            }
        }


        public bool AddToBAsket(int id)
        {
            for (int i = 0;i < Session.Count;i++)
            {
                int tempId = int.Parse(Session[i].ToString());
                if (tempId == id)
                {
                    return false;
                }
            }
            Session.Add(id.ToString(), id);
            return true;
        }

        public ActionResult Basket()
        {
            int[] productIdInBasket = new int[Session.Count];
            for (int i = 0;i < Session.Count;i++)
            {
                productIdInBasket[i] = int.Parse(Session[i].ToString());
            }
            return View(logic.GetProducts(productIdInBasket));
        }
        public ActionResult DeleteFromBasket(int id)
        {
            for (int i = 0;i < Session.Count;i++)
            {
                if (int.Parse(Session[i].ToString()) == id)
                {
                    Session.Remove(id.ToString());
                }
            }
            return RedirectToAction("Basket");
        }
        public ActionResult OrderPage()
        {
            int[] orderlist = new int[Session.Count];
            for (int i = 0;i < Session.Count;i++)
            {
                orderlist[i] = int.Parse(Session[i].ToString());
            }
            ViewBag.Products = logic.GetProducts(orderlist);
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
            logic.CreateOrder(order, id, orderlist, qty);
            return RedirectToAction("Index");
        }

        //Partial view for products list
        public ActionResult OrderList(IEnumerable<Product> prod)
        {
            return View(prod);
        }






      
        //=============================================
        #region AdminFunctions
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product , string[] charak, IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                file.SaveAs(Server.MapPath("~/Content/Images/" + file.FileName));
            }
            if (ModelState.IsValid)
            {
                //logic.CreateProduct(product, charak);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Edit/5
        //[Authorize(Roles = "admin")]
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = await db.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}
        //[Authorize(Roles = "admin")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "ProductId,Title,Description,CountInStock,CostProduct,TypeId")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(product).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}

        //[Authorize(Roles = "admin")]
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = await db.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}
        //[Authorize(Roles = "admin")]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Product product = await db.Products.FindAsync(id);
        //    db.Products.Remove(product);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
        #endregion
    }
}


