using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using identity1.Models;
using System.Collections.Generic;

namespace identity1.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public  ActionResult Index(int? type)
        {
            Image image = new Image { ImageId = 1, Path = @"\Content\Images\IphoneX.jpg" };
            Product product_1 = new Product { ProductId = 1, Title = "iPhone X", Description = "Last model", Images = new List<Image>() { image }, CostProduct = 999, TypeId = 1 };
            Product product_2 = new Product { ProductId = 2, Title = "iMac", Description = "Last model", Images = new List<Image>() { image }, CostProduct = 899, TypeId = 2 };
            Product product_3 = new Product { ProductId = 3, Title = "MacBook", Description = "Last model", Images = new List<Image>() { image }, CostProduct = 799, TypeId = 3 };
            Product product_4 = new Product { ProductId = 4, Title = "iPhone 8", Description = "Last model", Images = new List<Image>() { image }, CostProduct = 999, TypeId = 1 };
            Product product_5 = new Product { ProductId = 5, Title = "iPad", Description = "Last model", Images = new List<Image>() { image }, CostProduct = 899, TypeId = 4 };
            Product product_6 = new Product { ProductId = 6, Title = "MacBook Pro", Description = "Last model", Images = new List<Image>() { image }, CostProduct = 799, TypeId = 3 };
            Product product_7 = new Product { ProductId = 7, Title = "iPhone 7", Description = "Last model", Images = new List<Image>() { image }, CostProduct = 999, TypeId = 1 };
            Product product_8 = new Product { ProductId = 8, Title = "iPad Pro", Description = "Last model", Images = new List<Image>() { image }, CostProduct = 899, TypeId = 2 };
            Product product_9 = new Product { ProductId = 9, Title = "iPhone 6s", Description = "Last model", Images = new List<Image>() { image }, CostProduct = 799, TypeId = 1 };

            List<Product> list = new List<Product> { product_1, product_2, product_3, product_4, product_1, product_2, product_3, product_4, product_5, product_1, product_2, product_3, product_4, product_1, product_2, product_3, product_4, product_5, product_6, product_7, product_8, product_9 };
            var products = list.Where(x => x.TypeId == 1);

            return View(products);
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            List<string> Types = new List<string> { "iPhone", "iMac", "iPad", "MacBook", "Watch", "Accessories" };

            SelectList types = new SelectList(Types);
            ViewBag.Types = types;
            return View();
        }

        // POST: Products/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductId,Title,Description,CountInStock,CostProduct,TypeId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductId,Title,Description,CountInStock,CostProduct,TypeId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
