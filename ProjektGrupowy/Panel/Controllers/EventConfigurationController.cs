using Panel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Panel.Controllers
{
    [Authorize]
    public class EventConfigurationController : Controller
    {
        public ActionResult Index()
        {
            var model = new EventConfigurationViewModel()
            {
                Configurations = new List<EventConfigRow>
                {
                    new EventConfigRow
                    {
                        Id = 1,
                        Rule = "Rule rule rule",
                        Period = 3
                    },
                    new EventConfigRow
                    {
                        Id = 2,
                        Rule = "Rule rule rule2",
                        Period = 15
                    },
                    new EventConfigRow
                    {
                        Id = 3,
                        Rule = "Rule rule rule3",
                        Period = 31
                    }
                }
            };

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
