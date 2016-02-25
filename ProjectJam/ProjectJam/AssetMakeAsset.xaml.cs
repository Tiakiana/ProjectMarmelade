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
            //insert values til database
            myAssetController.CreateNewAsset(nameTextBox.Text,DateTime.Parse( purchaseDateTextBox.Text),decimal.Parse(purchasePriceTextBox.Text),decimal.Parse(scrapValueTextBox.Text),int.Parse(lifeSpanTextBox.Text));
            MessageBox.Show("New asset was created", "Succes");
        }

        public void InsertAsset()
        {

        }

    }
}
