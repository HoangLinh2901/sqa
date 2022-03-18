using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sqa.Models;

namespace sqa.Controllers
{
    public class tbctdtsController : Controller
    {
        private SQAEntities db = new SQAEntities();

        // GET: tbctdts
        public ActionResult Index()
        {
            return View(db.tbctdt.ToList());
        }

        // GET: tbctdts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbctdt tbctdt = db.tbctdt.Find(id);
            if (tbctdt == null)
            {
                return HttpNotFound();
            }
            return View(tbctdt);
        }

        // GET: tbctdts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbctdts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,mactdt,tenctdt,khoaquanly,filectdt,ghichu")] tbctdt tbctdt)
        {
            if (ModelState.IsValid)
            {
                db.tbctdt.Add(tbctdt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbctdt);
        }

        // GET: tbctdts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbctdt tbctdt = db.tbctdt.Find(id);
            if (tbctdt == null)
            {
                return HttpNotFound();
            }
            return View(tbctdt);
        }

        // POST: tbctdts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,mactdt,tenctdt,khoaquanly,filectdt,ghichu")] tbctdt tbctdt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbctdt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbctdt);
        }

        // GET: tbctdts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbctdt tbctdt = db.tbctdt.Find(id);
            if (tbctdt == null)
            {
                return HttpNotFound();
            }
            return View(tbctdt);
        }

        // POST: tbctdts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbctdt tbctdt = db.tbctdt.Find(id);
            db.tbctdt.Remove(tbctdt);
            db.SaveChanges();
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
