using AdminTools.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminTools.Data
{
    public class Server
    {
        public IEnumerable<ApplicationPool> ApplicationPools { get; set; }
        public IEnumerable<Site> Sites { get; set; }
        public String Name { get; set; }

    }
}
