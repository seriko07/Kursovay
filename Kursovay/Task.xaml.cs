using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace Kursovay
{
    /// <summary>
    /// Логика взаимодействия для Task.xaml
    /// </summary>
    public partial class Task : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        public Users users1 { get; set; }
        public Test test1 { get; set; }
        public Results results { get; set; }

        public Task(Users user, Test test, Results res)
        {
            results = res;
           test1=test;
            Stopwatch sw = new Stopwatch();
            string currentTime = string.Empty;
            users1 = user;
            InitializeComponent();
                dt.Tick += new EventHandler(dt_Tick);
                dt.Interval = new TimeSpan(0, 0, 0, 0, 1);

        }

        private void Perform_click(object sender, RoutedEventArgs e)
        {
            CSharpCodeProvider csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion","v4.0"} });
            CompilerParameters parameters = new CompilerParameters(new[] {"mscorlib.dll","System.Core.dll"}, "test.exe",true);
            parameters.GenerateExecutable = true;
            CompilerResults results= csc.CompileAssemblyFromSource(parameters,TxtSource.Text);



            if (results.Errors.HasErrors)
            {
                results.Errors.Cast<CompilerError>().ToList().ForEach(error => TxtStatus.Text += error.ErrorText + "\r\n");

            }
            else
            {
                TxtStatus.Text = "--------Build succedeed--------";
                String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                Process.Start($"{appStartPath}/{"test.exe"}");

            }

        }

        private async void Save_click(object sender, RoutedEventArgs e)
        {
            Results resultss = new Results();
            try
            {
                resultss.ID = Core.db.Results.ToList().Last().ID + 1;

            }
            catch (Exception)
            {

                resultss.ID = 1;
            }
            resultss.IDstudents = users1.ID;
            resultss.IDTest = test1.ID;
            Core.db.Results.Add(resultss);
            Core.db.SaveChanges(); 
            
            //string path = @"C:\dsds\"+(string)test1.Title + (string)users1.FCS +".txt";
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = (desktop + "\\Practics\\" + (string)test1.Title + " " + (string)users1.FCS + ".txt");
            //string dsdsds = users1.FCS;
            //string textConcat = (string)dsdsds.Concat("and prosper!");
            //string txt = path + (string)users1.FCS;
            File.WriteAllText(path, string.Empty);

            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {

                byte[] buffer = Encoding.Unicode.GetBytes(TxtSource.Text);
                char[] chars = Encoding.Unicode.GetChars(buffer);
                 await fstream.WriteAsync(buffer, 0, buffer.Length);
                //f.WriteLine(TxtSource.Text + "\r\n");
            }
        }
        public string currentTime = string.Empty;
        public Stopwatch sw = new Stopwatch();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (results!=null)
            {
                var Test = Core.db.Test.First(c => c.ID == results.IDTest);// сохраняем в лист информацию о том какой тест проверяет учитель
                var User = Core.db.Users.First(c => c.ID == results.IDstudents);// сохраняем в лист информацию о том чей тест проверяет учитель
                //TxtSource.Text = File.ReadAllText(@"C:\dsds\" + (string)Test.Title + (string)User.FCS+".txt");
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var text = File.ReadAllText((desktop + "\\Practics\\" + (string)Test.Title + (string)User.FCS + ".txt"), Encoding.GetEncoding(1251));
                TxtSource.Text = text;
                //TxtSource.Text = File.ReadAllText(desktop + "\\Practics\\" + (string)Test.Title + (string)User.FCS+".txt");
                save_but.Visibility = Visibility.Hidden;
                TxtTask.Text = Test.Task;

            }else TxtTask.Text = test1.Task;

            //TxtSource.Text = File.ReadAllText(@"C:\dsds\ddddШахбабянСерёжаРафикович.cs");
        }
        private void dt_Tick(object sender, EventArgs e)
        {
            if (sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                //clocktxtblock.Text = currentTime;
            }

        }
        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            sw.Start();
            dt.Start();
        }

        private void stopbtn_Click(object sender, RoutedEventArgs e)
        {
            if (sw.IsRunning)
            {
                sw.Stop();
            }
            //elapsedtimeitem.Items.Add(currentTime); нужен для таймера
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            sw.Reset();
            //clocktxtblock.Text = "00:00:00";
        }

        
    }
}
 