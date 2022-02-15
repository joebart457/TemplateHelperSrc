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
using Template.Frontend.Models.Constants.Enums;
using Template.Frontend.Models.ViewModels;

namespace Template.Frontend.Windows.Dialogs
{
    /// <summary>
    /// Interaction logic for AddParameterDialog.xaml
    /// </summary>
    public partial class AddParameterDialog : Window
    {
        public ParameterViewModel Result { get; private set; }
        public AddParameterDialog(ParameterViewModel parameter)
        {
            InitializeComponent();
            ((CreateParameterDialogDataContext)this.DataContext).Parameter = parameter;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            this.Result = ((CreateParameterDialogDataContext)this.DataContext).Parameter;
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
