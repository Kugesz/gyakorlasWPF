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

namespace gyakorlasWPF
{
    /// <summary>
    /// Interaction logic for berszamitas.xaml
    /// </summary>


    public partial class berszamitas : Window
    {
        public string oraberPassBack { get; set; }
        public string hetiMunkaPassBack { get; set; }
        public string haviberPassBack { get; set; }

        int oraberaValue;
        int hetiMunkaValue;
        public berszamitas()
        {
            InitializeComponent();
        }

        private void oraber_TextChanged(object sender, EventArgs e)
        {
            string oraberText = oraber.Text;

            
            if (int.TryParse(oraberText, out oraberaValue))
            {
                haviberOutput.Content = oraberaValue * hetiMunkaValue;
            }
            else
            {
                MessageBox.Show("Az órabérnek egy számnak kell lennie!");
            }
        }

        private void hetiMunka_TextChanged(object sender, EventArgs e)
        {
            string hetiMunkaText = hetiMunka.Text;

            
            if(int.TryParse(hetiMunkaText, out hetiMunkaValue))
            {
                haviberOutput.Content = oraberaValue * hetiMunkaValue;
            }
            else
            {
                MessageBox.Show("A heti munka óráknak egy számnak kell lennie!");
            }

        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            oraberPassBack = oraber.Text;
            hetiMunkaPassBack = hetiMunka.Text;
            haviberPassBack = haviberOutput.Content.ToString();
            this.Close();
        }
    }
}
