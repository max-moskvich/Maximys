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
    /// Логика взаимодействия для Menedgeri.xaml
    /// </summary>
    public partial class Menedgeri : Window
    {
        public static string ConnectionString = @"Data Source=172.18.22.254,1433;Initial Catalog=World_yachts_Kisin;User ID=Student";
        private SqlConnection Conn = new SqlConnection(ConnectionString);
        public Menedgeri()
        {
            InitializeComponent();
            Conn.Open();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            World_yachts.World_yachts_KisinDataSet1 world_yachts_KisinDataSet1 = ((World_yachts.World_yachts_KisinDataSet1)(this.FindResource("world_yachts_KisinDataSet1")));
            // Загрузить данные в таблицу Менеджеры. Можно изменить этот код как требуется.
            World_yachts.World_yachts_KisinDataSet1TableAdapters.МенеджерыTableAdapter world_yachts_KisinDataSet1МенеджерыTableAdapter = new World_yachts.World_yachts_KisinDataSet1TableAdapters.МенеджерыTableAdapter();
            world_yachts_KisinDataSet1МенеджерыTableAdapter.Fill(world_yachts_KisinDataSet1.Менеджеры);
            System.Windows.Data.CollectionViewSource менеджерыViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("менеджерыViewSource")));
            менеджерыViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string del = менеджерыDataGrid.SelectedItems[0].ToString();
            
            MessageBox.Show(del);
       
            //string cmdStr = "DELETE FROM dbo.Менеджеры WHERE Номер_менеджера = " + del + ";";
            //SqlCommand cmdinst = new SqlCommand(cmdStr, Conn);
            //cmdinst.ExecuteNonQuery();
            //Conn.Close();
            //World_yachts.World_yachts_KisinDataSet1TableAdapters.МенеджерыTableAdapter world_yachts_KisinDataSet1МенеджерыTableAdapter = new World_yachts.World_yachts_KisinDataSet1TableAdapters.МенеджерыTableAdapter();
        }
    }
}
