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
using System.Threading;

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
            
            
            List_Qss = Core.db.Questions.Where(u => u.ID_test == test1.ID).ToList();
            number_of_questions = List_Qss.Count();
            ans = number_of_questions;
            Qs_id = 0;
            Qs = List_Qss[Qs_id];
            tworightans();

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

        public void Textqs()
        {


        }
    

        public Test Ts { get; set; }
        public List<Questions> Ques { get; set; }

        public double amount_cor_ans;
        public int ans;
        public Questions Qs { get; set; }
        public Users users1 { get; set; }
        public Test test1 { get; set; }
        public List <Questions> List_Qss { get; set; }

        public int ID_test;
        public double first_ans;
        public double sec_ans;
        public double res;

        public int QS_ID;
        public int Qs_id;
        public List <int> order_but = new List<int>();
        public List <int> order_ans = new List<int>();

        public int TestId;
        public int number_of_questions;

        public void Question_output()
        {
            
           
                

            



        }

        public void random_ques()
        {
            InitializeComponent();
            DataContext = this;
            try
            {
                Qs = Core.db.Questions.First(c => c.ID == QS_ID);
            }
            catch (Exception)
            {
                new Result_test(ans, amount_cor_ans, users1, test1).Show();
                this.Close();
            }
            if (TestId == Qs.ID_test)
            {
                //Создание объекта для генерации чисел
                Random rnd = new Random();
                //Получить случайное число (в диапазоне от 0 до 3)
                int value = rnd.Next(1, 4);
                if (value==1)
                {
                    Ques_xaml.Text = Qs.Question;
                    Firranswer.Text = Qs.First_answer;
                    Sectanswer.Text = Qs.Second_answer;
                    Thiranswer.Text = Qs.Сorrect_answer;
                    ans++;
                }
                else
                if (value==2)
                {
                    Ques_xaml.Text = Qs.Question;
                    Sectanswer.Text = Qs.First_answer;
                    Firranswer.Text = Qs.Second_answer;
                    Thiranswer.Text = Qs.Сorrect_answer;
                    ans++;
                }
                else
                if (value==3)
                {
                    Ques_xaml.Text = Qs.Question;
                    Thiranswer.Text = Qs.First_answer;
                    //Firanswer.Content = Qs.Second_answer;
                    Firranswer.Text = Qs.Second_answer;
                    Sectanswer.Text = Qs.Сorrect_answer;
                    ans++;
                }
            }
            else
            {
                
                new Result_test(ans, amount_cor_ans, users1,test1).Show();
                this.Close();
            }
        }
        public void tworightans()
        {
            try
            {
                Qs = List_Qss[Qs_id];
               
            }
            catch (Exception)
            {
                new Result_test(ans, amount_cor_ans, users1, test1).Show();
                this.Close();
            }
            Ques_xaml.Text = Qs.Question;
            if (Qs.Open_question==true)
            {
                Firs_but.Visibility = Visibility.Hidden;
                Sec_but.Visibility = Visibility.Hidden;                
                Thir_but.Visibility = Visibility.Hidden;
                Fourtanswer_but.Visibility = Visibility.Hidden;
                Text_box_ans.Visibility = Visibility.Visible;
                Text_box_but.Visibility = Visibility.Visible;
                return;

            }
            if (Qs.Second_correct_answer!=null && Qs.Second_correct_answer !=""|| Qs.Answer_two_questions==true)   
            {
                 order_but = new List<int>(Enumerable.Range(1, 4));
                 order_ans = new List<int>(Enumerable.Range(1, 4));
                Fourtanswer_but.Visibility = Visibility.Visible;
                Grid.SetColumnSpan(Sec_but, 1);
                Grid.SetColumn(Thir_but, 2);
                Firs_but.Visibility = Visibility.Visible;
                Sec_but.Visibility = Visibility.Visible;
                Thir_but.Visibility = Visibility.Visible;
                Fourtanswer_but.Visibility = Visibility.Visible;
                Firs_but.IsEnabled=true;
                Sec_but.IsEnabled = true;
                Thir_but.IsEnabled = true;
                Fourtanswer_but.IsEnabled = true;
                Text_box_ans.Visibility = Visibility.Hidden;
                Text_box_but.Visibility = Visibility.Hidden;


            }
            else {
                 order_but = new List<int>(Enumerable.Range(1, 3));
                order_ans = new List<int>(Enumerable.Range(1, 3));
                Fourtanswer_but.Visibility = Visibility.Hidden;
                Grid.SetColumnSpan(Sec_but, 2);
                Grid.SetColumn(Thir_but, 3);
                Firs_but.Visibility = Visibility.Visible;
                Sec_but.Visibility = Visibility.Visible;
                Thir_but.Visibility = Visibility.Visible;
                Firs_but.IsEnabled = true;
                Sec_but.IsEnabled = true;
                Thir_but.IsEnabled = true;
                Fourtanswer_but.Visibility = Visibility.Hidden;
                Text_box_ans.Visibility = Visibility.Hidden;
                Text_box_but.Visibility = Visibility.Hidden;
            }
            
            order_ans.Shuffle();
            order_but.Shuffle();
        end_switch:

            foreach (int i in order_but.ToArray())
            {
                switch (i)
                {
                    case 1:
                        foreach (int b in order_ans.ToArray())
                        {
                             first:
                            switch (b)
                            {
                                
                                    case 1:
                                    
                                    Firranswer.Text = Qs.Сorrect_answer;
                                    order_ans.Remove(b);
                                    order_but.Remove(i);
                                    goto end_switch; 
                                    break;

                                    case 2:
                                    if (Qs.Second_correct_answer != null && Qs.Second_correct_answer != "")
                                    {
                                        Firranswer.Text = Qs.Second_correct_answer;
                                        order_but.Remove(i);
                                        order_ans.Remove(b);
                                        goto end_switch;
                                    }
                                    else
                                    {
                                        var a = order_ans.IndexOf(b);
                                        order_ans[a] = 4;
                                        goto end_switch;
                                    }
                                    break;
                                     case 3:
                                    Firranswer.Text = Qs.First_answer;
                                    order_ans.Remove(b);
                                    order_but.Remove(i);
                                    goto end_switch; 
                                    break;
                                     case 4:
                                    Firranswer.Text = Qs.Second_answer;
                                    order_ans.Remove(b);
                                    order_but.Remove(i);
                                    goto end_switch; 
                                    break;

                            }  
                        }
                        break;
                    case 2:
                        foreach (int b in order_ans.ToArray())
                        {
                            switch (b)
                            {
                                case 1:
                                    Sectanswer.Text = Qs.Сorrect_answer;
                                    order_ans.Remove(b);
                                    order_but.Remove(i);
                                    goto end_switch; break;
                                case 2:
                                    if (Qs.Second_correct_answer != null && Qs.Second_correct_answer != "")
                                    {
                                        Sectanswer.Text = Qs.Second_correct_answer;
                                        order_but.Remove(i);

                                        order_ans.Remove(b);
                                        goto end_switch;
                                    }
                                    else {
                                        var a = order_ans.IndexOf(b);
                                        order_ans[a] = 4;
                                        goto end_switch;
                                    }
                                    break;
                                case 3:
                                    Sectanswer.Text = Qs.First_answer;
                                    order_ans.Remove(b);
                                    order_but.Remove(i);
                                    goto end_switch; break;
                                case 4:
                                    Sectanswer.Text = Qs.Second_answer;
                                    order_ans.Remove(b);
                                    order_but.Remove(i);
                                    goto end_switch;
                                    break;
                            }
                        }
                        break; 
                    case 3:
                        
                        foreach (int b in order_ans.ToArray())
                        {
                            switch (b)
                            {
                                case 1:
                                    Thiranswer.Text = Qs.Сorrect_answer;
                                    order_ans.Remove(b);
                                    order_but.Remove(i);
                                    goto end_switch;

                                    break;
                                case 2:
                                    if (Qs.Second_correct_answer != null && Qs.Second_correct_answer != "")
                                    {
                                        Thiranswer.Text = Qs.Second_correct_answer;
                                        order_ans.Remove(b);
                                        order_but.Remove(i);

                                        goto end_switch;
                                    }
                                    else {
                                        var a = order_ans.IndexOf(b);
                                        order_ans[a] = 4;
                                        goto end_switch;
                                    }

                                    break;
                                case 3:
                                    Thiranswer.Text = Qs.First_answer;
                                    order_ans.Remove(b);
                                    order_but.Remove(i);
                                    goto end_switch;

                                    break;
                                case 4:
                                    Thiranswer.Text = Qs.Second_answer;
                                    order_ans.Remove(b);
                                    order_but.Remove(i);
                                    goto end_switch;
                                    break;
                            }

                        }
                        break;
                    case 4:
                        foreach (int b in order_ans.ToArray())

                            switch (b)
                            {
                                case 1:
                                    if (Qs.Second_correct_answer != null && Qs.Second_correct_answer != "")
                                    {
                                        Fourthanswer.Text = Qs.Сorrect_answer;
                                        order_but.Remove(i);
                                        order_ans.Remove(b);
                                        goto end_switch;
                                    }
                                    else { Fourthanswer.Visibility = Visibility.Hidden;
                                        order_ans.Remove(b);
                                    }
                                    break;
                                case 2:
                                    if (Qs.Second_correct_answer != null && Qs.Second_correct_answer != "")
                                    {
                                        Fourthanswer.Text = Qs.Second_correct_answer;
                                        order_but.Remove(i);
                                        order_ans.Remove(b);
                                        goto end_switch;
                                    }
                                    else { Fourthanswer.Visibility = Visibility.Hidden;
                                        order_ans.Remove(b);
                                    }

                                    break;
                                case 3:
                                    if (Qs.Second_correct_answer != null && Qs.Second_correct_answer != "")
                                    {
                                        Fourthanswer.Text = Qs.First_answer;
                                        order_ans.Remove(b);
                                        order_but.Remove(i);
                                        goto end_switch;
                                    }
                                    else { Fourthanswer.Visibility = Visibility.Hidden;
                                        order_ans.Remove(b);
                                    }
                                    break;
                                case 4:
                                    if (Qs.Second_correct_answer != null && Qs.Second_correct_answer != "")
                                    {
                                        Fourthanswer.Text = Qs.Second_answer;
                                        order_ans.Remove(b);
                                        order_but.Remove(i);

                                        goto end_switch;
                                    }
                                    else { Fourthanswer.Visibility = Visibility.Hidden;
                                        order_ans.Remove(b);
                                    }
                                    break;
                            }
                        
                      
                        break;

                }


            }
       

            //Console.WriteLine("The winning numbers are: {0}", string.Join(",  ", numbers.GetRange(0, 5)));







        }





 

       private void Checking_for_two_answers(double d)
        {
           res = res + d;
            if (res == 1)
            {
                Qs_id++;
                tworightans();

            }

        }








        private void First_but_click(object sender, RoutedEventArgs e)
        { 
            if (Qs.Answer_two_questions == true)
            {
                if (Firranswer.Text == Qs.Сorrect_answer || Firranswer.Text == Qs.Second_correct_answer) { Firs_but.IsEnabled = false; amount_cor_ans = +0.5; Checking_for_two_answers(0.5);  }
                else { Firs_but.IsEnabled = false; Checking_for_two_answers(0.5); }
            }
            else if (Firranswer.Text == Qs.Сorrect_answer || Firranswer.Text == Qs.Second_correct_answer) { amount_cor_ans ++; Qs_id++; tworightans(); } else { Qs_id++; tworightans(); } 




            //random_ques();
        }

       

        private void Thir_but_Click(object sender, RoutedEventArgs e)
        {
            if (Qs.Answer_two_questions == true)
            {
                if (Thiranswer.Text == Qs.Сorrect_answer || Thiranswer.Text == Qs.Second_correct_answer) { Thir_but.IsEnabled = false; amount_cor_ans = +0.5; Checking_for_two_answers(0.5);  }
                else { Thir_but.IsEnabled = false; Checking_for_two_answers(0.5);  }
            }
            else if (Thiranswer.Text == Qs.Сorrect_answer || Thiranswer.Text == Qs.Second_correct_answer) { amount_cor_ans++; Qs_id++; tworightans(); } else { Qs_id++; tworightans(); }

        }

        private void Sec_but_click(object sender, RoutedEventArgs e)
        {
            if (Qs.Answer_two_questions == true)
            {
                if (Sectanswer.Text == Qs.Сorrect_answer || Sectanswer.Text == Qs.Second_correct_answer) { Sec_but.IsEnabled = false; amount_cor_ans = +0.5; Checking_for_two_answers(0.5); }
                else { Firs_but.IsEnabled = false; Checking_for_two_answers(0.5); }
            }
            else if (Sectanswer.Text == Qs.Сorrect_answer || Sectanswer.Text == Qs.Second_correct_answer) { amount_cor_ans++; Qs_id++; tworightans(); } else { Qs_id++; tworightans(); }


        }



        private void Fourth_but_Click(object sender, RoutedEventArgs e)
        {
            if (Qs.Answer_two_questions == true)
            {
                if (Fourthanswer.Text == Qs.Сorrect_answer || Fourthanswer.Text == Qs.Second_correct_answer) { Fourtanswer_but.IsEnabled = false; amount_cor_ans = +0.5; Checking_for_two_answers(0.5); }
                else { Fourtanswer_but.IsEnabled = false; Checking_for_two_answers(0.5); }
            }
            else if (Fourthanswer.Text == Qs.Сorrect_answer || Fourthanswer.Text == Qs.Second_correct_answer) { amount_cor_ans++; Qs_id++; tworightans(); } else { Qs_id++; tworightans(); }

        }

        private void Text_box_but_Click(object sender, RoutedEventArgs e)
        {
            if (Text_box_ans.Text== Qs.Сorrect_answer|| Text_box_ans.Text == Qs.Second_correct_answer)
            {
                amount_cor_ans++;
            }
            Qs_id++;

            tworightans();
        }
    }

    public class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }
    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
