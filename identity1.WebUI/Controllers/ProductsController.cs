using System;
using System.Web.Mvc;
using identity1.LogicContracts;

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
        public ActionResult PageOfProduct(int id)
        {
            try
            {
                var product = logic.GetProduct(id);
                return View(product);
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


    }
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