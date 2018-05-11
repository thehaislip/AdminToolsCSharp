using System;
using NUnit.Framework;
using AdminTools.DataLayer;
using System.Linq;

namespace AdminTools.Tests
{
    [TestFixture]
    public class ApplicationPoolTest
    {
        private IISManager _iis;
        public ApplicationPoolTest()
        {
            _iis = new IISManager();
        }

        [SetUp]
        public void Setup() {

        }

        [Test]
        public void GetApplicationPoolsReturnsANonEmptyList() {
            CollectionAssert.IsNotEmpty(_iis.GetApplicationPools("itpr1web23"));
        }

        [Test]
        public void GetApplicationPoolsReturnsANonEmptyListMultipleServers()
        {
            CollectionAssert.IsNotEmpty(_iis.GetApplicationPools("itpr1web23,itpr1web34"));
        }

        [Test]
        public void GetAppPoolsReturnNonEmptySites() {
            CollectionAssert.IsNotEmpty(_iis.GetApplicationPools("itpr1web23").SelectMany(e => e.Sites));
        }


    }
}
