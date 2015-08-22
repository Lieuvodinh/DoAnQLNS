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
    public class BangTuKhaisController : Controller
    {
        private QLNSDataEntitiesNewest db = new QLNSDataEntitiesNewest();

        // GET: BangTuKhais
        public ActionResult DSTK()
        {
            var bangTuKhais = db.BangTuKhais.Include(b => b.NhanVien);
            return View(bangTuKhais.ToList());
        }

       

        // GET: BangTuKhais/Create
        public ActionResult Create()
        {
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen");
            return View();
        }

        // POST: BangTuKhais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTuKhai,IDNhanVien,TuNgay,DenNgay,NoiDung")] BangTuKhai bangTuKhai)
        {
            if (ModelState.IsValid)
            {
                db.BangTuKhais.Add(bangTuKhai);
                db.SaveChanges();
                return Json(new { success = true });
            }

            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", bangTuKhai.IDNhanVien);
            return View(bangTuKhai);
        }

        // GET: BangTuKhais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangTuKhai bangTuKhai = db.BangTuKhais.Find(id);
            if (bangTuKhai == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", bangTuKhai.IDNhanVien);
            return View(bangTuKhai);
        }

        // POST: BangTuKhais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTuKhai,IDNhanVien,TuNgay,DenNgay,NoiDung")] BangTuKhai bangTuKhai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangTuKhai).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", bangTuKhai.IDNhanVien);
            return View(bangTuKhai);
        }

        // GET: BangTuKhais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangTuKhai bangTuKhai = db.BangTuKhais.Find(id);
            if (bangTuKhai == null)
            {
                return HttpNotFound();
            }
            return View(bangTuKhai);
        }

        // POST: BangTuKhais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BangTuKhai bangTuKhai = db.BangTuKhais.Find(id);
            db.BangTuKhais.Remove(bangTuKhai);
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
