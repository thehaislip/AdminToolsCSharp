using AdminTools.Data;
using AdminTools.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminTools.BusinessLogic
{
    public class AppPoolRepository
    {
        private readonly IISManager _iisManager;
        
        public AppPoolRepository()
        {
            _iisManager = new IISManager();
        }
        public AppPoolRepository(IISManager iISManager)
        {
            _iisManager = iISManager;
        }
        public IEnumerable<Server> GetApplicationPools(IEnumerable<string> servers,string username, string password)
        {
            var list = new List<Server>();
            list = servers.AsParallel().Select(e => new Server {
                Name = e,
                ApplicationPools = _iisManager.GetApplicationPools(e, username, password)
            }).ToList();
            return list;
        }

        public ApplicationPool GetApplicationPoolBySiteName(string server, string sightName) {
            return null;
        }

    }
}
