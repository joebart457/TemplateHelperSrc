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
using Template.Frontend.DataContexts.Pages;

namespace Template.Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        #region EventLogic
        private void Button_NavigateToProjects_Click(object sender, RoutedEventArgs e)
        {
            Frame_MainContent.Source = new Uri("Pages/ProjectCreateEdit.xaml", UriKind.Relative);
        }

        private void Button_NavigateToParameterTemplates_Click(object sender, RoutedEventArgs e)
        {
            Frame_MainContent.Source = new Uri("Pages/ParameterTemplateCreateEdit.xaml", UriKind.Relative);
        }

        private void Button_NavigateToRunSession_Click(object sender, RoutedEventArgs e)
        {
            Frame_MainContent.Source = new Uri("Pages/RunSession.xaml", UriKind.Relative);
        }

        private void Button_NavigateToCodeEditor_Click(object sender, RoutedEventArgs e)
        {
            Frame_MainContent.Source = new Uri("Pages/CodeEditor.xaml", UriKind.Relative);
        }


        private void Button_CloseApplication_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        #endregion

    }
}
