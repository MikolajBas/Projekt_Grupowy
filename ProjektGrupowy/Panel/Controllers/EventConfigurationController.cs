using Common.Helpers;
using Common.Logging;
using Database.Models;
using Panel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        public async Task<ActionResult> Add(EventConfigurationViewModel data)
        {
            var response = string.Empty;
            try
            {
                int userId = UserHelper.GetUserByIdentityName(User.Identity.Name).Id;
                var config = GetEventConfigurationFromForm(userId, data.CurrentConfig);

                if (IsNewConfiguration(data.CurrentConfig.Id))
                {
                    EventConfigurationHelper.AddConfiguration(config);
                    response = "Event Configuration added successfully";
                }
                else
                {
                    EventConfigurationHelper.UpdateConfiguration(config);
                    response = "Event Configuration updated successfully";
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            var model = GetModel();
            model.Response = response;

            return View("Index", model);
        }

        public ActionResult Edit(int id)
        {
            var model = GetModel();

            try
            {
                int userId = UserHelper.GetUserByIdentityName(User.Identity.Name).Id;

                var  config = EventConfigurationHelper.GetConfiguration(id);
                model.CurrentConfig = GetCurrentConfig(config, userId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return View("Index", model);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var config = EventConfigurationHelper.GetConfiguration(id);
                EventConfigurationHelper.DeleteConfiguration(config);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            var model = GetModel();
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
                CurrentConfig = GetEmptyCurrentConfig(userId),
                Response = string.Empty
            };

            foreach (var config in configs)
            {
                model.Configurations.Add(new EventConfigRow
                {
                    Id = config.Id,
                    Rule = EventConfigurationHelper.FormatEventToString(config),
                    Period = config.Period
                });
            }

            return model;
        }

        private bool IsNewConfiguration(string id)
        {
            return string.IsNullOrEmpty(id);
        }

        private EventConfiguration GetEventConfigurationFromForm(int userId, CurrentConfig config)
        {
            var eventConfig = new EventConfiguration
            {
                PropertyId = config.PropertyId,
                PropertyOperator = config.PropertyOperator,
                PropertyValue = config.PropertyValue,
                Operator = config.Operator,
                ResultValue = Convert.ToInt32(config.ResultValue),
                Function = config.Function,
                Period = Convert.ToInt32(config.Period),
                UserId = userId,
                Template = config.Template,
                Category = string.Empty,
                CategoryId = 0
            };

            if (!IsNewConfiguration(config.Id))
            {
                eventConfig.Id = Convert.ToInt32(config.Id);
            }

            return eventConfig;
        }

        private CurrentConfig GetCurrentConfig(EventConfiguration config, int userId)
        {
            var operators = new List<string>() { "=", "<", ">" };
            var functions = new List<string>() { "SUM", "AVG", "COUNT" };
            var properties = DataConfigurationHelper.GetUserDataProperties(userId);

            return new CurrentConfig
            {
                Id = config.Id.ToString(),
                PropertyId = config.PropertyId,
                PropertyList =
                    properties.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString(),
                        Selected = x.Id == config.PropertyId
                    }),
                PropertyOperator = config.PropertyOperator,
                PropertyOperatorList =
                    operators.Select(x => new SelectListItem
                    {
                        Text = x,
                        Value = x,
                        Selected = x == config.PropertyOperator
                    }),
                PropertyValue = config.PropertyValue,
                Operator = config.Operator,
                OperatorList =
                    operators.Select(x => new SelectListItem
                    {
                        Text = x,
                        Value = x,
                        Selected = x == config.Operator
                    }),
                ResultValue = config.ResultValue.ToString(),
                Function = config.Function,
                FunctionList =
                    functions.Select(x => new SelectListItem
                    {
                        Text = x,
                        Value = x,
                        Selected = x == config.Function
                    }),
                Period = config.Period.ToString(),
                Template = config.Template
            };
        }

        private CurrentConfig GetEmptyCurrentConfig(int userId)
        {
            var operators = new List<string>() { "=", "<", ">" };
            var functions = new List<string>() { "SUM", "AVG", "COUNT" };
            var properties = DataConfigurationHelper.GetUserDataProperties(userId);

            return new CurrentConfig
            {
                Id = string.Empty,
                PropertyList =
                    properties.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString(),
                        Selected = x.Id == properties.First().Id
                    }),
                PropertyOperatorList =
                    operators.Select(x => new SelectListItem
                    {
                        Text = x,
                        Value = x,
                        Selected = x == operators.First()
                    }),
                PropertyValue = string.Empty,
                OperatorList =
                    operators.Select(x => new SelectListItem
                    {
                        Text = x,
                        Value = x,
                        Selected = x == operators.First()
                    }),
                ResultValue = string.Empty,
                FunctionList =
                    functions.Select(x => new SelectListItem
                    {
                        Text = x,
                        Value = x,
                        Selected = x == functions.First()
                    }),
                Period = string.Empty,
                Template = string.Empty
            };
        }
    }
}
