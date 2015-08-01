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
    public class LoaiHopDongController : Controller
    {
        private QLNSDataEntities db = new QLNSDataEntities();

        // GET: /LoaiHopDong/
        public ActionResult DSLHD()
        {
            return View(db.LoaiHopDongs.ToList());
        }

        // GET: /LoaiHopDong/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    LoaiHopDong loaihopdong = db.LoaiHopDongs.Find(id);
        //    if (loaihopdong == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(loaihopdong);
        //}

        // GET: /LoaiHopDong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /LoaiHopDong/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDLoaiHopDong,TenLoai")] LoaiHopDong loaihopdong)
        {
            if (ModelState.IsValid)
            {
                db.LoaiHopDongs.Add(loaihopdong);
                db.SaveChanges();
                return RedirectToAction("DSLHD");
            }

            return View(loaihopdong);
        }

        // GET: /LoaiHopDong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHopDong loaihopdong = db.LoaiHopDongs.Find(id);
            if (loaihopdong == null)
            {
                return HttpNotFound();
            }
            return View(loaihopdong);
        }

        // POST: /LoaiHopDong/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDLoaiHopDong,TenLoai")] LoaiHopDong loaihopdong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaihopdong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DSLHD");
            }
            return View(loaihopdong);
        }

        // GET: /LoaiHopDong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHopDong loaihopdong = db.LoaiHopDongs.Find(id);
            if (loaihopdong == null)
            {
                return HttpNotFound();
            }
            return View(loaihopdong);
        }

        // POST: /LoaiHopDong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiHopDong loaihopdong = db.LoaiHopDongs.Find(id);
            db.LoaiHopDongs.Remove(loaihopdong);
            db.SaveChanges();
            return RedirectToAction("DSLHD");
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
