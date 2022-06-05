using System;
using System.Collections.Generic;
using System.IO;
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
        //private Test selectedItem;
        public Teachers T { get; set; }
        public Test currentTest { get; set; }
        public Test CurrentTest { get; set; }
        public Test newtest1 { get; set; }

        public Test newtest = new Test();

        public string pathcurrentfile;

        public Lesson(Teachers Teacher, Test test)
        {

            InitializeComponent();
            DataContext = this;
            currentTest = test;
            CurrentTest = test;
            var questions = Core.db.Questions.ToList();

            T = Teacher;

            if (CurrentTest != null)
            {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                pathcurrentfile = (desktop + "\\Lectures\\" + CurrentTest.Title.ToString() + ".rtf");

                {
                    System.Windows.Documents.TextRange range;
                    System.IO.FileStream fStream;
                    var dataFormat = DataFormats.Rtf;

                    try
                    {
                        // Open the document in the RichTextBox.
                        range = new System.Windows.Documents.TextRange(Theory.Document.ContentStart, Theory.Document.ContentEnd);
                        fStream = new System.IO.FileStream(pathcurrentfile, System.IO.FileMode.Open);
                        range.Load(fStream, dataFormat);
                        fStream.Close();
                    }
                    catch (System.Exception)
                    {
                    }


                }



            }
        }



        public void savetest()
        {
            //if (currentTest != null)
            //{
            //    currentTest.Theory = Theory.Text;
            //    currentTest.Title = Title.Text;
            //    currentTest.Task = Task.Text;
            //    Core.db.SaveChanges();
            //    Lesson l2 = new Lesson(T, currentTest);
            //    l2.Show();
            //    this.Close();
            //}
            //else
            //{
            //    Test newtest = new Test();
            //    try
            //    {
            //        newtest.ID = Core.db.Test.ToList().Last().ID + 1;

            //    }
            //    catch (Exception)
            //    {
            //        newtest.ID = 1;
            //    }
            //    newtest.Title = Title.Text;
            //    newtest.Theory = Theory.Text;
            //    newtest.TeacherID = T.ID;
            //    newtest.Date_of_creation = DateTime.Now;
            //    newtest.Task = Task.Text;
            //    Core.db.Test.Add(newtest);
            //    Core.db.SaveChanges();
            //    Lesson l2 = new Lesson(T, newtest);
            //    l2.Show();
            //    this.Close();
            //    newtest1  = newtest;
            //}

            if (CurrentTest != null)
            {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


                FileInfo fileInf = new FileInfo(pathcurrentfile);
                if (fileInf.Exists)
                {
                    fileInf.Delete();

                }
                CurrentTest.Task = Task.Text;
                CurrentTest.Title = Title.Text;
                Core.db.SaveChanges();
                string path = (desktop + "\\Lectures\\" + Title.Text.ToString() + ".rtf");

                {
                    System.Windows.Documents.TextRange range;
                    System.IO.FileStream fStream;
                    var dataFormat = DataFormats.Rtf;

                    try
                    {
                        // Open the document in the RichTextBox.
                        range = new System.Windows.Documents.TextRange(Theory.Document.ContentStart, Theory.Document.ContentEnd);
                        fStream = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
                        range.Save(fStream, dataFormat);
                        fStream.Close();
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("File could not be opened. Make sure the file is a text file.");
                    }
                }
            }
            else
            {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                string path = (desktop + "\\Lectures\\" + Title.Text.ToString() + ".rtf");

                {
                    System.Windows.Documents.TextRange range;
                    System.IO.FileStream fStream;
                    var dataFormat = DataFormats.Rtf;

                    try
                    {
                        // Open the document in the RichTextBox.
                        range = new System.Windows.Documents.TextRange(Theory.Document.ContentStart, Theory.Document.ContentEnd);
                        fStream = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
                        range.Save(fStream, dataFormat);
                        fStream.Close();
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("File could not be opened. Make sure the file is a text file.");
                    }
                    newtest.Task = Task.Text;
                    newtest.TeacherID = T.ID;
                    newtest.Title = Title.Text;
                    newtest.Date_of_creation = DateTime.Now;
                    try
                    {
                        newtest.ID = Core.db.Test.ToList().Last().ID + 1;

                    }
                    catch (Exception)
                    {
                        newtest.ID = 1;
                    }
                    Core.db.Test.Add(newtest);

                    try
                    {
                        Core.db.SaveChanges();
                    }
                    catch (Exception)
                    {
                    }
                    
                }



            }
            this.Close();
        }

        private void Save_click(object sender, RoutedEventArgs e)
        {
            savetest();

            //if (CurrentTest != null)
            //{
            //    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


            //    FileInfo fileInf = new FileInfo(pathcurrentfile);
            //    if (fileInf.Exists)
            //    {
            //        fileInf.Delete();

            //    }
            //    CurrentTest.Task = Task.Text;
            //    CurrentTest.Title = Title.Text;
            //    Core.db.SaveChanges();
            //    string path = (desktop + "\\Lectures\\" + Title.Text.ToString() + ".rtf");

            //    {
            //        System.Windows.Documents.TextRange range;
            //        System.IO.FileStream fStream;
            //        var dataFormat = DataFormats.Rtf;

            //        try
            //        {
            //            // Open the document in the RichTextBox.
            //            range = new System.Windows.Documents.TextRange(Theory.Document.ContentStart, Theory.Document.ContentEnd);
            //            fStream = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
            //            range.Save(fStream, dataFormat);
            //            fStream.Close();
            //        }
            //        catch (System.Exception)
            //        {
            //            MessageBox.Show("File could not be opened. Make sure the file is a text file.");
            //        }
            //    }
            //}
            //else
            //{
            //    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //    string path = (desktop + "\\Lectures\\" + Title.Text.ToString() + ".rtf");

            //    {
            //        System.Windows.Documents.TextRange range;
            //        System.IO.FileStream fStream;
            //        var dataFormat = DataFormats.Rtf;

            //        try
            //        {
            //            // Open the document in the RichTextBox.
            //            range = new System.Windows.Documents.TextRange(Theory.Document.ContentStart, Theory.Document.ContentEnd);
            //            fStream = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
            //            range.Save(fStream, dataFormat);
            //            fStream.Close();
            //        }
            //        catch (System.Exception)
            //        {
            //            MessageBox.Show("File could not be opened. Make sure the file is a text file.");
            //        }
            //        newtest.Task = Task.Text;
            //        newtest.TeacherID = T.ID;
            //        newtest.Title = Title.Text;
            //        newtest.Date_of_creation = DateTime.Now;
            //        try
            //        {
            //            newtest.ID = Core.db.Test.ToList().Last().ID + 1;

            //        }
            //        catch (Exception)
            //        {
            //            newtest.ID = 1;
            //        }
            //        Core.db.Test.Add(newtest);
            //        Core.db.SaveChanges();
            //    }

                

            //}
            //this.Close();
        }
        private void Button_Click_Test(object sender, RoutedEventArgs e)
        {
            if (currentTest != null)
            {
                test_creation test_Creation = new test_creation(CurrentTest);
                test_Creation.Show();
            }
            else
            {
                test_creation test_Creation = new test_creation(newtest1);
                test_Creation.Show();
            }

            var questions = Core.db.Questions.ToList();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            savetest();
            if (CurrentTest==null)
            {
                List_questions questions = new List_questions(newtest); 
                questions.Show();
            }
            else { List_questions questions = new List_questions(CurrentTest);
                questions.Show(); }
            
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Title.Text == "" || Title.Text == null)
            {
                Title.Text = "Введите название лекции";
                Title.Foreground = Brushes.Gray;
            }
            Title.Foreground = Brushes.Black;
        }

        private void Title_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {




        }

        
    }
}
