using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Panel.Controllers
{
    public class StatisticsController : Controller
    {
        public ActionResult Index()
        {
            Configurator.DataConfigurator dataConfigurator = new Configurator.DataConfigurator();
            List<DataPropertiesConfiguration> dataPropertiesConfiguration = dataConfigurator.GetAllData();
            ViewBag.configurations = dataPropertiesConfiguration;
            return View();
        }

        public ActionResult addConfiguration()
        {
            Configurator.DataConfigurator dataConfigurator = new Configurator.DataConfigurator();
            String name = String.Format("{0}", Request.Form["name"]);
            String type = String.Format("{0}", Request.Form["type"]);
            int user;
            int.TryParse(Request.Form["user"], out user);
            dataConfigurator.AddDataPropertiesConfiguration(name, type, 1);

            List<DataPropertiesConfiguration> dataPropertiesConfiguration = dataConfigurator.GetAllData();
            ViewBag.configurations = dataPropertiesConfiguration;

            return View("Index");
        }

        public ActionResult editData()
        {
            return View();
        }

            public ActionResult deleteData()
        {
            int id;
            int.TryParse(Request.Form["delete"] , out id);
            Configurator.DataConfigurator dataConfigurator = new Configurator.DataConfigurator();
            dataConfigurator.deleteData(id);

            List<DataPropertiesConfiguration> dataPropertiesConfiguration = dataConfigurator.GetAllData();
            ViewBag.configurations = dataPropertiesConfiguration;

            return View("Index");

        }
    }
}
