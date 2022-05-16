﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using GemBox.Document;
using Microsoft.Win32;

namespace Kursovay
{
    /// <summary>
    /// Логика взаимодействия для Testwindow.xaml
    /// </summary>
    public partial class Testwindow : Window
    {

        public Users users1 { get; set; }
        public Test test1 { get; set; }
        public Testwindow(Users users, Test test)
        {
            InitializeComponent();
             users1 = users;
             test1 = test; 
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }



        private void Open(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                AddExtension = true,
                Filter =
                    "All Documents (*.docx;*.docm;*.doc;*.dotx;*.dotm;*.dot;*.htm;*.html;*.rtf;*.txt)|*.docx;*.docm;*.dotx;*.dotm;*.doc;*.dot;*.htm;*.html;*.rtf;*.txt|" +
                    "Word Documents (*.docx)|*.docx|" +
                    "Word Macro-Enabled Documents (*.docm)|*.docm|" +
                    "Word 97-2003 Documents (*.doc)|*.doc|" +
                    "Word Templates (*.dotx)|*.dotx|" +
                    "Word Macro-Enabled Templates (*.dotm)|*.dotm|" +
                    "Word 97-2003 Templates (*.dot)|*.dot|" +
                    "Web Pages (*.htm;*.html)|*.htm;*.html|" +
                    "Rich Text Format (*.rtf)|*.rtf|" +
                    "Text Files (*.txt)|*.txt"
            };

            if (dialog.ShowDialog() == true)
                using (var stream = new MemoryStream())
                {
                    // Convert input file to RTF stream.
                    DocumentModel.Load(dialog.FileName).Save(stream, SaveOptions.RtfDefault);

                    stream.Position = 0;

                    // Load RTF stream into RichTextBox.
                    var textRange = new TextRange(this.richTextBox.Document.ContentStart, this.richTextBox.Document.ContentEnd);
                    textRange.Load(stream, DataFormats.Rtf);
                }
        }

        private void Save(object sender, ExecutedRoutedEventArgs e)
        {
            //Results resultss = new Results();
            //try
            //{
            //    resultss.ID = Core.db.Results.ToList().Last().ID + 1;

            //}
            //catch (Exception)
            //{

            //    resultss.ID = 1;
            //}
            //resultss.IDstudents = users1.ID;
            //resultss.IDTest = test1.ID;
            //Core.db.Results.Add(resultss);
            //Core.db.SaveChanges();

            ////string path = @"C:\dsds\"+(string)test1.Title + (string)users1.FCS +".txt";
            //string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string path = (desktop + "\\Practics\\"+ "\\Lessons\\"+ (string)test1.Title + " " + (string)users1.FCS + ".docx");
            ////string dsdsds = users1.FCS;
            ////string textConcat = (string)dsdsds.Concat("and prosper!");
            ////string txt = path + (string)users1.FCS;
            //File.WriteAllText(path, string.Empty);

            //using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            //{

            //    byte[] buffer = Encoding.Unicode.GetBytes(TxtSource.Text);
            //    char[] chars = Encoding.Unicode.GetChars(buffer);
            //     fstream.WriteAsync(buffer, 0, buffer.Length);
            //    //f.WriteLine(TxtSource.Text + "\r\n");
            //}



















            //var dialog = new SaveFileDialog()
            //{
            //    AddExtension = true,
            //    Filter =
            //        "Word Document (*.docx)|*.docx|" +
            //    "Word Macro-Enabled Document (*.docm)|*.docm|" +
            //    "Word Template (*.dotx)|*.dotx|" +
            //    "Word Macro-Enabled Template (*.dotm)|*.dotm|" +
            //    "PDF (*.pdf)|*.pdf|" +
            //    "XPS Document (*.xps)|*.xps|" +
            //    "Web Page (*.htm;*.html)|*.htm;*.html|" +
            //    "Single File Web Page (*.mht;*.mhtml)|*.mht;*.mhtml|" +
            //    "Rich Text Format (*.rtf)|*.rtf|" +
            //    "Plain Text (*.txt)|*.txt|" +
            //    "Image (*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tif;*.tiff;*.wdp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tif;*.tiff;*.wdp"
            //};

            //if (dialog.ShowDialog(this) == true)
                using (var stream = new MemoryStream())
                {
                    // Save RichTextBox content to RTF stream.
                    var textRange = new TextRange(this.richTextBox.Document.ContentStart, this.richTextBox.Document.ContentEnd);
                    textRange.Save(stream, DataFormats.Rtf);

                    stream.Position = 0;
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string path = (desktop + "\\Practics\\" +"dsdsds" + ".docx");
                    // Convert RTF stream to output format.
                    DocumentModel.Load(stream, LoadOptions.RtfDefault).Save(path);
                    //Process.Start(path);
                }
        }

        private void Cut(object sender, ExecutedRoutedEventArgs e)
        {
            this.Copy(sender, e);

            // Clear selection.
            this.richTextBox.Selection.Text = string.Empty;
        }

        private void Copy(object sender, ExecutedRoutedEventArgs e)
        {
            using (var stream = new MemoryStream())
            {
                // Save RichTextBox selection to RTF stream.
                this.richTextBox.Selection.Save(stream, DataFormats.Rtf);

                stream.Position = 0;

                // Save RTF stream to clipboard.
                DocumentModel.Load(stream, LoadOptions.RtfDefault).Content.SaveToClipboard();
            }
        }

        private void Paste(object sender, ExecutedRoutedEventArgs e)
        {
            using (var stream = new MemoryStream())
            {
                // Save RichTextBox content to RTF stream.
                var textRange = new TextRange(this.richTextBox.Document.ContentStart, this.richTextBox.Document.ContentEnd);
                textRange.Save(stream, DataFormats.Rtf);

                stream.Position = 0;

                // Load document from RTF stream and prepend or append clipboard content to it.
                var document = DocumentModel.Load(stream, LoadOptions.RtfDefault);
                var position = (string)e.Parameter == "prepend" ? document.Content.Start : document.Content.End;
                position.LoadFromClipboard();

                stream.Position = 0;

                // Save document to RTF stream.
                document.Save(stream, SaveOptions.RtfDefault);

                stream.Position = 0;

                // Load RTF stream into RichTextBox.
                textRange.Load(stream, DataFormats.Rtf);
            }
        }

        private void CanSave(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.richTextBox != null)
            {
                var document = this.richTextBox.Document;
                var startPosition = document.ContentStart.GetNextInsertionPosition(LogicalDirection.Forward);
                var endPosition = document.ContentEnd.GetNextInsertionPosition(LogicalDirection.Backward);
                e.CanExecute = startPosition != null && endPosition != null && startPosition.CompareTo(endPosition) < 0;
            }
            else
                e.CanExecute = false;
        }

        private void CanCut(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.richTextBox != null && !this.richTextBox.Selection.IsEmpty;
        }

        private void CanCopy(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.richTextBox != null && !this.richTextBox.Selection.IsEmpty;
        }

        private void CanPaste(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.richTextBox != null && this.richTextBox.IsKeyboardFocused;
        }
    }
}
