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
    public class tbphongbansController : Controller
    {
        private SQAEntities db = new SQAEntities();

        // GET: tbphongbans
        public ActionResult Index()
        {
            return View(db.tbphongban.ToList());
        }

        // GET: tbphongbans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbphongban tbphongban = db.tbphongban.Find(id);
            if (tbphongban == null)
            {
                return HttpNotFound();
            }
            return View(tbphongban);
        }

        // GET: tbphongbans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbphongbans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tenphongban")] tbphongban tbphongban)
        {
            if (ModelState.IsValid)
            {
                db.tbphongban.Add(tbphongban);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbphongban);
        }

        // GET: tbphongbans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbphongban tbphongban = db.tbphongban.Find(id);
            if (tbphongban == null)
            {
                return HttpNotFound();
            }
            return View(tbphongban);
        }

        // POST: tbphongbans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tenphongban")] tbphongban tbphongban)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbphongban).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbphongban);
        }

        // GET: tbphongbans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbphongban tbphongban = db.tbphongban.Find(id);
            if (tbphongban == null)
            {
                return HttpNotFound();
            }
            return View(tbphongban);
        }

        // POST: tbphongbans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbphongban tbphongban = db.tbphongban.Find(id);
            db.tbphongban.Remove(tbphongban);
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
