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
    /// Логика взаимодействия для Klienti.xaml
    /// </summary>
    public partial class Klienti : Window
    {
        public static string ConnectionString = @"Data Source=172.18.22.254,1433;Initial Catalog=World_yachts_Kisin;User ID=Student";
        private SqlConnection Conn = new SqlConnection(ConnectionString);
        public Klienti()
        {
            InitializeComponent();
            Conn.Open();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            World_yachts.World_yachts_KisinDataSet1 world_yachts_KisinDataSet1 = ((World_yachts.World_yachts_KisinDataSet1)(this.FindResource("world_yachts_KisinDataSet1")));
            // Загрузить данные в таблицу Клиенты. Можно изменить этот код как требуется.
            World_yachts.World_yachts_KisinDataSet1TableAdapters.КлиентыTableAdapter world_yachts_KisinDataSet1КлиентыTableAdapter = new World_yachts.World_yachts_KisinDataSet1TableAdapters.КлиентыTableAdapter();
            world_yachts_KisinDataSet1КлиентыTableAdapter.Fill(world_yachts_KisinDataSet1.Клиенты);
            System.Windows.Data.CollectionViewSource клиентыViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("клиентыViewSource")));
            клиентыViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string del = клиентыDataGrid.SelectedCells[0].ToString();
            string cmdStr = "DELETE FROM dbo.Клиенты WHERE Наименование_клиента = '" + del + "';";
            SqlCommand cmdinst = new SqlCommand(cmdStr, Conn);
            cmdinst.ExecuteNonQuery();
            Conn.Close();
            World_yachts.World_yachts_KisinDataSet1TableAdapters.КлиентыTableAdapter world_yachts_KisinDataSet1КлиентыTableAdapter = new World_yachts.World_yachts_KisinDataSet1TableAdapters.КлиентыTableAdapter();
        }
    }
}
