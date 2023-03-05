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

namespace WpfApp_AsyncAwait_2
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

        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            Task<int> result1 = CalculateValueAsync1();

            result1.ContinueWith(t =>
            {
                textBox1.Text = result1.Result.ToString();
                MessageBox.Show("Current Thread => " + Thread.CurrentThread.ManagedThreadId.ToString());
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async void ButtonClick2(object sender, RoutedEventArgs e)
        {
            int value = await CalculateValueAsync2();
            MessageBox.Show("Current Thread => " + Thread.CurrentThread.ManagedThreadId.ToString());
            textBox2.Text = value.ToString();
        }

        private Task<int> CalculateValueAsync1()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                MessageBox.Show("Current Thread => " + Thread.CurrentThread.ManagedThreadId.ToString());
                return 123;
            });
        }

        private async Task<int> CalculateValueAsync2()
        {
            await Task.Delay(5000);
            MessageBox.Show("Current Thread => " + Thread.CurrentThread.ManagedThreadId.ToString());
            return 123;
        }

        private void Method()
        {
            for (int i = 0; i < 10; i++)
            {

            }

        }
    }
}
