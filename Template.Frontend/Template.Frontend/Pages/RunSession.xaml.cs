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
using Template.Frontend.Models;
using Template.Frontend.Models.ListItems;
using Template.Frontend.Repository;
using Template.Frontend.Services;

namespace Template.Frontend.Pages
{
    /// <summary>
    /// Interaction logic for RunSession.xaml
    /// </summary>
    public partial class RunSession : Page
    {
        private ParameterRepository _parameterRepository;
        private ParameterTemplateRepository _parameterTemplateRepository;
        private ProjectRepository _projectRepository;

        private ProjectListItem _project = null;
        private IList<FilledParameterListItem> _parametersItemSource = null;
        public RunSession()
        {
            InitializeComponent();
            _parameterRepository = new ParameterRepository(ContextService.ConnectionManager);
            _parameterTemplateRepository = new ParameterTemplateRepository(ContextService.ConnectionManager);
            _projectRepository = new ProjectRepository(ContextService.ConnectionManager);

            Setup();
            PopulateData();

        }

        #region Setup

        private void Setup()
        {
            SetupParametersEditDataGrid();
        }
        private void SetupParametersEditDataGrid()
        {

            // Add Delete Button 
            var deleteButtonTemplate = new FrameworkElementFactory(typeof(Button));
            deleteButtonTemplate.SetValue(Button.ContentProperty, "Delete");

            deleteButtonTemplate.SetBinding(ComboBox.IsEnabledProperty, new Binding("Enable"));

            deleteButtonTemplate.AddHandler(
                Button.ClickEvent,
                new RoutedEventHandler((o, e) => {
                    var item = ListItemService.Convert<FilledParameterListItem>(DataGrid_FilledParametersEdit.SelectedItem);
                    _parametersItemSource.Remove(item);
                    RefreshFilledParametersEditDataGrid();
                })
            );
            DataGrid_FilledParametersEdit.Columns.Add(
                new DataGridTemplateColumn()
                {
                    Header = "",
                    CellTemplate = new DataTemplate() { VisualTree = deleteButtonTemplate },
                }
            );

        }

        #endregion

        #region PopulateData

        private void PopulateData()
        {
            PopulateProjectsSelectComboBox();
            PopulateFilledParametersEditDataGrid();
        }
        private void PopulateFilledParametersEditDataGrid()
        {
            _parametersItemSource =  _project == null ?
                new List<FilledParameterListItem>()
                : _parameterRepository.GetAllParametersForProject(_project.Id).Select(x => x.ToListItem()).ToList();
;
            DataGrid_FilledParametersEdit.ItemsSource = _parametersItemSource;

        }

        private void RefreshFilledParametersEditDataGrid()
        {
            DataGrid_FilledParametersEdit.ItemsSource = null;
            DataGrid_FilledParametersEdit.ItemsSource = _parametersItemSource;
        }

        private void PopulateProjectsSelectComboBox()
        {
            ComboBox_ProjectsSelect.ItemsSource = _projectRepository.GetAllProjects().Select(x => x.ToListitem()).ToList();
            ComboBox_ProjectsSelect.Text = "<Select Project>";
        }

        #endregion

        #region EventLogic
        private void ComboBox_ProjectsSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_ProjectsSelect.SelectedItem == null)
            {
                _project = null;
                GroupBox_RunSessionEdit.IsEnabled = false;
            } else
            {
                _project = ListItemService.Convert<ProjectListItem>(ComboBox_ProjectsSelect.SelectedItem);
                GroupBox_RunSessionEdit.IsEnabled = true;
            }
            PopulateFilledParametersEditDataGrid();
        }

        private void Button_AddFilledParameter_Click(object sender, RoutedEventArgs e)
        {
            if (_project != null && _parametersItemSource != null)
            {
                var parameter = new FilledParameterListItem
                {
                    TemplateName = "?",
                    Description = "An example symbol",
                    Symbol = "!Example!",
                    Value = "",
                    Changed = false
                };
                _parametersItemSource.Add(parameter);
                RefreshFilledParametersEditDataGrid();
            }
        }

        private async void Button_RunSession_Click(object sender, RoutedEventArgs e)
        {
            if (_project != null)
            {
                Button_RunSession.IsEnabled = false;
                List<SymbolMacro> macros = DataGrid_FilledParametersEdit.ItemsSource.Cast<FilledParameterListItem>().Select(x => x.ToSymbolMacro()).ToList();
                Tasks.TemplateCreationTask task = new Tasks.TemplateCreationTask(
                    _project.InputDirectory,
                    TextBox_OutputDirectory.Text,
                    _project.SandboxDirectory,
                    CheckBox_RunForSandbox.IsChecked.GetValueOrDefault(),
                    CheckBox_AllowOverwrite.IsChecked.GetValueOrDefault(),
                    macros
                    );

                string err;
                if (!task.Validate(out err))
                {
                    MessageBox.Show(err, "Error validating task");
                    return;
                }

                int total = task.Estimate();


                IProgress<int> taskProgress = new Progress<int>(value => {
                    Label_TaskProgress.Content = $"{value}/{total} files processed";
                });

                await Task.Run(() => {
                    try
                    {
                        task.Execute(taskProgress);
                    } catch(Exception e)
                    {
                        MessageBox.Show(e.Message, "Error running task");
                    }               
                });
                Button_RunSession.IsEnabled = true;
            }
        }

        private void Button_BrowseOutputDirectory_Click(object sender, RoutedEventArgs e)
        {
            var folder = DialogService.FolderBrowser();
            if (folder != string.Empty)
            {
                TextBox_OutputDirectory.Text = folder;
            }
        }

        private void CheckBox_RunForSandbox_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBox_RunForSandbox.IsChecked.GetValueOrDefault())
            {
                TextBox_OutputDirectory.IsEnabled = false;
                Button_BrowseOutputDirectory.IsEnabled = false;
            } else
            {
                TextBox_OutputDirectory.IsEnabled = true;
                Button_BrowseOutputDirectory.IsEnabled = true;
            }
        }

        #endregion

    }
}
