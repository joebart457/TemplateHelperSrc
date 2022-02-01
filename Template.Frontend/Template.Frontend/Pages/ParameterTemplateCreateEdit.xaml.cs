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
using Template.Frontend.Models.Constants.Enums;
using Template.Frontend.Models.ListItems;
using Template.Frontend.Repository;
using Template.Frontend.Services;

namespace Template.Frontend.Pages
{
    /// <summary>
    /// Interaction logic for ParameterTemplateCreateEdit.xaml
    /// </summary>
    public partial class ParameterTemplateCreateEdit : Page
    {
        private ParameterRepository _parameterRepository;
        private ParameterTemplateRepository _parameterTemplateRepository;
        public ParameterTemplateCreateEdit()
        {
            InitializeComponent();
            _parameterRepository = new ParameterRepository(ContextService.ConnectionManager);
            _parameterTemplateRepository = new ParameterTemplateRepository(ContextService.ConnectionManager);

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
            DataGrid_ParametersEdit.Columns.Clear();

            DataGrid_ParametersEdit.Columns.Add(new DataGridTextColumn { Header = "Symbol", Binding = new Binding("Symbol"), });
            DataGrid_ParametersEdit.Columns.Add(new DataGridTextColumn { Header = "Description", Binding = new Binding("Description"), });

            // Add Excel Column Mapping ComboBox
            var parameterTypeComboBoxTemplate = new FrameworkElementFactory(typeof(ComboBox));
            parameterTypeComboBoxTemplate.SetValue(ComboBox.ItemsSourceProperty, Enum.GetValues(typeof(ParameterTypeEnum)));
            parameterTypeComboBoxTemplate.SetBinding(ComboBox.SelectedItemProperty, new Binding("Type"));
            parameterTypeComboBoxTemplate.AddHandler(
                ComboBox.SelectionChangedEvent,
                new SelectionChangedEventHandler((o, e) => {
                    if (DataGrid_ParametersEdit.SelectedItem != null)
                    {
                        var item = ListItemService.Convert<ParameterListItem>(DataGrid_ParametersEdit.SelectedItem);
                        item.Type = (ParameterTypeEnum)e.AddedItems[0];
                    }
                })
            );
            DataGrid_ParametersEdit.Columns.Add(
                new DataGridTemplateColumn()
                {
                    Header = "Map to Excel Column",
                    CellTemplate = new DataTemplate() { VisualTree = parameterTypeComboBoxTemplate },
                }
            );

            // Add Save Button 
            var saveButtonTemplate = new FrameworkElementFactory(typeof(Button));
            saveButtonTemplate.SetValue(Button.ContentProperty, "Save");
            saveButtonTemplate.SetBinding(Button.VisibilityProperty, new Binding
            {
                Path = new PropertyPath("Changed"),
                Converter = new BooleanToVisibilityConverter()
            });

            saveButtonTemplate.AddHandler(
                Button.ClickEvent,
                new RoutedEventHandler((o, e) =>
                {
                    var item = ListItemService.Convert<ParameterListItem>(DataGrid_ParametersEdit.SelectedItem);

                    item.Changed = false;
                    _parameterRepository.UpdateParameter(item.ToEntity());

                })
            );

            DataGrid_ParametersEdit.Columns.Add(
                new DataGridTemplateColumn()
                {
                    Header = "",
                    CellTemplate = new DataTemplate() { VisualTree = saveButtonTemplate },
                }
            );

            // Add Delete Button 
            var deleteButtonTemplate = new FrameworkElementFactory(typeof(Button));
            deleteButtonTemplate.SetValue(Button.ContentProperty, "Delete");
            deleteButtonTemplate.AddHandler(
                Button.ClickEvent,
                new RoutedEventHandler((o, e) => {
                    var item = ListItemService.Convert<ParameterListItem>(DataGrid_ParametersEdit.SelectedItem);
                    _parameterRepository.DeleteParameter(item.ToEntity());

                    PopulateParametersEditDataGrid();
                })
            );
            DataGrid_ParametersEdit.Columns.Add(
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
            PopulateParameterTemplatesSelectComboBox();
        }
        private void PopulateParametersEditDataGrid()
        {
            var parameterTemplate = ListItemService.Convert<ParameterTemplateListItem>(ComboBox_ParameterTemplatesSelect.SelectedItem);
            DataGrid_ParametersEdit.ItemsSource = _parameterRepository.GetParametersByTemplateId(parameterTemplate.Id).Select(x => x.ToListItem()).ToList();

        }

        private void PopulateParameterTemplatesSelectComboBox()
        {
            ComboBox_ParameterTemplatesSelect.ItemsSource = _parameterTemplateRepository.GetAllParameterTemplates().Select(x => x.ToListItem()).ToList();
            ComboBox_ParameterTemplatesSelect.Text = "<Select Template>";
        }

        #endregion

        #region EventLogic
        private void ComboBox_ParameterTemplatesSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_ParameterTemplatesSelect.SelectedItem == null)
            {
                Button_AddParameterTemplate.IsEnabled = true;
                Button_AddParameter.IsEnabled = false;
            } else
            {
                Button_AddParameterTemplate.IsEnabled = false;
                Button_AddParameter.IsEnabled = true;
                PopulateParametersEditDataGrid();
            }      
        }

        private void Button_AddParameterTemplate_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox_ParameterTemplatesSelect.SelectedItem == null)
            {
                var templateToAdd = new ParameterTemplateListItem
                {
                    Name = ComboBox_ParameterTemplatesSelect.Text
                };
                _parameterTemplateRepository.InsertParameterTemplate(templateToAdd.ToEntity());
                PopulateParameterTemplatesSelectComboBox();
            }
        }


        private void Button_AddParameter_Click(object sender, RoutedEventArgs e)
        {
            var parameterTemplate = ListItemService.Convert<ParameterTemplateListItem>(ComboBox_ParameterTemplatesSelect.SelectedItem);
            var parameterToAdd = new ParameterListItem
            {
                Symbol = "!example!",
                Description = "An example symbol.",
                TemplateId = parameterTemplate.Id,
                Type = ParameterTypeEnum.Text,
                Changed = false
            };
            _parameterRepository.InsertParameter(parameterToAdd.ToEntity());
            PopulateParametersEditDataGrid();
        }


        #endregion


    }
}
