using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Template.Frontend.Models.Entities;
using Template.Frontend.Models.ListItems;
using Template.Frontend.Repository;
using Template.Frontend.Services;

namespace Template.Frontend.Pages
{
    /// <summary>
    /// Interaction logic for ProjectCreateEdit.xaml
    /// </summary>
    public partial class ProjectCreateEdit : Page
    {
        private ProjectRepository _projectRepository;
        private ParameterTemplateRepository _parameterTemplateRepository;

        private ProjectListItem _selectedProject;

        public ProjectCreateEdit()
        {
            InitializeComponent();

            _projectRepository = new ProjectRepository(ContextService.ConnectionManager);
            _parameterTemplateRepository = new ParameterTemplateRepository(ContextService.ConnectionManager);

            Setup();
            PopulateData();

        }

        #region Setup

        private void Setup()
        {

        }

        #endregion

        #region PopulateData

        private void PopulateData()
        {
            PopulateProjectsSelectListBox();
            PopulateProjectEditForm();
        }

        private void PopulateProjectsSelectListBox()
        {
            ListBox_ProjectsSelect.ItemsSource = _projectRepository.GetAllProjects().Select(x => x.ToListitem()).ToList();
        }

        private void PopulateProjectEditForm()
        {
            if (_selectedProject != null)
            {
                GroupBox_ProjectEdit.IsEnabled = true;
                TextBox_NameEdit.Text = _selectedProject.Name;
                TextBox_TemplateDirectoryEdit.Text = _selectedProject.InputDirectory;
                TextBox_SandboxDirectoryEdit.Text = _selectedProject.SandboxDirectory;
                TextBox_SqlDirectoryEdit.Text = _selectedProject.SqlDirectory;

                IEnumerable<ParameterTemplateListItem> assignedTemplates = _selectedProject.Id != -1 ?
                    _parameterTemplateRepository.GetAssignedParameterTemplates(_selectedProject.Id).Select(x => x.ToListItem())
                    : new List<ParameterTemplateListItem>();

                IEnumerable<ParameterTemplateListItem> unassignedTemplates = _selectedProject.Id != -1 ?
                    _parameterTemplateRepository.GetUnassignedParameterTemplates(_selectedProject.Id).Select(x => x.ToListItem())
                    : new List<ParameterTemplateListItem>();

                ListBox_ParameterTemplateAssignments.Items.Clear();
                ListBox_ParameterTemplates.Items.Clear();

                foreach (var template in assignedTemplates)
                {
                    ListBox_ParameterTemplateAssignments.Items.Add(template);
                }

                foreach (var template in unassignedTemplates)
                {
                    ListBox_ParameterTemplates.Items.Add(template);
                }

                Button_UnassignTemplateFromProject.IsEnabled = false;
                Button_AssignTemplateToProject.IsEnabled = false;

            } else
            {
                GroupBox_ProjectEdit.IsEnabled = false;
                TextBox_NameEdit.Text = "";
                TextBox_TemplateDirectoryEdit.Text = "";
                TextBox_SandboxDirectoryEdit.Text = "";
                TextBox_SqlDirectoryEdit.Text = "";


                ListBox_ParameterTemplateAssignments.Items.Clear();
                ListBox_ParameterTemplates.Items.Clear();
            }
            
        }


        #endregion

        #region EventLogic

        private void Button_AddProject_Click(object sender, RoutedEventArgs e)
        {
            _selectedProject = new ProjectListItem
            {
                Id = -1,
                Name = "",
                InputDirectory = "",
                SandboxDirectory = ""
            };
            PopulateProjectEditForm();
        }

        private void Button_AssignTemplateToProject_Click(object sender, RoutedEventArgs e)
        {
            var itemToAdd = ListItemService.Convert<ParameterTemplateListItem>(ListBox_ParameterTemplates.SelectedItem);
            ListBox_ParameterTemplates.Items.Remove(itemToAdd);

            ListBox_ParameterTemplateAssignments.Items.Add(itemToAdd);
        }

        private void Button_UnassignTemplateFromProject_Click(object sender, RoutedEventArgs e)
        {
            var itemToAdd = ListItemService.Convert<ParameterTemplateListItem>(ListBox_ParameterTemplateAssignments.SelectedItem);
            ListBox_ParameterTemplateAssignments.Items.Remove(itemToAdd);

            ListBox_ParameterTemplates.Items.Add(itemToAdd);
        }

        private void Button_SaveProject_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedProject != null)
            {
                _selectedProject.Name = TextBox_NameEdit.Text;
                _selectedProject.InputDirectory = TextBox_TemplateDirectoryEdit.Text;
                _selectedProject.SandboxDirectory = TextBox_SandboxDirectoryEdit.Text;
                _selectedProject.SqlDirectory = TextBox_SqlDirectoryEdit.Text;

                var templateAssignments = new List<ParameterTemplateEntity>();
                foreach (object item in ListBox_ParameterTemplateAssignments.Items)
                {
                    var itemToAdd = ListItemService.Convert<ParameterTemplateListItem>(item).ToEntity();
                    templateAssignments.Add(itemToAdd);
                }
                _projectRepository.UpsertProject(_selectedProject.ToEntity(), templateAssignments);
                PopulateData();
            }
        }

        private void ListBox_ProjectsSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox_ProjectsSelect.SelectedItem != null)
            {
                _selectedProject = ListItemService.Convert<ProjectListItem>(ListBox_ProjectsSelect.SelectedItem);
                PopulateProjectEditForm();
            }
            else
            {
                PopulateProjectEditForm();
            }
        }

        private void ListBox_ParameterTemplateAssignments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Button_UnassignTemplateFromProject.IsEnabled = ListBox_ParameterTemplateAssignments.SelectedItem != null;
        }

        private void ListBox_ParameterTemplates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Button_AssignTemplateToProject.IsEnabled = ListBox_ParameterTemplates.SelectedItem != null;

        }

        private void Button_BrowseTemplateDirectory_Click(object sender, RoutedEventArgs e)
        {
            var folder = DialogService.FolderBrowser();
            if (folder != string.Empty)
            {
                TextBox_TemplateDirectoryEdit.Text = folder;
            }
        }

        private void Button_BrowseSandboxDirectory_Click(object sender, RoutedEventArgs e)
        {
            var folder = DialogService.FolderBrowser();
            if (folder != string.Empty)
            {
                TextBox_SandboxDirectoryEdit.Text = folder;
            }
        }

        private void Button_BrowseSqlDirectory_Click(object sender, RoutedEventArgs e)
        {
            var folder = DialogService.FolderBrowser();
            if (folder != string.Empty)
            {
                TextBox_SqlDirectoryEdit.Text = folder;
            }
        }

        #endregion


    }
}
