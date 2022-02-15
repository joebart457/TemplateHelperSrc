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
using Template.Frontend.Models.ViewModels;

namespace Template.Frontend.Windows.Dialogs
{
    /// <summary>
    /// Interaction logic for AddProjectDependencyDialog.xaml
    /// </summary>
    public partial class AddProjectDependencyDialog : Window
    {
        public DependencyViewModel Result { get; private set; }
        
        public AddProjectDependencyDialog(int projectId)
        {
            InitializeComponent();
            ((AddDependencyDialogDataContext)DataContext).Init(projectId);
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            this.Result = ((AddDependencyDialogDataContext)this.DataContext).Dependency;
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
