using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace AdminTools.Data
{
    public static class Extentions
    {
        public static T ConvertTo<T>(this PSObject obj) {
            var t = Activator.CreateInstance(typeof(T));
            //  var e = item.BaseObject as ApplicationPool;
            //  list.Add(new ApplicationPool() { Name = item.BaseObject.GetType().FullName });

            foreach (var prop in t.GetType().GetProperties())
            {
                if (obj.Properties.Any(e => e.Name.ToLower() == prop.Name.ToLower()))
                {
                    var v = obj.Properties.FirstOrDefault(e => e.Name.ToLower() == prop.Name.ToLower()).Value;
                    prop.SetValue(t, v, null);
                }
            }
            return (T)t;
        }
    }
}
