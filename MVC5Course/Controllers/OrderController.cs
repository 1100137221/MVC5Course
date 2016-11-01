using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class OrderController : Controller
    {
        OrderRepository repo = RepositoryHelper.GetOrderRepository();
        // GET: Order
        public ActionResult Index(int clientId)
        {
            var order = repo.All().Where(p => p.ClientId == clientId);
            return View(order.ToList());
        }
    }
}