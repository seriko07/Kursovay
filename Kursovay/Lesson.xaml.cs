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
    /// Логика взаимодействия для Lesson.xaml
    /// </summary>
    public partial class Lesson : Window
    {
        public Lesson()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test test = new Test();
            test.ID = Core.db.Test.ToList().Last().ID + 1;
            test.Title = Title.Text;
            test.Theory = Theory.Text;
            //test.TeacherID = Teachers.ID;
            
            Core.db.Test.Add(test);
        }
    }
}
