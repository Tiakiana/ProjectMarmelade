using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace ProjectJam
{
    /// <summary>
    /// Interaction logic for AssetInformation.xaml
    /// </summary>
    public partial class AssetInformation : Window
    {
        public AssetInformation()
        {
            InitializeComponent();
            fill_combo();
        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection conn = new SqlConnection("Server=ealdb1.eal.local;Database=ejl49_db; User ID = ejl49_usr; Password = Baz1nga49");
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("spCompoundAssDesc", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.Add(new SqlParameter("@AssetId", int.Parse(assetComboBox.SelectedValue.ToString().Substring(4,2))));

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string Asset = "Id: " + rdr["AssetId"] + "\nNavn: " + rdr["AssetName"]  + "\nStatus: " + rdr["AssetStatus"] + "\nAfskrivningsmetode: " + rdr["DecreciationType"] + "\nAfskriving: " + rdr["DecreciationValue"] ;
                    assetInformationListBox.Items.Add(Asset);
                }
                
            }
            catch (SqlException ee)
            {

                Console.WriteLine("whooops: " + ee.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        public void fill_combo()
        {

            SqlConnection conn = new SqlConnection("Server=ealdb1.eal.local;Database=ejl49_db; User ID = ejl49_usr; Password = Baz1nga49");
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT * from Asset";

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string Asset = "Id: " + rdr.GetInt32(0) + " Navn: " + rdr.GetString(1);
                    assetComboBox.Items.Add(Asset);
                }

            }
            catch (SqlException es)
            {
                Console.WriteLine("UPS " + es.Message);
                Console.ReadLine();
            }
            finally
            {
                conn.Close();
            }



        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {

            AssetInventory assetInventoryWindow = new AssetInventory();

            assetInventoryWindow.Show();
            this.Close();

        }

        private void assetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
