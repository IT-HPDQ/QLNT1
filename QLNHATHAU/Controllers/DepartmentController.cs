using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QLNHATHAU.Models;

namespace QLNHATHAU.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        QLNhaThauEntities db = new QLNhaThauEntities();
        public ActionResult Index(int? page)
        {
            var model = from a in db.PhongBan_list()
                        select new PhongBanValidation
                        {
                            IDPhongBan = a.IDPhongBan,
                            TenVT = a.TenVT,
                            TenDai = a.TenDai,
                            PCHN = (bool)a.PCHN
                        };
            if (page == null) page = 1;
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(model.OrderBy(x => x.TenVT).ToList().ToPagedList(pageNumber, pageSize));
            
        }
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(PhongBanValidation _DO)
        {
            db.PhongBan_insert(_DO.TenVT,_DO.TenDai,_DO.PCHN);
            TempData["msgSuccess"] = "<script>alert('Thêm mới bộ phận / nhà máy thành công');</script>";
            return RedirectToAction("Index", "Department");
        }
        public ActionResult Edit(int ID)
        {
            var model = (from u in db.PhongBans.Where(x => x.IDPhongBan == ID)
                         select new PhongBanValidation
                         {
                             IDPhongBan = u.IDPhongBan,
                             TenVT = u.TenVT,
                             TenDai = u.TenDai,
                             PCHN = (bool)u.PCHN
                         }).SingleOrDefault();
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(PhongBanValidation _DO)
        {
            db.PhongBan_update(_DO.IDPhongBan, _DO.TenVT, _DO.TenDai, _DO.PCHN);
            TempData["msgSuccess"] = "<script>alert('Cập nhật thành công');</script>";
            return RedirectToAction("Index", "Department");
        }
        public ActionResult Delete(int ID)
        {
            db.PhongBan_delete(ID);
            return RedirectToAction("Index", "Department");
        }
    }
}