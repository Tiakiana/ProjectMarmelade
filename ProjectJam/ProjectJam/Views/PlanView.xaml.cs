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
using ProjectJam.Controllers;

namespace ProjectJam.Views
{
    /// <summary>
    /// Interaction logic for PlanView.xaml
    /// </summary>
    public partial class PlanView : UserControl
    {
        private Popup popWin;
        public PlanView()
        {
            InitializeComponent();
        }

        private void buttonPlaning_Click(object sender, RoutedEventArgs e)
        {
            PlanController.DoProductionPlan();
        }

        private void buttonAddResource_Click(object sender, RoutedEventArgs e)
        {
            popWin = new Popup(new AddResourceView());
            popWin.Show();
            popWin.Activate();
        }

        private void buttonAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            popWin = new Popup(new AddRecipeView());
            popWin.Show();
            popWin.Activate();
        }

        private void buttonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            popWin = new Popup(new AddProductView());
            popWin.Show();
            popWin.Activate();
        }
    }
}
