using PagedList;
using QLNHATHAU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNHATHAU.Controllers
{
    public class ContractorsController : Controller
    {
        // GET: Contractors
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
    }
}