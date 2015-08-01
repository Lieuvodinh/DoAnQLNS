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
    public class NhanVienController : Controller
    {
        private QLNSDataEntities db = new QLNSDataEntities();

        // GET: /NhanVien/
        public ActionResult DSNV()
        {
            return View(db.NhanViens.ToList());
        }

        // GET: /NhanVien/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanvien = db.NhanViens.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // GET: /NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /NhanVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDNhanVien,HoTen,CMND,GioiTinh,NgaySinh,NoiSinh,QueQuan,DiaChi,HinhAnh")] NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanvien);
                db.SaveChanges();
                return RedirectToAction("DSNV");
            }

            return View(nhanvien);
        }

        // GET: /NhanVien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanvien = db.NhanViens.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // POST: /NhanVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDNhanVien,HoTen,CMND,GioiTinh,NgaySinh,NoiSinh,QueQuan,DiaChi,HinhAnh")] NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DSNV");
            }
            return View(nhanvien);
        }

        // GET: /NhanVien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanvien = db.NhanViens.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // POST: /NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanvien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanvien);
            db.SaveChanges();
            return RedirectToAction("DSNV");
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
