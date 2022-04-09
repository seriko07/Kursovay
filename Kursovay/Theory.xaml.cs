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
    /// Логика взаимодействия для Theory.xaml
    /// </summary>
    public partial class Theory : Window
    {
        public Theory()
        {
            InitializeComponent();
        }

        public Theory(Test test, Users users)
        {
            InitializeComponent();
            DataContext = this;
            Test_theory = test;
            users1 = users;

        }

     

        public Test Test_theory { get; }
        public Users users1 { get; set; }

        private void Test_click(object sender, RoutedEventArgs e)
        {
            new Test_student_choice((Test)Test_theory,users1).Show();
            this.Close();
        }

        private void Task_click(object sender, RoutedEventArgs e)
        {
            new Task().Show();

        }
    }
}
