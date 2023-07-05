using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyTapHoa.Models;

namespace QuanLyTapHoa.Controllers
{
    public class PhieuNhapHangsController : Controller
    {
        private QuanLyTapHoaEntities db = new QuanLyTapHoaEntities();

        // GET: PhieuNhapHangs
        public ActionResult Index()
        {
            return View(db.PhieuNhapHangs.ToList());
        }

        // GET: PhieuNhapHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapHang phieuNhapHang = db.PhieuNhapHangs.Find(id);
            if (phieuNhapHang == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapHang);
        }

        // GET: PhieuNhapHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhieuNhapHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuNhap,TongSoTienNhap,TongSoLuongNhap")] PhieuNhapHang phieuNhapHang)
        {
            if (ModelState.IsValid)
            {
                db.PhieuNhapHangs.Add(phieuNhapHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phieuNhapHang);
        }

        // GET: PhieuNhapHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapHang phieuNhapHang = db.PhieuNhapHangs.Find(id);
            if (phieuNhapHang == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapHang);
        }

        // POST: PhieuNhapHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuNhap,TongSoTienNhap,TongSoLuongNhap")] PhieuNhapHang phieuNhapHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuNhapHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phieuNhapHang);
        }

        // GET: PhieuNhapHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapHang phieuNhapHang = db.PhieuNhapHangs.Find(id);
            if (phieuNhapHang == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapHang);
        }

        // POST: PhieuNhapHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuNhapHang phieuNhapHang = db.PhieuNhapHangs.Find(id);
            db.PhieuNhapHangs.Remove(phieuNhapHang);
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
