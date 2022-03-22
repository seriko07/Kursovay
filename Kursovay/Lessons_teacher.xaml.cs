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

namespace Kursovay
{
    /// <summary>
    /// Логика взаимодействия для Lessons_teacher.xaml
    /// </summary>
    public partial class Lessons_teacher : Window

    {
        private Teachers Teacher;

        public List<Test> Tests { get; set; }

        public Lessons_teacher()
        {

            InitializeComponent();
            Tests = Core.db.Test.ToList();

            testgrid.ItemsSource = Tests;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void testgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Testgrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //    Tests path = testgrid.SelectedItem as tests;
            //    MessageBox.Show(" ID: " + path.Id + "\n Исполнитель: " + path.Vocalist + "\n Альбом: " + path.Album
            //    //    + "\n Год: " + path.Year);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Lesson tc = new Lesson(Teacher);
            tc.Show();
        }
    }
}
