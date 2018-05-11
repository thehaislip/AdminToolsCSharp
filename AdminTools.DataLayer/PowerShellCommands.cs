using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace AdminTools.Data
{
    public static class  PowerShellCommands<T>
    {
        public static IEnumerable<T> ExecuteScript(string script) {
            var list = new List<T>();
            using (PowerShell psInstance = PowerShell.Create())
            {
                //psInstance.AddScript("$password = ConvertTo-SecureString Sp@cecow22@ -AsPlainText -Force; $Cred = New-Object System.Management.Automation.PSCredential (\"adminteddyh\", $password)");
                //psInstance.AddScript($"invoke-command -Credential $Cred -computername {server} -scriptblock {{import-module WebAdministration; Get-WebApplication | Where-Object {{$_.ApplicationPool -eq \"{appPoolName}\"}};}};");
                psInstance.AddScript(script);

                IEnumerable<PSObject> psObject = psInstance.Invoke();
                if (psInstance.Streams.Error.Count > 0)
                {
                    //TODO: handle errors
                }
                else
                {
                    psObject.AsParallel().ForAll(e => {
                        if (e != null)
                        {
                            //var type t = typeof(T);
                            list.Add(e.ConvertTo<T>());

                        }
                    });
                }
            }
            return list;
        }
    }
}
