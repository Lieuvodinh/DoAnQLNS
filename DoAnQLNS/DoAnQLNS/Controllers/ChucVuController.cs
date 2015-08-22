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
    public class ChucVuController : Controller
    {
        private QLNSDataEntitiesNewest db = new QLNSDataEntitiesNewest();

        // GET: /ChucVu/
        public ActionResult DSCV()
        {
            return View(db.ChucVus.ToList());
        }

        // GET: /ChucVu/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ChucVu chucvu = db.ChucVus.Find(id);
        //    if (chucvu == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(chucvu);
        //}

        // GET: /ChucVu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ChucVu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDChucVu,TenChucVu,MoTa,PhuCap")] ChucVu chucvu)
        {
            if (ModelState.IsValid)
            {
                db.ChucVus.Add(chucvu);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return View(chucvu);
        }

        // GET: /ChucVu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVu chucvu = db.ChucVus.Find(id);
            if (chucvu == null)
            {
                return HttpNotFound();
            }
            return View(chucvu);
        }

        // POST: /ChucVu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDChucVu,TenChucVu,MoTa,PhuCap")] ChucVu chucvu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chucvu).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }

            return View("Edit", chucvu);
        }

        // GET: /ChucVu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVu chucvu = db.ChucVus.Find(id);
            if (chucvu == null)
            {
                return HttpNotFound();
            }
            return View(chucvu);
        }

        // POST: /ChucVu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChucVu chucvu = db.ChucVus.Find(id);
            db.ChucVus.Remove(chucvu);
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
