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
    public class LoaiHopDongsController : Controller
    {
        private QLNSDataEntitiesNewest db = new QLNSDataEntitiesNewest();

        // GET: LoaiHopDongs
        public ActionResult DSLHD()
        {
            return View(db.LoaiHopDongs.ToList());
        }
        

        // GET: LoaiHopDongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiHopDongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLoaiHopDong,TenLoai")] LoaiHopDong loaiHopDong)
        {
            if (ModelState.IsValid)
            {
                db.LoaiHopDongs.Add(loaiHopDong);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return View(loaiHopDong);
        }

        // GET: LoaiHopDongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHopDong loaiHopDong = db.LoaiHopDongs.Find(id);
            if (loaiHopDong == null)
            {
                return HttpNotFound();
            }
            return View(loaiHopDong);
        }

        // POST: LoaiHopDongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLoaiHopDong,TenLoai")] LoaiHopDong loaiHopDong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiHopDong).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return View(loaiHopDong);
        }

        // GET: LoaiHopDongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHopDong loaiHopDong = db.LoaiHopDongs.Find(id);
            if (loaiHopDong == null)
            {
                return HttpNotFound();
            }
            return View(loaiHopDong);
        }

        // POST: LoaiHopDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiHopDong loaiHopDong = db.LoaiHopDongs.Find(id);
            db.LoaiHopDongs.Remove(loaiHopDong);
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
