using System;
using System.Collections.Generic;
using System.Text;

namespace AdminTools.DataLayer
{
    public class ApplicationPool
    {
        public string Name { get; set; }
        public IEnumerable<Site> Sites { get; set; }
        public IEnumerable<Application> Applications { get; set; }
        public string State { get; set; }
    }
}
