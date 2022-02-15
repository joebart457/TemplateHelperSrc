using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Services;

namespace Template.Frontend.Managers
{
    public class ConnectionManager
    {
        private string _dbFileName { get; } = "data.db";
        private SqliteConnection _sqlConn { get; set; }

        private List<string> RELEASES = new List<string>
        {
            "1.0.0",
        };

        public ConnectionManager() { CreateConnection(); }
        ~ConnectionManager() { }

        public SqliteConnection GetSQLConnection()
        {
            if (_sqlConn != null)
            {
                return _sqlConn;
            }
            throw new Exception("Fatal! db was unitialized when requested.");
        }

        public int GetLastInsertRowId()
        {
            var conn = GetSQLConnection();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT last_insert_rowid();";

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        private void CreateConnection()
        {
            if (File.Exists(_dbFileName))
            {
                try
                {
                    _sqlConn = new SqliteConnection($"Data Source={_dbFileName};");
                    _sqlConn.Open();
                    var cmd = _sqlConn.CreateCommand();
                    cmd.CommandText = "select value from config where param='Db.Version'";
                    object version = cmd.ExecuteScalar();
                    if (version == null || !(version is string))
                    {
                        throw new Exception("Fatal! Invalid db data.");
                    }
                    else
                    {
                        string versionStr = version.ToString();
                        int index = RELEASES.FindIndex(x => x == versionStr);
                        if (index == -1)
                        {
                            throw new Exception("Invalid db version. Please update manually. Or recreate db.");
                        }
                        else
                        {
                            for (int i = index + 1; i < RELEASES.Count(); i++)
                            {
                                RunUpgrade(RELEASES.ElementAt(i));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggerService.LogError(ex.ToString());
                    throw ex;
                }
            }
            else
            {
                LoggerService.Log("Existing db not found. Creating...");
                SetupNewDatabase();
                LoggerService.Log("Finished new db creation.");
            }
        }

        private void UpgradeDatabase() { }

        private void SetupNewDatabase()
        {
            try
            {
                _sqlConn = new SqliteConnection($"Data Source={_dbFileName};");
                _sqlConn.Open();

                var createConfigTblCmd = _sqlConn.CreateCommand();
                createConfigTblCmd.CommandText = @"CREATE TABLE config (
                	id	INTEGER NOT NULL,
                	param	TEXT NOT NULL UNIQUE,
                	value	TEXT,
                	PRIMARY KEY(id AUTOINCREMENT)
                )";

                createConfigTblCmd.ExecuteNonQuery();

                var createParameterTemplateTblCmd = _sqlConn.CreateCommand();
                createParameterTemplateTblCmd.CommandText = @"CREATE TABLE ParameterTemplate (
                	id	INTEGER NOT NULL,
                	name	TEXT NOT NULL,
                    locked BOOLEAN NOT NULL DEFAULT FALSE,
                	PRIMARY KEY(id AUTOINCREMENT)
                );";

                createParameterTemplateTblCmd.ExecuteNonQuery();

                var createParameterTblCmd = _sqlConn.CreateCommand();
                createParameterTblCmd.CommandText = @"CREATE TABLE Parameter (
                	id	INTEGER NOT NULL,
                    template_id INTEGER NOT NULL,
                	symbol	TEXT NOT NULL,
                    description	TEXT,
                    type TEXT NOT NULL,
                	PRIMARY KEY(id AUTOINCREMENT)
                );";

                createParameterTblCmd.ExecuteNonQuery();


                var createProjectTblCmd = _sqlConn.CreateCommand();
                createProjectTblCmd.CommandText = @"CREATE TABLE Project (
                	id	INTEGER NOT NULL,
                    name TEXT NOT NULL,
                	input_directory TEXT NOT NULL,
                    sandbox_directory TEXT NOT NULL,
                    created_date INTEGER NOT NULL,
                	PRIMARY KEY(id AUTOINCREMENT)
                ); ";

                createProjectTblCmd.ExecuteNonQuery();

                var createProjectParameterTemplateTblCmd = _sqlConn.CreateCommand();
                createProjectParameterTemplateTblCmd.CommandText = @"CREATE TABLE ProjectParameterTemplate (
                	id	INTEGER NOT NULL,
                    project_id	INTEGER NOT NULL,
                    template_id	INTEGER NOT NULL,
                	PRIMARY KEY(id AUTOINCREMENT),
                    FOREIGN KEY('project_id') REFERENCES Project(id) ON DELETE CASCADE,
                    FOREIGN KEY('template_id') REFERENCES ParameterTemplate(id) ON DELETE CASCADE
                ); ";

                createProjectParameterTemplateTblCmd.ExecuteNonQuery();

                var createRunSessionTblCmd = _sqlConn.CreateCommand();
                createRunSessionTblCmd.CommandText = @"CREATE TABLE RunSession (
                	id	INTEGER NOT NULL,
                    run_date INTEGER NOT NULL,
                    output_directory TEXT NOT NULL,
                	PRIMARY KEY(id AUTOINCREMENT)
                ); ";

                createRunSessionTblCmd.ExecuteNonQuery();

                var createProjectDependencyTblCmd = _sqlConn.CreateCommand();
                createProjectDependencyTblCmd.CommandText = @"CREATE TABLE ProjectDependency (
                	id	INTEGER NOT NULL,
                    project_id INTEGER NOT NULL,
                    filepath TEXT NOT NULL,
                	PRIMARY KEY(id AUTOINCREMENT)
                ); ";

                createProjectDependencyTblCmd.ExecuteNonQuery();


                SetApplicationSettings();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetApplicationSettings()
        {
            try
            {
                var insertAppParamsCmd = _sqlConn.CreateCommand();
                insertAppParamsCmd.CommandText = @"INSERT INTO config (param, value) 
                    VALUES  ('Db.Version', '1.0.0'),
                            ('Logger.DoLogDebug', 'false'),
                            ('Logger.DoLogWarning', 'true'),
                            ('Logger.DoLogError', 'true'),
                            ('Settings.ProjectHome', @ProjectHome)";
                insertAppParamsCmd.Parameters.Add(new SqliteParameter("@ProjectHome", System.Reflection.Assembly.GetExecutingAssembly().Location));
                insertAppParamsCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        private void RunUpgrade(string upgradeVersion)
        {
            LoggerService.Log("Running upgrade: " + upgradeVersion);
            if (upgradeVersion == "1.0.0")
            {
                // Initial Release
            }


        }
    }
}
