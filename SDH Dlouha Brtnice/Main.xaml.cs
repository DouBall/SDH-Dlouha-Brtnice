using System;
using System.Collections.Generic;
using System.IO.Ports;
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

namespace SDH_Dlouha_Brtnice
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string timeLeft, timeRight, mes;
        public static string[] times = new string[2];
        public static SerialPort port = Main.sp;
        public MainWindow()
        {
            InitializeComponent();
            while(true)
            {
                try
                {
                    
                    mes = port.ReadLine();
                    times = mes.Split(';');
                    timeLeft = times[0];
                    timeRight = times[1];
                    time0.Content = timeLeft;
                    time1.Content = timeRight;
                }
                catch { }

            }
        }
    }
}
