using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace SDH_Dlouha_Brtnice
{
    /// <summary>
    /// Interakční logika pro Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public static SerialPort sp { set; get; }
        public static string port;
        public Main()
        {
            InitializeComponent();
            string[] ports = null;
            ports = SerialPort.GetPortNames();
            portSelect.ItemsSource = ports;
            portSelect.SelectedIndex = 1;
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                sp = new SerialPort(portSelect.SelectedValue.ToString());
                port = portSelect.SelectedValue.ToString();
                sp.Open();
                sp.Close();
                MainWindow main = new MainWindow();
                main.Owner = this;
                main.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Zvoleny port nelze otevrit!");
                log.logme(1);
            }
                      
        }
    }
}
