using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Configurator;
using DB = Database.Models;
using Database;

namespace Tests.Common
{
    [TestClass]
    public class ConfiguratorTest : TestWithDatabase
    {
        private EventConfigurator _configurator;

        [TestInitialize]
        public void SetUp()
        {
            _configurator = new EventConfigurator();
        }

        [TestMethod]
        public void IsResultCorrectTest()
        {
            var result1 = _configurator.IsResultCorrect(1, 2, "<");
            var result2 = _configurator.IsResultCorrect(3, 7, ">");

            Assert.AreEqual(result1, true);
            Assert.AreEqual(result2, false);
        }

        [TestMethod]
        public void CheckEventTest()
        {
            var data1 = new DB.Data
            {
                Id = 1,
                Ip = "127.0.0.1",
                UserId = 1,
                CategoryId = 1,
                ProductId = 1,
                Date = DateTime.Now
            };

            var data2 = new DB.Data
            {
                Id = 2,
                Ip = "127.0.0.1",
                UserId = 1,
                CategoryId = 1,
                ProductId = 2,
                Date = DateTime.Now
            };

            var data3 = new DB.Data
            {
                Id = 3,
                Ip = "127.0.0.1",
                UserId = 2,
                CategoryId = 1,
                ProductId = 1,
                Date = DateTime.Now
            };

            var dataProperty1 = new DB.DataProperty
            {
                PropertyId = 1,
                Value = "10",
                DataId = 1
            };

            var dataProperty2 = new DB.DataProperty
            {
                PropertyId = 1,
                Value = "30",
                DataId = 2
            };

            var dataProperty3 = new DB.DataProperty
            {
                PropertyId = 1,
                Value = "40",
                DataId = 3
            };

            var dataProperty4 = new DB.DataProperty
            {
                PropertyId = 2,
                Value = "90",
                DataId = 1
            };

            var config = new DB.EventConfiguration
            {
                Id = 1,
                PropertyId = 1,
                PropertyOperator = ">",
                PropertyValue = "0",
                Operator = ">",
                ResultValue = 15,
                Function = "avg",
                Period = 10,
                UserId = 1,
                CategoryId = 1
            };

            using (var session = Connector.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(data1);
                session.Save(data2);
                session.Save(data3);
                session.Save(dataProperty1);
                session.Save(dataProperty2);
                session.Save(dataProperty3);
                session.Save(dataProperty4);

                var result1 = _configurator.GetEventConditionResult(session, config, "127.0.0.1");

                config.ResultValue = 100;
                var result2 = _configurator.GetEventConditionResult(session, config, "127.0.0.1");

                Assert.AreEqual(result1, true);
                Assert.AreEqual(result2, false);

                transaction.Commit();
            }
        }
    }
}
