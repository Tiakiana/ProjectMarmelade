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
using ProjectJam.Models;
using ProjectJam.Controllers;

namespace ProjectJam.Views
{
    /// <summary>
    /// Interaction logic for AddRecipeView.xaml
    /// </summary>
    public partial class AddRecipeView : UserControl
    {
        List<Resource> placeHolder = new List<Resource>();
        List<Resource> userChoice = new List<Resource>();

        public AddRecipeView()
        {
            InitializeComponent();
            new Task(prepareResourceList).Start();
        }

        private void prepareResourceList()
        {
            placeHolder = DataFactory.PullResources();
            List<string> dataHolder = new List<string>();
            placeHolder.ForEach(x => dataHolder.Add(x.Name));
            
            this.Dispatcher.Invoke((Action)(() => {
                this.listBoxChoice.ItemsSource = dataHolder;
            }));

        }
    }
}
