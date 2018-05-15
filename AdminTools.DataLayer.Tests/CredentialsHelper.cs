using System;
using System.Collections.Generic;
using System.Text;

namespace AdminTools.Tests
{
    public class CredentialsHelper
    {
        
        public string UserName { get; set; }
        public string Password { get; set; }

        public CredentialsHelper()
        {
            var up = System.IO.File.ReadAllText("D:\\up.txt").Split(",");
            UserName = up[0];
            Password = up[1];
        }
    }
}
