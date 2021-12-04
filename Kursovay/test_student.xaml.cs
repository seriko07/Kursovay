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
using static System.Net.Mime.MediaTypeNames;

namespace Kursovay
{
    /// <summary>
    /// Логика взаимодействия для test_student.xaml
    /// </summary>
    public partial class test_student : Window
    {
        public test_student(Teachers Teacher)
            : this()
        {
            // InitializeComponent();
            T = Teacher;
        }
        public Teachers T { get; set; }

        public List<Teachers> teachers { get; set; }
        //public Test tests { get; set; }

        
        public Teachers Teacher { get; set; }

      public  List<Test> Tests { get; set; }


        public test_student()
        {

            InitializeComponent();
            Tests = Core.db.Test.ToList();

            testgrid.ItemsSource = Tests;
        

            //teachers = Core.db.Teachers.ToList();
            //teach.ItemsSource = teachers();

            //teachers = new List<string>;

            //Name.ItemsSource = Core.db.Teachers.ToList();
            //GenderID.ItemsSource = Core.db.gender.ToList();
        }
        private void Testgrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
        //    Tests path = testgrid.SelectedItem as tests;
        //    MessageBox.Show(" ID: " + path.Id + "\n Исполнитель: " + path.Vocalist + "\n Альбом: " + path.Album
        //    //    + "\n Год: " + path.Year);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Test_student_choice((Test)testgrid.SelectedItem).Show();
            
        }

        private void testgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}