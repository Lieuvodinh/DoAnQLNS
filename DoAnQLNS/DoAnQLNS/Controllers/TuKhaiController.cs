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
    public class TuKhaiController : Controller
    {
        private QLNSDataEntities db = new QLNSDataEntities();

        // GET: /TuKhai/
        public ActionResult DSTK()
        {
            var bangtukhais = db.BangTuKhais.Include(b => b.NhanVien);
            return View(bangtukhais.ToList());
        }

        // GET: /TuKhai/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangTuKhai bangtukhai = db.BangTuKhais.Find(id);
            if (bangtukhai == null)
            {
                return HttpNotFound();
            }
            return View(bangtukhai);
        }

        // GET: /TuKhai/Create
        public ActionResult Create()
        {
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen");
            return View();
        }

        // POST: /TuKhai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDTuKhai,IDNhanVien,TuNgay,DenNgay,NoiDung")] BangTuKhai bangtukhai)
        {
            if (ModelState.IsValid)
            {
                db.BangTuKhais.Add(bangtukhai);
                db.SaveChanges();
                return RedirectToAction("DSTK");
            }

            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", bangtukhai.IDNhanVien);
            return View(bangtukhai);
        }

        // GET: /TuKhai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangTuKhai bangtukhai = db.BangTuKhais.Find(id);
            if (bangtukhai == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", bangtukhai.IDNhanVien);
            return View(bangtukhai);
        }

        // POST: /TuKhai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDTuKhai,IDNhanVien,TuNgay,DenNgay,NoiDung")] BangTuKhai bangtukhai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangtukhai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DSTK");
            }
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", bangtukhai.IDNhanVien);
            return View(bangtukhai);
        }

        // GET: /TuKhai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangTuKhai bangtukhai = db.BangTuKhais.Find(id);
            if (bangtukhai == null)
            {
                return HttpNotFound();
            }
            return View(bangtukhai);
        }

        // POST: /TuKhai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BangTuKhai bangtukhai = db.BangTuKhais.Find(id);
            db.BangTuKhais.Remove(bangtukhai);
            db.SaveChanges();
            return RedirectToAction("DSTK");
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
