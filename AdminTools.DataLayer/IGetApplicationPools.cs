using System.Collections.Generic;

namespace AdminTools.DataLayer
{
    internal interface IGetApplicationPools
    {
         IEnumerable<ApplicationPool> GetApplicationPools(string server);
    }
}