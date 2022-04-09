using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Kursovay
{
    /// <summary>
    /// Логика взаимодействия для Task.xaml
    /// </summary>
    public partial class Task : Window
    {
        public Task()
        {
            InitializeComponent();
        }

        private void Perform_click(object sender, RoutedEventArgs e)
        {
            CSharpCodeProvider csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
            CompilerParameters parameters = new CompilerParameters(new[] {"mscorlib.dll","System.Core.dll"}, TxtOutput.Text,true);
            parameters.GenerateExecutable = true;
            CompilerResults results= csc.CompileAssemblyFromSource(parameters,TxtSource.Text);
            if (results.Errors.HasErrors)
            {
                results.Errors.Cast<CompilerError>().ToList().ForEach(error => TxtStatus.Text += error.ErrorText + "\r\n");

            }
            else
            {
                TxtStatus.Text = "--------Build succedeed--------";
                Process.Start(TxtSource.Text);

            }
            
        }

        private void Save_click(object sender, RoutedEventArgs e)
        {
            TxtSource.Text += "using System; namespace MyApp // Note: actual namespace depends on the project name.{internal class Program {static void Main(string[] args)/*{Console.WriteLine(Hello World!";
        }
    }
}
