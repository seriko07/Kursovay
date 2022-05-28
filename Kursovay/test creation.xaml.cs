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
                char ch = '%';
                int a = mark_3.Text.IndexOf(ch);
                mark_3.Text = mark_3.Text.Remove(a);
                 a = mark_4.Text.IndexOf(ch);
                mark_4.Text = mark_4.Text.Remove(a);
                 a = mark_5.Text.IndexOf(ch);
                mark_5.Text = mark_5.Text.Remove(a);             
                mark3 = Convert.ToInt32(mark_3.Text);
                mark4 = Convert.ToInt32(mark_4.Text);
                mark5 = Convert.ToInt32(mark_5.Text);

            }
            catch (Exception)
            {
                error_label.Visibility = Visibility.Visible;
                return;
            }
            if (mark3 > 100 || mark4 > 100 || mark5 >100)
            {
                error_label.Visibility= Visibility.Visible;
                return;
            }


            try
            {
                grade.ID = Core.db.Grade.ToList().Last().ID + 1;
                grade.assessment_5 = mark5;
                grade.assessment_4 = mark4;
                grade.assessment_3 = mark3;
                grade.ID_Test = Test.ID;
                Core.db.Grade.Add(grade);
                Core.db.SaveChanges();

                this.Close();
            }
            catch (Exception)
            {
                grade.ID = 1;
                grade.assessment_5 = mark5;
                grade.assessment_4 = mark4;
                grade.assessment_3 = mark3;
                grade.ID_Test = Test.ID;
                Core.db.Grade.Add(grade);
                Core.db.SaveChanges();
                this.Close();
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double number_of_questions = Core.db.Questions.Where(u => u.ID_test == Test.ID).ToList().Count();
            double d = 1 / number_of_questions * 100;
            One_correct_answer.Text = d.ToString()+"%";
            counter.Text = number_of_questions.ToString();

        }

        private void mark_3_KeyDown(object sender, KeyEventArgs e)
        {

            var b = mark_3.Text.ToString();

            char ch = '%';
            int indexOfChar = b.IndexOf(ch);
            if (indexOfChar==-1)
            {
                var v = b + ch;
                mark_3.Text = v;
            }
            var d = mark_3.Text.ToString();
        }

     

    }
}
