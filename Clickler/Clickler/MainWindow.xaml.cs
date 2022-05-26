using System;
using System.Collections.Generic;
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
using System.IO;

namespace Clickler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int szamlalo;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(@"C:\Users\tanulo\AppData\Roaming\FabiFolder\"))
            {
                Directory.CreateDirectory(@"C:\Users\tanulo\AppData\Roaming\FabiFolder\");
            }
            if (File.Exists(@"C:\Users\tanulo\AppData\Roaming\FabiFolder\szamlaloadat.txt"))
            {

            }
            else
            {
                StreamWriter sw = new StreamWriter(@"C:\Users\tanulo\AppData\Roaming\FabiFolder\szamlaloadat.txt");
                sw.WriteLine("0");
                sw.Close();
            }

            Szamlalo.Content = System.IO.File.ReadAllText(@"C:\Users\tanulo\AppData\Roaming\FabiFolder\szamlaloadat.txt");
            szamlalo = Convert.ToUInt16(Szamlalo.Content);
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            szamlalo++;
            Szamlalo.Content = szamlalo;
            var mentestartalma = Szamlalo.Content;
            var fajlnev = @"C:\Users\tanulo\AppData\Roaming\FabiFolder\szamlaloadat.txt";

            using (StreamWriter sw = File.CreateText(fajlnev))
            {
                sw.Write(mentestartalma);
                sw.Close();
            }
        }
    }
}
