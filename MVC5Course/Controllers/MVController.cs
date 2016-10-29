using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [localDebugOnly]
    public class MVController : BaseController
    {
        [shareData]
        // GET: MV
        public ActionResult Index()
        {
            ViewData["Temp1"] = "暫存資料";

            return View();
        }

        public ActionResult ProductList()
        {
            var data = repo.get產品筆數(10);

            return View(data);
        }

        public ActionResult BatchUpdate(IList<ProductBatchViewModel> items)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in items)
                {
                    var product = repo.find(item.ProductId);
                    product.ProductName = item.ProductName;
                    product.Stock = item.Stock;
                }
                repo.UnitOfWork.Commit();
                
            }
            return RedirectToAction("ProductList");
        }



    }
}