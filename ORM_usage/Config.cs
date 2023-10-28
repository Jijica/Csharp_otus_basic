using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ORM_usage
{
    internal class Config
    {
        public readonly static string SqlConnectionString;

        static Config()
        {
            var envVar = Environment.GetEnvironmentVariable("SqlConnectionStringLocal", EnvironmentVariableTarget.User);
            SqlConnectionString = envVar;
        }
    }
}
