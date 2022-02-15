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
using System.Windows.Shapes;
using Template.Frontend.DataContexts;
using Template.Frontend.Models.ListItems;

namespace Template.Frontend.Windows.Dialogs
{
    /// <summary>
    /// Interaction logic for TemplateAssignmentDialog.xaml
    /// </summary>
    public partial class TemplateAssignmentDialog : Window
    {
        public List<ParameterTemplateListItem> Result { get; private set; }
        public TemplateAssignmentDialog(int projectId)
        {
            InitializeComponent();
            ((TemplateAssignmentDialogDataContext)DataContext).ProjectId = projectId;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            this.Result = ((TemplateAssignmentDialogDataContext)DataContext).AssignedTemplates; 
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
