using Microsoft.Win32;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SampleWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            // adding a variable to check if the string is not null
            var stringCheck = string.IsNullOrEmpty(this.FileNameBox.Text);
            if (!stringCheck)
            {
                string fileContent= await OpenFileAsync(this.FileNameBox.Text);
                this.ContentBox.Text = fileContent;
            }
        }


        private async Task<string> OpenFileAsync(string fileName)
        {
            string result = null;
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                using (var reader = new StreamReader(fs))
                {
                    result = await reader.ReadToEndAsync();
                }
            }
         
            return result;
        }


        private string OpenFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.Title = "Select a .txt file";
            openDialog.Filter = "Text files (.txt)|*.txt";
            if (openDialog.ShowDialog() == true)
            {
                this.FileNameBox.Text = openDialog.FileName;
            }
        }

        private IEnumerable<string> EnumerateTextFiles(string directoryName)
        {
            // Using a lambda for demonstration purposes only
            // You might want to use a search pattern instead
            var list = Directory.EnumerateFiles(directoryName);
            var filteredList = list.Where(f => f.ToLower().Contains(".txt"));

            return filteredList;
        }

        private void FeelingLuckyButton_Click(object sender, RoutedEventArgs e)
        {
            this.FileNameBox.Text = OpenFile(EnumerateTextFiles("C:\\temp").FirstOrDefault());
        }
    }
}
