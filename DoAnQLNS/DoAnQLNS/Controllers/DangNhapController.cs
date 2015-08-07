using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnQLNS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace DoAnQLNS.Controllers
{
    public class DangNhapController : Controller
    {
        private QLNSDataEntities db = new QLNSDataEntities();

        
        // GET: /DangNhap/DangNhap
        [AllowAnonymous]
        public ActionResult DangNhap()
        {
            DangNhap lg = new DangNhap();
            return View("DangNhap", lg);//goi den trang Login va truyen cho cai model lg of Login
        }

        // POST: /DangNhap/DangNhap
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(DangNhap lg)
        {
            if (ModelState.IsValid)
            {
                var data = (from d in db.DangNhaps 
                            where d.TenDangNhap.Equals(lg.TenDangNhap) && d.MatKhau.Equals(lg.MatKhau)
                            select d).ToList();//lay du lieu voi dk tk va mk 
                
                if (data.Count > 0)
                {
                    
                    //neu tai khoan ton tai ta gan cho session
                    Session["TenDangNhap"] = lg.NhanVien.HoTen;
                    Session["Quyen"] = lg.Quyen;
                    Session["IDNhanVien"] = lg.IDNhanVien;
                    //goi den ham GetRolesForUser o customroleprovider
                    System.Web.Security.FormsAuthentication.SetAuthCookie(lg.TenDangNhap, false);
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.mess = "Sai Tai Khoan Hoac Mat Khau";
                return View("DangNhap", lg);
            }
            return View("DangNhap", lg);//neu khong dung cu phap thi quay lai form dang nhap bao loi
        }

        // GET: /DangNhap/
        public ActionResult DSDN()
        {
            var dangnhaps = db.DangNhaps.Include(d => d.NhanVien);
            return View(dangnhaps.ToList());
        }

        // GET: /DangNhap/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DangNhap dangnhap = db.DangNhaps.Find(id);
        //    if (dangnhap == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dangnhap);
        //}

        // GET: /DangNhap/Create
        public ActionResult Create()
        {
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen");
            return View();
        }

        // POST: /DangNhap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDDangNhap,IDNhanVien,TenDangNhap,MatKhau,Quyen")] DangNhap dangnhap)
        {
            if (ModelState.IsValid)
            {
                db.DangNhaps.Add(dangnhap);
                db.SaveChanges();
                return Json(new { success = true });
            }

            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", dangnhap.IDNhanVien);
            return View(dangnhap);
        }

        // GET: /DangNhap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangNhap dangnhap = db.DangNhaps.Find(id);
            if (dangnhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", dangnhap.IDNhanVien);
            return View(dangnhap);
        }

        // POST: /DangNhap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDDangNhap,IDNhanVien,TenDangNhap,MatKhau,Quyen")] DangNhap dangnhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dangnhap).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "HoTen", dangnhap.IDNhanVien);
            return View(dangnhap);
        }

        // GET: /DangNhap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangNhap dangnhap = db.DangNhaps.Find(id);
            if (dangnhap == null)
            {
                return HttpNotFound();
            }
            return View(dangnhap);
        }

        // POST: /DangNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DangNhap dangnhap = db.DangNhaps.Find(id);
            db.DangNhaps.Remove(dangnhap);
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
