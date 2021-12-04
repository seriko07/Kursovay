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
    /// Логика взаимодействия для Lesson.xaml
    /// </summary>
    public partial class Lesson : Window
    {
        public Lesson(Teachers Teacher)
        {
            InitializeComponent();
            T = Teacher;
        }
        public Teachers T { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test test = new Test();
            test.ID = Core.db.Test.ToList().Last().ID + 1;
            test.Title = Title.Text;
            test.Theory = Theory.Text;
            test.TeacherID = T.ID;
            Core.db.Test.Add(test);
            Core.db.SaveChanges();
            Lesson l2 = new Lesson(T);
            l2.Show();
            this.Close();
        }

        private void Button_Click_Test(object sender, RoutedEventArgs e)
        {
            test_creation test_Creation = new test_creation();
            test_Creation.Show();


        }
    }
}
