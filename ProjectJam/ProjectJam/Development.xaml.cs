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
        public void MainWindow()
        {
            InitializeComponent();
            Domain.DomainController.getDCT().onStart("M1");

        }
        /*
        int prodID, DateTime date, 
                string qualityTestActivities, string expresults, string results,
                string comments, string comment, string employee)
    */
        #region UIRecipe
        private void CreateRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            RecipeFrame.Content = cr;
        }
        private void JudgeRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            RecipeFrame.Content = jr;
        }
        private void GetRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            RecipeFrame.Content = gr;
        }
        private void BankBtn_Click(object sender, RoutedEventArgs e)
        {
            RecipeFrame.Content = kb;
        }
        private void DeleteRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            RecipeFrame.Content = dr;
        }
        #endregion
    }
}
