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
        public Test_student_choice(Test test)
        {
            InitializeComponent();
            DataContext = this;
            Ts = test;

            //Ques = (List<Questions>)Ts.Questions;

            //Qs = Ques;

        }

        public Test Ts { get; set; }
        public List<Questions> Ques { get; set; }

        public Questions Qs { get; set; }
    }
}
