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
    public class tbtieuchuansController : Controller
    {
        private SQAEntities db = new SQAEntities();

        // GET: tbtieuchuans
        public ActionResult Index()
        {
            return View(db.tbtieuchuan.ToList());
        }

        // GET: tbtieuchuans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtieuchuan tbtieuchuan = db.tbtieuchuan.Find(id);
            if (tbtieuchuan == null)
            {
                return HttpNotFound();
            }
            return View(tbtieuchuan);
        }

        // GET: tbtieuchuans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbtieuchuans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,sotieuchuan,tentieuchuan")] tbtieuchuan tbtieuchuan)
        {
            if (ModelState.IsValid)
            {
                db.tbtieuchuan.Add(tbtieuchuan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbtieuchuan);
        }

        // GET: tbtieuchuans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtieuchuan tbtieuchuan = db.tbtieuchuan.Find(id);
            if (tbtieuchuan == null)
            {
                return HttpNotFound();
            }
            return View(tbtieuchuan);
        }

        // POST: tbtieuchuans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,sotieuchuan,tentieuchuan")] tbtieuchuan tbtieuchuan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbtieuchuan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbtieuchuan);
        }

        // GET: tbtieuchuans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbtieuchuan tbtieuchuan = db.tbtieuchuan.Find(id);
            if (tbtieuchuan == null)
            {
                return HttpNotFound();
            }
            return View(tbtieuchuan);
        }

        // POST: tbtieuchuans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbtieuchuan tbtieuchuan = db.tbtieuchuan.Find(id);
            db.tbtieuchuan.Remove(tbtieuchuan);
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
