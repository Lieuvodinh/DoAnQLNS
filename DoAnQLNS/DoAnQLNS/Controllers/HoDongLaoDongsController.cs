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
    public class HoDongLaoDongsController : Controller
    {
        private QLNSDataEntitiesNewest db = new QLNSDataEntitiesNewest();

        // GET: HoDongLaoDongs
        public ActionResult DSHDLD()
        {
            var hoDongLaoDongs = db.HoDongLaoDongs.Include(h => h.LoaiHopDong).Include(h => h.NhanVien);
            return View(hoDongLaoDongs.ToList());
        }

        // GET: HoDongLaoDongs/Create
        public ActionResult Create()
        {
            ViewBag.IDLoaHopDong = new SelectList(db.LoaiHopDongs, "IDLoaiHopDong", "TenLoai");
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen");
            return View();
        }

        // POST: HoDongLaoDongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHopDong,IDNhanVien,NgayKy,NgayHieuLuc,NgayHetHan,QuyetDinhSo,NoiDungTomTat,IDLoaHopDong,TinhTrang")] HoDongLaoDong hoDongLaoDong)
        {
            if (ModelState.IsValid)
            {
                db.HoDongLaoDongs.Add(hoDongLaoDong);
                db.SaveChanges();
                return Json(new { success = true });
            }

            ViewBag.IDLoaHopDong = new SelectList(db.LoaiHopDongs, "IDLoaiHopDong", "TenLoai", hoDongLaoDong.IDLoaHopDong);
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", hoDongLaoDong.IDNhanVien);
            return View(hoDongLaoDong);
        }

        // GET: HoDongLaoDongs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoDongLaoDong hoDongLaoDong = db.HoDongLaoDongs.Find(id);
            if (hoDongLaoDong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLoaHopDong = new SelectList(db.LoaiHopDongs, "IDLoaiHopDong", "TenLoai", hoDongLaoDong.IDLoaHopDong);
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", hoDongLaoDong.IDNhanVien);
            return View(hoDongLaoDong);
        }

        // POST: HoDongLaoDongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHopDong,IDNhanVien,NgayKy,NgayHieuLuc,NgayHetHan,QuyetDinhSo,NoiDungTomTat,IDLoaHopDong,TinhTrang")] HoDongLaoDong hoDongLaoDong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoDongLaoDong).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.IDLoaHopDong = new SelectList(db.LoaiHopDongs, "IDLoaiHopDong", "TenLoai", hoDongLaoDong.IDLoaHopDong);
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", hoDongLaoDong.IDNhanVien);
            return View(hoDongLaoDong);
        }

        // GET: HoDongLaoDongs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoDongLaoDong hoDongLaoDong = db.HoDongLaoDongs.Find(id);
            if (hoDongLaoDong == null)
            {
                return HttpNotFound();
            }
            return View(hoDongLaoDong);
        }

        // POST: HoDongLaoDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoDongLaoDong hoDongLaoDong = db.HoDongLaoDongs.Find(id);
            db.HoDongLaoDongs.Remove(hoDongLaoDong);
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
