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
using Domain;
namespace ProjectJam
{
    /// <summary>
    /// Interaction logic for AssetMakeAsset.xaml
    /// </summary>
    public partial class AssetMakeAsset : Window
    {
        AssetController myAssetController = new AssetController();
        public AssetMakeAsset()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            AssetInventory assetInventoryWindow = new AssetInventory();

            assetInventoryWindow.Show();

            this.Close();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            InsertAsset();
            //insert values til database
            myAssetController.CreateNewAsset(nameTextBox.Text,DateTime.Parse( purchaseDateTextBox.Text),decimal.Parse(purchasePriceTextBox.Text),decimal.Parse(scrapValueTextBox.Text),int.Parse(lifeSpanTextBox.Text));
            MessageBox.Show("New asset was created", "Succes");
        }

        public void InsertAsset()
        {
            SqlConnection conn = new SqlConnection("Server=ealdb1.eal.local;Database=ejl49_db;User Id=ejl49_usr;Password=Baz1nga49;");
        
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spInsertAsset", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@AssetName", nameTexBox.Text));
                cmd.Parameters.Add(new SqlParameter("@AssetPurchasePrice", purchasePriceTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@AssetPurchaseDate", purchaseDateTextBox));
                cmd.Parameters.Add(new SqlParameter("@AssetScrapValue", scrapValueTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@AssetPostedValue", postedValueTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@AssetLifeSpan", lifeSpanTextBox.Text));
                //cmd.Parameters.Add(new SqlParameter("@AssetStatus", textBoxTestStatus.Text));

                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                // note the type of the exeption
                Console.WriteLine("UPS " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

     
    }

}
