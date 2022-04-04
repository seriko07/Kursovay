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
        //private Test selectedItem;
        public Teachers T { get; set; }
        public Test currentTest { get; set; }
        public Lesson(Teachers Teacher, Test test)
        {

            InitializeComponent();
            DataContext = this;
            currentTest = test;

            T = Teacher;
            
            //if (currentTest != null)
            //{
            //    Theory.Text = currentTest.Theory;
            //   Title.Text = currentTest.Title;

            //    Core.db.SaveChanges();
            //}

        }
        //public Test(Test test)
        //{
        //    Test test = new Test();

        //    InitializeComponent();
        //    d = test;
        //    Title.Text = d.Title;
  
        //}        
        //public Lesson(Test selectedItem)
        //{
        //    this.selectedItem = selectedItem;
        //}

       

        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (currentTest != null)
            {
                currentTest.Theory = Theory.Text;
                currentTest.Title = Title.Text;
                currentTest.Task = Task.Text;
                Core.db.SaveChanges();
                Lesson l2 = new Lesson(T, currentTest);
                l2.Show();
                this.Close();
            }
            else
            {
                Test newtest = new Test();
                newtest.ID = Core.db.Test.ToList().Last().ID + 1;
                newtest.Title = Title.Text;
                newtest.Theory = Theory.Text;
                newtest.TeacherID = T.ID;
                newtest.Date_of_creation= DateTime.Now ;
                newtest.Task= Task.Text;
                Core.db.Test.Add(newtest);
                Core.db.SaveChanges();
                Lesson l2 = new Lesson(T, newtest);
                l2.Show();
                this.Close();

            }



        }

        private void Button_Click_Test(object sender, RoutedEventArgs e)
        {
            test_creation test_Creation = new test_creation();
            test_Creation.Show();
        }


        
    }
}
