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
    public class tbnamhocsController : Controller
    {
        private SQAEntities db = new SQAEntities();

        // GET: tbnamhocs
        public ActionResult Index()
        {
            return View(db.tbnamhoc.ToList());
        }

        // GET: tbnamhocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbnamhoc tbnamhoc = db.tbnamhoc.Find(id);
            if (tbnamhoc == null)
            {
                return HttpNotFound();
            }
            return View(tbnamhoc);
        }

        // GET: tbnamhocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbnamhocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,namhoc")] tbnamhoc tbnamhoc)
        {
            if (ModelState.IsValid)
            {
                db.tbnamhoc.Add(tbnamhoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbnamhoc);
        }

        // GET: tbnamhocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbnamhoc tbnamhoc = db.tbnamhoc.Find(id);
            if (tbnamhoc == null)
            {
                return HttpNotFound();
            }
            return View(tbnamhoc);
        }

        // POST: tbnamhocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,namhoc")] tbnamhoc tbnamhoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbnamhoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbnamhoc);
        }

        // GET: tbnamhocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbnamhoc tbnamhoc = db.tbnamhoc.Find(id);
            if (tbnamhoc == null)
            {
                return HttpNotFound();
            }
            return View(tbnamhoc);
        }

        // POST: tbnamhocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbnamhoc tbnamhoc = db.tbnamhoc.Find(id);
            db.tbnamhoc.Remove(tbnamhoc);
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
