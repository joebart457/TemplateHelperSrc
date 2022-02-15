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
using Template.Frontend.Services;

namespace Template.Frontend.Windows.Dialogs
{
    /// <summary>
    /// Interaction logic for CreateEditProjectDependenciesDialog.xaml
    /// </summary>
    public partial class CreateEditProjectDependenciesDialog : Window
    {
        public List<DependencyViewModel> Result = new List<DependencyViewModel>();
        public CreateEditProjectDependenciesDialog(int projectId)
        {
            InitializeComponent();
            ((CreateEditDependenciesDialogDataContext)DataContext).Init(projectId);
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            this.Result = ((CreateEditDependenciesDialogDataContext)this.DataContext).Dependencies;
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void ListBox_Dependencies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((CreateEditDependenciesDialogDataContext)DataContext).SelectedDependencies = ((ListBox)sender).SelectedItems.Cast<DependencyViewModel>().ToList();
        }
    }
}
