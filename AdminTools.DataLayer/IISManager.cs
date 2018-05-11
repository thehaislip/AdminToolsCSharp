
using AdminTools.Data;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace AdminTools.DataLayer
{
    public class IISManager : IWebServerManager , IGetApplicationPools
    {
        
        public IISManager()
        {
        
            
        }
       
        public IISManager(string server)
        {
         
        }
        public  IEnumerable<ApplicationPool> GetApplicationPools(string server)
        {
            var sb = new StringBuilder();
            var list = new List<ApplicationPool>();

            sb.Append("$password = ConvertTo-SecureString password -AsPlainText -Force; $Cred = New-Object System.Management.Automation.PSCredential (\"user\", $password);");
            sb.Append($"invoke-command -Credential $Cred -computername {server} -scriptblock {{import-module WebAdministration; get-childitem -Path IIS:\\AppPools | select name,state ;}};");

            list = PowerShellCommands<ApplicationPool>.ExecuteScript(sb.ToString()).ToList();
            list.ForEach(e => e.Sites = GetSitesByAppPool(server,e.Name));   
            return list;
        }

        public IEnumerable<Site> GetSitesByAppPool(string server , string appPoolName)
        {
            var sb = new StringBuilder();
            sb.Append("$password = ConvertTo-SecureString Sp@cecow22@ -AsPlainText -Force; $Cred = New-Object System.Management.Automation.PSCredential (\"adminteddyh\", $password);");
            sb.Append($"invoke-command -Credential $Cred -computername {server} -scriptblock {{import-module WebAdministration; Get-WebApplication | Where-Object {{$_.ApplicationPool -eq \"{appPoolName}\"}};}};");
            return PowerShellCommands<Site>.ExecuteScript(sb.ToString());
        }

    }
}
