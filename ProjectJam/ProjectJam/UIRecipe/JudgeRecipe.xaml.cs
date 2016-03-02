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
        RecipeController recipeCon = new RecipeController();

        RecipeController _Con = new RecipeController();
        public JudgeRecipe()
        {
            InitializeComponent();
            //AllRecipeTextBox.Text = MethodThatReturnsAllRecipe()
            AllRecipeTextBox.Text = _Con.GetRecipeIDName();
        }

        /// <summary>
        /// finds recipe from choosen id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            string viewResult = recipeCon.ViewRecipe(Int32.Parse(GetRecipeText.Text));
            RecipeDescription.Text = viewResult;
        }

        private void JudgeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                recipeCon.JugdeRecipe(int.Parse(GetRecipeText.Text), JugdementBox.Text);

                JugdementBox.Text = "Judgement has been dealt!!";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Judgement not Created " + ex.Message);
            }

        }

        
    }
}
