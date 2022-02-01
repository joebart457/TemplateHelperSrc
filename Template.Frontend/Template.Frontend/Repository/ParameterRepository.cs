using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Managers;
using Template.Frontend.Models.Constants.Enums;
using Template.Frontend.Models.Entities;
using Template.Frontend.Services;

namespace Template.Frontend.Repository
{
    class ParameterRepository
    {
        private ConnectionManager _connectionManager;

        public ParameterRepository(ConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
        public List<ParameterEntity> GetParametersByTemplateId(int templateId)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                var selectParametersCmd = conn.CreateCommand();

                selectParametersCmd.CommandText = @"SELECT id, template_id, symbol, type, description FROM Parameter WHERE template_id = @TemplateId ORDER BY symbol DESC;";
                selectParametersCmd.Parameters.Add(new SqliteParameter("@TemplateId", templateId));

                var reader = selectParametersCmd.ExecuteReader();

                List<ParameterEntity> parameters = new List<ParameterEntity>();
                while (reader.Read())
                {
                    parameters.Add(new ParameterEntity
                    {
                        Id = reader.GetInt32(0),
                        TemplateId = reader.GetInt32(1),
                        Symbol = reader.GetString(2),
                        Type = (ParameterTypeEnum)Enum.Parse(typeof(ParameterTypeEnum), reader.GetString(3)),
                        Description = reader.GetString(4),
                    });
                }

                return parameters;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public List<FilledParameterEntity> GetAllParametersForProject(int projectId)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                var selectParametersCmd = conn.CreateCommand();

                selectParametersCmd.CommandText = @"SELECT p.id, p.template_id, t.name, p.symbol, p.type, p.description 
                                                    FROM Parameter p, ParameterTemplate t, ProjectParameterTemplate ppt 
                                                    WHERE p.template_id = t.id AND ppt.template_id = t.id AND ppt.project_id = @ProjectId
                                                    ORDER BY p.symbol DESC;";
                selectParametersCmd.Parameters.Add(new SqliteParameter("@ProjectId", projectId));

                var reader = selectParametersCmd.ExecuteReader();

                List<FilledParameterEntity> parameters = new List<FilledParameterEntity>();
                while (reader.Read())
                {
                    parameters.Add(new FilledParameterEntity
                    {
                        Id = reader.GetInt32(0),
                        TemplateId = reader.GetInt32(1),
                        TemplateName = reader.GetString(2),
                        Symbol = reader.GetString(3),
                        Type = (ParameterTypeEnum)Enum.Parse(typeof(ParameterTypeEnum), reader.GetString(4)),
                        Description = reader.GetString(5),
                    });
                }

                return parameters;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }


        public int InsertParameter(ParameterEntity parameterEntity)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();
                var insertParameterCmd = conn.CreateCommand();

                insertParameterCmd.CommandText = @"INSERT INTO Parameter (template_id, symbol, description, type) 
                                                      VALUES(@TemplateId, @Symbol, @Description, @Type);";
                insertParameterCmd.Parameters.Add(new SqliteParameter("@TemplateId", parameterEntity.TemplateId));
                insertParameterCmd.Parameters.Add(new SqliteParameter("@Symbol", parameterEntity.Symbol));
                insertParameterCmd.Parameters.Add(new SqliteParameter("@Description", parameterEntity.Description));
                insertParameterCmd.Parameters.Add(new SqliteParameter("@Type", parameterEntity.Type));

                insertParameterCmd.ExecuteNonQuery();

                return 0;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public int UpdateParameter(ParameterEntity parameterEntity)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();
                var updateParameterCmd = conn.CreateCommand();

                updateParameterCmd.CommandText = @"UPDATE Parameter 
                                                    SET template_id = @TemplateId,
                                                        symbol = @Symbol,
                                                        description = @Description,
                                                        type = @Type
                                                    WHERE id = @Id;";
                updateParameterCmd.Parameters.Add(new SqliteParameter("@Id", parameterEntity.Id));
                updateParameterCmd.Parameters.Add(new SqliteParameter("@TemplateId", parameterEntity.TemplateId));
                updateParameterCmd.Parameters.Add(new SqliteParameter("@Symbol", parameterEntity.Symbol));
                updateParameterCmd.Parameters.Add(new SqliteParameter("@Description", parameterEntity.Description));
                updateParameterCmd.Parameters.Add(new SqliteParameter("@Type", parameterEntity.Type));

                updateParameterCmd.ExecuteNonQuery();

                return 0;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }


        public void DeleteParameter(ParameterEntity parameterEntity)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();
                var deleteParameterCmd = conn.CreateCommand();

                deleteParameterCmd.CommandText = @"DELETE FROM Parameter WHERE id = @Id";
                deleteParameterCmd.Parameters.Add(new SqliteParameter("@Id", parameterEntity.Id));

                deleteParameterCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }
    }
}
