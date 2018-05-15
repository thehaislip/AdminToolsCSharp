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
        private CredentialsHelper creds;
        public ApplicationPoolTest()
        {
            _iis = new IISManager();
        }

        [SetUp]
        public void Setup() {
            creds = new CredentialsHelper();
        }

        [Test]
        public void GetApplicationPoolsReturnsANonEmptyList() {
            CollectionAssert.IsNotEmpty(_iis.GetApplicationPools("itpr1web23",creds.UserName,creds.Password));
        }

        [Test]
        public void GetApplicationPoolsReturnsANonEmptyListMultipleServers()
        {
            CollectionAssert.IsNotEmpty(_iis.GetApplicationPools("itpr1web23,itpr1web34", creds.UserName, creds.Password));
        }

        [Test]
        public void GetAppPoolsReturnNonEmptySites() {
            CollectionAssert.IsNotEmpty(_iis.GetApplicationPools("itpr1web23", creds.UserName, creds.Password).SelectMany(e => e.Sites));
        }


    }
}
