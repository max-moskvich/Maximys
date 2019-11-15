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
    /// Логика взаимодействия для Katalog.xaml
    /// </summary>
    public partial class Katalog : Window
    {
        public static string ConnectionString = @"Data Source=172.18.22.254,1433;Initial Catalog=World_yachts_Kisin;User ID=Student";
        private SqlConnection Conn = new SqlConnection(ConnectionString);
        public Katalog()
        {
            InitializeComponent();
            Conn.Open();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            World_yachts.World_yachts_KisinDataSet1 world_yachts_KisinDataSet1 = ((World_yachts.World_yachts_KisinDataSet1)(this.FindResource("world_yachts_KisinDataSet1")));
            // Загрузить данные в таблицу Каталог. Можно изменить этот код как требуется.
            World_yachts.World_yachts_KisinDataSet1TableAdapters.КаталогTableAdapter world_yachts_KisinDataSet1КаталогTableAdapter = new World_yachts.World_yachts_KisinDataSet1TableAdapters.КаталогTableAdapter();
            world_yachts_KisinDataSet1КаталогTableAdapter.Fill(world_yachts_KisinDataSet1.Каталог);
            System.Windows.Data.CollectionViewSource каталогViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("каталогViewSource")));
            каталогViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string del = каталогDataGrid.SelectedCells[0].ToString();
            string cmdStr = "DELETE FROM dbo.Каталог WHERE Наименование_товара = '" + del + "';";
            SqlCommand cmdinst = new SqlCommand(cmdStr, Conn);
            cmdinst.ExecuteNonQuery();
            Conn.Close();
            World_yachts.World_yachts_KisinDataSet1TableAdapters.КаталогTableAdapter world_yachts_KisinDataSet1КаталогTableAdapter = new World_yachts.World_yachts_KisinDataSet1TableAdapters.КаталогTableAdapter();
        }
    }
}
