using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Managers;
using Template.Frontend.Services;

namespace Template.Frontend.Repository
{
    class ConfigRepository
    {
        private ConnectionManager _connectionManager;

        public ConfigRepository(ConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
        public string TryGetStringOption(string param, string onFail)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();
                var selectParamCmd = conn.CreateCommand();

                selectParamCmd.CommandText = @"SELECT param, value FROM config WHERE param = @ParameterName";
                selectParamCmd.Parameters.Add(new SqliteParameter("@ParameterName", param));

                string result = onFail;
                var reader = selectParamCmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(1);
                }

                return result;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                return onFail;
            }
        }
    }
}
