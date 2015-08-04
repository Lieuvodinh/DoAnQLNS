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
    public class DangNhapController : Controller
    {
        private QLNSDataEntities db = new QLNSDataEntities();

        // GET: /DangNhap/
        public ActionResult Index()
        {
            var dangnhaps = db.DangNhaps.Include(d => d.NhanVien);
            return View(dangnhaps.ToList());
        }

        // GET: /DangNhap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangNhap dangnhap = db.DangNhaps.Find(id);
            if (dangnhap == null)
            {
                return HttpNotFound();
            }
            return View(dangnhap);
        }

        // GET: /DangNhap/Create
        public ActionResult Create()
        {
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen");
            return View();
        }

        // POST: /DangNhap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDDangNhap,IDNhanVien,TenDangNhap,MatKhau,Quyen")] DangNhap dangnhap)
        {
            if (ModelState.IsValid)
            {
                db.DangNhaps.Add(dangnhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", dangnhap.IDNhanVien);
            return View(dangnhap);
        }

        // GET: /DangNhap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangNhap dangnhap = db.DangNhaps.Find(id);
            if (dangnhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", dangnhap.IDNhanVien);
            return View(dangnhap);
        }

        // POST: /DangNhap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDDangNhap,IDNhanVien,TenDangNhap,MatKhau,Quyen")] DangNhap dangnhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dangnhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", dangnhap.IDNhanVien);
            return View(dangnhap);
        }

        // GET: /DangNhap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangNhap dangnhap = db.DangNhaps.Find(id);
            if (dangnhap == null)
            {
                return HttpNotFound();
            }
            return View(dangnhap);
        }

        // POST: /DangNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DangNhap dangnhap = db.DangNhaps.Find(id);
            db.DangNhaps.Remove(dangnhap);
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
