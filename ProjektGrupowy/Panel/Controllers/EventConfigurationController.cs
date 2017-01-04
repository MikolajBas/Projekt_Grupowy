using Common.Helpers;
using Common.Logging;
using Database.Models;
using Panel.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Panel.Controllers
{
    [Authorize]
    public class EventConfigurationController : Controller
    {
        private readonly Logger _logger = new Logger("EventConfigurationController");

        public ActionResult Index()
        {
            var model = GetModel();

            return View(model);
        }
        
        public ActionResult Add()
        {
            try
            {
                int userId = UserHelper.GetUserByIdentityName(User.Identity.Name).Id;
                var config = GetEventConfigurationFromForm(userId);

                EventConfigurationHelper.AddConfiguration(config);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            var model = GetModel();

            model.Response = "Event Configuration added successfully";

            return View("Index", model);
        }

        public ActionResult Edit(int id)
        {
            var model = GetModel();

            try
            {
                model.CurrentConfig = EventConfigurationHelper.GetConfiguration(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return View("Index", model);
        }

        public ActionResult Delete(int id)
        {
            var model = GetModel();

            try
            {
                var config = EventConfigurationHelper.GetConfiguration(id);
                EventConfigurationHelper.DeleteConfiguration(config);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            model.Response = "Event Configuration deleted successfully";

            return View("Index", model);
        }

        private EventConfigurationViewModel GetModel()
        {
            int userId = UserHelper.GetUserByIdentityName(User.Identity.Name).Id;

            var configs = EventConfigurationHelper.GetUserEventConfigurations(userId);

            var model = new EventConfigurationViewModel()
            {
                Configurations = new List<EventConfigRow>(),
                Properties = DataConfigurationHelper.GetUserDataProperties(userId),
                CurrentConfig = new EventConfiguration(),
                Response = string.Empty
            };

            foreach (var config in configs)
            {
                model.Configurations.Add(new EventConfigRow
                {
                    Rule = EventConfigurationHelper.FormatEventToString(config),
                    Period = config.Period
                });
            }

            return model;
        }

        private EventConfiguration GetEventConfigurationFromForm(int userId)
        {
            return new EventConfiguration
            {
                PropertyId = Convert.ToInt32(Request.Form["property"]),
                PropertyOperator = Request.Form["property-operator"],
                PropertyValue = Request.Form["property-value"],
                Operator = Request.Form["operator"],
                ResultValue = Convert.ToInt32(Request.Form["value"]),
                Function = Request.Form["function"],
                Period = Convert.ToInt32(Request.Form["period"]),
                UserId = userId,
                Template = Request.Form["template"],
                Category = string.Empty,
                CategoryId = 0
            };
        }
    }
}
