using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace Clickler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int szamlalo;
        public int szorzo=1;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (!Directory.Exists(@"C:\FabiFolder\"))
            {
                Directory.CreateDirectory(@"C:\FabiFolder\");
            }
            if (File.Exists(@"C:\FabiFolder\szamlaloadat.txt"))
            {

            }
            else
            {
                StreamWriter sw = new StreamWriter(@"C:\FabiFolder\szamlaloadat.txt");
                sw.WriteLine("0");
                sw.Close();
            }
            MusicCopy();

            Szamlalo.Content = System.IO.File.ReadAllText(@"C:\FabiFolder\szamlaloadat.txt");
            szamlalo = Convert.ToUInt16(Szamlalo.Content);

            hatterkep.Visibility = Visibility.Hidden;

            kinalat.Items.Add("Háttér");
            kinalat.Items.Add("Zene");
            kinalat.Items.Add("Duplázás");
            kinalat.Items.Add("Triplázás");

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            szamlalo+=szorzo;
            Szamlalo.Content = szamlalo;
            var mentestartalma = Szamlalo.Content;
            var fajlnev = @"C:\FabiFolder\szamlaloadat.txt";

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
                    var fajlnev = @"C:\FabiFolder\szamlaloadat.txt";

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
                    zene.Open(new Uri(@"C:\FabiFolder\Muzsika.wav"));
                    MessageBox.Show("");
                    zene.Play();


                    kinalat.Items.RemoveAt(1);
                    szamlalo = Convert.ToInt32(Szamlalo.Content);
                    szamlalo = szamlalo - 2000;
                    Szamlalo.Content = szamlalo;
                    var mentestartalma = Szamlalo.Content;
                    var fajlnev = @"C:\FabiFolder\szamlaloadat.txt";

                    using (StreamWriter sw = File.CreateText(fajlnev))
                    {
                        sw.Write(mentestartalma);
                        sw.Close();
                    }
                }


            }

            else if(kinalat.SelectedIndex==2)
            {
                if (Convert.ToInt32(Szamlalo.Content) < 5000)
                {
                    MessageBox.Show("Nincs elég clicked! A duplázás ára 5000 pont!");
                }
                else
                {
                    szorzo = 2;
                    kinalat.Items.RemoveAt(2);
                    szamlalo = Convert.ToInt32(Szamlalo.Content);
                    szamlalo = szamlalo - 5000;
                    Szamlalo.Content = szamlalo;
                    var mentestartalma = Szamlalo.Content;
                    var fajlnev = @"C:\FabiFolder\szamlaloadat.txt";

                    using (StreamWriter sw = File.CreateText(fajlnev))
                    {
                        sw.Write(mentestartalma);
                        sw.Close();
                    }
                }
            }

            else if (kinalat.SelectedIndex == 3)
            {
                if (Convert.ToInt32(Szamlalo.Content) < 20000)
                {
                    MessageBox.Show("Nincs elég clicked! A triplázás ára 20000 pont!");
                }
                else
                {
                    szorzo = 3;
                    kinalat.Items.RemoveAt(3);
                    szamlalo = Convert.ToInt32(Szamlalo.Content);
                    szamlalo = szamlalo - 20000;
                    Szamlalo.Content = szamlalo;
                    var mentestartalma = Szamlalo.Content;
                    var fajlnev = @"C:\FabiFolder\szamlaloadat.txt";

                    using (StreamWriter sw = File.CreateText(fajlnev))
                    {
                        sw.Write(mentestartalma);
                        sw.Close();
                    }
                }
            }

        }
        public void MusicCopy()
        {
            File.Copy("Muzsika.wav", @"C:\FabiFolder\Muzsika.wav", true);
        }

    }
}
