using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var text = File.ReadAllText(desktop + "\\Practics\\" + "C# вводный урок FCS" + ".txt");
            TxtSource.Text = text.ToString(); ;

            //using (var sr = new StreamReader(desktop + "\\Practics\\" + "C# вводный урок FCS" + ".txt"))
            //{
            //    var str = sr.ReadToEnd();
            //    TxtSource.Text = str;
            //}
        }
    }
}
