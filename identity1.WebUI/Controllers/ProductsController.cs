using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using identity1.Domain.Entities;
using identity1.Domain.Abstract;

namespace identity1.Controllers
{
    public class ProductsController:Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        IProductsRepository repository;
        public ProductsController(IProductsRepository _repository)
        {
            repository = _repository;
        } 
        public ActionResult Index(int type = 1)
        {
            var products = repository.GetProductsForCatalog(type);
            return View(products);
        } //main catalog
        public ActionResult PageOfProduct(int id)
        {
            var product = repository.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        } 
        //#region AdminFunctions
        //// GET: Products/Create
        //[Authorize(Roles = "admin")]
        //public ActionResult Create()
        //{
        //    List<string> Types = new List<string> { "iPhone", "iMac", "iPad", "MacBook", "Watch", "Accessories" };

        //    SelectList types = new SelectList(Types);
        //    ViewBag.Types = types;
        //    return View();
        //}

        //// POST: Products/Create
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "ProductId,Title,Description,CountInStock,CostProduct,TypeId")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Products.Add(product);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(product);
        //}

        //// GET: Products/Edit/5
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

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Product product = await db.Products.FindAsync(id);
        //    db.Products.Remove(product);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
        //#endregion
        
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
            Session[id.ToString()] = id.ToString();
            return true;
        }

        public ActionResult Basket()
        {
            int[] productIdInBasket = new int[Session.Count];
            for (int i = 0;i < Session.Count;i++)
            {
                productIdInBasket[i] = int.Parse(Session[i].ToString());
            }
            return View(repository.GetProductForBasket(productIdInBasket));
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
