﻿using System;
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
        public List<Teachers> Teachers { get; set; }
        public Teachers Teacher { get; set; }
       


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
            
            var users = Core.db.Users.ToList();
            foreach (var p in users)
            {
                if (p.Password == pas.Password && p.Login == log.Text)
                {
                    MessageBox.Show("Пользователь авторизовался- ученик");
                    Mystudents  = Core.db.Users.Where(c => c.ID == p.ID).ToList();// сохраняем в лист информацию о том какой студент зашёл
                    test_student ts = new test_student();
                    ts.Show();
                    this.Close();

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
                    //Teachers  = Core.db.Teachers.Where(c => c.ID == p.ID).ToList();
                    //Teachers  teachers1 = new Core.db.Teachers.First(c => c.ID == p.ID);
                    Teacher = Core.db.Teachers.First(c => c.ID == p.ID);// сохраняем в лист информацию о том какой учитель зашёл
                    Lesson L1 = new Lesson(Teacher);
                    test_student test_Student = new test_student(Teacher);
                    L1.Show();

                }
            }
            //Console.WriteLine(teachers); 


            //foreach (var p in Teacher)
            //    var id = p.ID;
                //Console.WriteLine("{0} - {1} - {2} - {3}", p.ID, p.Name, p.Login, p.Password);

        }





        



        private void Button_less(object sender, RoutedEventArgs e)
        {
            Lesson lesson = new Lesson(Teacher);
            lesson.Show();
            this.Close();
        }
    }
} 

