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
    /// Interaction logic for DeleteRecipe.xaml
    /// </summary>
    public partial class DeleteRecipe : Page
    {
        RecipeController _Con = new RecipeController();
        public DeleteRecipe()
        {
            InitializeComponent();
            AllRecipeTextBox.Text = _Con.GetRecipeIDName();
        }

        private void DeleteRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_Con.DeleteRecipe(int.Parse(IDtoDelete.Text)))
                {
                    RecipeInfoText.Text = "Recipe deleted";
                    AllRecipeTextBox.Text = _Con.GetRecipeIDName();
                }
                else
                {
                    RecipeInfoText.Text = "Recipe not found, therefore nothing was deleted";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter only numbers as ID. " + ex.Message, "Error");
                RecipeInfoText.Text = "Recipe not found, therefore nothing was deleted";
            }
        }
    }
}
