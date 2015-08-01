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
    public class HopDongLaoDongController : Controller
    {
        private QLNSDataEntities db = new QLNSDataEntities();

        // GET: /HopDongLaoDong/
        public ActionResult DSHDLD()
        {
            var hodonglaodongs = db.HoDongLaoDongs.Include(h => h.LoaiHopDong).Include(h => h.NhanVien);
            return View(hodonglaodongs.ToList());
        }
        
        // GET: /HopDongLaoDong/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoDongLaoDong hodonglaodong = db.HoDongLaoDongs.Find(id);
            if (hodonglaodong == null)
            {
                return HttpNotFound();
            }
            return View(hodonglaodong);
        }

        // GET: /HopDongLaoDong/Create
        public ActionResult Create()
        {
            ViewBag.IDLoaHopDong = new SelectList(db.LoaiHopDongs, "IDLoaiHopDong", "TenLoai");
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen");
            return View();
        }

        // POST: /HopDongLaoDong/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDHopDong,IDNhanVien,NgayKy,NgayHieuLuc,NgayHetHan,QuyetDinhSo,NoiDungTomTat,IDLoaHopDong,TinhTrang")] HoDongLaoDong hodonglaodong)
        {
            if (ModelState.IsValid)
            {
                db.HoDongLaoDongs.Add(hodonglaodong);
                db.SaveChanges();
                return RedirectToAction("DSHDLD");
            }

            ViewBag.IDLoaHopDong = new SelectList(db.LoaiHopDongs, "IDLoaiHopDong", "TenLoai", hodonglaodong.IDLoaHopDong);
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", hodonglaodong.IDNhanVien);
            return View(hodonglaodong);
        }

        // GET: /HopDongLaoDong/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoDongLaoDong hodonglaodong = db.HoDongLaoDongs.Find(id);
            if (hodonglaodong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLoaHopDong = new SelectList(db.LoaiHopDongs, "IDLoaiHopDong", "TenLoai", hodonglaodong.IDLoaHopDong);
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", hodonglaodong.IDNhanVien);
            return View(hodonglaodong);
        }

        // POST: /HopDongLaoDong/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDHopDong,IDNhanVien,NgayKy,NgayHieuLuc,NgayHetHan,QuyetDinhSo,NoiDungTomTat,IDLoaHopDong,TinhTrang")] HoDongLaoDong hodonglaodong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hodonglaodong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DSHDLD");
            }
            ViewBag.IDLoaHopDong = new SelectList(db.LoaiHopDongs, "IDLoaiHopDong", "TenLoai", hodonglaodong.IDLoaHopDong);
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", hodonglaodong.IDNhanVien);
            return View(hodonglaodong);
        }

        // GET: /HopDongLaoDong/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoDongLaoDong hodonglaodong = db.HoDongLaoDongs.Find(id);
            if (hodonglaodong == null)
            {
                return HttpNotFound();
            }
            return View(hodonglaodong);
        }

        // POST: /HopDongLaoDong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoDongLaoDong hodonglaodong = db.HoDongLaoDongs.Find(id);
            db.HoDongLaoDongs.Remove(hodonglaodong);
            db.SaveChanges();
            return RedirectToAction("DSHDLD");
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
