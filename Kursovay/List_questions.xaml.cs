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
    /// Логика взаимодействия для List_questions.xaml
    /// </summary>
    public partial class List_questions : Window
    {

        public List_questions(Test test1)
        {
            InitializeComponent();

            this.test = test1; 
            questions2=Core.db.Questions.Where(u=>u.ID_test==test.ID).ToList();
            //if (questions.Open_question == true)
            //{
            //    CheckBox_list.SetValue() 
            //}
            questions_grid.ItemsSource=questions2;
        }
        public Questions questions { get; set; }
        public Test test { get; private set; }

        private List<Questions> questions2;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Core.db.SaveChanges();
        }
        private void Dell_click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                var si = ((Questions)questions_grid.SelectedItem);
                Core.db.Questions.Remove(si);

            }
            catch (Exception)
            {
                
            }  
            
            Core.db.SaveChanges();
            questions2 = Core.db.Questions.Where(u => u.ID_test == test.ID).ToList();
            questions_grid.ItemsSource = questions2;


            //var Si = ((Test)testgrid.SelectedItem);
            //Core.db.Test.Remove(Si);
            //r = Core.db.Results.Where(c => c.IDTest == Si.ID).ToList();
            //w = Core.db.Questions.Where(c => c.ID_test == Si.ID).ToList();
            //Core.db.Results.RemoveRange(r);
            //Core.db.Questions.RemoveRange(w);
            //Core.db.SaveChanges();
            //Tests = Core.db.Test.ToList();
            //testgrid.ItemsSource = Tests;
        }

        private void Add_click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                questions = (Questions)questions_grid.SelectedItem;
                if (questions.ID!=0)
                {
                    Core.db.SaveChanges();
                    return;
                }
                try
                {
                    questions.ID = Core.db.Questions.ToList().Last().ID + 1;
                }
                catch (System.InvalidOperationException)
                {

                    questions.ID = 1;

                }


                questions.ID_test =test.ID;


                Core.db.Questions.Add(questions);
                Core.db.SaveChanges();

            }
            catch (Exception)
            {

                
            } 

        }

        private void questions_grid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()+1).ToString();
          
            
        }
        private void criteria_for_the_test(object sender, RoutedEventArgs e)
        {
             test_creation test_Creation = new test_creation(test);
            test_Creation.Show();
        }
    }
}
