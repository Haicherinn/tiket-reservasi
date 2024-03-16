using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tiket_reservation.Models;
using tiket_reservation.Helper;
using tiket_reservation.Security;


namespace tiket_reservation.Controllers
{
    [AuthorizationFilterAdmin]
    public class AdminController : Controller
    {

        static tiket_reservationEntities3 db = new tiket_reservationEntities3();

        // GET: Admin
        public ActionResult dashboard_admin()
        {
            Statistik statistik = new Statistik();
            statistik.total_user = db.detil_pesan_tiket.Count();
            statistik.user_lunas = db.detil_pesan_tiket.Where(u
            => u.total_transfer != 0).Count();
            statistik.user_belum_lunas = db.detil_pesan_tiket.Where(u
            => u.total_transfer == 0).Count();
            var checkPembeli = db.detil_pesan_tiket;
            // cek pembeli ada atau engga 
            if (checkPembeli.Count() == 0)
            {
                // biarkan kosong.
            }
            else
            {
                statistik.uang_estimasi = ConvertCurrency.
                ToRupiah(db.detil_pesan_tiket.Select(u
                => u.harga_tiket).Sum());
                statistik.uang_diterima = ConvertCurrency.
                ToRupiah(db.detil_pesan_tiket.Select(u
                => u.total_transfer).Sum());
                decimal estimasi = db.detil_pesan_tiket.Select(u
                => u.harga_tiket).Sum();
                decimal uangDiterima = db.detil_pesan_tiket.Select(u
                => u.total_transfer).Sum();
                statistik.selisiPendapatan = ConvertCurrency.
                ToRupiah(estimasi - uangDiterima);
            }
            statistik.user_validasi = db.pembeli_validasi.Where(u
            => u.uang_transfer_validasi != null).Count();
            return View(statistik);
        }
        public void RefreshAllTable()
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }
        public ActionResult log_out()
        {
            Session.Remove("admin");
            Session.Remove("email");
            return RedirectToAction("index", "Home");
        }

        public ActionResult semua_pembeli()
        {
            var joinData = from p in db.pembeli
                           from d in db.detil_pesan_tiket
                           where p.id_pembeli == d.id_pembeli
                           from v in db.pembeli_validasi
                           where d.id_pembeli == v.id_pembeli
                           select new Gabungan
                           { tblPembeli = p, tblDetailTiket = d, tblValidasi = v };
            return View(joinData);
        }


    }
}