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

namespace ProjectJam
{
    /// <summary>
    /// Interaction logic for AssetInventory.xaml
    /// </summary>
    public partial class AssetInventory : Window
    {
        public AssetInventory()
        {
            InitializeComponent();
        }

       
        private void planMaintenanceButton_Click(object sender, RoutedEventArgs e)
        {
            AssetPlanMaintenance newPlanMaintenanceWindow = new AssetPlanMaintenance();

            newPlanMaintenanceWindow.Show();
            this.Close();
        }

        private void newAssetButton_Click(object sender, RoutedEventArgs e)
        {
            AssetMakeAsset newMakeAssetWindow = new AssetMakeAsset();

            newMakeAssetWindow.Show();
            this.Close();
        }

        private void assetInformationButton_Click(object sender, RoutedEventArgs e)
        {
            AssetInformation newAssetInformationWindow = new AssetInformation();

            newAssetInformationWindow.Show();
            this.Close();
        }

        private void completedMaintenanceButton_Click(object sender, RoutedEventArgs e)
        {
            AssetCompletedMaintenance newCompletedMaintenanceWindow = new AssetCompletedMaintenance();

            newCompletedMaintenanceWindow.Show();
            this.Close();
        }

    }
}
