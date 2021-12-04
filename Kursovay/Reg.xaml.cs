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
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if ((Role)Role.SelectedItem == Core.db.Role.First(c=>c.RoleName=="Учитель"))
            {
                Teachers teachers = new Teachers();
                teachers.ID = Core.db.Teachers.ToList().Last().ID + 1;
                teachers.Name = Name.Text;
                teachers.Surname = Surname.Text;
                teachers.Patronomyc = Patronymic.Text;
                teachers.Login = Login.Text;
                teachers.Password = Password.Password;
                teachers.Role1 = (Role)Role.SelectedItem;
                teachers.gender = (gender)GenderID.SelectedItem;
                Core.db.Teachers.Add(teachers);
            }
            else
            {
                Users users = new Users();
                users.ID = Core.db.Users.ToList().Last().ID + 1;
                users.Name = Name.Text;
                users.Surname = Surname.Text;
                users.Patronomyc = Patronymic.Text;
                users.Login = Login.Text;
                users.Password = Password.Password;
                users.Role1 = (Role)Role.SelectedItem;
                users.gender = (gender)GenderID.SelectedItem;
                Core.db.Users.Add(users);
            }
            Core.db.SaveChanges();
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

        }

        private void GenderID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
