using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        // GET: SachOnline
        dbSachOnlineDataContext data = new dbSachOnlineDataContext();

        private List<SACH>LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }

        public ActionResult Index()
        {
            var listSachMoi = LaySachMoi(6);

            return View(listSachMoi);

        }

        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe);
        }
        public ActionResult NhaXuatBanPartial()
        {
            var listNhaXuatBan = from cd in data.NhaXuatBans select cd;
            return PartialView(listNhaXuatBan);
        }
    }
}