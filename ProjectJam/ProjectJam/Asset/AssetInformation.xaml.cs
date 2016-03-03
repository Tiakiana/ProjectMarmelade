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
        private Domain.AssetController newAssetController;

        public AssetInformation()
        {
            InitializeComponent();
            newAssetController = new Domain.AssetController();
            fill_combo();
        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            assetInformationListBox.Items.Clear();
            int tempID = int.Parse(assetComboBox.Text.Substring(4, (assetComboBox.Text.IndexOf(" ", 5) - 4)));

            newAssetController.GetAsset(tempID);

            assetInformationListBox.Items.Add("ID: " + newAssetController.CurrentAsset.AssetID);
            assetInformationListBox.Items.Add("Navn: " + newAssetController.CurrentAsset.AssetName);
            assetInformationListBox.Items.Add("Købsdato: " + newAssetController.CurrentAsset.AssetPurchaseDate);
            assetInformationListBox.Items.Add("Levetid: " + newAssetController.CurrentAsset.AssetLifeSpan);
            assetInformationListBox.Items.Add("Afskrivningsmetode: " + newAssetController.CurrentAsset.AssetDecreciationList[0].decreciationType);
            assetInformationListBox.Items.Add("Afskrivningsværdi: " + newAssetController.CurrentAsset.AssetDecreciationList[0].DecreciationValue);
            assetInformationListBox.Items.Add("Status: " + newAssetController.CurrentAsset.IsOperative);
        }

        public void fill_combo()
        {
            List<string> instringlist = newAssetController.ShowAssetInfo();

            foreach (string item in instringlist)
            {
                assetComboBox.Items.Add(item);
            }



            //SqlConnection conn = new SqlConnection("Server=ealdb1.eal.local;Database=ejl49_db; User ID = ejl49_usr; Password = Baz1nga49");

            //try
            //{
            //    conn.Open();

            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = conn;
            //    cmd.CommandText = "SELECT * from Asset";

            //    SqlDataReader rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        string Asset = "Id: " + rdr.GetInt32(0) + " Name: " + rdr.GetString(1);
            //        assetComboBox.Items.Add(Asset);
            //    }

            //}
            //catch (SqlException es)
            //{
            //    Console.WriteLine("UPS " + es.Message);
            //    Console.ReadLine();
            //}
            //finally
            //{
            //    conn.Close();
            //}
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
