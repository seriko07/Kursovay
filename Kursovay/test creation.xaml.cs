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
        int counter_ = 0;
        public Test Test { get; set; }
        public void addquest(Test test)
        {

            counter_++;
            Questions question1 = new Questions();
            question1.Question = ques.Text;
            question1.First_answer = answer_1.Text;
            question1.Second_answer = answer_2.Text;
            question1.Сorrect_answer = answer_3.Text;
            try
            {
                question1.ID = Core.db.Questions.ToList().Last().ID + 1;
            }
            catch (Exception)
            {
                question1.ID = 1;
            }

            try
            {
                question1.ID_test = test.ID;
            }
            catch (Exception)
            {
                question1.ID_test = 1;
            }
            Core.db.Questions.Add(question1);
            Core.db.SaveChanges();
            counter.Text = counter_.ToString();
            answer_1.Clear();
            answer_2.Clear();
            answer_3.Clear();
            ques.Clear();
        }
        public test_creation(Test test)
        {
            this.Test = test;   
            InitializeComponent();
        }
        private void Save_test_Click(object sender, RoutedEventArgs e)
        {   
            addquest(Test);
            Core.db.SaveChanges();
            this.Close();
        }
        private void Button_add_ques(object sender, RoutedEventArgs e)
        {
            addquest(Test);
        }
    }
}
