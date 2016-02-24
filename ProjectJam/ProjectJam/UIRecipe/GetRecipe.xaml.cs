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
    /// Interaction logic for GetRecipe.xaml
    /// </summary>
    public partial class GetRecipe : Page
    {
        RecipeController _Con = new RecipeController();
        public GetRecipe()
        {
            InitializeComponent();
            AllRecipeTextBox.Text = _Con.GetRecipeIDName();
        }

        private void GetRecipeConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string recipe = _Con.ViewRecipe(int.Parse(GetRecipeText.Text));
                RecipeInfoText.Text = recipe;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter only numbers as ID. " + ex.Message, "Error");
                RecipeInfoText.Text = "Recipe not found, please try again";
            }
        }
    }
}
