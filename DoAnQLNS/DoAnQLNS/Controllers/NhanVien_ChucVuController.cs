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
    public class NhanVien_ChucVuController : Controller
    {
        private QLNSDataEntitiesNewest db = new QLNSDataEntitiesNewest();

        // GET: NhanVien_ChucVu
        public ActionResult Index()
        {
            var nhanVien_ChucVu = db.NhanVien_ChucVu.Include(n => n.ChucVu).Include(n => n.HoDongLaoDong);
            return View(nhanVien_ChucVu.ToList());
        }

        // GET: NhanVien_ChucVu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien_ChucVu nhanVien_ChucVu = db.NhanVien_ChucVu.Find(id);
            if (nhanVien_ChucVu == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien_ChucVu);
        }

        // GET: NhanVien_ChucVu/Create
        public ActionResult Create()
        {
            ViewBag.IDChucVu = new SelectList(db.ChucVus, "IDChucVu", "TenChucVu");
            ViewBag.IDHopDong = new SelectList(db.HoDongLaoDongs, "IDHopDong", "IDNhanVien");
            return View();
        }

        // POST: NhanVien_ChucVu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHopDong,IDChucVu,NgayBatDau,NgayKetThuc,QuyetDinhSo,TinhTrang,IDNVCV")] NhanVien_ChucVu nhanVien_ChucVu)
        {
            if (ModelState.IsValid)
            {
                db.NhanVien_ChucVu.Add(nhanVien_ChucVu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDChucVu = new SelectList(db.ChucVus, "IDChucVu", "TenChucVu", nhanVien_ChucVu.IDChucVu);
            ViewBag.IDHopDong = new SelectList(db.HoDongLaoDongs, "IDHopDong", "IDNhanVien", nhanVien_ChucVu.IDHopDong);
            return View(nhanVien_ChucVu);
        }

        // GET: NhanVien_ChucVu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien_ChucVu nhanVien_ChucVu = db.NhanVien_ChucVu.Find(id);
            if (nhanVien_ChucVu == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDChucVu = new SelectList(db.ChucVus, "IDChucVu", "TenChucVu", nhanVien_ChucVu.IDChucVu);
            ViewBag.IDHopDong = new SelectList(db.HoDongLaoDongs, "IDHopDong", "IDNhanVien", nhanVien_ChucVu.IDHopDong);
            return View(nhanVien_ChucVu);
        }

        // POST: NhanVien_ChucVu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHopDong,IDChucVu,NgayBatDau,NgayKetThuc,QuyetDinhSo,TinhTrang,IDNVCV")] NhanVien_ChucVu nhanVien_ChucVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien_ChucVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDChucVu = new SelectList(db.ChucVus, "IDChucVu", "TenChucVu", nhanVien_ChucVu.IDChucVu);
            ViewBag.IDHopDong = new SelectList(db.HoDongLaoDongs, "IDHopDong", "IDNhanVien", nhanVien_ChucVu.IDHopDong);
            return View(nhanVien_ChucVu);
        }

        // GET: NhanVien_ChucVu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien_ChucVu nhanVien_ChucVu = db.NhanVien_ChucVu.Find(id);
            if (nhanVien_ChucVu == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien_ChucVu);
        }

        // POST: NhanVien_ChucVu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien_ChucVu nhanVien_ChucVu = db.NhanVien_ChucVu.Find(id);
            db.NhanVien_ChucVu.Remove(nhanVien_ChucVu);
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
