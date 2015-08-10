using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnQLNS.Models;

namespace DoAnQLNS.Controllers
{
    public class NhanVien_KyNangController : Controller
    {
        private QLNSDataEntities db = new QLNSDataEntities();

        // GET: NhanVien_KyNang
        public ActionResult Index()
        {
            var nhanVien_KyNang = db.NhanVien_KyNang.Include(n => n.KyNang).Include(n => n.NhanVien);
            return View(nhanVien_KyNang.ToList());
        }

        // GET: NhanVien_KyNang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien_KyNang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNhanVien,IDKyNang,SoNamKinhNghiem")] NhanVien_KyNang nhanVien_KyNang)
        {
            if (ModelState.IsValid)
            {
                db.NhanVien_KyNang.Add(nhanVien_KyNang);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return View(nhanVien_KyNang);
        }

        // GET: NhanVien_KyNang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KyNang kn = db.KyNangs.Find(id);
            NhanVien_KyNang nhanVien_KyNang = db.NhanVien_KyNang.Find(kn.IDKyNang);
            if (nhanVien_KyNang == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien_KyNang);
        }

        // POST: NhanVien_KyNang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNhanVien,IDKyNang,SoNamKinhNghiem")] NhanVien_KyNang nhanVien_KyNang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien_KyNang).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return View("Edit",nhanVien_KyNang);
        }

        // GET: NhanVien_KyNang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien_KyNang nhanVien_KyNang = db.NhanVien_KyNang.Find(id);
            if (nhanVien_KyNang == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien_KyNang);
        }

        // POST: NhanVien_KyNang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien_KyNang nhanVien_KyNang = db.NhanVien_KyNang.Find(id);
            db.NhanVien_KyNang.Remove(nhanVien_KyNang);
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
