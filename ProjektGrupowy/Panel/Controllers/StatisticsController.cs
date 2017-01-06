using Common.Helpers;
using Database.Models;
using Panel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using static Panel.Models.StatistiscViewModel;

namespace Panel.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        public ActionResult Index()
        {
            var model = GetModel();
            return View();
        }

        private StatistiscViewModel GetModel()
        {
            int userId = UserHelper.GetUserByIdentityName(User.Identity.Name).Id;

            var model = new StatistiscViewModel()
            {
                Attributes = GetAttributes(),
                ChartTypes = GetChartTypes(),
                CurrentAttribute = 1,
                CurrentChartType = 1
            };

            return model;
        }

        private static List<AttributeType> GetAttributes()
        {
            return new List<AttributeType>
            {
                new AttributeType(1, "screen_resolution"),
                new AttributeType(2, "browser"),
                new AttributeType(3, "agent"),
                new AttributeType(4, "system")
            };
        }
        private static List<AttributeType> GetChartTypes()
        {
            return new List<AttributeType>
            {
                new AttributeType(1, "pie"),
                new AttributeType(2, "radar"),
                new AttributeType(3, "bar"),
                new AttributeType(4, "doughnut")
            };
        }
    }
}
