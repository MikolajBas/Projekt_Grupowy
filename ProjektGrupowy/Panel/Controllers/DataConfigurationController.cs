using Common.Helpers;
using Database.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Panel.Controllers
{
    [Authorize]
    public class DataConfigurationController : Controller
    {
        public ActionResult Index()
        {
            int userId = UserHelper.GetUserByIdentityName(User.Identity.Name).Id;
            Configurator.DataConfigurator dataConfigurator = new Configurator.DataConfigurator();

            List<DataPropertiesConfiguration> dataPropertiesConfiguration = dataConfigurator.GetUserConfigurations(userId);
            ViewBag.configurations = dataPropertiesConfiguration;
            return View();
        }

        public ActionResult AddConfiguration()
        {
            Configurator.DataConfigurator dataConfigurator = new Configurator.DataConfigurator();
            var name = string.Format("{0}", Request.Form["name"]);
            var type = string.Format("{0}", Request.Form["type"]);
            
            int userId = UserHelper.GetUserByIdentityName(User.Identity.Name).Id;
            dataConfigurator.AddDataPropertiesConfiguration(name, type, userId);

            List<DataPropertiesConfiguration> dataPropertiesConfiguration = dataConfigurator.GetUserConfigurations(userId);
            ViewBag.configurations = dataPropertiesConfiguration;

            return View("Index");
        }

        public ActionResult DeleteData()
        {
            int id;
            int.TryParse(Request.Form["delete"], out id);

            Configurator.DataConfigurator dataConfigurator = new Configurator.DataConfigurator();
            dataConfigurator.DeleteData(id);

            int userId = UserHelper.GetUserByIdentityName(User.Identity.Name).Id;

            List<DataPropertiesConfiguration> dataPropertiesConfiguration = dataConfigurator.GetUserConfigurations(userId);
            ViewBag.configurations = dataPropertiesConfiguration;

            return View("Index");
        }

        public ActionResult EditData()
        {
            int id;
            int type;

            int.TryParse(Request.Form["id"], out id);
            var name = string.Format("{0}", Request.Form["name"]);
            var typeString = string.Format("{0}", Request.Form["type"]);

            if (typeString =="Int")
            {
                type = 1;
            }
            else
            {
                type = 2;
            }

            Configurator.DataConfigurator dataConfigurator = new Configurator.DataConfigurator();
            dataConfigurator.EditData(id, name, type);

            int userId = UserHelper.GetUserByIdentityName(User.Identity.Name).Id;

            List<DataPropertiesConfiguration> dataPropertiesConfiguration = dataConfigurator.GetUserConfigurations(userId);
            ViewBag.configurations = dataPropertiesConfiguration;

            return View("Index");
        }
    }
}
