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
    public class ChiTietKhenThuongController : Controller
    {
        private QLNSDataEntities db = new QLNSDataEntities();

        // GET: /ChiTietKhenThuong/
        public ActionResult DSCTKT()
        {
            var chitietkhenthuongs = db.ChiTietKhenThuongs.Include(c => c.HoDongLaoDong).Include(c => c.LoaiKhenThuong);
            return View(chitietkhenthuongs.ToList());
        }

        // GET: /ChiTietKhenThuong/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ChiTietKhenThuong chitietkhenthuong = db.ChiTietKhenThuongs.Find(id);
        //    if (chitietkhenthuong == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(chitietkhenthuong);
        //}

        // GET: /ChiTietKhenThuong/Create
        public ActionResult Create()
        {
            ViewBag.IDHopDong = new SelectList(db.HoDongLaoDongs, "IDHopDong", "IDNhanVien");
            ViewBag.IDKhenThuong = new SelectList(db.LoaiKhenThuongs, "IDKhenThuong", "TenKhenThuong");
            return View();
        }

        // POST: /ChiTietKhenThuong/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDHopDong,IDKhenThuong,NgayQuyetDinh,NoiDung,QuyetDinhSo")] ChiTietKhenThuong chitietkhenthuong)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietKhenThuongs.Add(chitietkhenthuong);
                db.SaveChanges();
                return Json(new { success = true });
            }

            ViewBag.IDHopDong = new SelectList(db.HoDongLaoDongs, "IDHopDong", "IDNhanVien", chitietkhenthuong.IDHopDong);
            ViewBag.IDKhenThuong = new SelectList(db.LoaiKhenThuongs, "IDKhenThuong", "TenKhenThuong", chitietkhenthuong.IDKhenThuong);
            return View(chitietkhenthuong);
        }

        // GET: /ChiTietKhenThuong/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietKhenThuong chitietkhenthuong = db.ChiTietKhenThuongs.Find(id);
            if (chitietkhenthuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDHopDong = new SelectList(db.HoDongLaoDongs, "IDHopDong", "IDNhanVien", chitietkhenthuong.IDHopDong);
            ViewBag.IDKhenThuong = new SelectList(db.LoaiKhenThuongs, "IDKhenThuong", "TenKhenThuong", chitietkhenthuong.IDKhenThuong);
            return View(chitietkhenthuong);
        }

        // POST: /ChiTietKhenThuong/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDHopDong,IDKhenThuong,NgayQuyetDinh,NoiDung,QuyetDinhSo")] ChiTietKhenThuong chitietkhenthuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietkhenthuong).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.IDHopDong = new SelectList(db.HoDongLaoDongs, "IDHopDong", "IDNhanVien", chitietkhenthuong.IDHopDong);
            ViewBag.IDKhenThuong = new SelectList(db.LoaiKhenThuongs, "IDKhenThuong", "TenKhenThuong", chitietkhenthuong.IDKhenThuong);
            return View("Edit",chitietkhenthuong);
        }

        // GET: /ChiTietKhenThuong/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietKhenThuong chitietkhenthuong = db.ChiTietKhenThuongs.Find(id);
            if (chitietkhenthuong == null)
            {
                return HttpNotFound();
            }
            return View(chitietkhenthuong);
        }

        // POST: /ChiTietKhenThuong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietKhenThuong chitietkhenthuong = db.ChiTietKhenThuongs.Find(id);
            db.ChiTietKhenThuongs.Remove(chitietkhenthuong);
            db.SaveChanges();
            return Json(new { success = true });
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
