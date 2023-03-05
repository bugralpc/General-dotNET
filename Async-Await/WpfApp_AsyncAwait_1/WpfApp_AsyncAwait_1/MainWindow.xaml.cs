using System;
using System.Collections.Generic;
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

namespace WpfApp_AsyncAwait_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            textBlock1.Text = "When you click button, the UI freezes. " +
                "UI object textBox1 waits for result1 task to finish until then it blocks main thread";

            textBlock2.Text = "When you click button, the UI does not freezes" +
                "UI object textbox2 waits for the result task to finish until then it does not block main thread" +
                "Using Task.ContinueWith() is important here.";
                
        }

        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            Task<string> result1 = CalculateValueAsync();

            textBox1.Text = result1.Result;
        }

        private void ButttonClick2(object sender, RoutedEventArgs e)
        {
            Task<string> result2 = CalculateValueAsync();

            result2.ContinueWith(t =>
            {
                textBox2.Text = result2.Result;
                MessageBox.Show("Task Thread Id => " + Thread.CurrentThread.ManagedThreadId.ToString());
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private Task<string> CalculateValueAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                MessageBox.Show("Task Thread Id => " + Thread.CurrentThread.ManagedThreadId.ToString());
                return "Done";
            });
        }
    }
}
