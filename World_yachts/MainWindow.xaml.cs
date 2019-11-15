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

namespace World_yachts
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            Zakazi zak = new Zakazi();
            zak.Show();
        }

        private void Katalog_Click(object sender, RoutedEventArgs e)
        {
            Katalog kat = new Katalog();
            kat.Show();
        }

        private void Klienti_Click(object sender, RoutedEventArgs e)
        {
            Klienti kli = new Klienti();
            kli.Show();
        }

        private void Menedjeri_Click(object sender, RoutedEventArgs e)
        {
            Menedgeri men = new Menedgeri();
            men.Show();
        }

        private void Acses_Click(object sender, RoutedEventArgs e)
        {
            Acsesys acs = new Acsesys();
            acs.Show();
        }
    }
}
