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
    public class tbvanbantheolinhvucsController : Controller
    {
        private SQAEntities db = new SQAEntities();

        // GET: tbvanbantheolinhvucs
        public ActionResult Index()
        {
            return View(db.tbvanbantheolinhvuc.ToList());
        }

        // GET: tbvanbantheolinhvucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbvanbantheolinhvuc tbvanbantheolinhvuc = db.tbvanbantheolinhvuc.Find(id);
            if (tbvanbantheolinhvuc == null)
            {
                return HttpNotFound();
            }
            return View(tbvanbantheolinhvuc);
        }

        // GET: tbvanbantheolinhvucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbvanbantheolinhvucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tenvanban,soquyetdinh,noibanhanh,mota,fileattach1,fileattach2")] tbvanbantheolinhvuc tbvanbantheolinhvuc)
        {
            if (ModelState.IsValid)
            {
                db.tbvanbantheolinhvuc.Add(tbvanbantheolinhvuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbvanbantheolinhvuc);
        }

        // GET: tbvanbantheolinhvucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbvanbantheolinhvuc tbvanbantheolinhvuc = db.tbvanbantheolinhvuc.Find(id);
            if (tbvanbantheolinhvuc == null)
            {
                return HttpNotFound();
            }
            return View(tbvanbantheolinhvuc);
        }

        // POST: tbvanbantheolinhvucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tenvanban,soquyetdinh,noibanhanh,mota,fileattach1,fileattach2")] tbvanbantheolinhvuc tbvanbantheolinhvuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbvanbantheolinhvuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbvanbantheolinhvuc);
        }

        // GET: tbvanbantheolinhvucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbvanbantheolinhvuc tbvanbantheolinhvuc = db.tbvanbantheolinhvuc.Find(id);
            if (tbvanbantheolinhvuc == null)
            {
                return HttpNotFound();
            }
            return View(tbvanbantheolinhvuc);
        }

        // POST: tbvanbantheolinhvucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbvanbantheolinhvuc tbvanbantheolinhvuc = db.tbvanbantheolinhvuc.Find(id);
            db.tbvanbantheolinhvuc.Remove(tbvanbantheolinhvuc);
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
