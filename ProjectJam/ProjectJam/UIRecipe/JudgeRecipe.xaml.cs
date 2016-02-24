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
    /// Interaction logic for JudgeRecipe.xaml
    /// </summary>
    public partial class JudgeRecipe : Page
    {
        RecipeController _Con = new RecipeController();
        public JudgeRecipe()
        {
            InitializeComponent();
            //AllRecipeTextBox.Text = MethodThatReturnsAllRecipe()
            AllRecipeTextBox.Text = _Con.GetRecipeIDName();
        }

        private void ChooseRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            //RecipeDescription.Text = MethodThatReturnsRecipe();
        }

        private void JudgeBtn_Click(object sender, RoutedEventArgs e)
        {
            JugdementBox.Text = "Judgement has been dealt!!";
        }
    }
}
