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
    /// Interaction logic for AssetCompletedMaintenance.xaml
    /// </summary>
    public partial class AssetCompletedMaintenance : Window
    {
        public AssetCompletedMaintenance()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            AssetInventory assetInventoryWindow = new AssetInventory();

            assetInventoryWindow.Show();
            this.Close();
        }

        private void completeButton_Click(object sender, RoutedEventArgs e)
        {
            // insert selected values in messagebox
            if (MessageBox.Show("Godkend at: \n AssetId \n AssetName \n er blevet vedligeholdt", "Vedligeholdelse", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // do yes stuff 
                MessageBox.Show("Anlægget er i drift");
            }
            else
            {
                // do no stuff
            }

        }
    }
}
