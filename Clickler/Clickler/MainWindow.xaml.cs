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

            hatterkep.Visibility = Visibility.Hidden;

            kinalat.Items.Add("Háttér");
            kinalat.Items.Add("Zene");
            kinalat.Items.Add("Autoclicker");
            kinalat.Items.Add("Hangeffekt");

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

        private void megvesz_Click(object sender, RoutedEventArgs e)
        {
            if (kinalat.SelectedIndex == 0)
            {
                if (Convert.ToInt32(Szamlalo.Content) < 1000)
                {
                    MessageBox.Show("Nincs elég clicked! A háttér ára 1000 click!");
                }
                else
                {
                    hatterkep.Visibility = Visibility.Visible;
                    kinalat.Items.RemoveAt(0);
                    szamlalo = Convert.ToInt32(Szamlalo.Content);
                    szamlalo = szamlalo - 1000;
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

            else if (kinalat.SelectedIndex == 1)
            {
                if (Convert.ToInt32(Szamlalo.Content) < 2000)
                {
                    MessageBox.Show("Nincs elég clicked! A zene ára 2000 click!");
                }
                else
                {
                    MediaPlayer zene = new MediaPlayer();
                    zene.Open(new Uri(@"/Muzsika.wav"));
                    zene.Play();


                    kinalat.Items.RemoveAt(1);
                    szamlalo = Convert.ToInt32(Szamlalo.Content);
                    szamlalo = szamlalo - 2000;
                    Szamlalo.Content = szamlalo;
                    var mentestartalma = Szamlalo.Content;
                    var fajlnev = @"C:\Users\tanulo\AppData\Roaming\FabiFolder\szamlaloadat.txt";

                    using (StreamWriter sw = File.CreateText(fajlnev))
                    {
                        sw.Write(mentestartalma);
                        sw.Close();
                    }
                }

                if (Convert.ToInt32(Szamlalo.Content) < 2000)
                {
                    MessageBox.Show("Nincs elég clicked! Az autoclicker ára 5000 pont!");
                }
                else
                {

                    kinalat.Items.RemoveAt(2);
                    szamlalo = Convert.ToInt32(Szamlalo.Content);
                    szamlalo = szamlalo - 5000;
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
    }
}
