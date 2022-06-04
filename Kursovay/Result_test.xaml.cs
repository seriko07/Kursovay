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
using System.Text.RegularExpressions;

namespace Kursovay
{
    /// <summary>
    /// Логика взаимодействия для Result_test.xaml
    /// </summary>
    public partial class Result_test : Window
    {
        public Users student { get; set; }
        public Test Test { get; set; }
        public Results Resultssss { get; set; }
        public Grade grade { get; set; }

        public Result_test(int ans, double amount_cor_ans, Users users, Test test)
        {


            InitializeComponent();

            DataContext = this;

            var anss = ans;
            var amount_cor_anss = amount_cor_ans;
            Test = test;
            student = users;
            var res = Regex.Split(student.FCS, "(?=\\p{Lu})");
            try
            {
                FCS.Text = res[1] + " " + res[2] + " " + res[3];

            }
            catch (Exception)
            {
                FCS.Text = student.FCS;
            }
            int bal = 0;
            double b = (double)amount_cor_anss / anss;
            double a = 0;
            a = (double)b * 100;
            a = Math.Round(a, 2);

            try
            {
                grade = (Grade)Core.db.Grade.First(u => u.ID_Test == Test.ID);

            }
            catch (Exception)
            {

                grade = (Grade)Core.db.Grade.FirstOrDefault(u => u.ID == 1);
            }
           
             
            int grade_5 = (int)grade.assessment_5;
            int grade_4 = (int)grade.assessment_4;
            int grade_3 = (int)grade.assessment_3;


            if(a >= grade_5 )
            {
                bal = 5;
                Ball.Text = "5";
            }
            else
            if (a >= grade_4)
            {
                bal = 4;
                Ball.Text = "4";

            }
            else
                
                if (a >= grade_3)
            {
                bal = 3;
                Ball.Text = "3";
            }
            else
                if (a < grade_3)
            {
                bal = 2;
                Ball.Text = "2";
            }






            string bb = Convert.ToString(a);
            Result.Text = bb + "%";

            try
            {
                Resultssss = (Results)Core.db.Results.FirstOrDefault(u => u.IDTest == Test.ID && u.IDstudents == student.ID);
                Resultssss.Test_done = true;
                Resultssss.Result = bal;
                Resultssss.Test_done = true;
                Core.db.SaveChanges();

            }
            catch (Exception)
            {
                Results results = new Results();
                try
                {
                    results.ID = Core.db.Results.ToList().Last().ID + 1;
                }
                catch (Exception)
                {
                    results.ID = 1;
                }
                results.IDstudents = student.ID;
                results.IDTest = Test.ID;
                results.Result = bal;
                results.Test_done = true;
                Core.db.Results.Add(results);
                Core.db.SaveChanges();
            }



           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test_student test_Student = new test_student();
            test_Student.Show();

        }

        private void FCS_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


            //    Users users = new Users();
            //    users.ID = Core.db.Users.ToList().Last().ID + 1;
            //    users.Name = Name.Text;
            //    users.Surname = Surname.Text;
            //    users.Patronomyc = Patronymic.Text;
            //    users.Login = Login.Text;
            //    users.Password = Password.Password;
            //    users.Role1 = (Role)Role.SelectedItem;
            //    users.gender = (gender)GenderID.SelectedItem;
            //    Core.db.Users.Add(users);
            //}
            //Core.db.SaveChanges();
