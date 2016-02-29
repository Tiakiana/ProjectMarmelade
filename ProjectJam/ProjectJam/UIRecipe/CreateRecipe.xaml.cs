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
    /// Interaction logic for CreateRecipe.xaml
    /// </summary>
    public partial class CreateRecipe : Page
    {
        RecipeController _Con = new RecipeController();
        public CreateRecipe()
        {
            InitializeComponent();
        }
        private void CreateUserRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            _Con.CreateRecipe(HeaderBox.Text, DescBox.Text, IngredientBox.Text);
        }
    }
}
