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
using System.Windows.Shapes;

namespace SDH_Dlouha_Brtnice
{
    /// <summary>
    /// Interakční logika pro Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public static SerialPort sp { set; get; }
        public Main()
        {
            InitializeComponent();
            string[] ports = null;
            ports = SerialPort.GetPortNames();
            portSelect.SelectedIndex = 1;
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                sp = new SerialPort(portSelect.SelectedValue.ToString());
                sp.Open();
                MainWindow main = new MainWindow();
                main.Owner = this;
                main.Show();
                this.Close();
            }
            catch { MessageBox.Show("Zvoleny port nelze otevrit!");}
                      
        }
    }
}
