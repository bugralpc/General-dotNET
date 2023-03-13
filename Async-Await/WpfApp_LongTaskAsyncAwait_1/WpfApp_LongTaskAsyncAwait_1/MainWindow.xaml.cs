using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp_LongTaskAsyncAwait_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ProgressBarItemViewModel progressBarIVM = new ProgressBarItemViewModel() { Progress = 0 };

        public MainWindow()
        {
            InitializeComponent();

            Binding binding = new Binding("Progress");
            binding.Source = progressBarIVM;
            progressBar1.SetBinding(ProgressBar.ValueProperty, binding);
        }

        private async void ButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Current Thread => " + Thread.CurrentThread.ManagedThreadId.ToString());

            // Some works are being done... 
            string str = "Sauron";

            for (int i = 0; i < str.Length; i++)
            {
                Thread.Sleep(50);
            }

            Task<string> task = Task.Factory.StartNew(() => DoWork(str));

            string output = await task;

            textBox1.Text = output;

            MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());

        }

        private static string DoWork(string str)
        {
            for (int i = 0; i < 101; i++)
            {
                progressBarIVM.Progress = i;
                Thread.Sleep(50);
            }

            MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());

            return str;
        }
    }

    public class ProgressBarItemViewModel : INotifyPropertyChanged
    {
        private int progress;

        public int Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                NotifyPropertyChanged("Progress");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
