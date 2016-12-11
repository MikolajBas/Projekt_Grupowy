using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Panel.Controllers
{
    public class DataConfigurationController : Controller
    {
        public ActionResult Index()
        {
            Configurator.DataConfigurator dataConfigurator = new Configurator.DataConfigurator();
            List<DataPropertiesConfiguration> dataPropertiesConfiguration = dataConfigurator.GetUserConfigurations(0);
            ViewBag.configurations = dataPropertiesConfiguration;
            return View();
        }
    }
}
