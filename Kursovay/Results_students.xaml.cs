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
        public Teachers teacher { get; set; }
        public Results_students(Teachers teachers)
        {
            teacher = teachers;
            InitializeComponent(); 
            Results_list = Core.db.Results.ToList();
            results_grid.ItemsSource = Results_list;
        }
        public List <Results> Results_list { get; set; }
        private void Check_task(object sender, RoutedEventArgs e)
        {
         
            //string code/* = File.ReadAllText(@"C:\dsds\ddddШахбабянСерёжаРафикович.txt")*/;
            Task task = new Task(null,null,(Results)(results_grid.SelectedItem));
            task.Show();
            ////Process.Start(@"C:\dsds\ddddШахбабянСерёжаРафикович.txt");
            //Console.WriteLine(code);

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Core.db.SaveChanges();
        }

        private void Open_lt(object sender, RoutedEventArgs e)
        {
            Lessons_teacher lessons_Teacher = new Lessons_teacher(teacher);
            lessons_Teacher.Show();
            this.Close();
        }
    }
}
