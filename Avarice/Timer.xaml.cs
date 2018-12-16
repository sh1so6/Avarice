using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Avarice
{
    /// <summary>
    /// Timer.xaml の相互作用ロジック
    /// </summary>
    public partial class Timer : Window
    {
        private DispatcherTimer dispatcherTimer;
        private DateTime nowTimer = new DateTime();
        public Timer()
        {
            InitializeComponent();

            dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // 数字とコロンのみ受け付ける
            Regex regex = new Regex("[^0-9:]");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (nowTimer.Hour <= 0 && nowTimer.Minute <= 0 && nowTimer.Second <= 0)
            {
                dispatcherTimer.Stop();
                MessageBox.Show("時間だよ");
                return;
            }
            nowTimer = nowTimer.AddSeconds(-1);
            strTimer.Text = $"{nowTimer.Hour:D2}:{nowTimer.Minute:D2}:{nowTimer.Second:D2}";
        }
        private void TimerControlButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!dispatcherTimer.IsEnabled)
            {
                dispatcherTimer.Start();
                nowTimer = DateTime.Parse(strTimer.Text);
            }
            else
            {
                dispatcherTimer.Stop();
            }
        }
    }
}
