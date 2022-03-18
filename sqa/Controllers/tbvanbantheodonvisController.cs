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
    public class tbvanbantheodonvisController : Controller
    {
        private SQAEntities db = new SQAEntities();

        // GET: tbvanbantheodonvis
        public ActionResult Index(string searchString, int id = 0)
        {
            var vanban = db.tbvanbantheodonvi.Include(vb => vb.tbphongban);
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                vanban = vanban.Where(vb => vb.tenvanban.ToLower().Contains(searchString));
            }

            if ((id != 0) & (id != 1))
            {
                vanban = vanban.Where(pb => pb.maphongban == id);
            }

            ViewBag.id = new SelectList(db.tbphongban, "id", "tenphongban", 1);

            return View(vanban.ToList());
        }

        // GET: tbvanbantheodonvis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbvanbantheodonvi tbvanbantheodonvi = db.tbvanbantheodonvi.Find(id);
            if (tbvanbantheodonvi == null)
            {
                return HttpNotFound();
            }
            return View(tbvanbantheodonvi);
        }

        // GET: tbvanbantheodonvis/Create
        public ActionResult Create()
        {
            ViewBag.maphongban = new SelectList(db.tbphongban, "id", "tenphongban");
            return View();
        }

        // POST: tbvanbantheodonvis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,maphongban,tenvanban,soquyetdinh,noibanhanh,mota,fileattach1,fileattach2")] tbvanbantheodonvi tbvanbantheodonvi, HttpPostedFileBase Attachfile1, HttpPostedFileBase Attachfile2)
        {
            string fileName1,fileName2, urlFile1, urlFile2;
            fileName1 = "";
            fileName2 = "";
            try
            {
                if (Attachfile1 != null && Attachfile1.ContentLength > 0)
                {
                    //tbvanbantheodonvi.fileattach1 = new byte[Attachfile1.ContentLength];
                    //Attachfile1.InputStream.Read(tbvanbantheodonvi.fileattach1, 0, Attachfile1.ContentLength);
                    fileName1 = System.IO.Path.GetFileName(Attachfile1.FileName);
                    urlFile1 = Server.MapPath("~/Uploads/" + fileName1);
                    Attachfile1.SaveAs(urlFile1);
                }
                if (Attachfile2 != null && Attachfile2.ContentLength > 0)
                {
                    fileName2 = System.IO.Path.GetFileName(Attachfile2.FileName);
                    urlFile2 = Server.MapPath("~/Uploads/" + fileName2);
                    Attachfile2.SaveAs(urlFile2);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Lỗi", "Thêm file không thành công!");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tbvanbantheodonvi.fileattach1 = fileName1;
                    tbvanbantheodonvi.fileattach2 = fileName2;
                    db.tbvanbantheodonvi.Add(tbvanbantheodonvi);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Lỗi", "Thêm dữ liệu không thành công!");
                }
            }
            return View(tbvanbantheodonvi);
        }

        // GET: tbvanbantheodonvis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbvanbantheodonvi tbvanbantheodonvi = db.tbvanbantheodonvi.Find(id);
            if (tbvanbantheodonvi == null)
            {
                return HttpNotFound();
            }
            return View(tbvanbantheodonvi);
        }

        // POST: tbvanbantheodonvis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tenvanban,soquyetdinh,noibanhanh,mota,fileattach1,fileattach2")] tbvanbantheodonvi tbvanbantheodonvi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbvanbantheodonvi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbvanbantheodonvi);
        }

        // GET: tbvanbantheodonvis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbvanbantheodonvi tbvanbantheodonvi = db.tbvanbantheodonvi.Find(id);
            if (tbvanbantheodonvi == null)
            {
                return HttpNotFound();
            }
            return View(tbvanbantheodonvi);
        }

        // POST: tbvanbantheodonvis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbvanbantheodonvi tbvanbantheodonvi = db.tbvanbantheodonvi.Find(id);
            db.tbvanbantheodonvi.Remove(tbvanbantheodonvi);
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
