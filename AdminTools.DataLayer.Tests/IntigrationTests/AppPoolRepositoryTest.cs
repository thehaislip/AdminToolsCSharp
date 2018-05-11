using System;
using NUnit.Framework;
using AdminTools.DataLayer;
using System.Linq;
using AdminTools.BusinessLogic;
using AdminTools.Data;

namespace AdminTools.Tests.IntigrationTests
{
    [TestFixture]
    public class AppPoolRepositoryTest
    {

        private AppPoolRepository _iis;
        public AppPoolRepositoryTest()
        {
            _iis = new AppPoolRepository();
        }

        [Test]
        public void GetAppPoolReturnsNonEmpyListOfServer() {
            var list = _iis.GetApplicationPools(new[] { "itpr1web23", "itpr1web34" });
            CollectionAssert.AllItemsAreInstancesOfType(list, typeof(Server));
        }


        [Test]
        public void GetAppPoolReturnsListOfServersWithNonEmpyAppPools()
        {
            var list = _iis.GetApplicationPools(new[] { "itpr1web23", "itpr1web34" });
            CollectionAssert.IsNotEmpty(list.Select(e => e.ApplicationPools));
        }
    }
}
