using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;

namespace Tests
{
    public abstract class TestWithDatabase
    {
        static TestWithDatabase()
        {
            InMemorySessionProvider.UseMe();
        }

        [TestInitialize]
        public void MemorySessionSetup()
        {
            InMemorySessionProvider.StartNewDBSession();
        }
    }
}