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
        public int ID_test;

        public Questions Qs { get; set; }

        public Test Test_theory { get; }
        public Users users1 { get; set; }

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

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = (desktop + "\\Lectures\\" + Test_theory.Title.ToString() + ".rtf");

            {
                System.Windows.Documents.TextRange range;
                System.IO.FileStream fStream;
                var dataFormat = DataFormats.Rtf;

                try
                {
                    // Open the document in the RichTextBox.
                    range = new System.Windows.Documents.TextRange(Theory_text.Document.ContentStart, Theory_text.Document.ContentEnd);
                    fStream = new System.IO.FileStream(path, System.IO.FileMode.Open);
                    range.Load(fStream, dataFormat);
                    fStream.Close();
                }
                catch (System.Exception)
                {
                    MessageBox.Show("File could not be opened. Make sure the file is a text file.");
                }


            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Test_theory.Task == null || Test_theory.Task =="")
            {
                task_but.Visibility = Visibility.Hidden;
            }


            try
            {
                Qs = Core.db.Questions.First(c => c.ID_test == Test_theory.ID);
                test_but.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {
                test_but.Visibility = Visibility.Hidden;

            }

            var grid_element = Test_theory;

            try
            {
                var d = Core.db.Results.Where(u => u.IDTest == grid_element.ID && u.IDstudents == users1.ID && u.Test_done == true).ToList();
                if (d.Count != 0)
                {
                    test_but.Visibility = Visibility.Hidden;
                }
                var sd = Core.db.Results.Where(u => u.IDTest == grid_element.ID && u.IDstudents == users1.ID && u.Task_done == true).ToList();
                if (sd.Count != 0)
                {
                    task_but.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception)
            {
            }

        }

        
        private void Test_click(object sender, RoutedEventArgs e)
        {
            new Test_student_choice(Test_theory, users1).Show();
            this.Close();
        }

        private void Task_click(object sender, RoutedEventArgs e)
        {
            new Task(users1,Test_theory,null).Show();
            task_but.Visibility = Visibility.Hidden;

        }
    }
}
