using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Managers;
using Template.Frontend.Models.Entities;
using Template.Frontend.Services;

namespace Template.Frontend.Repository
{
    class DependencyRepository
    {
        private ConnectionManager _connectionManager;

        public DependencyRepository(ConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
        public List<DependencyEntity> GetAllDependenciesForProject(int projectId)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                var selectCmd = conn.CreateCommand();

                selectCmd.CommandText = @"SELECT id, project_id, filepath FROM ProjectDependency
                                        WHERE project_id = @ProjectId
                                        ORDER BY filepath ASC";

                selectCmd.Parameters.Add(new SqliteParameter("@ProjectId", projectId));

                var reader = selectCmd.ExecuteReader();

                List<DependencyEntity> dependencies = new List<DependencyEntity>();
                while (reader.Read())
                {
                    dependencies.Add(new DependencyEntity
                    {
                        Id = reader.GetInt32(0),
                        ProjectId = reader.GetInt32(1),
                        Path = reader.GetString(2)
                    });
                }

                return dependencies;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public void DeleteDependenciesFromProject(int projectId)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                var deleteCmd = conn.CreateCommand();

                deleteCmd.CommandText = @"DELETE FROM ProjectDependency
                                        WHERE project_id = @ProjectId";

                deleteCmd.Parameters.Add(new SqliteParameter("@ProjectId", projectId));

                deleteCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public void AssignDependenciesToProject(int projectId, List<DependencyEntity> dependencies)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                foreach (var dependency in dependencies)
                {
                    var insertCmd = conn.CreateCommand();

                    insertCmd.CommandText = @"INSERT INTO ProjectDependency (project_id, filepath)
                                        VALUES (@ProjectId, @FilePath)";

                    insertCmd.Parameters.Add(new SqliteParameter("@ProjectId", projectId));
                    insertCmd.Parameters.Add(new SqliteParameter("@FilePath", dependency.Path));

                    insertCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public void AssignDependencyToProject(DependencyEntity dependency)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                var insertCmd = conn.CreateCommand();

                insertCmd.CommandText = @"INSERT INTO ProjectDependency (project_id, filepath)
                                        VALUES (@ProjectId, @FilePath)";

                insertCmd.Parameters.Add(new SqliteParameter("@ProjectId", dependency.ProjectId));
                insertCmd.Parameters.Add(new SqliteParameter("@FilePath", dependency.Path));

                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public void DeleteDependencyFromProject(DependencyEntity dependency)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                var deleteCmd = conn.CreateCommand();

                deleteCmd.CommandText = @"DELETE FROM ProjectDependency
                                        WHERE id = @Id";

                deleteCmd.Parameters.Add(new SqliteParameter("@Id", dependency.Id));

                deleteCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

    }
}
