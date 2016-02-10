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
    /// Interaction logic for JamFactoryUI.xaml
    /// </summary>
    public partial class JamFactoryUI : Window
    {
        public JamFactoryUI()
        {
            InitializeComponent();
        }

        private void assetInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            AssetInventory newAssetInventoryWindow = new AssetInventory();

            newAssetInventoryWindow.Show();

            this.Close();
        }

        private void qualityAssuranceButton_Click(object sender, RoutedEventArgs e)
        {
            //evt. ændre navnet på knap til et andet foretrukken navn

            MainWindow newQualityAssuranceWindow = new MainWindow();

            newQualityAssuranceWindow.Show();

            this.Close();
        }

        private void productDevelopmentButton_Click(object sender, RoutedEventArgs e)
        {
            //evt. ændre navnet på knap til et andet foretrukken navn
        }

        private void routePlanningButton_Click(object sender, RoutedEventArgs e)
        {
            //evt. ændre navnet på knap til et andet foretrukken navn
        }

        private void optimizationButton_Click(object sender, RoutedEventArgs e)
        {
            //evt. ændre navnet på knap til et andet foretrukken navn
        }
    }
}
