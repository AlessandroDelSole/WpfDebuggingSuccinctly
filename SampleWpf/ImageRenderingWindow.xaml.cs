using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace SampleWpf
{
    /// <summary>
    /// Interaction logic for ImageRenderingWindow.xaml
    /// </summary>
    public partial class ImageRenderingWindow : Window
    {
        public class ImageFile
        {
            public Uri ImagePath { get; set; }
            public string ImageName { get; set; }
        }

        public class ImageFileCollection : ObservableCollection<ImageFile>
        {
            public ImageFileCollection()
            {
                for (int i = 0; i <= 1000; i++)
                {
                    // Reaplace with a file you have on your pc...
                    this.Add(new ImageFile
                    {
                        ImageName = "Beach.jpg",
                        ImagePath = new Uri("Beach.jpg", UriKind.Relative)
                    });
                }
            }
        }

        private void SimulateIntensiveWork()
        {
            var watch = new Stopwatch();
            watch.Start();
            for (int i=0;i<10000;i++)
            {
                //Simulates intensive processing
                System.Threading.Thread.SpinWait(800000);
            }
            watch.Stop();
        }

        public ImageRenderingWindow()
        {
            InitializeComponent();
            this.DataContext = new ImageFileCollection();
            //SimulateIntensiveWork();
        }
    }
}
