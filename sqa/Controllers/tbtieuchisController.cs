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
    public class tbtieuchisController : Controller
    {
        private SQAEntities db = new SQAEntities();

        // GET: tbtieuchis
        public ActionResult Index()
        {
            return View(db.tbtieuchi.ToList());
        }

        // GET: tbtieuchis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtieuchi tbtieuchi = db.tbtieuchi.Find(id);
            if (tbtieuchi == null)
            {
                return HttpNotFound();
            }
            return View(tbtieuchi);
        }

        // GET: tbtieuchis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbtieuchis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tieuchuan,sotieuchi,tentieuchi")] tbtieuchi tbtieuchi)
        {
            if (ModelState.IsValid)
            {
                db.tbtieuchi.Add(tbtieuchi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbtieuchi);
        }

        // GET: tbtieuchis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtieuchi tbtieuchi = db.tbtieuchi.Find(id);
            if (tbtieuchi == null)
            {
                return HttpNotFound();
            }
            return View(tbtieuchi);
        }

        // POST: tbtieuchis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tieuchuan,sotieuchi,tentieuchi")] tbtieuchi tbtieuchi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbtieuchi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbtieuchi);
        }

        // GET: tbtieuchis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtieuchi tbtieuchi = db.tbtieuchi.Find(id);
            if (tbtieuchi == null)
            {
                return HttpNotFound();
            }
            return View(tbtieuchi);
        }

        // POST: tbtieuchis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbtieuchi tbtieuchi = db.tbtieuchi.Find(id);
            db.tbtieuchi.Remove(tbtieuchi);
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
