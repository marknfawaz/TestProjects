using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modernize.Web.Models;
using Modernize.Web.Mvc.Data;
using Modernize.Web.Facade;

namespace Modernize.Web.Mvc.Controllers
{
    public class PurchasesController : Controller
    {
        private ModernizeWebMvcContext db = new ModernizeWebMvcContext();
        private PurchaseFacade purchaseFacade = new PurchaseFacade();

        // GET: Purchases
        public async Task<ActionResult> Index()
        {
            var result = purchaseFacade.GetPurchases();
            var purchases = db.Purchases.Include(p => p.Customer).Include(p => p.Product);
            return View(await purchases.ToListAsync());
        }

        // GET: Purchases/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            Purchase myPurchase = purchaseFacade.GetPurchase();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            var sampleData = purchaseFacade.GetSampleData();
            return View(purchase);
        }

        // GET: Purchases/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PurchaseId,ProductId,CustomerId,Date")] Purchase purchase)
        {
            purchaseFacade.InsertPurchase(purchase);
            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchase);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", purchase.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", purchase.ProductId);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", purchase.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", purchase.ProductId);
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PurchaseId,ProductId,CustomerId,Date")] Purchase purchase)
        {
            purchaseFacade.UpdatePurchase(purchase);
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", purchase.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", purchase.ProductId);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            purchaseFacade.DeletePurchase(new Purchase());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Purchase purchase = await db.Purchases.FindAsync(id);
            db.Purchases.Remove(purchase);
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
