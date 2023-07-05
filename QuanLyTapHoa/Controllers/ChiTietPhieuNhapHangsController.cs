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
    public class ChiTietPhieuNhapHangsController : Controller
    {
        private QuanLyTapHoaEntities db = new QuanLyTapHoaEntities();

        // GET: ChiTietPhieuNhapHangs
        public ActionResult Index()
        {
            var chiTietPhieuNhapHangs = db.ChiTietPhieuNhapHangs.Include(c => c.HangHoa).Include(c => c.NhaCungCap).Include(c => c.PhieuNhapHang);
            return View(chiTietPhieuNhapHangs.ToList());
        }

        // GET: ChiTietPhieuNhapHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhapHang chiTietPhieuNhapHang = db.ChiTietPhieuNhapHangs.Find(id);
            if (chiTietPhieuNhapHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuNhapHang);
        }

        // GET: ChiTietPhieuNhapHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa");
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap");
            ViewBag.MaPhieuNhap = new SelectList(db.PhieuNhapHangs, "MaPhieuNhap", "MaPhieuNhap");
            return View();
        }

        // POST: ChiTietPhieuNhapHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHH,MaPhieuNhap,MaNhaCungCap,TenNhaCungCap,GiaNhap,SoLuongNhap")] ChiTietPhieuNhapHang chiTietPhieuNhapHang)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietPhieuNhapHangs.Add(chiTietPhieuNhapHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa", chiTietPhieuNhapHang.MaHH);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", chiTietPhieuNhapHang.MaNhaCungCap);
            ViewBag.MaPhieuNhap = new SelectList(db.PhieuNhapHangs, "MaPhieuNhap", "MaPhieuNhap", chiTietPhieuNhapHang.MaPhieuNhap);
            return View(chiTietPhieuNhapHang);
        }

        // GET: ChiTietPhieuNhapHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhapHang chiTietPhieuNhapHang = db.ChiTietPhieuNhapHangs.Find(id);
            if (chiTietPhieuNhapHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa", chiTietPhieuNhapHang.MaHH);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", chiTietPhieuNhapHang.MaNhaCungCap);
            ViewBag.MaPhieuNhap = new SelectList(db.PhieuNhapHangs, "MaPhieuNhap", "MaPhieuNhap", chiTietPhieuNhapHang.MaPhieuNhap);
            return View(chiTietPhieuNhapHang);
        }

        // POST: ChiTietPhieuNhapHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHH,MaPhieuNhap,MaNhaCungCap,TenNhaCungCap,GiaNhap,SoLuongNhap")] ChiTietPhieuNhapHang chiTietPhieuNhapHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietPhieuNhapHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa", chiTietPhieuNhapHang.MaHH);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", chiTietPhieuNhapHang.MaNhaCungCap);
            ViewBag.MaPhieuNhap = new SelectList(db.PhieuNhapHangs, "MaPhieuNhap", "MaPhieuNhap", chiTietPhieuNhapHang.MaPhieuNhap);
            return View(chiTietPhieuNhapHang);
        }

        // GET: ChiTietPhieuNhapHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhapHang chiTietPhieuNhapHang = db.ChiTietPhieuNhapHangs.Find(id);
            if (chiTietPhieuNhapHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuNhapHang);
        }

        // POST: ChiTietPhieuNhapHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietPhieuNhapHang chiTietPhieuNhapHang = db.ChiTietPhieuNhapHangs.Find(id);
            db.ChiTietPhieuNhapHangs.Remove(chiTietPhieuNhapHang);
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
