using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Managers;

namespace Template.Frontend.Services
{
    static class ContextService
    {
        private static ConnectionManager _connectionManager;
        public static ConnectionManager ConnectionManager { get { return BuildConnectionManager(); } }

        private static ConnectionManager BuildConnectionManager()
        {
            if (_connectionManager != null)
            {
                return _connectionManager;
            }
            _connectionManager = new ConnectionManager();
            return _connectionManager;
        }
    }
}
