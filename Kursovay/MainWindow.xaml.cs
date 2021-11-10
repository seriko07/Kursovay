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
            
            var user = Core.db.Users.AsNoTracking().FirstOrDefault(x => x.Login == log.Text);
            var userr = Core.db.Users.AsNoTracking().FirstOrDefault(x => x.Password == pas.Password);

            if (user != null && userr != null)
            {
                MessageBox.Show(
                     "Пользователь есть в базе");
            }
            else
            {
                MessageBox.Show(
                     "Пользователя нет в базе");
            }
        }
    }
}
