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
        public Test tests { get; set; }
        public Questions q { get; set; }
        public List <Questions> w { get; set; }
        public Results a { get; set; }
        public List <Results> r { get; set; }

        public Lessons_teacher(Teachers Teacher)
        {
            this.Teacher = Teacher;
            InitializeComponent();
            Tests = Core.db.Test.ToList();
            testgrid.ItemsSource = Tests;

        }
       

        private void Testgrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //    Tests path = testgrid.SelectedItem as tests;
            //    MessageBox.Show(" ID: " + path.Id + "\n Исполнитель: " + path.Vocalist + "\n Альбом: " + path.Album
            //    //    + "\n Год: " + path.Year);

        }
        private void New_lesson(object sender, RoutedEventArgs e)
        {
            Lesson tc = new Lesson(Teacher,tests) ;
            tc.Show();
            Tests = Core.db.Test.ToList();
            testgrid.ItemsSource = Tests;
        }
        private void New_test(object sender, RoutedEventArgs e)
        {

        }
        private void Editing_Test(object sender, RoutedEventArgs e)
        {
            Lesson red = new Lesson(Teacher, (Test)testgrid.SelectedItem);
            red.Show();
        }

        private void Del_lesson(object sender, RoutedEventArgs e)
        {
            var Si = ((Test)testgrid.SelectedItem);
            try
            {
                Core.db.Test.Remove(Si);

            }
            catch (Exception)
            {

            }
            r = Core.db.Results.Where(c => c.IDTest == Si.ID).ToList();
            w = Core.db.Questions.Where(c => c.ID_test == Si.ID).ToList();
            Core.db.Results.RemoveRange(r);
            Core.db.Questions.RemoveRange(w);
            Core.db.SaveChanges();
            Tests = Core.db.Test.ToList();
            testgrid.ItemsSource = Tests;


        }
        private void Open_Rs(object sender, RoutedEventArgs e)
        {
            Results_students results_Students = new Results_students(Teacher);
            results_Students.Show();
            this.Close();
        }
    }
}
