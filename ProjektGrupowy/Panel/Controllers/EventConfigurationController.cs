using Common.Helpers;
using Panel.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Panel.Controllers
{
    [Authorize]
    public class EventConfigurationController : Controller
    {
        public ActionResult Index()
        {
            int userId = UserHelper.GetUserByIdentityName(User.Identity.Name).Id;

            var configs = EventConfigurationHelper.GetUserEventConfigurations(userId);

            var model = new EventConfigurationViewModel()
            {
                Configurations = new List<EventConfigRow>()
            };

            foreach (var config in configs)
            {
                model.Configurations.Add(new EventConfigRow
                {
                    Rule = EventConfigurationHelper.FormatEventToString(config),
                    Period = config.Period
                });
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
