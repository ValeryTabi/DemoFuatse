using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoFua.Models;

namespace DemoFua.Controllers
{
    [Authorize]
    public class FundsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Funds
        public async Task<ActionResult> Index()
        {
            var funds = db.Funds.Include(f => f.company);
            return View(await funds.ToListAsync());
        }

        // GET: Funds/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fund fund = await db.Funds.FindAsync(id);
            if (fund == null)
            {
                return HttpNotFound();
            }
            return View(fund);
        }

        // GET: Funds/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "name");
            return View();
        }

        // POST: Funds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,requestDate,industry,status,isGranted,CompanyId")] Fund fund)
        {
            if (ModelState.IsValid)
            {
                db.Funds.Add(fund);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "name", fund.CompanyId);
            return View(fund);
        }

        // GET: Funds/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fund fund = await db.Funds.FindAsync(id);
            if (fund == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "name", fund.CompanyId);
            return View(fund);
        }

        // POST: Funds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,requestDate,industry,status,isGranted,CompanyId")] Fund fund)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fund).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "name", fund.CompanyId);
            return View(fund);
        }

        // GET: Funds/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fund fund = await db.Funds.FindAsync(id);
            if (fund == null)
            {
                return HttpNotFound();
            }
            return View(fund);
        }

        // POST: Funds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Fund fund = await db.Funds.FindAsync(id);
            db.Funds.Remove(fund);
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
