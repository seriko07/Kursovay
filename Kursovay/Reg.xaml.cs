using Kursovay;
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {

        public Reg()
        {
            InitializeComponent();
            Role.ItemsSource = Core.db.Role.ToList();
            GenderID.ItemsSource = Core.db.gender.ToList();
            GroupID.ItemsSource = Core.db.Group.ToList();       
            string FIO_Student = Surname.Text + Name.Text + Patronymic.Text;

    }

    private void Add_Click(object sender, RoutedEventArgs e)
        {
            var users=Core.db.Users.ToList();
            var teachers=Core.db.Teachers.ToList();


            if ((Role)Role.SelectedItem == Core.db.Role.First(c=>c.RoleName=="Учитель"))
            {
                string FIO_Student = Surname.Text + Name.Text + Patronymic.Text;
                string FIO_Teachers = Surname.Text + Name.Text + Patronymic.Text;
                foreach (var p in teachers)
                {
                    if (p.FCS == FIO_Teachers || p.Login == Login.Text)
                    {
                        MessageBox.Show(" Такой пользователь уже есть в базе или логин занят  выбирите другой");
                        Reg reg = new Reg();
                        reg.Show();
                        this.Close();
                    }
                   
                }
                foreach (var s in users)
                {
                    if (s.FCS == FIO_Student || s.Login == Login.Text)
                    {

                        MessageBox.Show("Такой пользователь уже есть логин занят выбирите другой");
                        Reg reg = new Reg();
                        reg.Show();
                        this.Close();
                    }
                }

                Teachers teacherss = new Teachers();
                try
                {
                    teacherss.ID = Core.db.Teachers.ToList().Last().ID + 1;
                }
                catch (Exception)
                {
                    teacherss.ID = 1;
                }
                teacherss.FCS = FIO_Teachers;
                teacherss.Login = Login.Text;
                teacherss.Password = Password.Password;
                teacherss.Role1 = (Role)Role.SelectedItem;
                teacherss.gender = (gender)GenderID.SelectedItem;
                Core.db.Teachers.Add(teacherss);
                Core.db.SaveChanges();
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                string FIO_Student = Surname.Text + Name.Text + Patronymic.Text;
                string FIO_Teachers = Surname.Text + Name.Text + Patronymic.Text;

                foreach (var p in users)
                {
                    if (p.FCS == FIO_Student || p.Login == Login.Text)
                    {

                        MessageBox.Show("Такой пользователь уже есть или логин занят выбирите другой");
                        Reg reg = new Reg();
                        reg.Show();
                        this.Close();
                    }
                }
                    foreach (var sd in teachers)
                    {
                        if (sd.FCS == FIO_Teachers || sd.Login == Login.Text)
                        {
                            MessageBox.Show("ЛТакой пользователь уже есть или логин занят выбирите другой");
                            Reg reg = new Reg();
                            reg.Show();
                            this.Close();
                        }
                    
                    }
                Users userss = new Users();
                try
                {
                    userss.ID = Core.db.Users.ToList().Last().ID + 1;
                }
                catch (Exception)
                {
                    userss.ID = 1;
                }
                 
                userss.FCS = FIO_Student;
                userss.Login = Login.Text;
                userss.Password = Password.Password;
                userss.Role1 = (Role)Role.SelectedItem;
                userss.gender = (gender)GenderID.SelectedItem;
                userss.Group = (Group)GroupID.SelectedItem;
                Core.db.Users.Add(userss);
                Core.db.SaveChanges();
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            //Core.db.SaveChanges();
            //MainWindow main = new MainWindow();
            //main.Show();
            //this.Close();

        }

        private void GenderID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Role)Role.SelectedItem == Core.db.Role.First(c => c.RoleName == "Учитель"))
            {
                GroupID.IsEnabled = false;

            }
            if ((Role)Role.SelectedItem == Core.db.Role.First(c => c.RoleName == "Ученик"))
            {
                GroupID.IsEnabled = true;

            }

        }
    }
}
