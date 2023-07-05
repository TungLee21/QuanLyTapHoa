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
    public class ChiTietPhieuTraHangsController : Controller
    {
        private QuanLyTapHoaEntities db = new QuanLyTapHoaEntities();

        // GET: ChiTietPhieuTraHangs
        public ActionResult Index()
        {
            var chiTietPhieuTraHangs = db.ChiTietPhieuTraHangs.Include(c => c.HangHoa).Include(c => c.NhaCungCap).Include(c => c.PhieuTraHang);
            return View(chiTietPhieuTraHangs.ToList());
        }

        // GET: ChiTietPhieuTraHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuTraHang chiTietPhieuTraHang = db.ChiTietPhieuTraHangs.Find(id);
            if (chiTietPhieuTraHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuTraHang);
        }

        // GET: ChiTietPhieuTraHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa");
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap");
            ViewBag.MaPhieuTra = new SelectList(db.PhieuTraHangs, "MaPhieuTra", "MaPhieuTra");
            return View();
        }

        // POST: ChiTietPhieuTraHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHH,MaPhieuTra,MaNhaCungCap,TenNhaCungCap,GiaTra,SoLuongTra")] ChiTietPhieuTraHang chiTietPhieuTraHang)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietPhieuTraHangs.Add(chiTietPhieuTraHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa", chiTietPhieuTraHang.MaHH);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", chiTietPhieuTraHang.MaNhaCungCap);
            ViewBag.MaPhieuTra = new SelectList(db.PhieuTraHangs, "MaPhieuTra", "MaPhieuTra", chiTietPhieuTraHang.MaPhieuTra);
            return View(chiTietPhieuTraHang);
        }

        // GET: ChiTietPhieuTraHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuTraHang chiTietPhieuTraHang = db.ChiTietPhieuTraHangs.Find(id);
            if (chiTietPhieuTraHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa", chiTietPhieuTraHang.MaHH);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", chiTietPhieuTraHang.MaNhaCungCap);
            ViewBag.MaPhieuTra = new SelectList(db.PhieuTraHangs, "MaPhieuTra", "MaPhieuTra", chiTietPhieuTraHang.MaPhieuTra);
            return View(chiTietPhieuTraHang);
        }

        // POST: ChiTietPhieuTraHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHH,MaPhieuTra,MaNhaCungCap,TenNhaCungCap,GiaTra,SoLuongTra")] ChiTietPhieuTraHang chiTietPhieuTraHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietPhieuTraHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa", chiTietPhieuTraHang.MaHH);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", chiTietPhieuTraHang.MaNhaCungCap);
            ViewBag.MaPhieuTra = new SelectList(db.PhieuTraHangs, "MaPhieuTra", "MaPhieuTra", chiTietPhieuTraHang.MaPhieuTra);
            return View(chiTietPhieuTraHang);
        }

        // GET: ChiTietPhieuTraHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuTraHang chiTietPhieuTraHang = db.ChiTietPhieuTraHangs.Find(id);
            if (chiTietPhieuTraHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuTraHang);
        }

        // POST: ChiTietPhieuTraHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietPhieuTraHang chiTietPhieuTraHang = db.ChiTietPhieuTraHangs.Find(id);
            db.ChiTietPhieuTraHangs.Remove(chiTietPhieuTraHang);
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
