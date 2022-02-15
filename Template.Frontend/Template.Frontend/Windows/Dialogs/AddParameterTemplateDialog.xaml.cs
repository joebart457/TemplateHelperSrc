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

namespace Template.Frontend.Windows.Dialogs
{
    /// <summary>
    /// Interaction logic for AddParameterTemplateDialog.xaml
    /// </summary>
    public partial class AddParameterTemplateDialog : Window
    {
        public string Result { get; private set; }

        public AddParameterTemplateDialog()
        {
            InitializeComponent();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            Result = ((AddParameterTemplateDialogDataContext)DataContext).TemplateName;
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
