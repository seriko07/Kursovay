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
        public test_creation()
        {
            InitializeComponent();
        }

     

        private void Save_test_Click(object sender, RoutedEventArgs e)
        {
            Core.db.SaveChanges();
            this.Close();
        }

        private void Button_add_ques(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                Questions question1 = new Questions();
                question1.Question = ques.Text;
                question1.First_answer = answer_1.Text;
                question1.Second_answer = answer_2.Text;
                question1.Third_answer = answer_3.Text;
                question1.ID = Core.db.Questions.ToList().Last().ID + 1;
                question1.ID_test = Core.db.Test.ToList().Last().ID;
                Core.db.Questions.Add(question1);
                Core.db.SaveChanges();

            }
        }





    }
}
