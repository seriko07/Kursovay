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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovay
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List <Users> Mystudents { get; set; }
        public List <Teachers> Teachers { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //Openpage(pages.login); // Открываем авторизацию
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Close();
        }
        private void Button_autoriz(object sender, RoutedEventArgs e)
        {
            //log.Text
            //pas.Text
            //if (log.Text == Core.db.Users.ToList().Last().Login)
            //{
            //    MessageBox.Show(
            //           "Пользователь есть в базе");
            //}


            //if (log.Text.Length > 0) // проверяем введён ли логин     
            //{
            //    if (pas.Password.Length > 0) // проверяем введён ли пароль         
            //    {             // ищем в базе данных пользователя с такими данными         
            //         Users users = MainWindow.Select("SELECT * FROM [dbo].[users] WHERE [login] = '" + log.Text + "' AND [password] = '" + pas.Password + "'");
            //        if (dt_user.Rows.Count > 0) // если такая запись существует       
            //        {
            //            MessageBox.Show("Пользователь авторизовался"); // говорим, что авторизовался         
            //        }
            //        else MessageBox.Show("Пользователя не найден"); // выводим ошибку  
            //    }
            //    else MessageBox.Show("Введите пароль"); // выводим ошибку    
            //}
            //else MessageBox.Show("Введите логин"); // выводим ошибку 


            //Users users = Core.db.Users.Last();
            //int b = users.ID;
            var users = Core.db.Users.ToList();
            foreach (var p in users)
            {
                if (p.Password == pas.Password && p.Login == log.Text)
                {
                    MessageBox.Show("Пользователь авторизовался- ученик");
                    Mystudents  = Core.db.Users.Where(c => c.ID == p.ID).ToList();// сохраняем в лист информацию о том какой студент зашёл
                   
                    //Console.WriteLine(users);
                }
               // Console.WriteLine("{0} - {1} - {2} - {3}", p.ID, p.Name, p.Login, p.Password);
            }
            //Console.WriteLine(users);

            var teachers = Core.db.Teachers.ToList();// список всех учителей
            foreach (var p in teachers)
            {
                if (p.Password == pas.Password && p.Login == log.Text)
                {
                    MessageBox.Show("Пользователь авторизовался - учитель");
                    Teachers  = Core.db.Teachers.Where(c => c.ID == p.ID).ToList();
                    //Teachers = Core.db.Teachers.Where(c => c.ID == p.ID).ToList();// сохраняем в лист информацию о том какой учитель зашёл
                    
                }
            }
            //Console.WriteLine(teachers); 
             
            
            foreach (var p in Teachers)
                Console.WriteLine("{0} - {1} - {2} - {3}", p.ID, p.Name, p.Login, p.Password);
            
        }





        //var user = Core.db.Users.AsNoTracking().FirstOrDefault(x => x.Login == log.Text);
        //var userr = Core.db.Users.AsNoTracking().FirstOrDefault(x => x.Password == pas.Password);

        //if (user != null && userr != null)
        //{
        //    MessageBox.Show(
        //         "Пользователь есть в базе");
        //}
        //else
        //{
        //    MessageBox.Show(
        //         "Пользователя нет в базе");
        //}



        private void Button_less(object sender, RoutedEventArgs e)
        {
            Lesson lesson = new Lesson();
            lesson.Show();
            this.Close();
        }
    }
} 

