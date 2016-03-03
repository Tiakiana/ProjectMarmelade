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
using System.Windows.Shapes;

namespace ProjectJam
{
    /// <summary>
    /// Interaction logic for Development.xaml
    /// </summary>
    public partial class Development : Window
    {
        CreateRecipe cr = new CreateRecipe();
        JudgeRecipe jr = new JudgeRecipe();
        GetRecipe gr = new GetRecipe();
        KnowlegdeBank kb = new KnowlegdeBank();
        DeleteRecipe dr = new DeleteRecipe();
        RecipeController _Con = new RecipeController();

        public Development()
        {
            InitializeComponent();
            Domain.DomainController.getDCT().onStart("M1");
        }

        #region UIRecipe
        private void CreateRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            RecipeFrame.Content = cr;
            //cr er en page for CreateRecipe
        }
        private void JudgeRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            _Con.Updater(jr.AllRecipeTextBox);
            RecipeFrame.Content = jr;
        }
        private void GetRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            _Con.Updater(gr.AllRecipeTextBox);
            RecipeFrame.Content = gr;
        }
        private void BankBtn_Click(object sender, RoutedEventArgs e)
        {
            kb.KnowledgeBox.Text = _Con.ViewKnowlegde();
            RecipeFrame.Content = kb;
        }
        private void DeleteRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            _Con.Updater(dr.AllRecipeTextBox);
            RecipeFrame.Content = dr;
        }
        #endregion

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            JamFactoryUI main = new JamFactoryUI();
            main.Show();
            this.Close();
        }
    }
}
