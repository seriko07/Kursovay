using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для Results_students.xaml
    /// </summary>
    public partial class Results_students : Window
    {
        public Results_students()
        {
            InitializeComponent(); 
            Results_list = Core.db.Results.ToList();

            results_grid.ItemsSource = Results_list;
        }
        public List <Results> Results_list { get; set; }

        private void Check_task(object sender, RoutedEventArgs e)
        {

            //string code/* = File.ReadAllText(@"C:\dsds\ddddШахбабянСерёжаРафикович.txt")*/;
            Task task = new Task(null,null,null);
            task.Show();
            ////Process.Start(@"C:\dsds\ddddШахбабянСерёжаРафикович.txt");
            //Console.WriteLine(code);
            Console.WriteLine("SDsds");
        }
    }
}
