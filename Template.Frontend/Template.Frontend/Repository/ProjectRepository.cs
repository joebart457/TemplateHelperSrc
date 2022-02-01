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
    class ProjectRepository
    {
        private ConnectionManager _connectionManager;
        private ParameterTemplateRepository _parameterTemplateRepository;

        public ProjectRepository(ConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
            _parameterTemplateRepository = new ParameterTemplateRepository(_connectionManager);
        }
        public List<ProjectEntity> GetAllProjects()
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                var selectProjectsCmd = conn.CreateCommand();

                selectProjectsCmd.CommandText = @"SELECT id, name, input_directory, sandbox_directory, sql_directory, created_date FROM Project ORDER BY name ASC";

                var reader = selectProjectsCmd.ExecuteReader();

                List<ProjectEntity> projects = new List<ProjectEntity>();
                while (reader.Read())
                {
                    projects.Add(new ProjectEntity
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        InputDirectory = reader.GetString(2),
                        SandboxDirectory = reader.GetString(3),
                        SqlDirectory = reader.GetString(4),
                        CreatedDate = reader.GetDateTime(5)
                    });
                }

                return projects;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public int UpsertProject(ProjectEntity projectEntity, IList<ParameterTemplateEntity> parameterTemplates)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();

                int projectId = projectEntity.Id;

                if (projectId == -1)
                {

                    InsertProject(projectEntity);

                    projectId = _connectionManager.GetLastInsertRowId();

                } else
                { 
                    UpdateProject(projectEntity);
                }

                _parameterTemplateRepository.DeleteAllProjectParameterTemplateAssignments(projectId);

                foreach (ParameterTemplateEntity template in parameterTemplates)
                {
                    var assignmentToAdd = new ProjectParameterTemplateEntity { ProjectId = projectId, TemplateId = template.Id };
                    
                    _parameterTemplateRepository.InsertProjectParameterTemplateAssignment(assignmentToAdd);
                }

                return 0;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public int InsertProject(ProjectEntity projectEntity)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();
                var insertProjectCmd = conn.CreateCommand();

                insertProjectCmd.CommandText = @"INSERT INTO Project (name, input_directory, sandbox_directory, sql_directory, created_date) 
                                                      VALUES(@Name, @InputDirectory, @SandboxDirectory, @SqlDirectory, @CreatedDate);";
                insertProjectCmd.Parameters.Add(new SqliteParameter("@Name", projectEntity.Name));
                insertProjectCmd.Parameters.Add(new SqliteParameter("@InputDirectory", projectEntity.InputDirectory));
                insertProjectCmd.Parameters.Add(new SqliteParameter("@SandboxDirectory", projectEntity.SandboxDirectory));
                insertProjectCmd.Parameters.Add(new SqliteParameter("@SqlDirectory", projectEntity.SqlDirectory));
                insertProjectCmd.Parameters.Add(new SqliteParameter("@CreatedDate", DateTime.Now));

                insertProjectCmd.ExecuteNonQuery();

                return 0;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public int UpdateProject(ProjectEntity projectEntity)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();
                var updateProjectCmd = conn.CreateCommand();

                updateProjectCmd.CommandText = @"UPDATE Project SET
                                                        name = @Name,
                                                        input_directory = @InputDirectory,
                                                        sandbox_directory = @SandboxDirectory,
                                                        sql_directory = @SqlDirectory,
                                                        created_date = @CreatedDate 
                                                   WHERE id = @Id;";

                updateProjectCmd.Parameters.Add(new SqliteParameter("@Id", projectEntity.Id));
                updateProjectCmd.Parameters.Add(new SqliteParameter("@Name", projectEntity.Name));
                updateProjectCmd.Parameters.Add(new SqliteParameter("@InputDirectory", projectEntity.InputDirectory));
                updateProjectCmd.Parameters.Add(new SqliteParameter("@SandboxDirectory", projectEntity.SandboxDirectory));
                updateProjectCmd.Parameters.Add(new SqliteParameter("@SqlDirectory", projectEntity.SqlDirectory));
                updateProjectCmd.Parameters.Add(new SqliteParameter("@CreatedDate", DateTime.Now));

                updateProjectCmd.ExecuteNonQuery();

                return 0;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }


        public void DeleteProject(ProjectEntity projectEntity)
        {
            try
            {
                var conn = _connectionManager.GetSQLConnection();
                var deleteProjectCmd = conn.CreateCommand();

                deleteProjectCmd.CommandText = @"DELETE FROM Project WHERE id = @Id";
                deleteProjectCmd.Parameters.Add(new SqliteParameter("@Id", projectEntity.Id));

                deleteProjectCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }
    }
}
