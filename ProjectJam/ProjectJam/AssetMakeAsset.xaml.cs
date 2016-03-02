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
    /// Interaction logic for AssetMakeAsset.xaml
    /// </summary>
    public partial class AssetMakeAsset : Window
    {
        Domain.AssetController myAssetController = new Domain.AssetController();
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
            Domain.DecreciationType tempDecType = new Domain.DecreciationType();
            switch (decreciationTypeComboBox.Text)
            {
                case "Lineær":
                    tempDecType = Domain.DecreciationType.Lineær;
                    break;
                case "Saldo":
                    tempDecType = Domain.DecreciationType.Saldo;
                    break;
                case "Annuitet":
                    tempDecType = Domain.DecreciationType.Annuitet;
                    break;
                default:
                    break;
            }
            //insert values til database
            myAssetController.CreateNewAsset(nameTextBox.Text, decimal.Parse(purchasePriceTextBox.Text), purchaseDateTextBox.Text, decimal.Parse(scrapValueTextBox.Text), int.Parse(lifeSpanTextBox.Text), statusComboBox.Text,tempDecType);
        
            ClearTextbox();
            MessageBox.Show("Anlæg oprettet", "Succes");
        }

        public void ClearTextbox()
        {
            nameTextBox.Text = String.Empty;
            purchasePriceTextBox.Text = String.Empty;
            purchaseDateTextBox.Text = String.Empty;
            scrapValueTextBox.Text = String.Empty;
            lifeSpanTextBox.Text = String.Empty;
            statusComboBox.Text = String.Empty;
            decreciationTypeComboBox.Text = String.Empty;

        }

    }

}
