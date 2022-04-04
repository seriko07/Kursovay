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
    /// Логика взаимодействия для Test_student_choice.xaml
    /// </summary>
    public partial class Test_student_choice : Window
    {
        public Test_student_choice(Test test,Users users)
        {
            InitializeComponent();
            DataContext = this;
            test1 = test;
            TestId = test.ID;
            users1 = users;
            //ID_test = Ts.ID;
            Qs = Core.db.Questions.First(c => c.ID_test == TestId);
            QS_ID = Qs.ID;
            ans = 0;
            random_ques();


            //Console.WriteLine(Qs.First_answer); Console.WriteLine(Qs.Second_answer); Console.WriteLine(Qs.Third_answer);

            //foreach (var p in Qss)
            //{
            //    Qs.ID = p.ID;
            //    Qs.Question = p.Question;
            //    Qs.ID_test = p.ID_test;
            //    Qs.First_answer = p.First_answer;
            //    Qs.Second_answer = p.Second_answer;
            //    Qs.Third_answer = p.Third_answer;

            //    Console.WriteLine("{0} - {1} - {2} - {3}", p.ID, p.First_answer, p.Second_answer, p.Second_answer);
            //}
        }

    

        public Test Ts { get; set; }
        public List<Questions> Ques { get; set; }

        public int amount_cor_ans;
        public int ans;
        public Questions Qs { get; set; }
        public Users users1 { get; set; }
        public Test test1 { get; set; }
        public List <Questions> Qss { get; set; }

        public int ID_test;

        public int QS_ID;

        public int TestId;



        public void random_ques()
        {
            InitializeComponent();
            DataContext = this;
            Qs = Core.db.Questions.First(c => c.ID == QS_ID);
            if (TestId == Qs.ID_test)
            {
                //Создание объекта для генерации чисел
                Random rnd = new Random();
                //Получить случайное число (в диапазоне от 0 до 3)
                int value = rnd.Next(1, 4);
                if (value==1)
                {
                    Ques_xaml.Content = Qs.Question;
                    Firranswer.Text = Qs.First_answer;
                    Sectanswer.Text = Qs.Second_answer;
                    Thiranswer.Text = Qs.Third_answer;
                    ans++;
                }
                else
                if (value==2)
                {
                    Ques_xaml.Content = Qs.Question;
                    Sectanswer.Text = Qs.First_answer;
                    Firranswer.Text = Qs.Second_answer;
                    Thiranswer.Text = Qs.Third_answer;
                    ans++;
                }
                else
                if (value==3)
                {
                    Ques_xaml.Content = Qs.Question;
                    Thiranswer.Text = Qs.First_answer;
                    //Firanswer.Content = Qs.Second_answer;
                    Firranswer.Text = Qs.Second_answer;
                    Sectanswer.Text = Qs.Third_answer;
                    ans++;
                }
            }
            else
            {
                
                new Result_test(ans, amount_cor_ans, users1,test1).Show();
                this.Close();
            }


        }


        //public void output_ques()
        //{
        //    InitializeComponent();
        //    DataContext = this;
        //    Qs = Core.db.Questions.First(c => c.ID == QS_ID);
        //    if (TestId == Qs.ID_test)
        //    {
        //        Ques_xaml.Content = Qs.Question;
        //        Ans_fir.Text = Qs.First_answer;
        //        Ans_sec.Text = Qs.Second_answer;
        //        Ans_thir.Text = Qs.Third_answer;
        //        ans++;
        //    }
        //    else
        //    {
        //        new Result_test(ans, amount_cor_ans).Show();
        //    }
        //}

        


        private void First_but_click(object sender, RoutedEventArgs e)
        {
            if (Firranswer.Text == Qs.First_answer)
            {
                amount_cor_ans++;
            }
            QS_ID++;
            random_ques();
        }

       

        private void Thir_but_Click(object sender, RoutedEventArgs e)
        {
            if (Thiranswer.Text == Qs.First_answer)
            {
                amount_cor_ans++;
            }
            QS_ID++;
            random_ques();
        }

        private void Sec_but_click(object sender, RoutedEventArgs e)
        {
            if (Sectanswer.Text == Qs.First_answer)
            {
                amount_cor_ans++;
            }
            QS_ID++;
            random_ques();
        }
    }
}
