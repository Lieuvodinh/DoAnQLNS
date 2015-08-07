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
    public class PhongBanController : Controller
    {
        private QLNSDataEntities db = new QLNSDataEntities();

        // GET: /PhongBan/
        public ActionResult DSPB()
        {
            return View(db.PhongBans.ToList());
        }

        // GET: /PhongBan/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PhongBan phongban = db.PhongBans.Find(id);
        //    if (phongban == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(phongban);
        //}

        // GET: /PhongBan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PhongBan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDPhongBan,TenPhongBan,SDT,Email")] PhongBan phongban)
        {
            if (ModelState.IsValid)
            {
                db.PhongBans.Add(phongban);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return View(phongban);
        }

        // GET: /PhongBan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongBan phongban = db.PhongBans.Find(id);
            if (phongban == null)
            {
                return HttpNotFound();
            }
            return View(phongban);
        }

        // POST: /PhongBan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhongBan,TenPhongBan,SDT,Email")] PhongBan phongban)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phongban).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return View(phongban);
        }

        // GET: /PhongBan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongBan phongban = db.PhongBans.Find(id);
            if (phongban == null)
            {
                return HttpNotFound();
            }
            return View(phongban);
        }

        // POST: /PhongBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhongBan phongban = db.PhongBans.Find(id);
            db.PhongBans.Remove(phongban);
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
