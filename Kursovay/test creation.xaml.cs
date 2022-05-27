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
    /// Логика взаимодействия для test_creation.xaml
    /// </summary>
    public partial class test_creation : Window
    {
        public Test Test { get; set; }
        public Grade Grade1 { get; set; }
        public int mark5;
        public int mark4;
        public int mark3;
        public void Addquest(Test test)
        {

            
        }
        public test_creation(Test test)
        {
            this.Test = test;
            var number_of_questions = Core.db.Questions.Where(u => u.ID_test == Test.ID).ToList().Count();
            //counter.Text = number_of_questions.ToString();
            InitializeComponent();

           

           

        }
        private void Save_test_Click(object sender, RoutedEventArgs e)
        {
            Grade grade = new Grade();
            try
        {
             mark5 = Convert.ToInt32(mark_5.Text);
             mark4 = Convert.ToInt32(mark_4.Text);
             mark3 = Convert.ToInt32(mark_3.Text);
        }
        catch (Exception)
        {
        }

        try
            {
                grade.ID = Core.db.Grade.ToList().Last().ID + 1;
            }
            catch (Exception)
            {
                grade.ID = 1;
            }
            grade.assessment_5 = mark5;
            grade.assessment_4 = mark4;
            grade.assessment_3 = mark3;
            grade.ID_Test = Test.ID;
            Core.db.Grade.Add(grade);
            Core.db.SaveChanges();

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var number_of_questions = Core.db.Questions.Where(u => u.ID_test == Test.ID).ToList().Count();
            counter.Text = number_of_questions.ToString();
        }
    }
}
