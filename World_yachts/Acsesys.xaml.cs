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
using System.Data.SqlClient;

namespace World_yachts
{
    /// <summary>
    /// Логика взаимодействия для Acsesys.xaml
    /// </summary>
    public partial class Acsesys : Window
    {
        public static string ConnectionString = @"Data Source=172.18.22.254,1433;Initial Catalog=World_yachts_Kisin;User ID=Student";
        private SqlConnection Conn = new SqlConnection(ConnectionString);
        public Acsesys()
        {
            InitializeComponent();
            Conn.Open();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            World_yachts.World_yachts_KisinDataSet1 world_yachts_KisinDataSet1 = ((World_yachts.World_yachts_KisinDataSet1)(this.FindResource("world_yachts_KisinDataSet1")));
            // Загрузить данные в таблицу Аксессуары. Можно изменить этот код как требуется.
            World_yachts.World_yachts_KisinDataSet1TableAdapters.АксессуарыTableAdapter world_yachts_KisinDataSet1АксессуарыTableAdapter = new World_yachts.World_yachts_KisinDataSet1TableAdapters.АксессуарыTableAdapter();
            world_yachts_KisinDataSet1АксессуарыTableAdapter.Fill(world_yachts_KisinDataSet1.Аксессуары);
            System.Windows.Data.CollectionViewSource аксессуарыViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("аксессуарыViewSource")));
            аксессуарыViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string del = аксессуарыDataGrid.SelectedCells[0].ToString();
            string cmdStr = "DELETE FROM dbo.Аксессуары WHERE Номер_аксессуара = '" + del + "';";
            SqlCommand cmdinst = new SqlCommand(cmdStr, Conn);
            cmdinst.ExecuteNonQuery();
            Conn.Close();
            World_yachts.World_yachts_KisinDataSet1TableAdapters.АксессуарыTableAdapter world_yachts_KisinDataSet1АксессуарыTableAdapter = new World_yachts.World_yachts_KisinDataSet1TableAdapters.АксессуарыTableAdapter();
        }
    }
}
