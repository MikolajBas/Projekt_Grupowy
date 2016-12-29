using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Panel.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
