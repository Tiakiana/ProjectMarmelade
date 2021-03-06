﻿using System;
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
    /// Interaction logic for AssetPlanMaintenance.xaml
    /// </summary>
    public partial class AssetPlanMaintenance : Window
    {
        public AssetPlanMaintenance()
        {
            InitializeComponent();
        }

        private void confirmPlanMaintenanceButton_Click(object sender, RoutedEventArgs e)
        {
            // insert selected values in messagebox
            if (MessageBox.Show("Planlæg vedligeholdelse for: \n AnlægsId \n AssetName \n Dato \n Beskrivelse", "Planlæg vedligeholdelse", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // do yes stuff
                MessageBox.Show("Vedligeholdelse planlagt");
            }
            else
            {
                // do no stuff
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            AssetInventory assetInventoryWindow = new AssetInventory();

            assetInventoryWindow.Show();
            this.Close();
        }
    }
}
