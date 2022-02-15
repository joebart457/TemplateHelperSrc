using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Managers;
using Template.Frontend.Repository;

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

        private static ParameterRepository _parameterRepository;
        public static ParameterRepository ParameterRepository { get { return BuildParameterRepository(); } }
        private static ParameterRepository BuildParameterRepository()
        {
            if (_parameterRepository != null)
            {
                return _parameterRepository;
            }
            if (_connectionManager == null)
            {
                BuildConnectionManager();
            }
            _parameterRepository = new ParameterRepository(_connectionManager);
            return _parameterRepository;
        }

        private static ProjectRepository _projectRepository;
        public static ProjectRepository ProjectRepository { get { return BuildProjectRepository(); } }
        private static ProjectRepository BuildProjectRepository()
        {
            if (_projectRepository != null)
            {
                return _projectRepository;
            }
            if (_connectionManager == null)
            {
                BuildConnectionManager();
            }
            _projectRepository = new ProjectRepository(_connectionManager);
            return _projectRepository;
        }

        private static ParameterTemplateRepository _parameterTemplateRepository;
        public static ParameterTemplateRepository ParameterTemplateRepository { get { return BuildParameterTemplateRepository(); } }
        private static ParameterTemplateRepository BuildParameterTemplateRepository()
        {
            if (_parameterTemplateRepository != null)
            {
                return _parameterTemplateRepository;
            }
            if (_connectionManager == null)
            {
                BuildConnectionManager();
            }
            _parameterTemplateRepository = new ParameterTemplateRepository(_connectionManager);
            return _parameterTemplateRepository;
        }

        private static ConfigRepository _configRepository;
        public static ConfigRepository ConfigRepository { get { return BuildConfigRepository(); } }
        private static ConfigRepository BuildConfigRepository()
        {
            if (_configRepository != null)
            {
                return _configRepository;
            }
            if (_connectionManager == null)
            {
                BuildConnectionManager();
            }
            _configRepository = new ConfigRepository(_connectionManager);
            return _configRepository;
        }

        private static DependencyRepository _dependencyRepository;
        public static DependencyRepository DependencyRepository { get { return BuildDependencyRepository(); } }
        private static DependencyRepository BuildDependencyRepository()
        {
            if (_dependencyRepository != null)
            {
                return _dependencyRepository;
            }
            if (_connectionManager == null)
            {
                BuildConnectionManager();
            }
            _dependencyRepository = new DependencyRepository(_connectionManager);
            return _dependencyRepository;
        }
    }
}
