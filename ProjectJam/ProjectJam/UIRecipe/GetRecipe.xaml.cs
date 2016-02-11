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
        //Controller _Con = new Controller();
        public GetRecipe()
        {
            InitializeComponent();
            //AllRecipeTextBox.Text = MethodThatReturnsAllRecipe()
        }

        private void GetRecipeConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            //string recipe = _Con.MethodToGetRecipe(int.Parse(GetRecipeText.Text));
            //RecipeInfoText.Text = recipe;
            RecipeInfoText.Text = "Recipe not found, please try again";

        }
    }
}
