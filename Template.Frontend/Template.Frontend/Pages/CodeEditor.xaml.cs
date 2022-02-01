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
using Template.Frontend.Services;
using Mochj.Models.Fn;

namespace Template.Frontend.Pages
{
    /// <summary>
    /// Interaction logic for CodeEditor.xaml
    /// </summary>
    public partial class CodeEditor : Page
    {
        public CodeEditor()
        {
            InitializeComponent();
            Setup();
        }
        
        
        #region Setup

        void Setup()
        {
            ScriptingService.AddGlobalFunction("print-to-screen",
                new NativeFunction()
                .Action((Args args) =>
                {
                    RichTextBox_CodeOutput.Document.Blocks.Add(new Paragraph(new Run(args.Get<string>(0))));
                    return Mochj.Builders.QualifiedObjectBuilder.BuildEmptyValue();
                })
                .RegisterParameter<string>("source")
                .ReturnsEmpty()
                .Build());

        }


        #endregion


        #region EventLogic
        private void Button_RunCode_Click(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(RichTextBox_CodeInput.Document.ContentStart, RichTextBox_CodeInput.Document.ContentEnd).Text;
            if (richText != string.Empty)
            {
                RichTextBox_CodeOutput.Document.Blocks.Clear();
                try
                {
                    ScriptingService.RunInSandbox(richText);
                } catch (Exception ex)
                {
                    RichTextBox_CodeOutput.Document.Blocks.Add(new Paragraph(new Run(ex.ToString())));
                }
            }
        }

        #endregion
    }
}
