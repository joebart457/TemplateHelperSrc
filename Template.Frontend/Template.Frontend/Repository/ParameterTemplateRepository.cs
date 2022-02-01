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
    class ParameterTemplateRepository
    {
        private ConnectionManager _connectionManager;

        public ParameterTemplateRepository(ConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
        public List<ParameterTemplateEntity> GetAllParameterTemplates()
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                var selectParameterTemplatesCmd = conn.CreateCommand();

                selectParameterTemplatesCmd.CommandText = @"SELECT id, name FROM ParameterTemplate ORDER BY name ASC";

                var reader = selectParameterTemplatesCmd.ExecuteReader();

                List<ParameterTemplateEntity> templates = new List<ParameterTemplateEntity>();
                while (reader.Read())
                {
                    templates.Add(new ParameterTemplateEntity
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                    });
                }

                return templates;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }


        public List<ParameterTemplateEntity> GetAssignedParameterTemplates(int projectId)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                var selectParameterTemplatesCmd = conn.CreateCommand();

                selectParameterTemplatesCmd.CommandText = @"SELECT pt.id, pt.name 
                                                                FROM ParameterTemplate pt, ProjectParameterTemplate ppt 
                                                                WHERE ppt.template_id = pt.id AND ppt.project_id = @Id ORDER BY name ASC";
                selectParameterTemplatesCmd.Parameters.Add(new SqliteParameter("@Id", projectId));
                var reader = selectParameterTemplatesCmd.ExecuteReader();

                List<ParameterTemplateEntity> templates = new List<ParameterTemplateEntity>();
                while (reader.Read())
                {
                    templates.Add(new ParameterTemplateEntity
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                    });
                }

                return templates;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public List<ParameterTemplateEntity> GetUnassignedParameterTemplates(int projectId)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                var selectParameterTemplatesCmd = conn.CreateCommand();

                selectParameterTemplatesCmd.CommandText = @"SELECT pt.id, pt.name 
                                                                FROM ParameterTemplate pt
                                                                WHERE NOT pt.id IN 
                                                                (SELECT template_id FROM ProjectParameterTemplate ppt WHERE ppt.project_id = @Id) 
                                                                ORDER BY name ASC";

                selectParameterTemplatesCmd.Parameters.Add(new SqliteParameter("@Id", projectId));
                var reader = selectParameterTemplatesCmd.ExecuteReader();

                List<ParameterTemplateEntity> templates = new List<ParameterTemplateEntity>();
                while (reader.Read())
                {
                    templates.Add(new ParameterTemplateEntity
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                    });
                }

                return templates;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public void DeleteProjectParameterTemplateAssignment(ProjectParameterTemplateEntity entity)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                var deleteCmd = conn.CreateCommand();

                deleteCmd.CommandText = @"DELETE FROM ProjectParameterTemplate WHERE project_id = @ProjectId AND template_id = @TemplateId)";
                deleteCmd.Parameters.Add(new SqliteParameter("@ProjectId", entity.ProjectId));
                deleteCmd.Parameters.Add(new SqliteParameter("@TemplateId", entity.TemplateId));
                deleteCmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public void DeleteAllProjectParameterTemplateAssignments(int projectId)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                var deleteCmd = conn.CreateCommand();

                deleteCmd.CommandText = @"DELETE FROM ProjectParameterTemplate WHERE project_id = @ProjectId;";
                deleteCmd.Parameters.Add(new SqliteParameter("@ProjectId", projectId));

                deleteCmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public void InsertProjectParameterTemplateAssignment(ProjectParameterTemplateEntity entity)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                var insertCmd = conn.CreateCommand();

                insertCmd.CommandText = @"INSERT INTO ProjectParameterTemplate (project_id, template_id)
                                                                VALUES(@ProjectId, @TemplateId)";
                insertCmd.Parameters.Add(new SqliteParameter("@ProjectId", entity.ProjectId));
                insertCmd.Parameters.Add(new SqliteParameter("@TemplateId", entity.TemplateId));
                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }


        public int InsertParameterTemplate(ParameterTemplateEntity parameterTemplateEntity)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();
                var insertParameterTemplateCmd = conn.CreateCommand();

                insertParameterTemplateCmd.CommandText = @"INSERT INTO ParameterTemplate (name) 
                                                      VALUES(@Name);";
                insertParameterTemplateCmd.Parameters.Add(new SqliteParameter("@Name", parameterTemplateEntity.Name));

                insertParameterTemplateCmd.ExecuteNonQuery();

                return 0;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public int UpdateParameter(ParameterTemplateEntity parameterTemplateEntity)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();
                var updateParameterTemplateCmd = conn.CreateCommand();

                updateParameterTemplateCmd.CommandText = @"UPDATE ParameterTemplate
                                                    SET name = @Name,
                                                    WHERE id = @Id;";
                updateParameterTemplateCmd.Parameters.Add(new SqliteParameter("@Id", parameterTemplateEntity.Id));
                updateParameterTemplateCmd.Parameters.Add(new SqliteParameter("@Name", parameterTemplateEntity.Name));

                updateParameterTemplateCmd.ExecuteNonQuery();

                return 0;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }


        public void DeleteParameterTemplate(ParameterTemplateEntity parameterTemplateEntity)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();
                var deleteParameterTemplateCmd = conn.CreateCommand();

                deleteParameterTemplateCmd.CommandText = @"DELETE FROM ParameterTemplate WHERE id = @Id";
                deleteParameterTemplateCmd.Parameters.Add(new SqliteParameter("@Id", parameterTemplateEntity.Id));

                deleteParameterTemplateCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }
    }
}
