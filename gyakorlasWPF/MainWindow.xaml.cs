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
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace gyakorlasWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Alkalmazott> alkalmazottList = new ObservableCollection<Alkalmazott>();
        public class Alkalmazott
        {
            public string name { get; set; }
            public string phone { get; set; }
            public int hourly { get; set; }
            public int workhours { get; set; }
            public int totalPay { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            alkalmazottList.Add(new Alkalmazott(){name = "Kovács Gergő",
                                                  phone = "+36 20 327 3389",
                                                  hourly = 2500,
                                                  workhours = 40,
                                                  totalPay = 400000});
            alkalmazottakLista.ItemsSource = alkalmazottList;
        }

        private void torles_Click(object sender, RoutedEventArgs e)
        {
            if (alkalmazottakLista.SelectedItem != null)
            {
                Alkalmazott selectedAlkalmazott = (Alkalmazott)alkalmazottakLista.SelectedItem;

                MessageBoxResult result = MessageBox.Show("Biztos ki akarja törölni ezt az alkalmazottat?", "Folytatás", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if(alkalmazottList.IndexOf(selectedAlkalmazott) == -1)
                    {
                        MessageBox.Show("Hiba lépett fel!");
                    }
                    else
                    {
                        alkalmazottList.Remove(selectedAlkalmazott);
                        alkalmazottakLista.ItemsSource = alkalmazottList;
                        
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Kérjuk válasszon ki egy alkalmazottat!");
            }

        }

        private void bezaras_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztos be akarja zárni a programot?", "Folytatás", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void berszamitas_Gomb_Click(object sender, RoutedEventArgs e)
        {
            berszamitas berszamitasWindow = new berszamitas();
            berszamitasWindow.ShowDialog();

            berekBetoltese(berszamitasWindow.oraberPassBack,
                           berszamitasWindow.hetiMunkaPassBack,
                           berszamitasWindow.haviberPassBack);
        }

        public void berekBetoltese(string oraber,
                                   string hetiMunka,
                                   string haviber)
        {
            oraberOutput.Content = oraber;
            hetiMunkaOutput.Content = hetiMunka;
            haviOutput.Content = haviber;
        }

        private void hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            string nev = inputName.Text;
            if(nev == null || nev ==  string.Empty)
            {
                MessageBox.Show("Meg kell adnia egy nevet is!");
                return;
            }

            string telefon = inputPhone.Text;
            if (telefon == null || telefon == string.Empty)
            {
                MessageBox.Show("Meg kell adnia egy telefonszámot is!");
                return;
            }

            alkalmazottList.Add(new Alkalmazott()
            {
                name = nev,
                phone = telefon,
                hourly = Convert.ToInt32(oraberOutput.Content),
                workhours = Convert.ToInt32(hetiMunkaOutput.Content),
                totalPay = Convert.ToInt32(haviOutput.Content)
            });
        }
    }
}
