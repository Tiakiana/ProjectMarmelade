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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controller;

namespace View
{    
    public partial class ProductIndexWindow : Window
    {
        ProductIndex PI = new ProductIndex();
        public ProductIndexWindow()
        {
            InitializeComponent();            
        }
        private void PNameSelectBox_Loaded(object sender, RoutedEventArgs e)
        {
            var pNameSelectBox = sender as ComboBox;
            pNameSelectBox.ItemsSource = PI.pNameList;
            pNameSelectBox.SelectedIndex = 0;
        }
        private void PTypeSelectBox_Loaded(object sender, RoutedEventArgs e)
        {
            var pTypeSelectBox = sender as ComboBox;
            pTypeSelectBox.ItemsSource = PI.pTypeList;
            pTypeSelectBox.SelectedIndex = 0;
        }
        private void PDocumationSelectBox_Loaded(object sender, RoutedEventArgs e)
        {
            var pDocumationSelectBox = sender as ComboBox;
            pDocumationSelectBox.ItemsSource = PI.pDocumationList;
            pDocumationSelectBox.SelectedIndex = 0;
        }
        private void Finder_Click(object sender, RoutedEventArgs e)
        {
            WindowData wd = new WindowData(PI.ShowProductDocumation(PNameSelectBox.Text, PTypeSelectBox.Text, PDocumationSelectBox.Text);
            wd.Show();
        }      
    }
}
