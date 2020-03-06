using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    public static class Servers
    {
        private static T GetServers<T>() where T : new()
        {
            var servers = new T();
            return servers;
        }

        public static General general
        {
            get { return GetServers<General>(); }
        }
    }
}
