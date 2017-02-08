using Common.Helpers;
using Database.Models;
using Panel.Models;
using Common.Logging;
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
        private readonly Logger _logger = new Logger("StatisticsController");

        public ActionResult Index()
        {
            var model = GetModel();
            return View("Index", model);
        }

        [HttpPost]
        public JsonResult Statistics(StatistiscViewModel model)
        {

            int userId = UserHelper.GetUserByIdentityName(User.Identity.Name).Id;
            List<SiteCount> data = StatisticsHelper.GetSitesStatistics(
               model.CurrentAttribute, userId, model.StartDate, model.EndDate);
            model.Labels = GetLabels(data);
            model.CountedData = GetData(data);
            model.Attributes = GetAttributes();
            model.ChartTypes = GetChartTypes();
            return Json(new { labels = model.Labels, countedData = model.CountedData, chartType = model.CurrentChartType});
        }

        private StatistiscViewModel GetModel()
        {
            var model = new StatistiscViewModel()
            {
                Attributes = GetAttributes(),
                ChartTypes = GetChartTypes(),
                CurrentAttribute = "system",
                CurrentChartType = "pie",
                StartDate = new DateTime(2016, 01, 01),
                EndDate = new DateTime(2017, 01, 01),
                Labels = null,
                CountedData = null
            };

            return model;
        }

        private List<SelectListItem> GetAttributes()
        {
             return new List<SelectListItem>
            {
                new SelectListItem() { Value = "System", Text  = "system"},
                new SelectListItem() { Value = "Browser", Text = "browser" },
                new SelectListItem() { Value = "Agent", Text = "agent" },
                new SelectListItem() { Value = "ScreenResolution", Text = "screen resolution" }
            };
        }
        private List<SelectListItem> GetChartTypes()
        {
            return new List<SelectListItem>
            {
                new SelectListItem() { Value = "pie", Text  = "pie"},
                new SelectListItem() { Value = "radar", Text = "radar" },
                new SelectListItem() { Value = "bar", Text = "bar" },
                new SelectListItem() { Value = "doughnut", Text = "doughnut" }
            };
        }
        
        private List<String> GetLabels(List<SiteCount> filteredData)
        {
            return filteredData.Select(x => x.Name).ToList();
        }

        private List<int> GetData(List<SiteCount> filteredData)
        {
            return filteredData.Select(x => x.Count).ToList();
        }
    }
}
