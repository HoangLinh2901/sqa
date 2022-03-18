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
    public class tbvanban_kehoachController : Controller
    {
        private SQAEntities db = new SQAEntities();

        // GET: tbvanban_kehoach
        public ActionResult Index()
        {
            return View(db.tbvanban_kehoach.ToList());
        }

        // GET: tbvanban_kehoach/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbvanban_kehoach tbvanban_kehoach = db.tbvanban_kehoach.Find(id);
            if (tbvanban_kehoach == null)
            {
                return HttpNotFound();
            }
            return View(tbvanban_kehoach);
        }

        // GET: tbvanban_kehoach/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbvanban_kehoach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,loaivanban,sovanban,tenvanban,noibanhanh,nguoinhap,ngaynhap,ghihu")] tbvanban_kehoach tbvanban_kehoach)
        {
            if (ModelState.IsValid)
            {
                db.tbvanban_kehoach.Add(tbvanban_kehoach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbvanban_kehoach);
        }

        // GET: tbvanban_kehoach/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbvanban_kehoach tbvanban_kehoach = db.tbvanban_kehoach.Find(id);
            if (tbvanban_kehoach == null)
            {
                return HttpNotFound();
            }
            return View(tbvanban_kehoach);
        }

        // POST: tbvanban_kehoach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,loaivanban,sovanban,tenvanban,noibanhanh,nguoinhap,ngaynhap,ghihu")] tbvanban_kehoach tbvanban_kehoach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbvanban_kehoach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbvanban_kehoach);
        }

        // GET: tbvanban_kehoach/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbvanban_kehoach tbvanban_kehoach = db.tbvanban_kehoach.Find(id);
            if (tbvanban_kehoach == null)
            {
                return HttpNotFound();
            }
            return View(tbvanban_kehoach);
        }

        // POST: tbvanban_kehoach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbvanban_kehoach tbvanban_kehoach = db.tbvanban_kehoach.Find(id);
            db.tbvanban_kehoach.Remove(tbvanban_kehoach);
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
