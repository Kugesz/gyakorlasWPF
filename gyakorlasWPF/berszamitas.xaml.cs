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
using System.Windows.Shapes;
using System.ComponentModel;

namespace gyakorlasWPF
{
    /// <summary>
    /// Interaction logic for berszamitas.xaml
    /// </summary>

    internal class Adatok : INotifyPropertyChanged
    {
        public int oraber;
        public int hetiMunka;
        public int haviber;

        public int Oraber
        {
            get { return oraber; }
            set
            {
                if (int.TryParse(value.ToString(), out int result))
                {
                    oraber = result;
                    OnPropertyChanged(nameof(Oraber));
                    OnPropertyChanged(nameof(Haviber)); // Update Haviber when Oraber changes
                }
                else
                {
                    MessageBox.Show("Nem megfelelő az érték!");
                }
            }
        }

        public int HetiMunka
        {
            get { return hetiMunka; }
            set
            {
                if (int.TryParse(value.ToString(), out int result))
                {
                    hetiMunka = result;
                    OnPropertyChanged(nameof(HetiMunka));
                    OnPropertyChanged(nameof(Haviber)); // Update Haviber when HetiMunka changes
                }
                else
                {
                    MessageBox.Show("Nem megfelelő az érték!");
                }
            }
        }

        public int Haviber
        {
            get { return oraber * hetiMunka * 4; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



    public partial class berszamitas : Window
    {
        Adatok adatok = new Adatok();

        public int oraberPassBack { get; private set; }
        public int hetiMunkaPassBack { get; private set; }
        public int haviberPassBack { get; private set; }

        public berszamitas()
        {
            InitializeComponent();

            DataContext = adatok;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            oraberPassBack = adatok.Oraber;
            hetiMunkaPassBack = adatok.HetiMunka;
            haviberPassBack = adatok.Haviber;
            this.Close();
        }
    }
}
