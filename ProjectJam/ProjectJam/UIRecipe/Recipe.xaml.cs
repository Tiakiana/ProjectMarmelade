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


namespace ProjectJam
{
    /// <summary>
    /// Interaction logic for Recipe.xaml
    /// </summary>
    public partial class Recipe : Page
    {
        public Recipe()
        {
            InitializeComponent();
        }

      

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
