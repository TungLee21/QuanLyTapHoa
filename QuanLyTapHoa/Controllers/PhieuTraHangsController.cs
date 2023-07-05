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
    public class PhieuTraHangsController : Controller
    {
        private QuanLyTapHoaEntities db = new QuanLyTapHoaEntities();

        // GET: PhieuTraHangs
        public ActionResult Index()
        {
            return View(db.PhieuTraHangs.ToList());
        }

        // GET: PhieuTraHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuTraHang phieuTraHang = db.PhieuTraHangs.Find(id);
            if (phieuTraHang == null)
            {
                return HttpNotFound();
            }
            return View(phieuTraHang);
        }

        // GET: PhieuTraHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhieuTraHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuTra,TongSoTienTra,TongSoLuongTra")] PhieuTraHang phieuTraHang)
        {
            if (ModelState.IsValid)
            {
                db.PhieuTraHangs.Add(phieuTraHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phieuTraHang);
        }

        // GET: PhieuTraHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuTraHang phieuTraHang = db.PhieuTraHangs.Find(id);
            if (phieuTraHang == null)
            {
                return HttpNotFound();
            }
            return View(phieuTraHang);
        }

        // POST: PhieuTraHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuTra,TongSoTienTra,TongSoLuongTra")] PhieuTraHang phieuTraHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuTraHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phieuTraHang);
        }

        // GET: PhieuTraHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuTraHang phieuTraHang = db.PhieuTraHangs.Find(id);
            if (phieuTraHang == null)
            {
                return HttpNotFound();
            }
            return View(phieuTraHang);
        }

        // POST: PhieuTraHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuTraHang phieuTraHang = db.PhieuTraHangs.Find(id);
            db.PhieuTraHangs.Remove(phieuTraHang);
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
