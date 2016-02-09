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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Domain.DomainController.getDCT().onStart("M1");
            Recipe rec = new Recipe();
            RecipeFrame.Content = rec;
        }
        /*
        int prodID, DateTime date, 
                string qualityTestActivities, string expresults, string results,
                string comments, string comment, string employee)
    */
        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            DateTime? date = dt_DatePicker.SelectedDate;
            Domain.DomainController.getDCT().GetQualityTestController().CreateQualityTest(Int32.Parse(tb_prodID.Text), dt_DatePicker.DisplayDate, tb_TestActivities.Text, tb_ExpectedRes.Text, tb_Employee.Text, null, null);
        }
    }
}
