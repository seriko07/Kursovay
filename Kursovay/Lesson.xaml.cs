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
        public Test CurrentTest { get; set; }
        public Test newtest1 { get; set; }
        public Lesson(Teachers Teacher, Test test)
        {

            InitializeComponent();
            DataContext = this;
            currentTest = test;
            CurrentTest = test;
            var questions = Core.db.Questions.ToList();
            //foreach (var item in questions)
            //{
            //    if (item.ID_test == currentTest.ID)
            //    {
            //        View_test.Visibility = Visibility.Visible;
            //    }
            //}
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

       

        public void savetest()
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
                try
                {
                    newtest.ID = Core.db.Test.ToList().Last().ID + 1;

                }
                catch (Exception)
                {
                    newtest.ID = 1;
                }
                newtest.Title = Title.Text;
                newtest.Theory = Theory.Text;
                newtest.TeacherID = T.ID;
                newtest.Date_of_creation = DateTime.Now;
                newtest.Task = Task.Text;
                Core.db.Test.Add(newtest);
                Core.db.SaveChanges();
                Lesson l2 = new Lesson(T, newtest);
                l2.Show();
                this.Close();
                newtest1  = newtest;
            }
        }
        
        private void Save_click(object sender, RoutedEventArgs e)
        {
            savetest();
        }

        private void Button_Click_Test(object sender, RoutedEventArgs e)
        {
            savetest();
            if (currentTest != null)
            {
                test_creation test_Creation = new test_creation(CurrentTest);
                test_Creation.Show();
            }
            else
            {
                test_creation test_Creation = new test_creation(newtest1);
                test_Creation.Show();
            }
           
            var questions = Core.db.Questions.ToList();
            //foreach (var item in questions)
            //{
            //    if (item.ID_test == currentTest.ID)
            //    {
            //        View_test.Visibility = Visibility.Visible;
            //    }
            //    else { View_test.Visibility = Visibility.Collapsed; }

            //}
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List_questions questions = new List_questions(CurrentTest);
            questions.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //InitializeComponent();

            //var questions = Core.db.Questions.ToList();
            //try
            //{
            //    //questions = Core.db.Questions.Where(u => u.ID_test == CurrentTest.ID).ToList();

            //}
            //catch (Exception)
            //{

            //}
            //Console.WriteLine(questions.Count);
                            //questions2 = Core.db.Questions.Where(u => u.ID_test == test.ID).ToList();



            //foreach (var item in questions)
            //{
            //    if (item.ID_test == CurrentTest.ID)
            //    {
            //        View_test.Visibility = Visibility.Visible;
            //    }
            //    else { View_test.Visibility = Visibility.Collapsed; }
            //    InitializeComponent();

            //}
        }
    }
}
