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
    public class NhanVien_PhongBanController : Controller
    {
        private QLNSDataEntitiesNewest db = new QLNSDataEntitiesNewest();

        // GET: NhanVien_PhongBan
        public ActionResult Index()
        {
            var nhanVien_PhongBan = db.NhanVien_PhongBan.Include(n => n.HoDongLaoDong).Include(n => n.PhongBan);
            return View(nhanVien_PhongBan.ToList());
        }

        // GET: NhanVien_PhongBan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien_PhongBan nhanVien_PhongBan = db.NhanVien_PhongBan.Find(id);
            if (nhanVien_PhongBan == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien_PhongBan);
        }

        // GET: NhanVien_PhongBan/Create
        public ActionResult Create()
        {
            ViewBag.IDHopDong = new SelectList(db.HoDongLaoDongs, "IDHopDong", "IDNhanVien");
            ViewBag.IDPhongBan = new SelectList(db.PhongBans, "IDPhongBan", "TenPhongBan");
            return View();
        }

        // POST: NhanVien_PhongBan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHopDong,IDPhongBan,NgayBatDau,NgayKetThuc,QuyetDinhSo,TinhTrang,IDNVPB")] NhanVien_PhongBan nhanVien_PhongBan)
        {
            if (ModelState.IsValid)
            {
                List<NhanVien_PhongBan> list = db.NhanVien_PhongBan.ToList();
                foreach (var item in list)
                {
                    if (nhanVien_PhongBan.IDHopDong == item.IDHopDong)
                    {
                        nhanVien_PhongBan = null;
                    }
                }
                db.NhanVien_PhongBan.Add(nhanVien_PhongBan);
                db.SaveChanges();
                return Json(new { success = true });
            }

            ViewBag.IDHopDong = new SelectList(db.HoDongLaoDongs, "IDHopDong", "IDNhanVien", nhanVien_PhongBan.IDHopDong);
            ViewBag.IDPhongBan = new SelectList(db.PhongBans, "IDPhongBan", "TenPhongBan", nhanVien_PhongBan.IDPhongBan);
            return View(nhanVien_PhongBan);
        }

        // GET: NhanVien_PhongBan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien_PhongBan nhanVien_PhongBan = db.NhanVien_PhongBan.Find(id);
            if (nhanVien_PhongBan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDHopDong = new SelectList(db.HoDongLaoDongs, "IDHopDong", "IDNhanVien", nhanVien_PhongBan.IDHopDong);
            ViewBag.IDPhongBan = new SelectList(db.PhongBans, "IDPhongBan", "TenPhongBan", nhanVien_PhongBan.IDPhongBan);
            return View(nhanVien_PhongBan);
        }

        // POST: NhanVien_PhongBan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHopDong,IDPhongBan,NgayBatDau,NgayKetThuc,QuyetDinhSo,TinhTrang,IDNVPB")] NhanVien_PhongBan nhanVien_PhongBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien_PhongBan).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.IDHopDong = new SelectList(db.HoDongLaoDongs, "IDHopDong", "IDNhanVien", nhanVien_PhongBan.IDHopDong);
            ViewBag.IDPhongBan = new SelectList(db.PhongBans, "IDPhongBan", "TenPhongBan", nhanVien_PhongBan.IDPhongBan);
            return View(nhanVien_PhongBan);
        }

        // GET: NhanVien_PhongBan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien_PhongBan nhanVien_PhongBan = db.NhanVien_PhongBan.Find(id);
            if (nhanVien_PhongBan == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien_PhongBan);
        }

        // POST: NhanVien_PhongBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien_PhongBan nhanVien_PhongBan = db.NhanVien_PhongBan.Find(id);
            db.NhanVien_PhongBan.Remove(nhanVien_PhongBan);
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
